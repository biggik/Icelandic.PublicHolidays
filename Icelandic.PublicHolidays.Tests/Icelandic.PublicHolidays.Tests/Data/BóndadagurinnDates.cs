using System;
using System.Collections.Generic;

namespace Icelandic.PublicHolidays.Tests.Data
{
    static class BóndadagurinnDates
    {
        static public IEnumerable<DateTime> Values
        {
            // Values from http://www.almanak.hi.is/dagsetn.html og víðar
            get
            {
                var official = new(int year, int month, int date)[]
                {
                    (2016, 1, 22),
                    (2017, 1, 20),
                    (2018, 1, 19),
                    (2019, 1, 25),
                    (2020, 1, 24),
                    (2021, 1, 22),
                    (2022, 1, 21)
                };
                foreach (var (year, month, date) in official)
                    yield return new DateTime(year, month, date);
            }
        }
    }
}