using System.Threading.Tasks;
using backend.DTOs.AuthorizationDTOs;
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
        RegisterResult registerResult = await _authorizationService.RegisterAsync(dto);
        if (registerResult.UserId == null) return Conflict(registerResult);
        return Ok(registerResult);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> LoginUser([FromBody] LoginUserDTO dto)
    {
        LoginResult loginResult = await _authorizationService.LoginAsync(dto);
        if (loginResult.UserId == null) return NotFound(loginResult);

        Response.Cookies.Append("jwt", loginResult.JwtToken!, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            Expires = DateTime.UtcNow.AddHours(loginResult.ExpireHours)
        });
        return Ok(loginResult);
    }
}