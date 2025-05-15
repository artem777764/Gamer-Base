using backend.DTOs.GameDTOs;
using backend.Interfaces.IRepositories;
using backend.Interfaces.IServices;

namespace backend.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;
    public GameService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }
    public async Task<List<GetReviewWithComments>?> GetActivityByGameAsync(int gameId)
    {
        return await _gameRepository.GetByGameAsync(gameId);
    }
}