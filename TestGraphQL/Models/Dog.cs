namespace TestGraphQL.Models;

public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            DateCreated = DateTime.UtcNow;
            Deleted = false;
        }
        
        [Key]
        public Guid Id { get; set; }

        private DateTime DateCreated { get; set; }
        public DateTime? LocalDateUpdate { get; set; }
        public DateTime? ServerDateUpdated { get; set; }
        public bool Deleted { get; set; }
        public DateTime? LastSyncedAt { get; set; }
    }

    public class Dog : BaseEntity
    {
        [Required]
        public string? Name { get; set; }
        public int? Age { get; set; }
        public Breed? Breed { get; set; }
        public string? Color { get; set; }
        [Required]
        public Guid? OwnerId { get; set; }
        [Required]
        public Owner? Owner { get; set; }
    }

    public enum Breed
    {
        LabradorRetriever,
        GoldenRetriever,
        GermanShepherd,
        Bulldog,
        Poodle,
        BorderCollie
    }

    public class Owner : BaseEntity
    {
        [Required]
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int? Age { get; set; }
        public List<Dog>? Dogs { get; set; }
    }
