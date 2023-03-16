using System.Text;

namespace LongToShortUrl.Domain.URLHelpers
{
    //Base62 conversion algorithm https://en.wikipedia.org/wiki/Base64
    static public class ConversionAlgorithm
    {
        public static readonly string Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        public static readonly int Base = Alphabet.Length;

        public static string Encode(int i)
        {
            if (i == 0) return Alphabet[0].ToString();

            StringBuilder sb = new StringBuilder();

            while (i > 0)
            {
                sb.Append(Alphabet[i % Base]);
                i /= Base;
            }
            return string.Join(string.Empty, sb.ToString().Reverse());

        }

        public static int Decode(string s)
        {
            if (s == null) return 0;
            var i = 0;

            foreach (var c in s)
            {
                i = (i * Base) + Alphabet.IndexOf(c);
            }

            return i;
        }
    }
}
