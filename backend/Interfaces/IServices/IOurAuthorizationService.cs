using backend.DTOs.AuthorizationDTOs;
using backend.DTOs.UserDTOs;

namespace backend.Interfaces.IServices;

public interface IOurAuthorizationService
{
    Task<RegisterResult> RegisterAsync(CreateUserDTO dto);
    Task<LoginResult> LoginAsync(LoginUserDTO dto);
    Task<bool> UpdateProfilePhotoAsync(IFormFile file, int userId);
}