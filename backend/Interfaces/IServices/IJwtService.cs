using backend.Models.Entities;

public interface IJwtService
{
    string GenerateToken(UserEntity user);
    int GetExpireHours();
}