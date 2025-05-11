using backend.Models.Entities;

namespace backend.Interfaces.IRepositories;

public interface IReviewRepository
{
    Task<ReviewEntity?> GetByIdAsync(int reviewId);
    Task<List<ReviewEntity>> GetByGameAsync(int gameId);
    Task<int> CreateAsync(ReviewEntity entity);
    Task<bool> UpdateAsync(ReviewEntity entity);
    Task<bool> DeleteAsync(int reviewId);
}