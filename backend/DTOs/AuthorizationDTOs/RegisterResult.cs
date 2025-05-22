namespace backend.DTOs.AuthorizationDTOs;

public record RegisterResult
{
    public int? UserId { get; set; }
    public string? Message { get; set; }
}