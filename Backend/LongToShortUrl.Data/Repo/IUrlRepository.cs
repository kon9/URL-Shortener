using LongToShortUrl.Data.Models;

namespace LongToShortUrl.Data.Repo;

public interface IUrlRepository
{
    Task<Url> GetByUrlAsync(string longUrl);
    Task<Url> GetByCodeAsync(string urlCode);
    Task AddUrlAsync(Url url);
    Task SaveChangesAsync();
}
