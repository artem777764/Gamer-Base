using backend.DTOs.ReviewDTOs;

namespace backend.Interfaces.IServices;

public interface IReviewService
{
    Task<GetReviewDTO?> GetByIdAsync(int reviewId);
    Task<List<GetReviewDTO>> GetByGameAsync(int gameId);
    Task<int> CreateAsync(CreateReviewDTO reviewDTO);
    Task<bool> UpdateAsync(int reviewId, UpdateReviewDTO reviewDTO);
    Task<bool> DeleteAsync(int reviewId);
}