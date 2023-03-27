

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddPooledDbContextFactory<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("Test"));

builder.Services.AddGraphQLServer()
    .AddMutationConventions(applyToAllMutations: true)
    .RegisterDbContext<ApplicationDbContext>(DbContextKind.Pooled)
    .AddQueryType<Query>().AddProjections().AddFiltering().AddSorting()
    .AddMutationType<Mutation>();

builder.Services.AddTransient<IDogRepository,DogRepository>();
builder.Services.AddTransient<IOwnerRepository,OwnerRepository>();
 
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<ApplicationDbContext>>();
    using (var dbContext = dbContextFactory.CreateDbContext())
    {
        dbContext.Database.EnsureCreated();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseHttpsRedirection();

app.UseRouting();
app.MapGraphQL();


app.Run();