namespace backend.Models.Entities;

public class UserDataEntity
{
    public required int Id { get; set; }
    public required string Login { get; set; }
    public int ProfileImageId { get; set; }

    public UserEntity UserEntity { get; set; } = null!;
}