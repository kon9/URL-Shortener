using LongToShortUrl.Core.Models;
using LongToShortUrl.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LongToShortUrl.Infrastructure.Repo;

public class UrlRepository : IUrlRepository
{
    private readonly ApplicationContext _context;

    public UrlRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Url> GetByUrlAsync(string longUrl)
    {
        return await _context.Url.SingleOrDefaultAsync(u => u.LongUrl == longUrl);
    }

    public async Task<Url> GetByCodeAsync(string urlCode)
    {
        return await _context.Url.SingleOrDefaultAsync(u => u.UrlCode == urlCode);
    }

    public async Task AddUrlAsync(Url url)
    {
        await _context.Url.AddAsync(url);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
