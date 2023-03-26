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
    public async Task<IActionResult> CreateShortUrl([FromBody] string longUrl)
    {
        try
        {
            var shortUrl = await _urlShorteningService.CreateShortUrlAsync(longUrl);
            return Ok(shortUrl);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{shortUrlCode}")]
    public async Task<IActionResult> GetLongUrl(string shortUrlCode)
    {
        var url = await _urlShorteningService.GetLongUrlAsync(shortUrlCode);

        if (url == null)
        {
            return NotFound();
        }

        return Ok(url.LongUrl);
    }
}
