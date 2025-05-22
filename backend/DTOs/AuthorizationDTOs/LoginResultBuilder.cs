namespace backend.DTOs.AuthorizationDTOs;

public record LoginResultBuilder
{
    private readonly LoginResult _loginResultDTO;

    public LoginResultBuilder()
    {
        _loginResultDTO = new LoginResult();
    }

    public LoginResultBuilder SetMessage(string message)
    {
        _loginResultDTO.Message = message;
        return this;
    }

    public LoginResultBuilder SetUserId(int userId)
    {
        _loginResultDTO.UserId = userId;
        return this;
    }

    public LoginResultBuilder SetRoleId(int roleId)
    {
        _loginResultDTO.RoleId = roleId;
        return this;
    }

    public LoginResultBuilder SetJwtToken(string JwtToken, int expireHours)
    {
        _loginResultDTO.JwtToken = JwtToken;
        _loginResultDTO.ExpireHours = expireHours;
        return this;
    }

    public LoginResult Build()
    {
        return _loginResultDTO;
    }
}