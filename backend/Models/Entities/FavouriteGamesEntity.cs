namespace backend.Models.Entities;

public class FavouriteGamesEntity
{
    public required int UserId { get; set; }
    public required int GameId { get; set; }

    public UserEntity User { get; set; } = null!;
    public GameEntity Game { get; set; } = null!;
}