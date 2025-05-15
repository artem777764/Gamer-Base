using backend.Interfaces.IRepositories;
using backend.Models;
using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class UserRepository : IUserRepository
{
    private readonly PostgresDbContext _postgresDb;

    public UserRepository(PostgresDbContext postgresDb)
    {
        _postgresDb = postgresDb;
    }

    public async Task<UserEntity?> GetByIdAsync(int userId)
    {
        return await _postgresDb.Users.Include(u => u.UserData)
                                      .FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await _postgresDb.Users.AnyAsync(u => u.Email == email);
    }

    public async Task<bool> ExistsByLoginAsync(string login)
    {
        return await _postgresDb.UserData.AnyAsync(ud => ud.Login == login);
    }

    public async Task<int> CreateAsync(UserEntity entity)
    {
        await _postgresDb.Users.AddAsync(entity);
        await _postgresDb.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> UpdateDataAsync(UserDataEntity entity)
    {
        UserDataEntity? data = await _postgresDb.UserData.FindAsync(entity.Id);
        if (data == null) return false;

        _postgresDb.UserData.Entry(data).CurrentValues.SetValues(entity);
        await _postgresDb.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int userId)
    {
        UserEntity? user = await _postgresDb.Users.Include(u => u.UserData)
                                                  .FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null) return false;

        _postgresDb.Users.Remove(user);
        await _postgresDb.SaveChangesAsync();
        return true;
    }
}