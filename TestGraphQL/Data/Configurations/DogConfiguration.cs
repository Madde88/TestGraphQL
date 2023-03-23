namespace TestGraphQL.Data.Configurations;

    public class DogConfiguration : IEntityTypeConfiguration<Dog>
    {
        private Guid[] _ids;

        public DogConfiguration(Guid[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Dog> builder)
        {
            builder
                .HasData(
                new Dog()
                {
                    Id = Guid.NewGuid(),
                    Name = "Lucy",
                    Description = "Description of Lucy",
                },
                new Dog()
                {
                    Id = Guid.NewGuid(),
                    Name = "Ruby",
                    Description = "Description of Ruby",
                }
                );
        }
    }