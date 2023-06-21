using LongToShortUrl.Core.Models;

namespace LongToShortUrl.Infrastructure.Interfaces;

public interface IUrlShorteningService
{
    Task<Url> CreateShortUrlAsync(string longUrl, string userId);
    Task<Url> GetLongUrlAsync(string shortUrlCode);
    bool IsValidUrl(string longUrl);
}