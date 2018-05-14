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
    }
}
