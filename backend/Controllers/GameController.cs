using backend.DTOs.CommentDTOs;
using backend.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("Game")]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;
    
    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpGet("Activity/{gameId}")]
    public async Task<IActionResult> GetReviewWithComments([FromRoute] int gameId)
    {
        return Ok(await _gameService.GetActivityByGameAsync(gameId));
    }

    [HttpGet("{gameId}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int gameId)
    {
        return Ok(await _gameService.GetByIdAsync(gameId));
    }
}