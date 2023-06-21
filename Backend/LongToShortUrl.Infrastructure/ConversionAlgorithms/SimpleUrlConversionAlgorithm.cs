using LongToShortUrl.Infrastructure.Interfaces;

namespace LongToShortUrl.Infrastructure.ConversionAlgorithms;

public class SimpleUrlConversionAlgorithm : IUrlConversionAlgorithm
{
    private readonly Random _random = new Random();

    public string GenerateUrlCode(string longUrl)
    {
        int length = 6;
        const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Repeat(characters, length)
            .Select(s => s[_random.Next(s.Length)]).ToArray());
    }
}