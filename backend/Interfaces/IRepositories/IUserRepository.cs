using backend.Models.Entities;
using MongoDB.Bson;

namespace backend.Interfaces.IRepositories;

public interface IUserRepository
{
    Task<int> CreateAsync(UserEntity entity);
    Task<bool> DeleteAsync(int userId);
    Task<bool> ExistsByEmailAsync(string email);
    Task<bool> ExistsByLoginAsync(string login);
    Task<UserEntity?> GetByEmailAsync(string email);
    Task<UserEntity?> GetByIdAsync(int userId);
    Task<UserEntity?> GetByLoginAsync(string login);
    Task<bool> UpdateDataAsync(UserDataEntity entity);
    Task<bool> UpdateProfilePhotoId(int userId, ObjectId photoId);
}