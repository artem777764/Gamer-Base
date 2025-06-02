using backend.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("Developers")]
public class DeveloperController : ControllerBase
{
    private readonly IDeveloperService _developerService;
    
    public DeveloperController(IDeveloperService developerService)
    {
        _developerService = developerService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _developerService.GetDevelopers());
    }
}