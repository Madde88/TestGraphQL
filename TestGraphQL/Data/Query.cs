namespace TestGraphQL.Data;

public class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Dog> GetDogs([Service] ApplicationDbContext context) =>
        context.Dogs;
}