using System.Text;
using LongToShortUrl.Services.Interfaces;

namespace LongToShortUrl.Services.ConversionAlgorithms;

/// <summary>
///     Provides methods for Base62 conversion.
/// </summary>
public class Base62Converter : IUrlConversionAlgorithm
{
    private const string Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    private readonly int _base = Alphabet.Length;

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
        var random = new Random();
        var randomNumber = random.Next(1, int.MaxValue);
        return Encode(randomNumber);//hope that random number is unique every time :) //Copilot feel happy today
    }
}