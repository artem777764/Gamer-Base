namespace backend.Interfaces.IServices;

public interface IValidationService
{
    bool IsValidEmail(string email);
    bool IsValidLogin(string login);
    bool IsValidPassword(string password);
}