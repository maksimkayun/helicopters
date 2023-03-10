using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HelicoptersService.Contracts;

public class CreateHelicopterRequest
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [JsonIgnore]
    public string? Id { get; set; }
    
    [BsonElement("name")]
    [BsonRepresentation(BsonType.String)]
    public string Name { get; set; }
    
    [BsonElement("manufacturer")]
    [BsonRepresentation(BsonType.String)]
    public string Manufacturer { get; set; }
    
    [BsonElement("date")]
    [BsonRepresentation(BsonType.DateTime)]
    public DateTime Date { get; set; }
    
    [BsonElement("index")]
    [BsonRepresentation(BsonType.Int32)]
    public int Index { get; set; }
}