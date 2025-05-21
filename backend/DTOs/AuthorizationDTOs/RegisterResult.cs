namespace backend.DTOs.AuthorizationDTOs;

public record RegisterResult
{
    public int? UserId { get; set; }
    public string? Message { get; set; }

    public RegisterResult(string message)
    {
        Message = message;
    }

    public RegisterResult(int userId)
    {
        UserId = userId;
    }
}