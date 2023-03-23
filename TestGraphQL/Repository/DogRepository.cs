namespace TestGraphQL.Repository;

public class DogRepository : IDogRepository
{
    private readonly ApplicationDbContext _appDbContext;

    public DogRepository(ApplicationDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
}

public interface IDogRepository
{
}