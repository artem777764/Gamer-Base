using System.Threading.Tasks;
using backend.DTOs.CommentDTOs;
using backend.DTOs.GameDTOs;
using backend.Interfaces.IServices;
using backend.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("Games")]
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

    [HttpPost("Search")]
    public async Task<IActionResult> GetGamesByFilterAsync([FromQuery] int page, [FromQuery] int size, [FromBody] GetGamesByFilter filter)
    {
        return Ok(await _gameService.GetGamesByFilterAsync(page, size, filter));
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGameDTO dto)
    {
        int? id = await _gameService.CreateAsync(dto);
        if (id == null) return NotFound();
        return Ok(new IdDTO(id.Value));
    }
}