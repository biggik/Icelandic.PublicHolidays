using System;
using System.Globalization;

namespace Icelandic.PublicHolidays.Utils
{
    /// <summary>
    /// Calculates Solstice / Equinox for a given year
    /// </summary>
    static class Solstice
    {
        static readonly double Deg2Radian = Math.PI / 180.0;

        enum EquinoxSolsticeEnum : byte
        {
            VernalEquinox = 0,
            SummerSolstice = 1,
            AutumnalEquinox = 2,
            WinterSolstice = 3
        }

        public static DateTime VernalEquinox(int year) => GetEquinoxSolstice(year, EquinoxSolsticeEnum.VernalEquinox).Date;
        public static DateTime SummerSolstice(int year) => GetEquinoxSolstice(year, EquinoxSolsticeEnum.SummerSolstice).Date;
        public static DateTime AutumnalEquinox(int year) => GetEquinoxSolstice(year, EquinoxSolsticeEnum.AutumnalEquinox).Date;
        public static DateTime WinterSolstice(int year) => GetEquinoxSolstice(year, EquinoxSolsticeEnum.WinterSolstice).Date;

        /// <summary>Get the date the equinox or solstice occurs.</summary>
        /// <param name="year">The year to get the value for</param>
        /// <param name="season">Equinox or solstice to calculate for.</param>
        /// <returns>Date and time event occurs.</returns>
        private static DateTime GetEquinoxSolstice(int year, EquinoxSolsticeEnum season)
        {
            return Julian2Date(EquinoxSolstice(year, season));
        }

        /// <summary>Calculates time of Equinox and Solstice.
        /// </summary>
        /// <param name="year">Year to calculate for</param>
        /// <param name="season">Event to calculate</param>
        /// <returns>Date and time event occurs as a fractional Julian Day.</returns>
        private static double EquinoxSolstice(double year, EquinoxSolsticeEnum season)
        {
            double julianEphemerisDay = 0;

            if (year >= 1000)
            {
                var y = (Math.Floor(year) - 2000) / 1000;
                switch (season)
                {
                    case EquinoxSolsticeEnum.VernalEquinox:
                        julianEphemerisDay = 2451623.80984
                                + (365242.37404 * y)
                                + (0.05169 * (y * y))
                                - (0.00411 * (y * y * y))
                                - (0.00057 * (y * y * y * y));
                        break;
                    case EquinoxSolsticeEnum.SummerSolstice:
                        julianEphemerisDay = 2451716.56767
                                + (365241.62603 * y)
                                + (0.00325 * (y * y))
                                - (0.00888 * (y * y * y))
                                - (0.00030 * (y * y * y * y));
                        break;
                    case EquinoxSolsticeEnum.AutumnalEquinox:
                        julianEphemerisDay = 2451810.21715
                                + (365242.01767 * y)
                                + (0.11575 * (y * y))
                                - (0.00337 * (y * y * y))
                                - (0.00078 * (y * y * y * y));
                        break;
                    case EquinoxSolsticeEnum.WinterSolstice:
                        julianEphemerisDay = 2451900.05952
                                + (365242.74049 * y)
                                + (0.06223 * (y * y))
                                - (0.00823 * (y * y * y))
                                - (0.00032 * (y * y * y * y));
                        break;
                }
            }
            else
            {
                var y = Math.Floor(year) / 1000;
                switch (season)
                {
                    case EquinoxSolsticeEnum.VernalEquinox:
                        julianEphemerisDay = 1721139.29189
                                + (365242.13740 * y)
                                + (0.06134 * (y * y))
                                - (0.00111 * (y * y * y))
                                - (0.00071 * (y * y * y * y));
                        break;
                    case EquinoxSolsticeEnum.SummerSolstice:
                        julianEphemerisDay = 1721233.25401
                                + (365241.72562 * y)
                                + (0.05323 * (y * y))
                                - (0.00907 * (y * y * y))
                                - (0.00025 * (y * y * y * y));
                        break;
                    case EquinoxSolsticeEnum.AutumnalEquinox:
                        julianEphemerisDay = 1721325.70455
                                + (365242.49558 * y)
                                + (0.11677 * (y * y))
                                - (0.00297 * (y * y * y))
                                - (0.00074 * (y * y * y * y));
                        break;
                    case EquinoxSolsticeEnum.WinterSolstice:
                        julianEphemerisDay = 1721414.39987
                                + (365242.88257 * y)
                                + (0.00769 * (y * y))
                                - (0.00933 * (y * y * y))
                                - (0.00006 * (y * y * y * y));
                        break;
                }
            }

            var julianCenturies = (julianEphemerisDay - 2451545.0) / 36525;

            var w = (35999.373 * julianCenturies) - 2.47;

            var lambda = 1 + (0.0334 * Math.Cos(w * Deg2Radian))
                           + (0.0007 * Math.Cos(2 * w * Deg2Radian));

            double Calc(int factor, double v1, double v2)
                => factor * Math.Cos((Deg2Radian * v1) + (Deg2Radian * (v2 * julianCenturies)));

            // sum of periodic terms
            var sum = Calc(485, 324.96,   1934.136)
                    + Calc(203, 337.23,  32964.467)
                    + Calc(199, 342.08,     20.186)
                    + Calc(182,  27.85, 445267.112)
                    + Calc(156,  73.14,  45036.886)
                    + Calc(136, 171.52,  22518.443)
                    + Calc( 77, 222.54,  65928.934)
                    + Calc( 74, 296.72,   3034.906)
                    + Calc( 70, 243.58,   9037.513)
                    + Calc( 58, 119.81,  33718.147)
                    + Calc( 52, 297.17,    150.678)
                    + Calc( 50,  21.02,   2281.226)
                    + Calc( 45, 247.54,  29929.562)
                    + Calc( 44, 325.15,  31555.956)
                    + Calc( 29,  60.93,   4443.417)
                    + Calc( 28, 155.12,  67555.328)
                    + Calc( 17, 288.79,   4562.452)
                    + Calc( 16, 198.04,  62894.029)
                    + Calc( 14, 199.76,  31436.921)
                    + Calc( 12,  95.39,  14577.848)
                    + Calc( 12, 287.11,  31931.756)
                    + Calc( 12, 320.81,  34777.259)
                    + Calc(  9, 227.73,   1222.114)
                    + Calc(  8,  15.45,  16859.074);

            return julianEphemerisDay + (0.00001 * sum / lambda);
        }

        #region Julian / Date conversion

        /// <summary>Converts a fractional Julian Day to a .NET DateTime.</summary>
        /// <param name="JD">Fractional Julian Day to convert.</param>
        /// <returns>Date and Time in .NET DateTime format.</returns>
        public static DateTime Julian2Date(double JD)
        {
            //double A, B, C, D, E, F, J, Z;
            //int month, year;
            //double alpha;
            //double day;

            var J = JD + 0.5;

            var Z = Math.Floor(J);

            var F = J - Z;

            double A = Z;
            if (Z >= 2299161)
            {
                var alpha = Math.Floor((Z - 1867216.25) / 36524.25);
                A = Z + 1 + alpha - Math.Floor(alpha / 4);
            }

            var B = A + 1524;

            var C = Math.Floor((B - 122.1) / 365.25);

            var D = Math.Floor(365.25 * C);

            var E = Math.Floor((B - D) / 30.6001);

            var day = B - D - Math.Floor(30.6001 * E) + F;

            int month;
            if (E < 14)
                month = (int)(E - 1.0);
            else if ((int)E == 14 || (int)E == 15)
                month = (int)(E - 13.0);
            else
                throw new Exception("Illegal month calculated.");

            int year;
            if (month > 2)
                year = (int)(C - 4716.0);
            else if (month == 1 || month == 2)
                year = (int)(C - 4715.0);
            else
                throw new Exception("Illegal year calculated.");

            TimeSpan span = TimeSpan.FromDays(day);

            return new DateTime(
                year,
                month,
                (int)day,
                span.Hours,
                span.Minutes,
                span.Seconds,
                span.Milliseconds,
                new GregorianCalendar(),
                DateTimeKind.Utc);
        }

        /// <summary>Calculates the Julian Day from a DateTime object.</summary>
        /// <param name="d">DateTime object from which to calculate a Julian Day.</param>
        /// <returns>A fractional Julian Day value.</returns>
        /// <remarks>Tested against pg 61 input data.</remarks>
        public static double Date2Julian(DateTime d)
        {
            int year = d.Year;
            int month = d.Month;
            if (d.Month <= 2)
            {
                year--;
                month += 12;
            }

            var A = Math.Floor(year / 100.0);

            double B;
            if (d.Year < 1582)
            {
                B = 0;
            }
            else if (d.Year > 1582)
            {
                B = 2 - A + Math.Floor(A / 4);
            }
            else
            {
                if (d.Month < 10)
                {
                    B = 0;
                }
                else if (d.Month > 10)
                {
                    B = 2 - A + Math.Floor(A / 4);
                }
                else
                {
                    if (d.Day < 5)
                        B = 0;
                    else if (d.Day >= 15)
                        B = 2 - A + Math.Floor(A / 4);
                    else
                        throw new Exception("Input day falls between 10/5/1582 and 10/14/1582, which does not exist in the Gregorian Calendar.");
                }
            }

            double jd = Math.Floor(365.25 * (year + 4716))
                        + Math.Floor(30.6001 * (month + 1))
                        + d.Day
                        + B
                        - 1524.5;

            // add fractional parts of the day to the Julian Day
            TimeSpan span = TimeSpan.FromHours(d.Hour)
                            + TimeSpan.FromMinutes(d.Minute)
                            + TimeSpan.FromSeconds(d.Second)
                            + TimeSpan.FromMilliseconds(d.Millisecond);

            return jd + span.TotalDays;
        }
        #endregion
    }
}