using LongToShortUrl.Services.Interfaces;

namespace LongToShortUrl.Services.ConversionAlgorithms;

public class SimpleUrlConversionAlgorithm : IUrlConversionAlgorithm
{
    public string GenerateUrlCode(string longUrl)
    {
        int length = 6;
        const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Repeat(characters, length)
            .Select(s => s[new Random().Next(s.Length)]).ToArray());
    }
}