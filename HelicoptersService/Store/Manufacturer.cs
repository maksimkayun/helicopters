using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HelicoptersService.Store;

public class Manufacturer
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    [BsonElement("name")]
    public string Name { get; set; }
    
    [BsonElement("date_foundation")]
    public DateTime DateFoundation { get; set; }
}