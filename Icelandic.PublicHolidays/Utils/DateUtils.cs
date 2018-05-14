using System;

namespace Icelandic.PublicHolidays.Utils
{
    internal static class DateUtils
    {
        internal static DateTime FirstDayAfter(DateTime date, DayOfWeek dow)
        {
            while (date.DayOfWeek != dow)
            {
                date = date.AddDays(1);
            }
            return date;
        }

        internal static DateTime FirstDateAfterWeeks(DateTime dt, int weeks, DayOfWeek dow) =>
            FirstDayAfter(dt.AddDays(7 * weeks), dow);
    }
}
