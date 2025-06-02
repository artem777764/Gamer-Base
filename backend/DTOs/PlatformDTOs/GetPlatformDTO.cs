namespace backend.DTOs.PlatformDTOs;

public record GetPlatformDTO
{
    public required int Id { get; set; }
    public required string Name { get; set; }
}