using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using MongoDB.Driver;

public class RealEstateDbContext : DbContext
{
    public DbSet<Property> Properties { get; set; }
    public DbSet<Owner> Owners { get; set; }

    private readonly IMongoDatabase _mongoDatabase;

    public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options, IMongoDatabase mongoDatabase)
        : base(options)
    {
        _mongoDatabase = mongoDatabase;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Property>().ToCollection("properties");
        modelBuilder.Entity<Owner>().ToCollection("owners");

        modelBuilder.Entity<Property>()
            .HasOne(p => p.Owner)
            .WithMany(o => o.Properties)
            .HasForeignKey(p => p.IdOwner);
    }
}
