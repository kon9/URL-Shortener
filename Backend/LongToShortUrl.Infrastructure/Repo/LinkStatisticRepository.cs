using LongToShortUrl.Core.Models;
using LongToShortUrl.Infrastructure.Interfaces;

namespace LongToShortUrl.Infrastructure.Repo;

public class LinkStatisticRepository : ILinkStatisticRepository
{
    private readonly ApplicationContext _context;

    public LinkStatisticRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task AddLinkStatisticAsync(LinkStatistic linkStatistic)
    {
        await _context.LinkStatistics.AddAsync(linkStatistic);
        await _context.SaveChangesAsync();
    }
}