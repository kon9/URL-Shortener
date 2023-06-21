using LongToShortUrl.Core.Models;

namespace LongToShortUrl.Infrastructure.Interfaces;

public interface IUrlRepository
{
    Task<Url> GetByUrlAsync(string longUrl);
    Task<Url> GetByCodeAsync(string urlCode);
    Task AddUrlAsync(Url url);
    Task SaveChangesAsync();
}
