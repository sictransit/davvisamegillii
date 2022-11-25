using Davvisámegillii.Numerals;

namespace Davvisámegillii
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            for (var i = 0; i <= 1000; i++)
            {
                Console.WriteLine($"{i}: {i.ToNumeral()} {i.ToNumeral(true)}");
            }
        }
    }
}