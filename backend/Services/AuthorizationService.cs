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
    public AuthorizationService(IUserRepository userRepository,
                                IEncryptionService encryptionService,
                                IJwtService jwtService,
                                IValidationService validationService)
    {
        _userRepository = userRepository;
        _encryptionService = encryptionService;
        _jwtSevice = jwtService;
        _validationService = validationService;
    }

    public async Task<RegisterResult> RegisterAsync(CreateUserDTO dto)
    {
        if (await _userRepository.ExistsByEmailAsync(dto.Email)) return new RegisterResultBuilder().SetMessage("Email уже занят").Build();
        if (await _userRepository.ExistsByLoginAsync(dto.Login)) return new RegisterResultBuilder().SetMessage("Login уже занят").Build();

        if (!_validationService.IsValidEmail(dto.Email)) return new RegisterResultBuilder().SetMessage("Email некорректен").Build();
        if (!_validationService.IsValidLogin(dto.Login)) return new RegisterResultBuilder().SetMessage("Login некорректен").Build();
        if (!_validationService.IsValidPassword(dto.Password)) return new RegisterResultBuilder().SetMessage("Пароль некорректен").Build();
        if (dto.Password != dto.PasswordConfirm) return new RegisterResultBuilder().SetMessage("Пароли не совпадают").Build();

        int userId = await _userRepository.CreateAsync(dto.ToEntity(_encryptionService.HashPassword(dto.Password)));
        return new RegisterResultBuilder().SetUserId(userId).Build();
    }

    public async Task<LoginResult> LoginAsync(LoginUserDTO dto)
    {
        UserEntity? user = await _userRepository.GetByEmailAsync(dto.UserName);
        user ??= await _userRepository.GetByLoginAsync(dto.UserName);
        if (user == null) return new LoginResultBuilder().SetMessage("Пользователь не найден")
                                                         .Build();

        if (!_encryptionService.VerifyPassword(dto.Password, user.HashPassword))
        return new LoginResultBuilder().SetMessage("Неверный пароль")
                                       .Build();

        return new LoginResultBuilder().SetUserId(user.Id)
                                       .SetRoleId(user.Role.Id)
                                       .SetJwtToken(_jwtSevice.GenerateToken(user), _jwtSevice.GetExpireHours())
                                       .Build();
    }
}