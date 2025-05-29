using System.Security.Claims;
using backend.DTOs.ReviewDTOs;
using backend.DTOs.UserDTOs;
using backend.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("Review")]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;
    
    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        GetReviewDTO? reviewDTO = await _reviewService.GetByIdAsync(id);
        if (reviewDTO == null) return NotFound();
        return Ok(reviewDTO);
    }

    [HttpGet("Game/{id}")]
    public async Task<IActionResult> GetByGameAsync([FromRoute] int id)
    {
        return Ok(await _reviewService.GetByGameAsync(id));
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReviewDTO dto)
    {
        Claim? userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null) return Unauthorized();
        return Ok(await _reviewService.CreateAsync(dto, int.Parse(userIdClaim.Value)));
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateReviewDTO dto)
    {
        if (await _reviewService.UpdateAsync(id, dto)) return NoContent();
        return NotFound();
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (await _reviewService.DeleteAsync(id)) return NoContent();
        return NotFound();
    }
}