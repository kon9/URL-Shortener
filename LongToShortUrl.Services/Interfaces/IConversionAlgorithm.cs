namespace LongToShortUrl.Services.Interfaces;

public interface IUrlConversionAlgorithm
{
    string GenerateUrlCode(string longUrl);
}
