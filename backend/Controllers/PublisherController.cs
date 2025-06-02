using backend.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("Publishers")]
public class PublisherController : ControllerBase
{
    private readonly IPublisherService _publisherController;
    
    public PublisherController(IPublisherService publisherService)
    {
        _publisherController = publisherService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _publisherController.GetPublishers());
    }
}