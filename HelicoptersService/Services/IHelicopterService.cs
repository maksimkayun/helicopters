using HelicoptersService.Store;

namespace HelicoptersService.Services;

public interface IHelicopterService
{
    public Task<List<Helicopter>> GetListAsync(int skip, int take);

    public Task<Helicopter?> GetAsync(string id);

    public Task CreateAsync(Helicopter newHelicopter);

    public Task<Helicopter?> UpdateAsync(string id, Helicopter updatedBook);

    public Task<Helicopter?> RemoveAsync(string id);
    
    public Task<Helicopter?> RecoverAsync(string id);
    
    public Task<HelicopterManufacturer?> AggregateAsync(string id);
}