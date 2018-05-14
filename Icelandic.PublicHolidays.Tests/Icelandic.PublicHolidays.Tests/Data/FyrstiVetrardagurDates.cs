using System;
using System.Collections.Generic;

namespace Icelandic.PublicHolidays.Tests.Data
{
    static class FyrstiVetrardagurDates
    {
        static public IEnumerable<DateTime> Values
        {
            // Values from:
            // various - among others
            // http://www.almanak.hi.is/dagsetn.html
            get
            {
                var official = new(int year, int month, int date)[]
                {
                    (2003, 10, 25),
                    (2006, 10, 21),
                    (2010, 10, 23),
                    (2011, 10, 22),
                    (2015, 10, 24),
                    (2016, 10, 22),
                    (2017, 10, 21),
                    (2019, 10, 26),
                    (2020, 10, 24),
                    (2021, 10, 23),
                    (2022, 10, 22)
                };
                foreach (var (year, month, date) in official)
                    yield return new DateTime(year, month, date);
            }
        }
    }
}