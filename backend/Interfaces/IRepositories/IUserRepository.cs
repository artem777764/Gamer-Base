using backend.Models.Entities;

namespace backend.Interfaces.IRepositories;

public interface IUserRepository
{
    Task<UserEntity?> GetByIdAsync(int userId);
    Task<bool> ExistsByEmailAsync(string email);
    Task<bool> ExistsByLoginAsync(string login);
    Task<int> CreateAsync(UserEntity entity);
    Task<bool> UpdateDataAsync(UserDataEntity entity);
    Task<bool> DeleteAsync(int userId);
}