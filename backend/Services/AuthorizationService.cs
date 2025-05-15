using backend.DTOs.UserDTOs;
using backend.Extansions;
using backend.Interfaces.IRepositories;
using backend.Interfaces.IServices;

namespace backend.Services;

public class AuthorizationService : IOurAuthorizationService
{
    private readonly IUserRepository _userRepository;
    public AuthorizationService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<int?> Register(CreateUserDTO dto)
    {
        if(await _userRepository.ExistsByEmailAsync(dto.Email)) return null;
        if(await _userRepository.ExistsByLoginAsync(dto.Email)) return null;
        return await _userRepository.CreateAsync(dto.ToEntity());
    }
}