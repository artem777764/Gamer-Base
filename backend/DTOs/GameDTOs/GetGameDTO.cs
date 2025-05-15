namespace backend.DTOs.GameDTOs;

public record GetGameDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required List<string> Genres { get; set; }
    public required string Developer { get; set; }
    public required string Publisher { get; set; }
    public required DateOnly ReleaseDate { get; set; }
}