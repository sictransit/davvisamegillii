using Davvisámegillii.Numerals;

namespace Davvisámegillii
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                Console.WriteLine($"{i}: {i.ToNumeral()}");
            }
        }
    }
}