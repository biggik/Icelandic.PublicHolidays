using System;
using System.Linq;
using Icelandic.PublicHolidays.Tests.Data;
using Icelandic.PublicHolidays.Enums;
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
            foreach (var year in (from d in dates select d).GroupBy(x => x.year))
            {
                var dagar = new Dagar(year.Key);
                ValidateStandardDates(dagar, year.Key);

                DateTime getter(Dagarnir holidayDate) =>
                    year.First(x => x.holidayDate == holidayDate).date;

                Assert.AreEqual(getter(Dagarnir.Bóndadagurinn), dagar.AðrirViðburðardagar.Bóndadagurinn, dagar.AðrirViðburðardagar.Bóndadagurinn.ToString());
                Assert.AreEqual(getter(Dagarnir.Bolludagur), dagar.AðrirViðburðardagar.Bolludagur, dagar.AðrirViðburðardagar.Bolludagur.ToString());
                Assert.AreEqual(getter(Dagarnir.Sprengidagur), dagar.AðrirViðburðardagar.Sprengidagur, dagar.AðrirViðburðardagar.Sprengidagur.ToString());
                Assert.AreEqual(getter(Dagarnir.Öskudagur), dagar.AðrirViðburðardagar.Öskudagur, dagar.AðrirViðburðardagar.Öskudagur.ToString());
                Assert.AreEqual(getter(Dagarnir.Konudagurinn), dagar.AðrirViðburðardagar.Konudagurinn, dagar.AðrirViðburðardagar.Konudagurinn.ToString());
                Assert.AreEqual(getter(Dagarnir.Pálmasunnudagur), dagar.AðrirViðburðardagar.Pálmasunnudagur, dagar.AðrirViðburðardagar.Pálmasunnudagur.ToString());
                Assert.AreEqual(getter(Dagarnir.Skírdagur), dagar.AlmennirFrídagar.Skírdagur, dagar.AlmennirFrídagar.Skírdagur.ToString());
                Assert.AreEqual(getter(Dagarnir.FöstudagurinnLangi), dagar.AlmennirFrídagar.FöstudagurinnLangi, dagar.AlmennirFrídagar.FöstudagurinnLangi.ToString());
                Assert.AreEqual(getter(Dagarnir.Páskadagur), dagar.AlmennirFrídagar.Páskadagur, dagar.AlmennirFrídagar.Páskadagur.ToString());
                Assert.AreEqual(getter(Dagarnir.SumardagurinnFyrsti), dagar.AlmennirFrídagar.SumardagurinnFyrsti, dagar.AlmennirFrídagar.SumardagurinnFyrsti.ToString());
                Assert.AreEqual(getter(Dagarnir.Verkalýðsdagurinn), dagar.AlmennirFrídagar.Verkalýðsdagurinn, dagar.AlmennirFrídagar.Verkalýðsdagurinn.ToString());
                Assert.AreEqual(getter(Dagarnir.Mæðradagurinn), dagar.AðrirViðburðardagar.Mæðradagurinn, dagar.AðrirViðburðardagar.Mæðradagurinn.ToString());
                Assert.AreEqual(getter(Dagarnir.Uppstigningardagur), dagar.AlmennirFrídagar.Uppstigningardagur, dagar.AlmennirFrídagar.Uppstigningardagur.ToString());
                Assert.AreEqual(getter(Dagarnir.Hvítasunnudagur), dagar.AlmennirFrídagar.Hvítasunnudagur, dagar.AlmennirFrídagar.Hvítasunnudagur.ToString());
                Assert.AreEqual(getter(Dagarnir.Sjómannadagurinn), dagar.AðrirViðburðardagar.Sjómannadagurinn, dagar.AðrirViðburðardagar.Sjómannadagurinn.ToString());
                Assert.AreEqual(getter(Dagarnir.FrídagurVerslunarmanna), dagar.AlmennirFrídagar.FrídagurVerslunarmanna, dagar.AlmennirFrídagar.FrídagurVerslunarmanna.ToString());
                Assert.AreEqual(getter(Dagarnir.FyrstiVetrardagur), dagar.AðrirViðburðardagar.FyrstiVetrardagur, dagar.AðrirViðburðardagar.FyrstiVetrardagur.ToString());
                Assert.AreEqual(getter(Dagarnir.Feðradagurinn), dagar.AðrirViðburðardagar.Feðradagurinn, dagar.AðrirViðburðardagar.Feðradagurinn.ToString());
            }
        }

        private void ValidateStandardDates(Dagar dagar, int year)
        {
            Assert.AreEqual(new DateTime(year, 1, 1), dagar.AlmennirFrídagar.Nýársdagur);
            Assert.AreEqual(new DateTime(year, 5, 1), dagar.AlmennirFrídagar.Verkalýðsdagurinn);
            Assert.AreEqual(new DateTime(year, 6, 17), dagar.AlmennirFrídagar.Lýðveldisdagurinn);
            Assert.AreEqual(new DateTime(year, 6, 24), dagar.AðrirViðburðardagar.Jónsmessa);
            Assert.AreEqual(new DateTime(year, 12, 1), dagar.AðrirViðburðardagar.Fullveldisdagurinn);
            Assert.AreEqual(new DateTime(year, 12, 23), dagar.AðrirViðburðardagar.Þorláksmessa);
            Assert.AreEqual(new DateTime(year, 12, 24), dagar.AlmennirFrídagar.Aðfangadagur);
            Assert.AreEqual(new DateTime(year, 12, 25), dagar.AlmennirFrídagar.Jóladagur);
            Assert.AreEqual(new DateTime(year, 12, 26), dagar.AlmennirFrídagar.AnnarÍJólum);
            Assert.AreEqual(new DateTime(year, 12, 31), dagar.AlmennirFrídagar.Gamlársdagur);

            Assert.AreEqual(
                year >= 1996
                ? new DateTime(year, 11, 16)
                : DateTime.MinValue, dagar.AðrirViðburðardagar.DagurÍslenskrarTungu);

        }

        [TestMethod]
        public void TestYear1979()
        {
            int year = 1979;
            var dagar = new Dagar(year);
            Assert.AreEqual(dagar.AlmennirFrídagar.Páskadagur, new DateTime(year, 4, 15));

            Assert.AreEqual(new DateTime(year,  4,  8), dagar.AðrirViðburðardagar.Pálmasunnudagur);
            Assert.AreEqual(new DateTime(year,  4, 12), dagar.AlmennirFrídagar.Skírdagur);
            Assert.AreEqual(new DateTime(year,  4, 13), dagar.AlmennirFrídagar.FöstudagurinnLangi);
            Assert.AreEqual(new DateTime(year,  4, 16), dagar.AlmennirFrídagar.AnnarÍPáskum);
            Assert.AreEqual(new DateTime(year,  5, 24), dagar.AlmennirFrídagar.Uppstigningardagur);
            Assert.AreEqual(new DateTime(year,  6,  3), dagar.AlmennirFrídagar.Hvítasunnudagur);
            Assert.AreEqual(new DateTime(year,  6,  4), dagar.AlmennirFrídagar.AnnarÍHvítasunnu);
            Assert.AreEqual(new DateTime(year,  8,  6), dagar.AlmennirFrídagar.FrídagurVerslunarmanna);

            Assert.AreEqual(new DateTime(year,  4, 19), dagar.AlmennirFrídagar.SumardagurinnFyrsti);
            Assert.AreEqual(new DateTime(year, 10, 27), dagar.AðrirViðburðardagar.FyrstiVetrardagur);

            Assert.AreEqual(new DateTime(year,  2, 26), dagar.AðrirViðburðardagar.Bolludagur);
            Assert.AreEqual(new DateTime(year,  2, 27), dagar.AðrirViðburðardagar.Sprengidagur);
            Assert.AreEqual(new DateTime(year,  2, 28), dagar.AðrirViðburðardagar.Öskudagur);

            Assert.AreEqual(new DateTime(year, 5, 13), dagar.AðrirViðburðardagar.Mæðradagurinn);
            Assert.AreEqual(DateTime.MinValue, dagar.AðrirViðburðardagar.Feðradagurinn);

            Assert.AreEqual(new DateTime(year, 6, 10), dagar.AðrirViðburðardagar.Sjómannadagurinn);

            ValidateStandardDates(dagar, year);

            Assert.AreEqual(new DateTime(year, 3, 21), dagar.AðrirViðburðardagar.Vorjafndægur);
            Assert.AreEqual(new DateTime(year, 9, 23), dagar.AðrirViðburðardagar.Haustjafndægur);
            Assert.AreEqual(new DateTime(year, 6, 21), dagar.AðrirViðburðardagar.Sumarsólstöður);
            Assert.AreEqual(new DateTime(year, 12, 22), dagar.AðrirViðburðardagar.Vetrarsólstöður);
        }

        [TestMethod]
        public void TestYear2000()
        {
            int year = 2000;
            var dagar = new Dagar(year);
            Assert.AreEqual(dagar.AlmennirFrídagar.Páskadagur, new DateTime(year, 4, 23));

            Assert.AreEqual(new DateTime(year, 4, 16), dagar.AðrirViðburðardagar.Pálmasunnudagur);
            Assert.AreEqual(new DateTime(year, 4, 20), dagar.AlmennirFrídagar.Skírdagur);
            Assert.AreEqual(new DateTime(year, 4, 21), dagar.AlmennirFrídagar.FöstudagurinnLangi);
            Assert.AreEqual(new DateTime(year, 4, 24), dagar.AlmennirFrídagar.AnnarÍPáskum);
            Assert.AreEqual(new DateTime(year, 6, 1), dagar.AlmennirFrídagar.Uppstigningardagur);
            Assert.AreEqual(new DateTime(year, 6, 11), dagar.AlmennirFrídagar.Hvítasunnudagur);
            Assert.AreEqual(new DateTime(year, 6, 12), dagar.AlmennirFrídagar.AnnarÍHvítasunnu);
            Assert.AreEqual(new DateTime(year, 8, 7), dagar.AlmennirFrídagar.FrídagurVerslunarmanna);

            Assert.AreEqual(new DateTime(year, 4, 20), dagar.AlmennirFrídagar.SumardagurinnFyrsti);
            Assert.AreEqual(new DateTime(year, 10, 21), dagar.AðrirViðburðardagar.FyrstiVetrardagur);

            Assert.AreEqual(new DateTime(year, 3, 6), dagar.AðrirViðburðardagar.Bolludagur);
            Assert.AreEqual(new DateTime(year, 3, 7), dagar.AðrirViðburðardagar.Sprengidagur);
            Assert.AreEqual(new DateTime(year, 3, 8), dagar.AðrirViðburðardagar.Öskudagur);

            Assert.AreEqual(new DateTime(year, 5, 14), dagar.AðrirViðburðardagar.Mæðradagurinn);
            Assert.AreEqual(DateTime.MinValue, dagar.AðrirViðburðardagar.Feðradagurinn);

            Assert.AreEqual(new DateTime(year, 6, 4), dagar.AðrirViðburðardagar.Sjómannadagurinn);

            ValidateStandardDates(dagar, year);

            Assert.AreEqual(new DateTime(year, 3, 20), dagar.AðrirViðburðardagar.Vorjafndægur);
            Assert.AreEqual(new DateTime(year, 9, 22), dagar.AðrirViðburðardagar.Haustjafndægur);
            Assert.AreEqual(new DateTime(year,  6, 21), dagar.AðrirViðburðardagar.Sumarsólstöður);
            Assert.AreEqual(new DateTime(year, 12, 21), dagar.AðrirViðburðardagar.Vetrarsólstöður);
        }

        [TestMethod]
        public void TestYear2037()
        {
            int year = 2037;
            var dagar = new Dagar(year);
            Assert.AreEqual(dagar.AlmennirFrídagar.Páskadagur, new DateTime(year, 4, 5));

            Assert.AreEqual(new DateTime(year, 3, 29), dagar.AðrirViðburðardagar.Pálmasunnudagur);
            Assert.AreEqual(new DateTime(year, 4,  2), dagar.AlmennirFrídagar.Skírdagur);
            Assert.AreEqual(new DateTime(year, 4,  3), dagar.AlmennirFrídagar.FöstudagurinnLangi);
            Assert.AreEqual(new DateTime(year, 4,  6), dagar.AlmennirFrídagar.AnnarÍPáskum);
            Assert.AreEqual(new DateTime(year, 5, 14), dagar.AlmennirFrídagar.Uppstigningardagur);
            Assert.AreEqual(new DateTime(year, 5, 24), dagar.AlmennirFrídagar.Hvítasunnudagur);
            Assert.AreEqual(new DateTime(year, 5, 25), dagar.AlmennirFrídagar.AnnarÍHvítasunnu);
            Assert.AreEqual(new DateTime(year, 8, 3), dagar.AlmennirFrídagar.FrídagurVerslunarmanna);

            Assert.AreEqual(new DateTime(year, 4, 23), dagar.AlmennirFrídagar.SumardagurinnFyrsti);
            Assert.AreEqual(new DateTime(year, 10, 24), dagar.AðrirViðburðardagar.FyrstiVetrardagur);

            Assert.AreEqual(new DateTime(year, 2, 16), dagar.AðrirViðburðardagar.Bolludagur);
            Assert.AreEqual(new DateTime(year, 2, 17), dagar.AðrirViðburðardagar.Sprengidagur);
            Assert.AreEqual(new DateTime(year, 2, 18), dagar.AðrirViðburðardagar.Öskudagur);

            Assert.AreEqual(new DateTime(year, 5, 10), dagar.AðrirViðburðardagar.Mæðradagurinn);
            Assert.AreEqual(new DateTime(year, 11, 8), dagar.AðrirViðburðardagar.Feðradagurinn);

            Assert.AreEqual(new DateTime(year, 6, 7), dagar.AðrirViðburðardagar.Sjómannadagurinn);

            ValidateStandardDates(dagar, year);

            Assert.AreEqual(new DateTime(year, 3, 20), dagar.AðrirViðburðardagar.Vorjafndægur);
            Assert.AreEqual(new DateTime(year, 9, 22), dagar.AðrirViðburðardagar.Haustjafndægur);
            Assert.AreEqual(new DateTime(year, 6, 21), dagar.AðrirViðburðardagar.Sumarsólstöður);
            Assert.AreEqual(new DateTime(year, 12, 21), dagar.AðrirViðburðardagar.Vetrarsólstöður);
        }

        [TestMethod]
        public void TestCount()
        {
            int year = 2000;
            var dagar = new Dagar(year);
            Assert.AreEqual(16, dagar.AlmennirFrídagar.Allir.Count());
            Assert.AreEqual(18, dagar.AðrirViðburðardagar.Allir.Count());
        }

        [TestMethod]
        public void TestEaster()
        {
            foreach (var data in EasterDates.Values)
            {
                var dagar = new Dagar(data.Year);
                Assert.AreEqual(data, dagar.AlmennirFrídagar.Páskadagur);
            }
        }

        [TestMethod]
        public void TestSumardagurinnFyrsti()
        {
            foreach (var data in SumardagurinnFyrstiDates.Values)
            {
                var dagar = new Dagar(data.Year);
                Assert.AreEqual(data, dagar.AlmennirFrídagar.SumardagurinnFyrsti);
            }
        }

        [TestMethod]
        public void TestSumarOgVetrardagur()
        {
            foreach (var year in FyrstiVetSumDates.Values.GroupBy(x => x.date.Year))
            {
                var dagar = new Dagar(year.Key);
                Assert.AreEqual(dagar.AlmennirFrídagar.SumardagurinnFyrsti, year.First(x => x.holidayDate == Dagarnir.SumardagurinnFyrsti).date);
                Assert.AreEqual(dagar.AðrirViðburðardagar.FyrstiVetrardagur, year.First(x => x.holidayDate == Dagarnir.FyrstiVetrardagur).date);
            }
        }

        [TestMethod]
        public void TestBóndagurinn()
        {
            foreach (var data in BóndadagurinnDates.Values)
            {
                var dagar = new Dagar(data.Year);
                Assert.AreEqual(data, dagar.AðrirViðburðardagar.Bóndadagurinn);
            }
        }
    }
}