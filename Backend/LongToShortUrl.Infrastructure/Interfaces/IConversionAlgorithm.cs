namespace LongToShortUrl.Infrastructure.Interfaces;

public interface IUrlConversionAlgorithm
{
    string GenerateUrlCode(string longUrl);
}
