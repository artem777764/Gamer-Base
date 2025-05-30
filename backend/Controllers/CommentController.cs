using System.Security.Claims;
using backend.DTOs.CommentDTOs;
using backend.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("Comment")]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;
    
    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        GetCommentDTO? commentDTO = await _commentService.GetByIdAsync(id);
        if (commentDTO == null) return NotFound();
        return Ok(commentDTO);
    }

    [HttpGet("Review/{id}")]
    public async Task<IActionResult> GetByGameAsync([FromRoute] int id)
    {
        return Ok(await _commentService.GetByReviewAsync(id));
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCommentDTO dto)
    {
        Claim? userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null) return Unauthorized();
        int commentId = await _commentService.CreateAsync(dto, int.Parse(userIdClaim.Value));
        return Ok(new IdDTO(commentId));
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentDTO dto)
    {
        if (await _commentService.UpdateAsync(id, dto)) return NoContent();
        return NotFound();
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (await _commentService.DeleteAsync(id)) return NoContent();
        return NotFound();
    }
}