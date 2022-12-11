namespace Davvisámegillii
{
    public static class Times
    {
        public static string ToTime(this TimeSpan time)
        {
            var hour = time.Hours + (time.Minutes > 20 ? 1 : 0);
            hour %= 12;

            var hours = (hour == 0 ? 12 : hour).ToNumeral();

            var minutes = time.Minutes switch
            {
                0 => string.Empty,
                15 => "goartil badjel",
                <= 20 => time.Minutes.ToNumeral() + " badjel",
                30 => "beal",
                < 30 => (30 - time.Minutes).ToNumeral() + " váile beal",
                < 40 => (time.Minutes - 30).ToNumeral() + " badjel beal",
                45 => "goartil váile",
                _ => (60 - time.Minutes).ToNumeral() + " váile",
            };

            return string.Join(" ", new[] { minutes, hours }.Where(p => !string.IsNullOrEmpty(p)));
        }
    }
}
