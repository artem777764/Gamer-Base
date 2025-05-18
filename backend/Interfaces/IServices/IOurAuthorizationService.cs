using backend.DTOs.UserDTOs;

namespace backend.Interfaces.IServices;

public interface IOurAuthorizationService
{
    Task<int?> RegisterAsync(CreateUserDTO dto);
    Task<AuthResult?> LoginAsync(LoginUserDTO dto);
}