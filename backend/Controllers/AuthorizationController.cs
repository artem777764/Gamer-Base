using System.Threading.Tasks;
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
        int? userId = await _authorizationService.RegisterAsync(dto);
        if (userId == null) return Conflict();
        return Ok(new IdDTO(userId.Value));
    }

    [HttpPost("Login")]
    public async Task<IActionResult> LoginUser([FromBody] LoginUserDTO dto)
    {
        AuthResult? result = await _authorizationService.LoginAsync(dto);
        if (result == null) return NotFound();

        Response.Cookies.Append("jwt", result.jwtToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            Expires = DateTime.UtcNow.AddHours(result.ExpireHours)
        });
        return Ok(new IdDTO(result.UserId));
    }
}