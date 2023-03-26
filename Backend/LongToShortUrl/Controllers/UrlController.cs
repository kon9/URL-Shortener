using LongToShortUrl.Data.Models;
using LongToShortUrl.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LongToShortUrl.Controllers;


[ApiController]
public class UrlController : ControllerBase
{
    private readonly IUrlShorteningService _urlShorteningService;

    public UrlController(IUrlShorteningService urlShorteningService)
    {
        _urlShorteningService = urlShorteningService;
    }

    [HttpPost("generate")]
    public async Task<IActionResult> CreateShortUrl([FromBody] LongUrlModel longUrlModel)
    {
        var shortUrl = await _urlShorteningService.CreateShortUrlAsync(longUrlModel.LongUrl);
        return Ok(shortUrl);
    }

    [HttpGet("{urlCode}")]
    public async Task<IActionResult> RedirectToLongUrl(string urlCode)
    {
        var longUrl = await _urlShorteningService.GetLongUrlAsync(urlCode);
        if (longUrl == null) return NotFound(new { title = "Short URL not found." });
        return Redirect(longUrl.LongUrl);
    }
}
