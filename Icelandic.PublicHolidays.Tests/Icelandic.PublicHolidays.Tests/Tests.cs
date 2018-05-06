using System;
using System.Linq;
using Icelandic.PublicHolidays.Tests.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Icelandic.PublicHolidays.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestCalendarDates()
        {
            var dates = CalendarDates.Values;
            var yearDates = (from d in dates select d).GroupBy(x => x.year);

            foreach (var year in yearDates)
            {
                var gen = new Generator(year.Key);
                ValidateStandardDates(gen, year.Key);

                DateTime getter(Generator.HolidayDates holidayDate) =>
                    year.First(x => x.holidayDate == holidayDate).date;

                Assert.AreEqual(getter(Generator.HolidayDates.Bóndadagurinn), gen.Bóndadagurinn, gen.Bóndadagurinn.ToString());
                Assert.AreEqual(getter(Generator.HolidayDates.Bolludagur), gen.Bolludagur, gen.Bolludagur.ToString());
                Assert.AreEqual(getter(Generator.HolidayDates.Sprengidagur), gen.Sprengidagur, gen.Sprengidagur.ToString());
                Assert.AreEqual(getter(Generator.HolidayDates.Öskudagur), gen.Öskudagur, gen.Öskudagur.ToString());
                Assert.AreEqual(getter(Generator.HolidayDates.Konudagurinn), gen.Konudagurinn, gen.Konudagurinn.ToString());
                Assert.AreEqual(getter(Generator.HolidayDates.Pálmasunnudagur), gen.Pálmasunnudagur, gen.Pálmasunnudagur.ToString());
                Assert.AreEqual(getter(Generator.HolidayDates.Skírdagur), gen.Skírdagur, gen.Skírdagur.ToString());
                Assert.AreEqual(getter(Generator.HolidayDates.FöstudagurinnLangi), gen.FöstudagurinnLangi, gen.FöstudagurinnLangi.ToString());
                Assert.AreEqual(getter(Generator.HolidayDates.Páskadagur), gen.Páskadagur, gen.Páskadagur.ToString());
                Assert.AreEqual(getter(Generator.HolidayDates.SumardagurinnFyrsti), gen.SumardagurinnFyrsti, gen.SumardagurinnFyrsti.ToString());
                Assert.AreEqual(getter(Generator.HolidayDates.Verkalýðsdagurinn), gen.Verkalýðsdagurinn, gen.Verkalýðsdagurinn.ToString());
                Assert.AreEqual(getter(Generator.HolidayDates.Mæðradagurinn), gen.Mæðradagurinn, gen.Mæðradagurinn.ToString());
                Assert.AreEqual(getter(Generator.HolidayDates.Uppstigningardagur), gen.Uppstigningardagur, gen.Uppstigningardagur.ToString());
                Assert.AreEqual(getter(Generator.HolidayDates.Hvítasunnudagur), gen.Hvítasunnudagur, gen.Hvítasunnudagur.ToString());
                Assert.AreEqual(getter(Generator.HolidayDates.Sjómannadagurinn), gen.Sjómannadagurinn, gen.Sjómannadagurinn.ToString());
                Assert.AreEqual(getter(Generator.HolidayDates.FrídagurVerslunarmanna), gen.FrídagurVerslunarmanna, gen.FrídagurVerslunarmanna.ToString());
                Assert.AreEqual(getter(Generator.HolidayDates.FyrstiVetrardagur), gen.FyrstiVetrardagur, gen.FyrstiVetrardagur.ToString());
                Assert.AreEqual(getter(Generator.HolidayDates.Feðradagurinn), gen.Feðradagurinn, gen.Feðradagurinn.ToString());
            }
        }

        private void ValidateStandardDates(Generator gen, int year)
        {
            Assert.AreEqual(new DateTime(year, 1, 1), gen.Nýársdagur);
            Assert.AreEqual(new DateTime(year, 5, 1), gen.Verkalýðsdagurinn);
            Assert.AreEqual(new DateTime(year, 6, 17), gen.Lýðveldisdagurinn);
            Assert.AreEqual(new DateTime(year, 6, 24), gen.Jónsmessa);
            Assert.AreEqual(new DateTime(year, 12, 1), gen.Fullveldisdagurinn);
            Assert.AreEqual(new DateTime(year, 12, 23), gen.Þorláksmessa);
            Assert.AreEqual(new DateTime(year, 12, 24), gen.Aðfangadagur);
            Assert.AreEqual(new DateTime(year, 12, 25), gen.Jóladagur);
            Assert.AreEqual(new DateTime(year, 12, 26), gen.AnnarÍJólum);
            Assert.AreEqual(new DateTime(year, 12, 31), gen.Gamlársdagur);

            Assert.AreEqual(
                year >= 1996
                ? new DateTime(year, 11, 16)
                : DateTime.MinValue, gen.DagurÍslenskrarTungu);

        }

        [TestMethod]
        public void TestYear1979()
        {
            int year = 1979;
            var gen = new Generator(year);
            Assert.AreEqual(gen.Páskadagur, new DateTime(year, 4, 15));

            Assert.AreEqual(new DateTime(year,  4,  8), gen.Pálmasunnudagur);
            Assert.AreEqual(new DateTime(year,  4, 12), gen.Skírdagur);
            Assert.AreEqual(new DateTime(year,  4, 13), gen.FöstudagurinnLangi);
            Assert.AreEqual(new DateTime(year,  4, 16), gen.AnnarÍPáskum);
            Assert.AreEqual(new DateTime(year,  5, 24), gen.Uppstigningardagur);
            Assert.AreEqual(new DateTime(year,  6,  3), gen.Hvítasunnudagur);
            Assert.AreEqual(new DateTime(year,  6,  4), gen.AnnarÍHvítasunnu);
            Assert.AreEqual(new DateTime(year,  8,  6), gen.FrídagurVerslunarmanna);

            Assert.AreEqual(new DateTime(year,  4, 19), gen.SumardagurinnFyrsti);
            Assert.AreEqual(new DateTime(year, 10, 27), gen.FyrstiVetrardagur);

            Assert.AreEqual(new DateTime(year,  2, 26), gen.Bolludagur);
            Assert.AreEqual(new DateTime(year,  2, 27), gen.Sprengidagur);
            Assert.AreEqual(new DateTime(year,  2, 28), gen.Öskudagur);

            Assert.AreEqual(new DateTime(year, 5, 13), gen.Mæðradagurinn);
            Assert.AreEqual(DateTime.MinValue, gen.Feðradagurinn);

            Assert.AreEqual(new DateTime(year, 6, 10), gen.Sjómannadagurinn);

            ValidateStandardDates(gen, year);

            Assert.AreEqual(new DateTime(year, 3, 21), gen.Vorjafndægur);
            Assert.AreEqual(new DateTime(year, 9, 23), gen.Haustjafndægur);
            Assert.AreEqual(new DateTime(year, 6, 21), gen.Sumarsólstöður);
            Assert.AreEqual(new DateTime(year, 12, 22), gen.Vetrarsólstöður);
        }

        [TestMethod]
        public void TestYear2000()
        {
            int year = 2000;
            var gen = new Generator(year);
            Assert.AreEqual(gen.Páskadagur, new DateTime(year, 4, 23));

            Assert.AreEqual(new DateTime(year, 4, 16), gen.Pálmasunnudagur);
            Assert.AreEqual(new DateTime(year, 4, 20), gen.Skírdagur);
            Assert.AreEqual(new DateTime(year, 4, 21), gen.FöstudagurinnLangi);
            Assert.AreEqual(new DateTime(year, 4, 24), gen.AnnarÍPáskum);
            Assert.AreEqual(new DateTime(year, 6, 1), gen.Uppstigningardagur);
            Assert.AreEqual(new DateTime(year, 6, 11), gen.Hvítasunnudagur);
            Assert.AreEqual(new DateTime(year, 6, 12), gen.AnnarÍHvítasunnu);
            Assert.AreEqual(new DateTime(year, 8, 7), gen.FrídagurVerslunarmanna);

            Assert.AreEqual(new DateTime(year, 4, 20), gen.SumardagurinnFyrsti);
            Assert.AreEqual(new DateTime(year, 10, 21), gen.FyrstiVetrardagur);

            Assert.AreEqual(new DateTime(year, 3, 6), gen.Bolludagur);
            Assert.AreEqual(new DateTime(year, 3, 7), gen.Sprengidagur);
            Assert.AreEqual(new DateTime(year, 3, 8), gen.Öskudagur);

            Assert.AreEqual(new DateTime(year, 5, 14), gen.Mæðradagurinn);
            Assert.AreEqual(DateTime.MinValue, gen.Feðradagurinn);

            Assert.AreEqual(new DateTime(year, 6, 4), gen.Sjómannadagurinn);

            ValidateStandardDates(gen, year);

            Assert.AreEqual(new DateTime(year, 3, 20), gen.Vorjafndægur);
            Assert.AreEqual(new DateTime(year, 9, 22), gen.Haustjafndægur);
            Assert.AreEqual(new DateTime(year,  6, 21), gen.Sumarsólstöður);
            Assert.AreEqual(new DateTime(year, 12, 21), gen.Vetrarsólstöður);
        }

        [TestMethod]
        public void TestYear2037()
        {
            int year = 2037;
            var gen = new Generator(year);
            Assert.AreEqual(gen.Páskadagur, new DateTime(year, 4, 5));

            Assert.AreEqual(new DateTime(year, 3, 29), gen.Pálmasunnudagur);
            Assert.AreEqual(new DateTime(year, 4,  2), gen.Skírdagur);
            Assert.AreEqual(new DateTime(year, 4,  3), gen.FöstudagurinnLangi);
            Assert.AreEqual(new DateTime(year, 4,  6), gen.AnnarÍPáskum);
            Assert.AreEqual(new DateTime(year, 5, 14), gen.Uppstigningardagur);
            Assert.AreEqual(new DateTime(year, 5, 24), gen.Hvítasunnudagur);
            Assert.AreEqual(new DateTime(year, 5, 25), gen.AnnarÍHvítasunnu);
            Assert.AreEqual(new DateTime(year, 8, 3), gen.FrídagurVerslunarmanna);

            Assert.AreEqual(new DateTime(year, 4, 23), gen.SumardagurinnFyrsti);
            Assert.AreEqual(new DateTime(year, 10, 24), gen.FyrstiVetrardagur);

            Assert.AreEqual(new DateTime(year, 2, 16), gen.Bolludagur);
            Assert.AreEqual(new DateTime(year, 2, 17), gen.Sprengidagur);
            Assert.AreEqual(new DateTime(year, 2, 18), gen.Öskudagur);

            Assert.AreEqual(new DateTime(year, 5, 10), gen.Mæðradagurinn);
            Assert.AreEqual(new DateTime(year, 11, 8), gen.Feðradagurinn);

            Assert.AreEqual(new DateTime(year, 6, 7), gen.Sjómannadagurinn);

            ValidateStandardDates(gen, year);

            Assert.AreEqual(new DateTime(year, 3, 20), gen.Vorjafndægur);
            Assert.AreEqual(new DateTime(year, 9, 22), gen.Haustjafndægur);
            Assert.AreEqual(new DateTime(year, 6, 21), gen.Sumarsólstöður);
            Assert.AreEqual(new DateTime(year, 12, 21), gen.Vetrarsólstöður);
        }

        [TestMethod]
        public void TestCount()
        {
            int year = 2000;
            var gen = new Generator(year);
            Assert.AreEqual(16, gen.AlmennirFrídagar.Count());
            Assert.AreEqual(14, gen.AðrirDagar.Count());
        }

        [TestMethod]
        public void TestEaster()
        {
            foreach (var data in EasterDates.Values)
            {
                var gen = new Generator(data.Year);
                Assert.AreEqual(data, gen.Páskadagur);
            }
        }

        [TestMethod]
        public void TestSumardagurinnFyrsti()
        {
            foreach (var data in SumardagurinnFyrstiDates.Values)
            {
                var gen = new Generator(data.Year);
                Assert.AreEqual(data, gen.SumardagurinnFyrsti);
            }
        }

        [TestMethod]
        public void TestBóndagurinn()
        {
            foreach (var data in BóndadagurinnDates.Values)
            {
                var gen = new Generator(data.Year);
                Assert.AreEqual(data, gen.Bóndadagurinn);
            }
        }
    }
}