using LongToShortUrl.Core.Models;
using LongToShortUrl.Infrastructure.Exceptions;
using LongToShortUrl.Infrastructure.Interfaces;

namespace LongToShortUrl.Infrastructure.Services;

public class UrlShorteningService : IUrlShorteningService
{
    private readonly IUrlRepository _urlRepository;
    private readonly IUrlConversionAlgorithm _urlConversionAlgorithm;

    public UrlShorteningService(IUrlRepository urlRepository, IUrlConversionAlgorithm urlConversionAlgorithm)
    {
        _urlRepository = urlRepository;
        _urlConversionAlgorithm = urlConversionAlgorithm;
    }

    /// <summary>
    /// Create short url based on the provided long url
    /// </summary>
    /// <param name="longUrl"></param>
    /// <returns></returns>
    /// <exception cref="InvalidUrlException"></exception>
    public async Task<Url> CreateShortUrlAsync(string longUrl, string userId)
    {
        if (!IsValidUrl(longUrl))
        {
            throw new InvalidUrlException("Invalid URL");
        }

        var existingUrl = await _urlRepository.GetByUrlAsync(longUrl);
        if (existingUrl != null)
        {
            return existingUrl;
        }

        var urlCode = _urlConversionAlgorithm.GenerateUrlCode(longUrl);
        var shortUrl = new Url
        {
            LongUrl = longUrl,
            UrlCode = urlCode,
            ShortUrl = $"{GlobalConstants.BaseUrl}/{urlCode}",
            CreationDate = DateTime.UtcNow,
        };

        await _urlRepository.AddUrlAsync(shortUrl);
        await _urlRepository.SaveChangesAsync();

        return shortUrl;
    }

    /// <summary>
    /// Returns original url
    /// </summary>
    /// <param name="urlCode"></param>
    /// <returns></returns>
    public async Task<Url> GetLongUrlAsync(string urlCode)
    {
        if (string.IsNullOrWhiteSpace(urlCode))
        {
            throw new ArgumentException("URL code is required.");
        }

        var url = await _urlRepository.GetByCodeAsync(urlCode);

        if (url == null)
        {
            throw new NotFoundException("Short URL not found.");
        }

        return url;
    }

    public bool IsValidUrl(string longUrl)
    {
        if (!Uri.TryCreate(longUrl, UriKind.Absolute, out var uriResult) ||
            uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps)
        {
            return false;
        }
        return true;
    }
}