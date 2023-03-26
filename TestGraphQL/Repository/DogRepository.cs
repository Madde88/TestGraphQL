using TestGraphQL.Exceptions;

namespace TestGraphQL.Repository;

public class DogRepository : IDogRepository
{
    private readonly ApplicationDbContext _dbContext;
    public DogRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory)
    {
        _dbContext = dbContextFactory.CreateDbContext();
    }
    public Task<List<Dog>> GetDogsAsync() =>
        _dbContext.Dogs.ToListAsync();

    public async Task<Dog> GetDogByIdAsync(Guid id)
    {
       var dog = await _dbContext.Dogs.Where(a => a.Id == id).FirstOrDefaultAsync();

       if (dog == null) throw new EntityDontExistsException(nameof(dog));

       return dog;
    }
     
    
    public async Task<DogPayload> AddDogAsync(AddDogInput input)
    {
        var dog = new Dog
        {
            Name = input.Name,
            Description = input.Description
        };

        _dbContext.Dogs.Add(dog);
        await _dbContext.SaveChangesAsync();

        return new DogPayload(dog);
    }
    
    public async Task<DogPayload> UpdateDogAsync(Guid id, UpdateDogInput input)
    {
        var dog = await _dbContext.Dogs.Where(a => a.Id == id).FirstOrDefaultAsync();

        if (dog == null) throw new EntityDontExistsException(nameof(dog));
        dog.Name = input.Name;
        dog.Description = input.Description;
            
        _dbContext.Update(dog);
        await _dbContext.SaveChangesAsync();
        return new DogPayload(dog);

    }

    public async Task<bool> DeleteDogAsync(Guid id)
    {
        var dog = await _dbContext.Dogs.Where(a => a.Id == id).FirstOrDefaultAsync();
        if (dog == null) throw new EntityDontExistsException(nameof(dog));
        
        _dbContext.Remove(dog);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}


public interface IDogRepository
{
    Task<List<Dog>> GetDogsAsync();
    Task<Dog> GetDogByIdAsync(Guid id);
    Task<DogPayload> AddDogAsync(AddDogInput input);
    Task<DogPayload> UpdateDogAsync(Guid id, UpdateDogInput input);
    Task<bool> DeleteDogAsync(Guid id);
}