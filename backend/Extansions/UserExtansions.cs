using backend.DTOs.ReviewDTOs;
using backend.DTOs.UserDTOs;
using backend.Models.Entities;

namespace backend.Extansions;

public static class UserExtansions
{
    public static UserEntity ToEntity(this CreateUserDTO userDTO)
    {
        return new()
        {
            Email = userDTO.Email,
            HashPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(userDTO.Password),
            RoleId = userDTO.RoleId,
            UserData = new()
            {
                Login = userDTO.Login,
            }
        };
    }
}