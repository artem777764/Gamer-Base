using System.Threading.Tasks;
using backend.DTOs.GameDTOs;
using backend.Extansions;
using backend.Interfaces.IRepositories;
using backend.Interfaces.IServices;
using backend.Models.Entities;
using MongoDB.Bson;

namespace backend.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;
    private readonly IImageService _imageService;
    public GameService(IGameRepository gameRepository, IImageService imageService)
    {
        _gameRepository = gameRepository;
        _imageService = imageService;
    }
    public async Task<List<GetReviewWithComments>?> GetActivityByGameAsync(int gameId, int? userId = null)
    {
        return await _gameRepository.GetByGameAsync(gameId, userId);
    }

    public async Task<GetGameDTO?> GetByIdAsync(int gameId)
    {
        return await _gameRepository.GetByIdAsync(gameId);
    }

    public async Task<List<GetGameDTO>> GetGamesByFilterAsync(int page, int size, GetGamesByFilter filter)
    {
        return await _gameRepository.GetGamesByFilterAsync(page, size, filter);
    }

    public async Task<int?> CreateAsync(CreateGameDTO dto)
    {
        ObjectId? objectId = null;
        if (dto.ImagePath != null)
        {
            objectId = await _imageService.Upload(dto.ImagePath);
            if (objectId == null) return null;
        }

        int gameId = await _gameRepository.CreateAsync(dto.ToEntity(objectId));
        await _gameRepository.AddPlatforms(dto.ToEntityPlatforms(gameId));
        await _gameRepository.AddGenres(dto.ToEntityGenres(gameId));
        return gameId;
    }
}