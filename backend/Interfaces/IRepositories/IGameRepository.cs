using backend.DTOs.GameDTOs;
using backend.Models.Entities;

namespace backend.Interfaces.IRepositories;

public interface IGameRepository
{
    Task<List<GetReviewWithComments>?> GetByGameAsync(int gameId);
    Task<GameEntity?> GetByIdAsync(int gameId);
}