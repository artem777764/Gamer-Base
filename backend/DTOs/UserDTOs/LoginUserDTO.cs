namespace backend.DTOs.UserDTOs;

public record LoginUserDTO
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
}