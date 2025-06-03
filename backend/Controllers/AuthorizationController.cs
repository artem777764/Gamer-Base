using System.Security.Claims;
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

    [Authorize]
    [HttpPut("UpdateProfilePhoto")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UpdateProfilePhotoAsync([FromForm] UpdateProfilePhotoDTO dto)
    {
        if (dto == null || dto.File.Length == 0) return BadRequest("Файл не выбран");

        Claim? userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null) return Unauthorized();

        bool isSuccessful = await _authorizationService.UpdateProfilePhotoAsync(dto.File, int.Parse(userIdClaim.Value));
        if (!isSuccessful) return NotFound();
        return Ok();
    }

    [HttpGet("GetUserInfo/{userId}")]
    public async Task<IActionResult> GetUserInfo([FromRoute] int userId)
    {
        GetUserDTO? dto = await _authorizationService.GetUserInfo(userId);
        if (dto == null) return NotFound();
        return Ok(dto);
    }

    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteUser([FromRoute] int userId)
    {
        bool isSuccessful = await _authorizationService.RemoveUser(userId);
        if (!isSuccessful) return NotFound();
        return Ok();
    }
}