using backend.Interfaces.IRepositories;
using backend.Models;
using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly PostgresDbContext _postgresDb;
    public ReviewRepository(PostgresDbContext postgresDb)
    {
        _postgresDb = postgresDb;
    }

    public async Task<ReviewEntity?> GetByIdAsync(int reviewId)
    {
        return await _postgresDb.Reviews.Include(r => r.User)
                                        .ThenInclude(u => u.UserData)
                                        .FirstOrDefaultAsync(r => r.Id == reviewId);
    }

    public async Task<List<ReviewEntity>> GetByGameAsync(int gameId)
    {
        return await _postgresDb.Reviews.Include(r => r.Game)
                                        .Include(r => r.User)
                                        .ThenInclude(u => u.UserData)
                                        .Where(r => r.Game.Id == gameId)
                                        .ToListAsync();
    }

    public async Task<int> CreateAsync(ReviewEntity entity)
    {
        await _postgresDb.Reviews.AddAsync(entity);
        await _postgresDb.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(ReviewEntity entity)
    {
        ReviewEntity? review = await _postgresDb.Reviews.FindAsync(entity.Id);
        if (review == null) return false;

        _postgresDb.Entry(review).CurrentValues.SetValues(entity);
        await _postgresDb.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int reviewId)
    {
        ReviewEntity? review = await _postgresDb.Reviews.FindAsync(reviewId);
        if (review == null) return false;

        _postgresDb.Reviews.Remove(review);
        await _postgresDb.SaveChangesAsync();
        return true;
    }
}