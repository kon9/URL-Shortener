using LongToShortUrl.Core.Models;

namespace LongToShortUrl.Infrastructure.Interfaces;

public interface ILinkStatisticRepository
{
    Task AddLinkStatisticAsync(LinkStatistic linkStatistic);
}