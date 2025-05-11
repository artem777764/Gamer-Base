namespace backend.Models.Entities;

public class DeveloperEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    
    public List<GameEntity> Games { get; set; } = new List<GameEntity>();
}