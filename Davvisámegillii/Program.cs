namespace Davvisámegillii
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            for (var i = 0; i <= 1000; i++)
            {
                Console.WriteLine($"{i}: {i.ToNumeral()} {i.ToNumeral(true)}");
            }

            for (var i = -6; i < 7; i++)
            {
                Console.WriteLine($"{DateTime.Today.AddDays(i):yyyy-MM-dd}: {DateTime.Today.AddDays(i).ToDate()}");
            }
        }
    }
}