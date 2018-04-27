using System;

namespace Icelandic.PublicHolidays
{
    public class EventDate
    {
        public enum HolidayTypes
        {
            None,
            Half,
            Full
        }

        public DateTime Date { get; }
        public string Name { get; }
        public Generator.HolidayDates HolidayDate { get; }
        public HolidayTypes HolidayType { get; }

        public EventDate(DateTime date, string name, Generator.HolidayDates holidayDate, HolidayTypes holidayType)
        {
            Date = date;
            Name = name;
            HolidayDate = holidayDate;
            HolidayType = holidayType;
        }
    }
}
