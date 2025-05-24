using backend.DTOs.ReviewDTOs;
using backend.DTOs.UserDTOs;
using backend.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace backend.Controllers;

[ApiController]
[Route("Image")]
public class ImageController : ControllerBase
{
    private readonly IImageService _imageService;

    public ImageController(IImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpPost("Upload")]
    public async Task<IActionResult> Upload([FromQuery] string path)
    {
        ObjectId? objectId = await _imageService.Upload(path);
        if (objectId == null) return NotFound();
        return Ok(objectId.ToString());
    }

    [HttpGet("Download/{id}")]
    public async Task<IActionResult> Download([FromRoute] string id)
    {
        FileDownloadResult? result = await _imageService.Download(id);
        if (result == null) return NotFound();
        return File(result.Stream, result.ContentType, result.FileName);
    }

    [HttpDelete("Remove/{id}")]
    public async Task<IActionResult> Remove([FromRoute] string id)
    {
        bool successfully = await _imageService.Remove(id);
        if (!successfully) return NotFound();
        return Ok();
    }
}