namespace backend.Models.Entities;

public class GenreEntity
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    
    public List<GameGenresEntity> GameGenres { get; set; } = new List<GameGenresEntity>();
}