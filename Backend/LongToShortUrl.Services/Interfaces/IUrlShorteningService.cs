using LongToShortUrl.Data.Models;

namespace LongToShortUrl.Services.Interfaces;

public interface IUrlShorteningService
{
    Task<Url> CreateShortUrlAsync(string longUrl);
    Task<Url> GetLongUrlAsync(string shortUrlCode);
}