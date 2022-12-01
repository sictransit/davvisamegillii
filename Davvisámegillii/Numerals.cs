using System.Text;

namespace Davvisámegillii
{
    public static class Numerals
    {
        public static string ToNumeral(this int number, bool ordinal = false)
        {
            var parts = SplitNumber(number).ToArray();

            var numeral = new StringBuilder();

            var plural = false;
            for (var p = 0; p < parts.Length; p++)
            {
                var n = parts[p];
                numeral.Append(n.ToText(plural, genitive: p < parts.Length - 1, ordinal: ordinal && p == parts.Length - 1));
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

        private static string ToText(this int n, bool plural = false, bool genitive = false, bool ordinal = false) => n switch
        {
            0 => "nolla",
            1 => ordinal ? "vuosttaš" : "okta",
            2 => ordinal ? "nubbi" : "guokte",
            3 => ordinal ? "goalmmát" : "golbma",
            4 => ordinal ? "njealját" : "njeallje",
            5 => ordinal ? "viđát" : "vihtta",
            6 => ordinal ? "guđát" : "guhtta",
            7 => ordinal ? "čihččet" : "čieža",
            8 => ordinal ? "gávccát" : "gávcci",
            9 => ordinal ? "ovccát" : "ovcci",
            > 10 and < 20 => (n % 10).ToText() + (ordinal ? "nuppelogát" : "nuppelohkái"),
            10 => ordinal ? "logát" : "logi",
            100 => ordinal ? "čuođát" : genitive ? "čuođi" : "čuohti",
            1_000 => "duhát",
            1_000_000 => plural ? "miljovnna" : "miljon",
            1_000_000_000 => plural ? "miljárdda" : "miljárda",
            _ => throw new ArgumentOutOfRangeException(nameof(n), n.ToString()),
        };
    }
}