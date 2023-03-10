using HelicoptersService.Configuration;
using HelicoptersService.Store;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HelicoptersService.Services;

public class HelicoptersService : IHelicopterService
{
    private readonly IMongoCollection<Helicopter> _helicoptersCollection;

    public HelicoptersService(IOptions<HelicoptersMongoDbSettings> helicoptersMongoDbSettings)
    {
        var mongoClient = new MongoClient(helicoptersMongoDbSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            helicoptersMongoDbSettings.Value.DatabaseName);
        _helicoptersCollection =
            mongoDatabase.GetCollection<Helicopter>(helicoptersMongoDbSettings.Value.HelicoptersCollectionName);
    }

    public async Task<List<Helicopter>> GetListAsync(int skip, int take) =>
        await _helicoptersCollection.FindAsync(e => e.Destroyed == null, new FindOptions<Helicopter>
        {
            Limit = take,
            Skip = skip,
        }).Result.ToListAsync();

    public async Task<Helicopter?> GetAsync(string id) =>
        await _helicoptersCollection.Find(e => e.Destroyed == null && e.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Helicopter newHelicopter) =>
        await _helicoptersCollection.InsertOneAsync(newHelicopter);
    

    public async Task<Helicopter?> UpdateAsync(string id, Helicopter updatedHelicopter) =>
        await _helicoptersCollection.FindOneAndReplaceAsync(e => e.Id == id, updatedHelicopter);

    public async Task<Helicopter?> RemoveAsync(string id) =>
        await _helicoptersCollection.FindOneAndUpdateAsync(e => e.Id == id,
            Builders<Helicopter>.Update
                .Set(rec => rec.Destroyed, DateTime.Now));

    public async Task<Helicopter?> RecoverAsync(string id) =>
        await _helicoptersCollection.FindOneAndUpdateAsync(e => e.Id == id,
            Builders<Helicopter>.Update
                .Set(rec => rec.Destroyed, null));

    public async Task<HelicopterManufacturer?> AggregateAsync(string id) =>
        await _helicoptersCollection.Aggregate()
            .Match(e=>e.Id == id)
            .Lookup("manufacturers", "manufacturer", "name", @as: "manufacturerinfo")
            .As<HelicopterManufacturer>()
            .FirstOrDefaultAsync();
}