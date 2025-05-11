namespace backend.Models.Entities;

public class UserDataEntity
{
    public int Id { get; set; }
    public required string Login { get; set; }
    public int? ProfileImageId { get; set; }

    public UserEntity User { get; set; } = null!;
}