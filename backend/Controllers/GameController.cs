using backend.DTOs.CommentDTOs;
using backend.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("Game")]
public class GameController : ControllerBase
{
    private readonly ISocialActivityService _socialActivityService;
    
    public GameController(ISocialActivityService socialActivityService)
    {
        _socialActivityService = socialActivityService;
    }

    [HttpGet("Activity/{gameId}")]
    public async Task<IActionResult> GetReviewWithComments([FromRoute] int gameId)
    {
        return Ok(await _socialActivityService.GetActivityByGameAsync(gameId));
    }
}