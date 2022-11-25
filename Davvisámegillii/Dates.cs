using System.Globalization;

namespace Davvisámegillii
{
    public static class Dates
    {
        public static string ToDate(this DateTime date)
        {
            return string.Join(' ', date.ToDayOfWeek(), date.ToMonth(), date.Day.ToNumeral(true), "beaivi");
        }

        private static string ToMonth(this DateTime date, bool genitive = true) =>
            date.Month switch
            {
                1 => "ođđajagi",
                2 => "guovva",
                3 => "njukča",
                4 => "cuoŋo",
                5 => "miesse",
                6 => "geasse",
                7 => "suoidne",
                8 => "borge",
                9 => "čakča",
                10 => "golggot",
                11 => "skábma",
                12 => "juovla",
                _ => throw new ArgumentOutOfRangeException(nameof(date), date.Month.ToString())
            } + (genitive ? "mánu" : "mánnu");

        private static string ToDayOfWeek(this DateTime date)
        {
            return date.DayOfWeek switch
            {
                DayOfWeek.Sunday => "sotnabeaivi",
                DayOfWeek.Monday => "mánnodat",
                DayOfWeek.Tuesday => "disdat",
                DayOfWeek.Wednesday => "gaskavahkku",
                DayOfWeek.Thursday => "duorastat",
                DayOfWeek.Friday => "bearjadat",
                DayOfWeek.Saturday => "lávvordat",
                _ => throw new ArgumentOutOfRangeException(nameof(date), date.ToString(CultureInfo.InvariantCulture))
            };
        }
    }
}
