namespace backend.DTOs.DeveloperDTOs;

public record GetDeveloperDTO
{
    public required int Id { get; set; }
    public required string Name { get; set; }
}