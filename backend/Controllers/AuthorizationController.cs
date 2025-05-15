using backend.DTOs.ReviewDTOs;
using backend.DTOs.UserDTOs;
using backend.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("Authorization")]
public class AuthorizationController : ControllerBase
{
    private readonly IOurAuthorizationService _authorizationService;
    
    public AuthorizationController(IOurAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO dto)
    {
        int? userId = await _authorizationService.Register(dto);
        if (userId == null) return Conflict();
        return Ok(userId);
    }
}