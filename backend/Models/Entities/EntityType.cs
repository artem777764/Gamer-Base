namespace backend.Models.Entities;

public class EntityType
{
    public required int Id { get; set; }
    public required int Name { get; set; }

    public List<NotificationEntity> Notifications { get; set; } = new List<NotificationEntity>();
}