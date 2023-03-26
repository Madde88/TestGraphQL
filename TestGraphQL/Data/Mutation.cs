
using TestGraphQL.Exceptions;

namespace TestGraphQL.Data;

public class Mutation
{
    private readonly IDogRepository _dogRepository;

    public Mutation(IDogRepository dogRepository)
    {
        _dogRepository = dogRepository;
    }

    public async Task<DogPayload> AddDogAsync(AddDogInput input)
    {
        return await _dogRepository.AddDogAsync(input);
    }
    
    [Error(typeof(EntityDontExistsException))]
    public async Task<DogPayload> UpdateDogAsync([ID] Guid id, UpdateDogInput input)
    {
        return await _dogRepository.UpdateDogAsync(id,input);
    }
    
    [Error(typeof(EntityDontExistsException))]
    public async Task<bool> DeleteDogAsync([ID] Guid id)
    {
        return await _dogRepository.DeleteDogAsync(id);
    }
}