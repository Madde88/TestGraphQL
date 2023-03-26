
namespace TestGraphQL.Models;

public class Dog
{

    [Key]
    public Guid Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public string? Description { get; set; }
}