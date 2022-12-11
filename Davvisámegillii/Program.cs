using System.Globalization;

namespace Davvisámegillii
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            for (var i = 0; i <= 100; i++)
            {
                Console.WriteLine($"{i}: {i.ToNumeral()} {i.ToNumeral(true)}");
            }

            for (var i = -6; i < 7; i++)
            {
                Console.WriteLine($"{DateTime.Today.AddDays(i):yyyy-MM-dd}: {DateTime.Today.AddDays(i).ToDate()}");
            }

            for (var m = 0; m < 1440; m++)
            {
                var t = DateTime.Now.AddMinutes(m);
                Console.WriteLine($"{t.ToString("HH:mm", CultureInfo.InvariantCulture)}: diibmu lea {t.TimeOfDay.ToTime()}");
            }
        }
    }
}