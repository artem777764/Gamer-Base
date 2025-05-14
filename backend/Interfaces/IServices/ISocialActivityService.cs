using backend.DTOs.SocialActivityDTOs;

namespace backend.Interfaces.IServices;

public interface ISocialActivityService
{
    Task<List<GetReviewWithComments>?> GetActivityByGameAsync(int gameId);
}