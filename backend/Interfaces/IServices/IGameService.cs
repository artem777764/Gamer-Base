using backend.DTOs.GameDTOs;

namespace backend.Interfaces.IServices;

public interface IGameService
{
    Task<List<GetReviewWithComments>?> GetActivityByGameAsync(int gameId);
    Task<GetGameDTO?> GetByIdAsync(int gameId);
    Task<int?> CreateAsync(CreateGameDTO dto);
}