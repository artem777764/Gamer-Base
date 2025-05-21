using backend.DTOs.AuthorizationDTOs;
using backend.DTOs.UserDTOs;
using backend.Extansions;
using backend.Interfaces.IRepositories;
using backend.Interfaces.IServices;
using backend.Models.Entities;

namespace backend.Services;

public class AuthorizationService : IOurAuthorizationService
{
    private readonly IUserRepository _userRepository;
    private readonly IEncryptionService _encryptionService;
    private readonly IJwtService _jwtSevice;
    private readonly IValidationService _validationService;
    public AuthorizationService(IUserRepository userRepository, IEncryptionService encryptionService, IJwtService jwtService, IValidationService validationService)
    {
        _userRepository = userRepository;
        _encryptionService = encryptionService;
        _jwtSevice = jwtService;
        _validationService = validationService;
    }

    public async Task<RegisterResult> RegisterAsync(CreateUserDTO dto)
    {
        if (await _userRepository.ExistsByEmailAsync(dto.Email)) return new RegisterResult("Email уже занят");
        if (await _userRepository.ExistsByLoginAsync(dto.Login)) return new RegisterResult("Login уже занят");

        if (!_validationService.IsValidEmail(dto.Email)) return new RegisterResult("Email некорректен");
        if (!_validationService.IsValidLogin(dto.Login)) return new RegisterResult("Login некорректен");
        if (!_validationService.IsValidPassword(dto.Password)) return new RegisterResult("Пароль некорректен");

        int userId = await _userRepository.CreateAsync(dto.ToEntity(_encryptionService.HashPassword(dto.Password)));
        return new RegisterResult(userId);
    }

    public async Task<LoginResult> LoginAsync(LoginUserDTO dto)
    {
        UserEntity? user = await _userRepository.GetByEmailAsync(dto.UserName);
        user ??= await _userRepository.GetByLoginAsync(dto.UserName);
        if (user == null) return new LoginResult("Пользователь не найден");

        if (!_encryptionService.VerifyPassword(dto.Password, user.HashPassword)) return new LoginResult("Неверный пароль");
        return new LoginResult(user.Id, _jwtSevice.GenerateToken(user), _jwtSevice.GetExpireHours());
    }
}