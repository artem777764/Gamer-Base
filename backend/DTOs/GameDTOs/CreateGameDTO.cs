namespace backend.DTOs.GameDTOs;

public record CreateGameDTO
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int DeveloperId { get; set; }
    public required int PublisherId { get; set; }
    public required List<int> GamePlatforms { get; set; }
    public required List<int> GameGenres { get; set; }
    public required DateOnly ReleaseDate { get; set; }
    public string? ImagePath { get; set; }
}