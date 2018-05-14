using Icelandic.PublicHolidays.Utils;
using Icelandic.PublicHolidays.Enums;
using System;
using System.Collections.Generic;

namespace Icelandic.PublicHolidays
{
    public class AlmennirFrídagar
    {
        Dagar dagar;
        internal AlmennirFrídagar(Dagar dagar)
        {
            this.dagar = dagar;

            allir = new Lazy<IEnumerable<Viðburðardagur>>(Initialize);
        }

        public DateTime Nýársdagur => new DateTime(dagar.Ár, 1, 1);

        public DateTime Páskadagur => dagar.páskadagur.Value;
        public DateTime Uppstigningardagur { get { return Páskadagur.AddDays(39); } }
        public DateTime Skírdagur { get { return Páskadagur.AddDays(-3); } }
        public DateTime FöstudagurinnLangi { get { return Páskadagur.AddDays(-2); } }
        public DateTime AnnarÍPáskum { get { return Páskadagur.AddDays(1); } }
        public DateTime Hvítasunnudagur { get { return Páskadagur.AddDays(49); } }
        public DateTime AnnarÍHvítasunnu { get { return Páskadagur.AddDays(50); } }

        public DateTime Verkalýðsdagurinn => new DateTime(dagar.Ár, 5, 1);
        public DateTime Lýðveldisdagurinn => new DateTime(dagar.Ár, 6, 17);

        public DateTime Aðfangadagur => new DateTime(dagar.Ár, 12, 24);
        public DateTime Jóladagur => Aðfangadagur.AddDays(1);
        public DateTime AnnarÍJólum => Aðfangadagur.AddDays(2);
        public DateTime Gamlársdagur => Aðfangadagur.AddDays(7);

        public DateTime FrídagurVerslunarmanna => DateUtils.FirstDayAfter(new DateTime(dagar.Ár, 8, 1), DayOfWeek.Monday);

        public DateTime SumardagurinnFyrsti => DateUtils.FirstDayAfter(new DateTime(dagar.Ár, 4, 19), DayOfWeek.Thursday);

        IEnumerable<Viðburðardagur> Initialize()
        {
            var dates = new SortedList<string, Viðburðardagur>();

            void Add(
                DateTime date,
                string name,
                Dagarnir holidayDate,
                Frídagur holidayType = Frídagur.Já)
            {
                dates.Add(date.ToString("yyyyMMdd") + name, new Viðburðardagur(date, name, holidayDate, holidayType));
            }

            Add(Nýársdagur, "Nýársdagur", Dagarnir.Nýársdagur);

            Add(Skírdagur, "Skírdagur", Dagarnir.Skírdagur);
            Add(FöstudagurinnLangi, "Föstudagurinn langi", Dagarnir.FöstudagurinnLangi);

            Add(Páskadagur, "Páskadagur", Dagarnir.Páskadagur);
            Add(AnnarÍPáskum, "Annar í páskum", Dagarnir.AnnarÍPáskum);

            Add(SumardagurinnFyrsti, "Sumardagurinn fyrsti", Dagarnir.SumardagurinnFyrsti);

            Add(Verkalýðsdagurinn, "Verkalýðsdagurinn", Dagarnir.Verkalýðsdagurinn);

            Add(Uppstigningardagur, "Uppstigningardagur", Dagarnir.Uppstigningardagur);

            Add(Hvítasunnudagur, "Hvítasunnudagur", Dagarnir.Hvítasunnudagur);
            Add(AnnarÍHvítasunnu, "Annar í hvítasunnu", Dagarnir.AnnarÍHvítasunnu);

            Add(Lýðveldisdagurinn, "Lýðveldisdagurinn", Dagarnir.Lýðveldisdagurinn);

            Add(Aðfangadagur, "Aðfangadagur", Dagarnir.Aðfangadagur, Frídagur.Hálfur);
            Add(Jóladagur, "Jóladagur", Dagarnir.Jóladagur);
            Add(AnnarÍJólum, "Annar í jólum", Dagarnir.AnnarÍJólum);
            Add(Gamlársdagur, "Gamlársdagur", Dagarnir.Gamlársdagur, Frídagur.Hálfur);

            Add(FrídagurVerslunarmanna, "Frídagur verslunarmanna", Dagarnir.FrídagurVerslunarmanna);

            return dates.Values;
        }

        readonly Lazy<IEnumerable<Viðburðardagur>> allir;
        public IEnumerable<Viðburðardagur> Allir => allir.Value;
    }
}
