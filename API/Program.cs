using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MongoDB.Bson;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Mongo config //
var mongoConnectionString = builder.Configuration["MongoDb:ConnectionString"];
var mongoDatabaseName = builder.Configuration["MongoDb:Database"];

// Register MongoDB client and database
builder.Services.AddSingleton<IMongoClient>(_ => new MongoClient(mongoConnectionString));
builder.Services.AddSingleton<IMongoDatabase>(sp =>
{
  var client = sp.GetRequiredService<IMongoClient>();
  return client.GetDatabase(mongoDatabaseName);
});

// Register DbContext
builder.Services.AddDbContext<RealEstateDbContext>((sp, options) =>
{
  var mongoDatabase = sp.GetRequiredService<IMongoDatabase>();
  options.UseMongoDB(mongoDatabase.Client, mongoDatabase.DatabaseNamespace.DatabaseName);
});

// End Mongo config //

// Add CORS services
builder.Services.AddCors(options =>
{
  options.AddDefaultPolicy(builder =>
  {
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
  });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "RealEstate API", Description = "Premium Real Estate Collection", Version = "v1" });
});

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
  options.SerializerOptions.Converters.Add(new ObjectIdJsonConverter());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI(c =>
  {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "RealEstate API V1");
  });
}

// Property endpoints
app.MapGet("/properties", async (RealEstateDbContext db, string? name, string? address, decimal? minPrice, decimal? maxPrice) =>
{
  var query = db.Properties.AsQueryable();

  if (!string.IsNullOrEmpty(name))
  {
    query = query.Where(p => p.Name != null && p.Name.ToLower().Contains(name.ToLower()));
  }

  if (!string.IsNullOrEmpty(address))
  {
    query = query.Where(p => p.Address != null && p.Address.ToLower().Contains(address.ToLower()));
  }
  if (minPrice.HasValue)
  {
    query = query.Where(p => p.Price >= minPrice.Value);
  }
  if (maxPrice.HasValue)
  {
    query = query.Where(p => p.Price <= maxPrice.Value);
  }

  var properties = await query.ToListAsync();

  foreach (var property in properties)
  {
    if (property.IdOwner.HasValue)
    {
      property.Owner = await db.Owners.FirstOrDefaultAsync(o => o.Id == property.IdOwner.Value);
      if (property.Owner != null)
      {
        property.Owner.Properties = new List<Property>();
      }
    }
  }

  return Results.Ok(properties);
});

app.MapGet("/properties/{id}", async (RealEstateDbContext db, string id) =>
{
  var property = await db.Properties.FirstOrDefaultAsync(p => p.Id == ObjectId.Parse(id));

  if (property != null && property.IdOwner.HasValue)
  {
    property.Owner = await db.Owners.FirstOrDefaultAsync(o => o.Id == property.IdOwner.Value);
    if (property.Owner != null)
    {
      property.Owner.Properties = new List<Property>();
    }
  }

  return property is not null ? Results.Ok(property) : Results.NotFound();
});

app.MapPost("/properties", async (RealEstateDbContext db, Property property) =>
{

  if (property.IdOwner.HasValue)
  {
    var ownerExists = await db.Owners.AnyAsync(o => o.Id == property.IdOwner.Value);
    if (!ownerExists)
    {
      return Results.BadRequest($"Owner with Id {property.IdOwner} does not exist.");
    }
  }

  db.Properties.Add(property);
  await db.SaveChangesAsync();
  return Results.Created($"/properties/{property.Id}", property);
});

app.MapPut("/properties/{id}", async (RealEstateDbContext db, Property updateProperty, string id) =>
{
  var property = await db.Properties.FirstOrDefaultAsync(p => p.Id == ObjectId.Parse(id));
  if (property is null) return Results.NotFound();

  property.Name = updateProperty.Name;
  property.Address = updateProperty.Address;
  property.Price = updateProperty.Price;
  property.CodeInternal = updateProperty.CodeInternal;
  property.Year = updateProperty.Year;
  property.ImageUrl = updateProperty.ImageUrl;

  await db.SaveChangesAsync();
  return Results.Ok(property);
});

app.MapDelete("/properties/{id}", async (RealEstateDbContext db, string id) =>
{
  var property = await db.Properties.FirstOrDefaultAsync(p => p.Id == ObjectId.Parse(id));
  if (property is null) return Results.NotFound();

  db.Properties.Remove(property);
  await db.SaveChangesAsync();
  return Results.Ok();
});

// Owner endpoints
app.MapGet("/owners", async (RealEstateDbContext db) =>
{
  var owners = await db.Owners.ToListAsync();
  return Results.Ok(owners);
});

app.MapPost("/owners", async (RealEstateDbContext db, Owner owner) =>
{
  db.Owners.Add(owner);
  await db.SaveChangesAsync();
  return Results.Created($"/owners/{owner.Id}", owner);
});

app.MapPut("owners/{id}", async (RealEstateDbContext db, Owner updateOwner, string id) =>
{
  var owner = await db.Owners.FirstOrDefaultAsync(o => o.Id == ObjectId.Parse(id));
  if (owner is null) return Results.NotFound();

  owner.Name = updateOwner.Name;
  owner.Address = updateOwner.Address;
  owner.Photo = updateOwner.Photo;
  owner.Birthday = updateOwner.Birthday;

  await db.SaveChangesAsync();
  return Results.Ok(owner);

});

app.MapDelete("/owners/{id}", async (RealEstateDbContext db, string id) =>
{
  var owner = await db.Owners.FirstOrDefaultAsync(o => o.Id == ObjectId.Parse(id));
  if (owner is null) return Results.NotFound();

  db.Owners.Remove(owner);
  await db.SaveChangesAsync();
  return Results.Ok();
});

app.UseCors();

app.Run();