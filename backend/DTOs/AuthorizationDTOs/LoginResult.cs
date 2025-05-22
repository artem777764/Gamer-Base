namespace backend.DTOs.AuthorizationDTOs;

public record LoginResult
{
    public string? Message { get; set; }
    public int? UserId { get; set; }
    public int? RoleId { get; set; }
    public string? JwtToken { get; set; }
    public int ExpireHours { get; set; } = 0;
}