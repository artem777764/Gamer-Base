namespace backend.Models.Entities;

public class GameGenresEntity
{
    public required int GameId { get; set; }
    public required int GenreId { get; set; }

    public GameEntity Game { get; set; } = null!;
    public GenreEntity Genre { get; set; } = null!;
}