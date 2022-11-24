using System.Text;

namespace Davvisámegillii.Numerals
{
    public static class Converter
    {
        public static string ToNumeral(this int number)
        {
            var parts = SplitNumber(number).ToArray();

            var numeral = new StringBuilder();

            var plural = false;
            for (int p = 0; p < parts.Length; p++)
            {
                var n = parts[p];
                numeral.Append(n.ToText(plural, p < parts.Length - 1));
                plural = n > 1;
            }

            return numeral.ToString();
        }

        private static IEnumerable<int> SplitNumber(int n)
        {
            if ((n < 10) || (n is > 10 and < 20) )
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

        private static string ToText(this int n, bool plural = false, bool accusative = false) => n switch
        {
            0 => "nolla",
            1 => "okta",
            2 => "guokte",
            3 => "golbma",
            4 => "njeallje",
            5 => "vihtta",
            6 => "guhtta",
            7 => "čieža",
            8 => "gávcci",
            9 => "ovcci",
            > 10 and < 20 => (n % 10).ToText() + "nuppelohkái",
            10 => "logi",
            100 => accusative ? "čuođi" : "čuohti",
            1_000 => "duhát",
            1_000_000 => plural ? "miljovnna" : "miljon",
            1_000_000_000 => plural ? "miljárdda" : "miljárda",
            _ => throw new ArgumentOutOfRangeException(nameof(n), n.ToString()),
        };
    }
}