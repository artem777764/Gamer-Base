namespace backend.DTOs.GameDTOs;

public record GetGamesByFilter
{
    public string? Name { get; set; }
    public int? PlatformId { get; set; }
    public int? GenreId { get; set; }
    public int? DeveloperId { get; set; }
    public int? PublisherId { get; set; }
    public int? TagId { get; set; }
}