using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using MongoDB.Bson.Serialization.Attributes;

[Collection("properties")]
public class Property
{
  [BsonId]
  public ObjectId Id { get; set; }

  [BsonElement("name")]
  public string? Name { get; set; }

  [BsonElement("address")]
  public string? Address { get; set; }

  [BsonElement("price")]
  public int Price { get; set; }

  [BsonElement("codeInternal")]
  public string? CodeInternal { get; set; }

  [BsonElement("year")]
  public int Year { get; set; }

  [BsonElement("imageUrl")]
  public string? ImageUrl { get; set; }

  [BsonElement("idOwner")]
  public ObjectId? IdOwner { get; set; }

  public Owner? Owner { get; set; }
}