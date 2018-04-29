using System;
using System.Globalization;

namespace Icelandic.PublicHolidays
{
    /// <summary>
    /// Calculates Easter days for a given year
    /// Derived from http://www.assa.org.au/edm.html#Method
    /// </summary>
    internal static class Easter
    {
        /// <summary>
        /// Calculate easter date for the specified year
        /// Works for all years between 1583 - 4099
        /// </summary>
        /// <param name="year">Four digit year</param>
        /// <returns>Easter date for the year</returns>
        internal static DateTime CalculateForYear(int year)
        {
            // Easter Sunday is the Sunday following the Paschal Full Moon
            // (PFM) date for the year
            // This algorithm is an arithmetic interpretation of the 3 step
            // Easter Dating Method developed by Ron Mallen 1985, as a vast
            // improvement on the method described in the Common Prayer Book

            // Because this algorithm is a direct translation of the
            // official tables, it can be easily proved to be 100% correct
            // This algorithm derives values by sequential inter-dependent
            // calculations, so ... DO NOT MODIFY THE ORDER OF CALCULATIONS!

            // Get first two digits of year
            var firstDigits = year / 100;

            // remainder of year / 19
            var remainder19 = year % 19;

            // calculate PFM date
            var temp = ((firstDigits - 15) / 2) + 202 - (11 * remainder19);

            switch (firstDigits)
            {
                case 21:
                case 24:
                case 25:
                case 27:
                case 28:
                case 29:
                case 30:
                case 31:
                case 32:
                case 34:
                case 35:
                case 38:
                    temp--;
                    break;
                case 33:
                case 36:
                case 37:
                case 39:
                case 40:
                    temp -= 2;
                    break;
            }
            temp %= 30;

            var tA = temp + 21;
            if (temp == 29) tA--;
            else if (temp == 28 && remainder19 > 10) tA--;

            // find the next Sunday
            var tB = (tA - 19) % 7;

            var tC = (40 - firstDigits) % 4;
            if (tC == 3) tC++;
            if (tC > 1) tC++;

            temp = year % 100;
            var tD = (temp + temp / 4) % 7;

            var tE = ((20 - tB - tC - tD) % 7) + 1;

            int d = tA + tE;

            if ((tA + tE) > 31)
            {
                return new DateTime(year, 4, (tA + tE) - 31);
            }
            else
            {
                return new DateTime(year, 3, d);
            }
        }
    }
}