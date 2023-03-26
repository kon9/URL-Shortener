using LongToShortUrl.Data.Context;
using LongToShortUrl.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LongToShortUrl.Data.Repo;

public class UrlRepository : IUrlRepository
{
    private readonly ApplicationContext _context;

    public UrlRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Url> GetByUrlAsync(string longUrl)
    {
        return await _context.Urls.SingleOrDefaultAsync(u => u.LongUrl == longUrl);
    }

    public async Task<Url> GetByCodeAsync(string urlCode)
    {
        return await _context.Urls.SingleOrDefaultAsync(u => u.UrlCode == urlCode);
    }

    public async Task AddUrlAsync(Url url)
    {
        await _context.Urls.AddAsync(url);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
