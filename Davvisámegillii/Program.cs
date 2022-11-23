using Davvisámegillii.Numerals;

namespace Davvisámegillii
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 1000; i++)
            {
                Console.WriteLine($"{i}: {i.ToNumeral()} {i.ToNumeral(true)}");
            }
        }
    }
}