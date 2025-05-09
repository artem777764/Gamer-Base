namespace backend.Models.Entities;

public class PlatformEntity
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    
    public List<GamePlatformsEntity> GamePlatforms { get; set; } = new List<GamePlatformsEntity>();
}