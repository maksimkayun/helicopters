using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HelicoptersService.Store;

public class HelicopterManufacturer
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
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
    
    [BsonElement("destroyed")]
    [BsonRepresentation(BsonType.DateTime)]
    [JsonIgnore]
    public DateTime? Destroyed { get; set; }
    
    [BsonElement("secret")]
    [BsonRepresentation(BsonType.Boolean)]
    [JsonIgnore]
    public bool? Secret { get; set; }
    
    [BsonElement("manufacturerinfo")]
    public List<Manufacturer> ManufacturerInfo { get; set; }
}