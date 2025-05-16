using System.ComponentModel.DataAnnotations;

namespace backend.DTOs.UserDTOs;

public record CreateUserDTO
{
    public required string Login { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required int RoleId { get; set; }
    public string? ProfileImageId { get; set; }
}