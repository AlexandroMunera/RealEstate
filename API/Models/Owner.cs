using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using MongoDB.Bson.Serialization.Attributes;

[Collection("owners")]
public class Owner
{
  [BsonId]
  public ObjectId Id { get; set; }

  [BsonElement("name")]
  public string? Name { get; set; }

  [BsonElement("address")]
  public string? Address { get; set; }

  [BsonElement("photo")]
  public string? Photo { get; set; }

  [BsonElement("birthday")]
  public string? Birthday { get; set; }

  public List<Property> Properties { get; set; } = new();
}