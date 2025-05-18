using System.Text.RegularExpressions;
using backend.Interfaces.IServices;

namespace backend.Services;

public class ValidationService : IValidationService
{
    const string LoginPattern = @"^[a-zA-Z0-9_]{3,20}$";
    const string EmailPattern = @"^(?![.])(?:[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*)@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?\.)+[a-zA-Z]{2,}$";
    const string PasswordPattern = @"^[^\s]{6,}$";
    private readonly Regex LoginRegex = new Regex(LoginPattern, RegexOptions.Compiled);
    private readonly Regex EmailRegex = new Regex(EmailPattern, RegexOptions.Compiled);
    private readonly Regex PasswordRegex = new Regex(PasswordPattern, RegexOptions.Compiled);

    public bool IsValidLogin(string login)
    {
        return LoginRegex.IsMatch(login);
    }

    public bool IsValidEmail(string email)
    {
        return EmailRegex.IsMatch(email);
    }

    public bool IsValidPassword(string password)
    {
        return PasswordRegex.IsMatch(password);
    }
}