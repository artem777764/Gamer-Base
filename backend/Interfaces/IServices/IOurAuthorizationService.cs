using backend.DTOs.UserDTOs;

namespace backend.Interfaces.IServices;

public interface IOurAuthorizationService
{
    Task<int?> Register(CreateUserDTO dto);
}