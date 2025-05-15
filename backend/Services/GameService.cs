using System.Threading.Tasks;
using backend.DTOs.GameDTOs;
using backend.Extansions;
using backend.Interfaces.IRepositories;
using backend.Interfaces.IServices;
using backend.Models.Entities;

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

    public async Task<GetGameDTO?> GetByIdAsync(int gameId)
    {
        GameEntity? game = await _gameRepository.GetByIdAsync(gameId);
        if (game == null) return null;
        return game.ToDTO();
    }
}