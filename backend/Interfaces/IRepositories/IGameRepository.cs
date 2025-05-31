using backend.DTOs.GameDTOs;
using backend.Models.Entities;

namespace backend.Interfaces.IRepositories;

public interface IGameRepository
{
    Task<List<GetReviewWithComments>?> GetByGameAsync(int gameId, int? userId = null);
    Task<GameEntity?> GetByIdAsync(int gameId);
    Task<int> CreateAsync(GameEntity game);
    Task AddPlatforms(List<GamePlatformsEntity> entities);
    Task AddGenres(List<GameGenresEntity> genres);
    Task<List<GameEntity>> GetGamesByFilterAsync(int page, int size, GetGamesByFilter filter);
}