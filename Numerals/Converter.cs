using System.Net.Http.Headers;
using System.Text;

namespace Davvisámegillii.Numerals
{
    public class Converter
    {
        public string ToNumeral(int n)
        {
            var numeral = new StringBuilder();

            if (n == 0)
            {
                return Number(n);
            }

            if (n < 10)
            {
                numeral.Append(Number(n));
            }
            else if (n < 20)
            {
                numeral.Append(Compound(n));
            }
            else if (n < 100)
            { 
                numeral.Append(Tens(n % 10));
                if (n%10!=0) 
                {
                    numeral.Append(Number(n % 10));
                }
            }            

            return numeral.ToString();
        }

        private string Number(int n)
        {
            return n switch
            {
                0 => "nolla",
                1 => "okta",
                2 => "guokte",
                3 => "golbma",
                4 => "njeall",
                5 => "vihtta",
                6 => "guhtta",
                7 => "čieža",
                8 => "gávcci",
                9 => "ovcci",
                _ => throw new ArgumentOutOfRangeException(nameof(n)),
            };
        }

        private string Compound(int n) 
        {
            if (n is < 11 or > 19)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }

            return Number(n%10) + "nuppelohkái";
        }

        private string Tens(int n) 
        {
            if (n % 10 != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }

            n/=10;

            if (n is < 1 or > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }

            return (n == 1 ? string.Empty : Number(n)) + "logi";
        }
    }
}