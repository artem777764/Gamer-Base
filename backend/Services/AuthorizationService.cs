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
    public AuthorizationService(IUserRepository userRepository, IEncryptionService encryptionService, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _encryptionService = encryptionService;
        _jwtSevice = jwtService;
    }

    public async Task<int?> RegisterAsync(CreateUserDTO dto)
    {
        if (await _userRepository.ExistsByEmailAsync(dto.Email)) return null;
        if (await _userRepository.ExistsByLoginAsync(dto.Email)) return null;
        return await _userRepository.CreateAsync(dto.ToEntity(_encryptionService.HashPassword(dto.Password)));
    }

    public async Task<AuthResult?> LoginAsync(LoginUserDTO dto)
    {
        UserEntity? user = await _userRepository.GetByEmailAsync(dto.UserName);
        user ??= await _userRepository.GetByLoginAsync(dto.UserName);
        if (user == null) return null;

        if (!_encryptionService.VerifyPassword(dto.Password, user.HashPassword)) return null;
        return new()
        {
            UserId = user.Id,
            jwtToken = _jwtSevice.GenerateToken(user),
            ExpireHours = _jwtSevice.GetExpireHours(),
        };
    }
}