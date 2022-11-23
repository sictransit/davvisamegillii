using System.Net.Http.Headers;
using System.Text;

namespace Davvisámegillii.Numerals
{
    public static class Converter
    {
        private static int PowerOfTen(int n) 
        {
            return (int)Math.Pow(10, (int)Math.Log10(n));
        }

        public static string ToNumeral(this int n, bool suppressLeadingOne = false, bool suppressTrailingZero = false)
        {
            return n switch
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
                > 10 and < 20 => (n % 10).ToNumeral() + "nuppelohkái",
                10 => "logi",
                > 10 and < 100 => (n/10).ToNumeral(suppressLeadingOne:true) +10.ToNumeral()+ (n%10).ToNumeral(suppressTrailingZero:true) ,
                100 => "čuođi",
                > 100 and < 1000 => (n / 100).ToNumeral(suppressLeadingOne: true) + 100.ToNumeral() + (n % 100).ToNumeral(suppressTrailingZero: true),
                1000 => "duhat",
                > 1000 and < 1000000 => (n / 1000).ToNumeral(suppressLeadingOne: true) + 1000.ToNumeral() + (n % 1000).ToNumeral(suppressTrailingZero: true),
                _ => throw new NotImplementedException($"unsupported number: {n}")
            };
        }
    }
}