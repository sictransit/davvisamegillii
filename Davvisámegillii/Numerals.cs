using System.Text;

namespace Davvisámegillii
{
    public static class Numerals
    {
        public static string ToNumeral(this int number, bool adverb = false)
        {
            var parts = SplitNumber(number).ToArray();

            var numeral = new StringBuilder();

            var plural = false;
            for (var p = 0; p < parts.Length; p++)
            {
                var n = parts[p];
                numeral.Append(n.ToText(plural, accusative: p < parts.Length - 1, adverb: adverb && p == parts.Length - 1));
                plural = n > 1;
            }

            return numeral.ToString();
        }

        private static IEnumerable<int> SplitNumber(int n)
        {
            if (n is < 10 or > 10 and < 20)
            {
                yield return n;
            }
            else
            {
                var powerOfTen = (int)Math.Log10(n) switch
                {
                    1 => 10,
                    2 => 100,
                    < 6 => 1_000,
                    < 9 => 1_000_000,
                    9 => 1_000_000_000,
                    _ => throw new NotImplementedException(),
                };

                if (n / powerOfTen > 1)
                {
                    foreach (var number in SplitNumber(n / powerOfTen))
                    {
                        yield return number;
                    }
                }

                yield return powerOfTen;

                if (n % powerOfTen != 0)
                {
                    foreach (var number in SplitNumber(n % powerOfTen))
                    {
                        yield return number;
                    }
                }
            }
        }

        private static string ToText(this int n, bool plural = false, bool accusative = false, bool adverb = false) => n switch
        {
            0 => "nolla",
            1 => adverb ? "vuosttaš" : "okta",
            2 => adverb ? "nubbi" : "guokte",
            3 => adverb ? "goalmmát" : "golbma",
            4 => adverb ? "njealját" : "njeallje",
            5 => adverb ? "viđát" : "vihtta",
            6 => adverb ? "guđát" : "guhtta",
            7 => adverb ? "čihččet" : "čieža",
            8 => adverb ? "gávccát" : "gávcci",
            9 => adverb ? "ovccát" : "ovcci",
            > 10 and < 20 => (n % 10).ToText() + (adverb ? "nuppelogát" : "nuppelohkái"),
            10 => adverb ? "logát" : "logi",
            100 => adverb ? "čuođát" : accusative ? "čuođi" : "čuohti",
            1_000 => "duhát",
            1_000_000 => plural ? "miljovnna" : "miljon",
            1_000_000_000 => plural ? "miljárdda" : "miljárda",
            _ => throw new ArgumentOutOfRangeException(nameof(n), n.ToString()),
        };
    }
}