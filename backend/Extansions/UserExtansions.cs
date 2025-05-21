using backend.DTOs.ReviewDTOs;
using backend.DTOs.UserDTOs;
using backend.Models.Entities;

namespace backend.Extansions;

public static class UserExtansions
{
    public static UserEntity ToEntity(this CreateUserDTO userDTO, string hashedPassword)
    {
        return new()
        {
            Email = userDTO.Email,
            HashPassword = hashedPassword,
            RoleId = userDTO.RoleId ?? 1,
            UserData = new()
            {
                Login = userDTO.Login,
            }
        };
    }
}