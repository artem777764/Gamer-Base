using backend.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("Platforms")]
public class PlatformController : ControllerBase
{
    private readonly IPlatformService _platformService;
    
    public PlatformController(IPlatformService platformService)
    {
        _platformService = platformService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _platformService.GetPlatforms());
    }
}