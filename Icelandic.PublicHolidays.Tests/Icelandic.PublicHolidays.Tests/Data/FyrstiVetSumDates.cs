using Icelandic.PublicHolidays.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Icelandic.PublicHolidays.Tests.Data
{
    static class FyrstiVetSumDates
    {
        static public IEnumerable<(Dagarnir holidayDate, DateTime date)> Values
        {
            // Values from http://www.almanak.hi.is/f2.html, table IV
            get
            {
                var data = new (IEnumerable<int> years,
                    (int aprilDate, int octDate) C1700_2100,
                    (int aprilDate, int octDate) C1800_2200,
                    (int aprilDate, int octDate) C1900_2300,
                    (int aprilDate, int octDate) C2000_2400)[]
                {
                    (new [] {0}, (22,23), (24,25), (19,27), (20,21)),
                    (new [] {1,29,57,85}, (21,22), (23,24), (25,26), (19,27)),
                    (new [] {2,30,58,86}, (20,21), (22,23), (24,25), (25,26)),
                    (new [] {3,31,59,87}, (19,27), (21,22), (23,24), (24,25)),
                    (new [] {4,32,60,88}, (24,25), (19,27), (21,22), (22,23)),
                    (new [] {5,33,61,89}, (23,24), (25,26), (20,21), (21,22)),
                    (new [] {6,34,62,90}, (22,23), (24,25), (19,27), (20,21)),
                    (new [] {7,35,63,91}, (21,22), (23,24), (25,26), (19,27)),
                    (new [] {8,36,64,92}, (19,27), (21,22), (23,24), (24,25)),
                    (new [] {9,37,65,93}, (25,26), (20,21), (22,23), (23,24)),
                    (new [] {10,38,66,94}, (24,25), (19,27), (21,22), (22,23)),
                    (new [] {11,39,67,95}, (23,24), (25,26), (20,28), (21,22)),
                    (new [] {12,40,68,96}, (21,22), (23,24), (25,26), (19,27)),
                    (new [] {13,41,69,97}, (20,21), (22,23), (24,25), (25,26)),
                    (new [] {14,42,70,98}, (19,27), (21,22), (23,24), (24,25)),
                    (new [] {99}, (25,26), (20,21), (22,23), (23,24)),
                    (new [] {15,43,71}, (25,26), (20,28), (22,23), (23,24)),
                    (new [] {16,44,72}, (23,24), (25,26), (20,21), (21,22)),
                    (new [] {17,45,73}, (22,23), (24,25), (19,27), (20,21)),
                    (new [] {18,46,74}, (21,22), (23,24), (25,26), (19,27)),
                    (new [] {19,47,75}, (20,28), (22,23), (24,25), (25,26)),
                    (new [] {20,48,76}, (25,26), (20,21), (22,23), (23,24)),
                    (new [] {21,49,77}, (24,25), (19,27), (21,22), (22,23)),
                    (new [] {22,50,78}, (23,24), (25,26), (20,21), (21,22)),
                    (new [] {23,51,79}, (22,23), (24,25), (19,27), (20,28)),
                    (new [] {24,52,80}, (20,21), (22,23), (24,25), (25,26)),
                    (new [] {25,53,81}, (19,27), (21,22), (23,24), (24,25)),
                    (new [] {26,54,82}, (25,26), (20,21), (22,23), (23,24)),
                    (new [] {27,55,83}, (24,25), (19,27), (21,22), (22,23)),
                    (new [] {28,56,84}, (22,23), (24,25), (19,27), (20,21))
                };
                foreach (var (years,
                    C1700_2100,
                    C1800_2200,
                    C1900_2300,
                    C2000_2400) in data)
                {
                    foreach (var year in years)
                    {
                        yield return (Dagarnir.SumardagurinnFyrsti, new DateTime(1700 + year,  4, C1700_2100.aprilDate));
                        yield return (Dagarnir.FyrstiVetrardagur,   new DateTime(1700 + year, 10, C1700_2100.octDate));
                        yield return (Dagarnir.SumardagurinnFyrsti, new DateTime(2100 + year,  4, C1700_2100.aprilDate));
                        yield return (Dagarnir.FyrstiVetrardagur,   new DateTime(2100 + year, 10, C1700_2100.octDate));

                        yield return (Dagarnir.SumardagurinnFyrsti, new DateTime(1800 + year,  4, C1800_2200.aprilDate));
                        yield return (Dagarnir.FyrstiVetrardagur,   new DateTime(1800 + year, 10, C1800_2200.octDate));
                        yield return (Dagarnir.SumardagurinnFyrsti, new DateTime(2200 + year,  4, C1800_2200.aprilDate));
                        yield return (Dagarnir.FyrstiVetrardagur,   new DateTime(2200 + year, 10, C1800_2200.octDate));

                        yield return (Dagarnir.SumardagurinnFyrsti, new DateTime(1900 + year,  4, C1900_2300.aprilDate));
                        yield return (Dagarnir.FyrstiVetrardagur,   new DateTime(1900 + year, 10, C1900_2300.octDate));
                        yield return (Dagarnir.SumardagurinnFyrsti, new DateTime(2300 + year,  4, C1900_2300.aprilDate));
                        yield return (Dagarnir.FyrstiVetrardagur,   new DateTime(2300 + year, 10, C1900_2300.octDate));

                        yield return (Dagarnir.SumardagurinnFyrsti, new DateTime(2000 + year,  4, C2000_2400.aprilDate));
                        yield return (Dagarnir.FyrstiVetrardagur,   new DateTime(2000 + year, 10, C2000_2400.octDate));
                        yield return (Dagarnir.SumardagurinnFyrsti, new DateTime(2400 + year,  4, C2000_2400.aprilDate));
                        yield return (Dagarnir.FyrstiVetrardagur,   new DateTime(2400 + year, 10, C2000_2400.octDate));
                    }
                }
            }
        }
    }
}