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
    public async Task<List<GetReviewWithComments>?> GetActivityByGameAsync(int gameId)
    {
        return await _gameRepository.GetByGameAsync(gameId);
    }

    public async Task<GetGameDTO?> GetByIdAsync(int gameId)
    {
        GameEntity? game = await _gameRepository.GetByIdAsync(gameId);
        if (game == null) return null;

        GetGameDTO gameDTO = game.ToDTO();
        gameDTO.Rating = CalculateRating(game);
        return gameDTO;
    }

    public async Task<List<GetGameDTO>> GetGamesByFilterAsync(int page, int size, GetGamesByFilter filter)
    {
        List<GameEntity> games = await _gameRepository.GetGamesByFilterAsync(page, size, filter);
        List<GetGameDTO> gamesDTO = new List<GetGameDTO>();

        return games.Select(game =>
        {
            GetGameDTO dto = game.ToDTO();
            dto.Rating = CalculateRating(game);
            return dto;
        }).ToList();
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

    public double? CalculateRating(GameEntity game)
    {
        List<ReviewEntity> uniqueReviews = game.Reviews.OrderByDescending(r => r.Date).DistinctBy(r => r.AuthorId).ToList();
        if (uniqueReviews == null || uniqueReviews.Count == 0) return null;
        return uniqueReviews.Sum(r => r.Mark) / (double)uniqueReviews.Count;
    }
}