using System.Text;
using LongToShortUrl.Infrastructure.Interfaces;

namespace LongToShortUrl.Infrastructure.ConversionAlgorithms;

/// <summary>
///     Provides methods for Base62 conversion.
/// </summary>
public class Base62Converter : IUrlConversionAlgorithm
{
    private const string Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    private readonly int _base = Alphabet.Length;
    private readonly Random _random = new Random();

    /// <summary>
    ///     Encodes an integer into a Base62 string.
    /// </summary>
    /// <param name="value">The integer value to encode.</param>
    /// <returns>A Base62 encoded string.</returns>
    private string Encode(int value)
    {
        if (value == 0) return Alphabet[0].ToString();

        var sb = new StringBuilder();

        while (value > 0)
        {
            sb.Append(Alphabet[value % _base]);
            value /= _base;
        }

        return string.Join(string.Empty, sb.ToString().Reverse());
    }

    public string GenerateUrlCode(string longUrl)
    {
        var randomNumber = _random.Next(1, int.MaxValue);
        return Encode(randomNumber);
    }
}