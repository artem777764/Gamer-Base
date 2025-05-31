using System.Security.Claims;
using backend.DTOs.ReviewDTOs;
using backend.DTOs.VoteDTOs;
using backend.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("Vote")]
public class VoteController : ControllerBase
{
    private readonly IVoteService _voteService;
    
    public VoteController(IVoteService voteService)
    {
        _voteService = voteService;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] List<VoteDTO> dtos)
    {
        Claim? userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null) return Unauthorized();

        await _voteService.AddVotes(int.Parse(userIdClaim.Value), dtos);
        return Ok();
    }
}