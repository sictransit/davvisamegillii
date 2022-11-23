using Davvisámegillii.Numerals.Enums;

namespace Davvisámegillii.Numerals
{
    public static class Converter
    {
        public static string ToNumeral(this int number)
        {
            return number.ToNumeral(NumeralFlags.None);
        }

        private static string DivideAndContinue(int n)
        {
            var denominator = (int)Math.Log10(n) switch
            {
                1 => 10,
                2 => 100,
                < 6 => 1_000,
                < 9 => 1_000_000,
                9 => 1_000_000_000,
                _ => throw new NotImplementedException(),
            };

            var numerator = n / denominator;

            return numerator.ToNumeral(NumeralFlags.SuppressLeadingOne) + denominator.ToNumeral(numerator > 1 ? NumeralFlags.Plural : NumeralFlags.None) + (n % denominator).ToNumeral(NumeralFlags.SuppressTrailingZero);
        }

        private static string ToNumeral(this int number, NumeralFlags flags) => number switch
        {
            0 => flags.HasFlag(NumeralFlags.SuppressTrailingZero) ? string.Empty : "nolla",
            1 => flags.HasFlag(NumeralFlags.SuppressLeadingOne) ? string.Empty : "okta",
            2 => "guokte",
            3 => "golbma",
            4 => "njeallje",
            5 => "vihtta",
            6 => "guhtta",
            7 => "čieža",
            8 => "gávcci",
            9 => "ovcci",
            > 10 and < 20 => (number % 10).ToNumeral() + "nuppelohkái",
            10 => "logi",
            100 => flags.HasFlag(NumeralFlags.Accusative) ? "čuođi" : "čuohti",
            1_000 => "duhát",
            1_000_000 => flags.HasFlag(NumeralFlags.Plural) ? "miljovnna" : "miljon",
            1_000_000_000 => flags.HasFlag(NumeralFlags.Plural) ? "miljárdda" : "miljárda",
            _ => DivideAndContinue(number)
        };
    }
}