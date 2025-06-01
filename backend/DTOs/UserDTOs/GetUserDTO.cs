namespace backend.DTOs.UserDTOs;

public record GetUserDTO
{
    public required int Id { get; set; }
    public required string Email { get; set; }
    public required string Login { get; set; }
    public string? UserImageURL { get; set; }
}