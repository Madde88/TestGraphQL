namespace TestGraphQL.Models.Inputs;

public record AddDogInput(string Name, string? Description);

public record UpdateDogInput(string Name, string? Description);