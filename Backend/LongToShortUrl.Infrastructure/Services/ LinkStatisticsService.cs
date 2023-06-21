using LongToShortUrl.Core.Models;
using LongToShortUrl.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LongToShortUrl.Infrastructure.Services;

public class LinkStatisticsService : ILinkStatisticsService
{
    private readonly IUrlRepository _urlRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILinkStatisticRepository _linkStatisticRepository;

    public LinkStatisticsService(IUrlRepository urlRepository, IHttpContextAccessor httpContextAccessor, ILinkStatisticRepository linkStatisticRepository)
    {
        _urlRepository = urlRepository;
        _httpContextAccessor = httpContextAccessor;
        _linkStatisticRepository = linkStatisticRepository;
    }

    public async Task RecordLinkStatisticAsync(string urlCode, string ipAddress, string userAgent)
    {
        var url = await _urlRepository.GetByCodeAsync(urlCode);

        var linkStatistic = new LinkStatistic
        {
            AccessTime = DateTime.UtcNow,
            UserAgent = userAgent,
            UserPlatform = _httpContextAccessor.HttpContext.Request.Headers["ApplicationUser-Agent"].ToString(),
            UserBrowser = _httpContextAccessor.HttpContext.Request.Headers["ApplicationUser-Agent"].ToString(),
            UrlId = url.Id
        };

        await _linkStatisticRepository.AddLinkStatisticAsync(linkStatistic);
    }
}