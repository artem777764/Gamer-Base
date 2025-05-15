using backend.DTOs.GameDTOs;

namespace backend.Interfaces.IServices;

public interface IGameService
{
    Task<List<GetReviewWithComments>?> GetActivityByGameAsync(int gameId);
}