using System.Net.Http.Headers;
using System.Text;

namespace Davvisámegillii.Numerals
{
    public static class Converter
    {
        public static string ToNumeral(this int number, bool suppressLeadingOne = false, bool suppressTrailingZero = false, bool plural = false)
        {
            static string divideAndRecurse (int n)
            {
                var denominator = (int)Math.Log10(n) switch
                {
                    1 => 10,
                    2 => 100,
                    >= 3 and < 6 => 1000,
                    >= 6 and < 9 => 1000000,
                    _ => throw new NotImplementedException(),
                };

                var numerator = n / denominator;

                return numerator.ToNumeral(suppressLeadingOne: true) + denominator.ToNumeral(plural:numerator>1) + (n % denominator).ToNumeral(suppressTrailingZero: true);
            } 

            return number switch
            {
                0 =>  suppressTrailingZero ? string.Empty :"nolla",
                1 => suppressLeadingOne ? string.Empty : "okta",
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
                100 => "čuođi",
                1000 => "duhat",
                1000000 => plural ? "miljovnna" : "miljon",
                _ => divideAndRecurse(number)
            };
        }
    }
}