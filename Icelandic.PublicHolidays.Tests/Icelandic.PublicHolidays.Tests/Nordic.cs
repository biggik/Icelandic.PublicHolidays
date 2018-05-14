using System;
using System.Collections.Generic;
using System.Linq;
using Icelandic.PublicHolidays.Enums;
using Icelandic.PublicHolidays.Tests.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Icelandic.PublicHolidays.Tests
{
    [TestClass]
    public class Nordic
    {
        static IEnumerable<DateTime> MonthDates(NorrænirMánuðir mánuður)
        {
            return from x in NordicDates.Values
                   where x.mánuður == mánuður
                   orderby x.date
                   select x.date;
        }

        [TestCategory("Nordic")]
        [TestMethod]
        public void TestÞorri()
        {
            foreach (var date in MonthDates(NorrænirMánuðir.Þorri))
            {
                var dagar = new Dagar(date.Year);
                Assert.AreEqual(date, dagar.NorræntDagatal.Þorri);
            }
        }

        [TestCategory("Nordic")]
        [TestMethod]
        public void TestGóa()
        {
            foreach (var date in MonthDates(NorrænirMánuðir.Góa))
            {
                var dagar = new Dagar(date.Year);
                Assert.AreEqual(date, dagar.NorræntDagatal.Góa);
            }
        }

        [TestCategory("Nordic")]
        [TestMethod]
        public void TestEinmánuður()
        {
            foreach (var date in MonthDates(NorrænirMánuðir.Einmánuður))
            {
                var dagar = new Dagar(date.Year);
                Assert.AreEqual(date, dagar.NorræntDagatal.Einmánuður);
            }
        }

        [TestCategory("Nordic")]
        [TestMethod]
        public void TestHarpa()
        {
            foreach (var date in MonthDates(NorrænirMánuðir.Harpa))
            {
                var dagar = new Dagar(date.Year);
                Assert.AreEqual(date, dagar.NorræntDagatal.Harpa);
            }
        }

        [TestCategory("Nordic")]
        [TestMethod]
        public void TestSkerpla()
        {
            foreach (var date in MonthDates(NorrænirMánuðir.Skerpla))
            {
                var dagar = new Dagar(date.Year);
                Assert.AreEqual(date, dagar.NorræntDagatal.Skerpla);
            }
        }

        [TestCategory("Nordic")]
        [TestMethod]
        public void TestSólmánuður()
        {
            foreach (var date in MonthDates(NorrænirMánuðir.Sólmánuður))
            {
                var dagar = new Dagar(date.Year);
                Assert.AreEqual(date, dagar.NorræntDagatal.Sólmánuður);
            }
        }

        [TestCategory("Nordic")]
        [TestMethod]
        public void TestHeyannir()
        {
            foreach (var date in MonthDates(NorrænirMánuðir.Heyannir))
            {
                var dagar = new Dagar(date.Year);
                Assert.AreEqual(date, dagar.NorræntDagatal.Heyannir);
            }
        }

        [TestCategory("Nordic")]
        [TestMethod]
        public void TestTvímánuður()
        {
            foreach (var date in MonthDates(NorrænirMánuðir.Tvímánuður))
            {
                var dagar = new Dagar(date.Year);
                Assert.AreEqual(date, dagar.NorræntDagatal.Tvímánuður);
            }
        }

        [TestCategory("Nordic")]
        [TestMethod]
        public void TestHaustmánuður()
        {
            foreach (var date in MonthDates(NorrænirMánuðir.Haustmánuður))
            {
                var dagar = new Dagar(date.Year);
                Assert.AreEqual(date, dagar.NorræntDagatal.Haustmánuður);
            }
        }

        [TestCategory("Nordic")]
        [TestMethod]
        public void TestGormánuður()
        {
            foreach (var date in MonthDates(NorrænirMánuðir.Gormánuður))
            {
                var dagar = new Dagar(date.Year);
                Assert.AreEqual(date, dagar.NorræntDagatal.Gormánuður);
            }
        }

        [TestCategory("Nordic")]
        [TestMethod]
        public void TestÝlir()
        {
            foreach (var date in MonthDates(NorrænirMánuðir.Ýlir))
            {
                var dagar = new Dagar(date.Year);
                Assert.AreEqual(date, dagar.NorræntDagatal.Ýlir);
            }
        }

        [TestCategory("Nordic")]
        [TestMethod]
        public void TestMörsugur()
        {
            foreach (var date in MonthDates(NorrænirMánuðir.Mörsugur))
            {
                var dagar = new Dagar(date.Year);
                Assert.AreEqual(date, dagar.NorræntDagatal.Mörsugur);
            }
        }
    }
}
