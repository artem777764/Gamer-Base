using backend.DTOs.ReviewDTOs;
using backend.DTOs.UserDTOs;
using backend.Extansions;
using backend.Interfaces.IRepositories;
using backend.Interfaces.IServices;
using backend.Models.Entities;

namespace backend.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    public ReviewService(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<GetReviewDTO?> GetByIdAsync(int reviewId)
    {
        ReviewEntity? review = await _reviewRepository.GetByIdAsync(reviewId);
        if (review == null) return null;

        return review.ToDTO();
    }

    public async Task<List<GetReviewDTO>> GetByGameAsync(int gameId)
    {
        List<ReviewEntity> reviews = await _reviewRepository.GetByGameAsync(gameId);
        return reviews.Select(r => r.ToDTO()).ToList();
    }

    public async Task<int> CreateAsync(CreateReviewDTO reviewDTO, int userId)
    {
        return await _reviewRepository.CreateAsync(reviewDTO.ToEntity(userId));
    }

    public async Task<bool> UpdateAsync(int reviewId, UpdateReviewDTO reviewDTO)
    {
        ReviewEntity? review = await _reviewRepository.GetByIdAsync(reviewId);
        if (review == null) return false;

        review.UpdateEntity(reviewDTO);
        await _reviewRepository.UpdateAsync(review);
        return true;
    }

    public async Task<bool> DeleteAsync(int reviewId)
    {
        return await _reviewRepository.DeleteAsync(reviewId);
    }
}