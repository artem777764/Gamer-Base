namespace backend.Models.Entities;

public class NotificationEntity
{
    public required int Id { get; set; }
    public required int UserId { get; set; }
    public required int ReviewId { get; set; }
    public required int EntityTypeId { get; set; }
    public required int EntityId { get; set; }
    public required DateTime Date { get; set; }
    public bool IsRead { get; set; } = false;
    public required int InitiatorUserId { get; set; }
    public required string ShortText { get; set; }

    public UserEntity User { get; set; } = null!;
    public ReviewEntity Review { get; set; } = null!;
    public EntityType EntityType { get; set; } = null!;
    public UserEntity InitiatorUser { get; set; } = null!;
}