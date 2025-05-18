namespace backend.DTOs.UserDTOs;

public record AuthResult
{
    public required int UserId { get; set; }
    public required string jwtToken { get; set; }
    public required int ExpireHours { get; set; }
}