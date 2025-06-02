namespace backend.DTOs.GenreDTOs;

public record GetGenreDTO
{
    public required int Id { get; set; }
    public required string Name { get; set; }
}