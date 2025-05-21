namespace backend.DTOs.AuthorizationDTOs;

public record LoginResult
{
    public string? Message { get; set; }
    public int? UserId { get; set; }
    public string? JwtToken { get; set; }
    public int ExpireHours { get; set; } = 0;

    public LoginResult(string message)
    {
        Message = message;
    }

    public LoginResult(int userId, string jwtToken, int expireHours)
    {
        UserId = userId;
        JwtToken = jwtToken;
        ExpireHours = expireHours;
    }
}