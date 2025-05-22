namespace backend.DTOs.AuthorizationDTOs;

public record RegisterResultBuilder
{
    private readonly RegisterResult _registerResult;

    public RegisterResultBuilder()
    {
        _registerResult = new RegisterResult();
    }

    public RegisterResultBuilder SetMessage(string message)
    {
        _registerResult.Message = message;
        return this;
    }

    public RegisterResultBuilder SetUserId(int userId)
    {
        _registerResult.UserId = userId;
        return this;
    }

    public RegisterResult Build()
    {
        return _registerResult;
    }
}