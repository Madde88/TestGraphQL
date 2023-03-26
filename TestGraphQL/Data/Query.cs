namespace TestGraphQL.Data;

public class Query
{
    private readonly IDogRepository _dogRepository;
    public Query(IDogRepository dogRepository)
    {
        _dogRepository = dogRepository;
    }
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public Task<List<Dog>> GetDogs() =>
        _dogRepository.GetDogsAsync();
    
    public Task<Dog> GetDogById([ID] Guid id) =>
        _dogRepository.GetDogByIdAsync(id);
}