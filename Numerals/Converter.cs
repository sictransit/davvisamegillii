using System.Net.Http.Headers;
using System.Text;

namespace Davvisámegillii.Numerals
{
    public static class Converter
    {
        private static readonly string[] powersOfTen = new[] { "logi", "čuođi" };

        public static string ToNumeral(this int n)
        {
            if (n == 0)
            {
                return Number(n);
            }

            return Below1000(n);
        }

        private static string Below1000(int n)
        {
            var numeral = new StringBuilder();

            if (n >= 100)
            {
                numeral.Append(PowerOfTens(2, n));

                n %= 100;
            }

            if (n > 0)
            {
                numeral.Append(Below100(n));
            }

            return numeral.ToString();
        }

        private static string Below100(int n)
        {
            var numeral = new StringBuilder();

            if (n < 10)
            {
                numeral.Append(Number(n));
            }
            else if (n is > 10 and < 20)
            {
                numeral.Append(Compound(n));
            }
            else if (n < 100)
            {
                numeral.Append(PowerOfTens(1, n));
                if (n % 10 != 0)
                {
                    numeral.Append(Number(n % 10));
                }
            }

            return numeral.ToString();
        }

        private static string Number(int n)
        {
            return n switch
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
                _ => throw new ArgumentOutOfRangeException(nameof(n)),
            };
        }

        private static string Compound(int n) 
        {
            if (n is < 11 or > 19)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }

            return Number(n%10) + "nuppelohkái";
        }

        private static string PowerOfTens(int p,  int n) 
        {
            n/=(int)Math.Pow(10, p);            

            if (n is < 0 or > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }

            return (n == 1 ? string.Empty : Number(n)) + powersOfTen[p-1];
        }

    }
}