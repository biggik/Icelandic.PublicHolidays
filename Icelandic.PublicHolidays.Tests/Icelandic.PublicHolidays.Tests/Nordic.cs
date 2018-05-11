using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Icelandic.PublicHolidays.Nordic;
using Icelandic.PublicHolidays.Tests.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Icelandic.PublicHolidays.Tests
{
    [TestClass]
    public class Nordic
    {
        private IEnumerable<DateTime> MonthDates(NorrænirMánuðir mánuður)
        {
            return from x in NordicDates.Values
                   where x.mánuður == mánuður
                   select x.date;
        }

        [TestCategory("Nordic")]
        [TestMethod]
        public void Debug()
        {
                var gen = new Generator(2017);
                Assert.AreEqual(new DateTime(2017,9,28), gen.Norrænt.Haustmánuður);
        }

        [TestCategory("Nordic")]
        [TestMethod]
        public void TestÞorri()
        {
            foreach (var date in MonthDates(NorrænirMánuðir.Þorri))
            {
                var gen = new Generator(date.Year);
                Assert.AreEqual(date, gen.Norrænt.Þorri);
            }
        }

        [TestCategory("Nordic")]
        [TestMethod]
        public void TestGóa()
        {
            foreach (var date in MonthDates(NorrænirMánuðir.Góa))
            {
                var gen = new Generator(date.Year);
                Assert.AreEqual(date, gen.Norrænt.Góa);
            }
        }

        [TestCategory("Nordic")]
        [TestMethod]
        public void TestEinmánuður()
        {
            foreach (var date in MonthDates(NorrænirMánuðir.Einmánuður))
            {
                var gen = new Generator(date.Year);
                Assert.AreEqual(date, gen.Norrænt.Einmánuður);
            }
        }

        [TestCategory("Nordic")]
        [TestMethod]
        public void TestHarpa()
        {
            foreach (var date in MonthDates(NorrænirMánuðir.Harpa))
            {
                var gen = new Generator(date.Year);
                Assert.AreEqual(date, gen.Norrænt.Harpa);
            }
        }

        [TestCategory("Nordic")]
        [TestMethod]
        public void TestSkerpla()
        {
            foreach (var date in MonthDates(NorrænirMánuðir.Skerpla))
            {
                var gen = new Generator(date.Year);
                Assert.AreEqual(date, gen.Norrænt.Skerpla);
            }
        }

        [TestCategory("Nordic")]
        [TestMethod]
        public void TestSólmánuður()
        {
            foreach (var date in MonthDates(NorrænirMánuðir.Sólmánuður))
            {
                var gen = new Generator(date.Year);
                Assert.AreEqual(date, gen.Norrænt.Sólmánuður);
            }
        }

        [TestCategory("Nordic")]
        [TestMethod]
        public void TestHeyannir()
        {
            foreach (var date in MonthDates(NorrænirMánuðir.Heyannir))
            {
                var gen = new Generator(date.Year);
                Assert.AreEqual(date, gen.Norrænt.Heyannir);
            }
        }

        [TestCategory("Nordic")]
        [TestMethod]
        public void TestTvímánuður()
        {
            foreach (var date in MonthDates(NorrænirMánuðir.Tvímánuður))
            {
                var gen = new Generator(date.Year);
                Assert.AreEqual(date, gen.Norrænt.Tvímánuður);
            }
        }

        [TestCategory("Nordic")]
        [TestMethod]
        public void TestHaustmánuður()
        {
            foreach (var date in MonthDates(NorrænirMánuðir.Haustmánuður))
            {
                var gen = new Generator(date.Year);
                Assert.AreEqual(date, gen.Norrænt.Haustmánuður);
            }
        }

        [TestCategory("Nordic")]
        [TestMethod]
        public void TestGormánuður()
        {
            foreach (var date in MonthDates(NorrænirMánuðir.Gormánuður))
            {
                var gen = new Generator(date.Year);
                Assert.AreEqual(date, gen.Norrænt.Gormánuður);
            }
        }

        [TestCategory("Nordic")]
        [TestMethod]
        public void TestÝlir()
        {
            foreach (var date in MonthDates(NorrænirMánuðir.Ýlir))
            {
                var gen = new Generator(date.Year);
                Assert.AreEqual(date, gen.Norrænt.Ýlir);
            }
        }

        [TestCategory("Nordic")]
        [TestMethod]
        public void TestMörsugur()
        {
            foreach (var date in MonthDates(NorrænirMánuðir.Mörsugur))
            {
                var gen = new Generator(date.Year);
                Assert.AreEqual(date, gen.Norrænt.Mörsugur);
            }
        }
    }
}
