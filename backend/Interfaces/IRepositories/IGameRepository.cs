using backend.DTOs.GameDTOs;
using backend.Models.Entities;

namespace backend.Interfaces.IRepositories;

public interface IGameRepository
{
    Task<List<GetReviewWithComments>?> GetByGameAsync(int gameId, int? userId = null);
    Task<GetGameDTO?> GetByIdAsync(int gameId);
    Task<int> CreateAsync(GameEntity game);
    Task AddPlatforms(List<GamePlatformsEntity> entities);
    Task AddGenres(List<GameGenresEntity> genres);
    Task<List<GetGameDTO>> GetGamesByFilterAsync(int page, int size, GetGamesByFilter filter);
}