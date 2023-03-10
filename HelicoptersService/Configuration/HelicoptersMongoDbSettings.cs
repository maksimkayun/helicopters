namespace HelicoptersService.Configuration;

public class HelicoptersMongoDbSettings
{
    public string ConnectionString { get; set; }

    public string DatabaseName { get; set; }

    public string HelicoptersCollectionName { get; set; }
}