namespace backend.Models.Entities;

public class GenreEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    
    public List<GameGenresEntity> GameGenres { get; set; } = new List<GameGenresEntity>();
}