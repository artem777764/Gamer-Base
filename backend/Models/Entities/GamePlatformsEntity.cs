namespace backend.Models.Entities;

public class GamePlatformsEntity
{
    public required int GameId { get; set; }
    public required int PlatformId { get; set; }

    public GameEntity Game { get; set; } = null!;
    public PlatformEntity Platform { get; set; } = null!;
}