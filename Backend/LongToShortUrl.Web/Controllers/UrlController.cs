using System.Security.Claims;
using LongToShortUrl.Infrastructure.Interfaces;
using LongToShortUrl.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LongToShortUrl.Web.Controllers;


[ApiController]
public class UrlController : ControllerBase
{
    private readonly IUrlShorteningService _urlShorteningService;
    private readonly ILinkStatisticsService _linkStatisticsService;

    public UrlController(IUrlShorteningService urlShorteningService, ILinkStatisticsService linkStatisticsService)
    {
        _urlShorteningService = urlShorteningService;
        _linkStatisticsService = linkStatisticsService;
    }

    [Authorize]
    [HttpPost("generate")]
    public async Task<IActionResult> CreateShortUrl([FromBody] LongUrlModel longUrlModel)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var shortUrl = await _urlShorteningService.CreateShortUrlAsync(longUrlModel.LongUrl, userId);
        return Ok(shortUrl);
    }

    [HttpGet("{urlCode}")]
    public async Task<IActionResult> RedirectToLongUrl(string urlCode)
    {
        var longUrl = await _urlShorteningService.GetLongUrlAsync(urlCode);
        if (longUrl == null) return NotFound(new { title = "Short URL not found." });
        await _linkStatisticsService.RecordLinkStatisticAsync(urlCode, HttpContext.Connection.RemoteIpAddress.ToString(), Request.Headers["User-Agent"].ToString());
        return Redirect(longUrl.LongUrl);
    }
}
