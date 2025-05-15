namespace backend.Models.Entities;

public class GameEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public int DeveloperId { get; set; }
    public int PublisherId { get; set; }
    public double Rating { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public DeveloperEntity Developer { get; set; } = null!;
    public PublisherEntity Publisher { get; set; } = null!;
    public List<GamePlatformsEntity> GamePlatforms { get; set; } = new List<GamePlatformsEntity>();
    public List<GameGenresEntity> GameGenres { get; set; } = new List<GameGenresEntity>();
    public List<ReviewEntity> Reviews { get; set; } = new List<ReviewEntity>();
    public List<FavouriteGamesEntity> FavouriteGames { get; set; } = new List<FavouriteGamesEntity>();
}