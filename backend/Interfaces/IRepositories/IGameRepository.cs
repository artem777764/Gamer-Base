using backend.DTOs.GameDTOs;

namespace backend.Interfaces.IRepositories;

public interface IGameRepository
{
    Task<List<GetReviewWithComments>?> GetByGameAsync(int gameId);
}