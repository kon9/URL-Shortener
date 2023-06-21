namespace LongToShortUrl.Infrastructure.Interfaces;

public interface ILinkStatisticsService
{
    Task RecordLinkStatisticAsync(string urlCode, string ipAddress, string userAgent);
}