using Icelandic.PublicHolidays.Utils;
using Icelandic.PublicHolidaysEnums;
using System;
using System.Collections.Generic;

namespace Icelandic.PublicHolidays
{
    public class AðrirViðburðardagar
    {
        readonly Dagar dagar;
        internal AðrirViðburðardagar(Dagar dagar)
        {
            this.dagar = dagar;

            allir = new Lazy<IEnumerable<Viðburðardagur>>(Initialize);
        }

        public DateTime Pálmasunnudagur => dagar.páskadagur.Value.AddDays(-7);

        public DateTime Jónsmessa => new DateTime(dagar.Ár, 6, 24);

        public DateTime Fullveldisdagurinn => new DateTime(dagar.Ár, 12, 1);

        public DateTime DagurÍslenskrarTungu =>
            dagar.Ár >= 1996
                ? new DateTime(dagar.Ár, 11, 16)
                : DateTime.MinValue;

        public DateTime Þorláksmessa => dagar.AlmennirFrídagar.Aðfangadagur.AddDays(-1);

        public DateTime Vorjafndægur => Solstice.VernalEquinox(dagar.Ár);
        public DateTime Haustjafndægur => Solstice.AutumnalEquinox(dagar.Ár);
        public DateTime Sumarsólstöður => Solstice.SummerSolstice(dagar.Ár);
        public DateTime Vetrarsólstöður => Solstice.WinterSolstice(dagar.Ár);

        // Fyrsti vetrardagur er 28.10 í rímspillisárum, annars fyrsti laugardagur á/eftir 21.10
        public DateTime FyrstiVetrardagur => 
            dagar.ErRímspillisÁr
            ? new DateTime(dagar.Ár, 10, 28)
            : DateUtils.FirstDayAfter(new DateTime(dagar.Ár, 10, 21), DayOfWeek.Saturday);

        private DateTime Lent => dagar.AlmennirFrídagar.Páskadagur.AddDays(-46);
        public DateTime Bolludagur => Lent.AddDays(-2);
        public DateTime Sprengidagur => Lent.AddDays(-1);
        public DateTime Öskudagur => Lent;

        public DateTime Mæðradagurinn => dagar.Ár >= 1934
            ? DateUtils.FirstDayAfter(DateUtils.FirstDayAfter(new DateTime(dagar.Ár, 5, 1), DayOfWeek.Sunday).AddDays(1), DayOfWeek.Sunday)
            : DateTime.MinValue;
        public DateTime Feðradagurinn =>
            dagar.Ár >= 2006
            ? DateUtils.FirstDayAfter(DateUtils.FirstDayAfter(new DateTime(dagar.Ár, 11, 1), DayOfWeek.Sunday).AddDays(1), DayOfWeek.Sunday)
            : DateTime.MinValue;

        public DateTime Bóndadagurinn =>
            DateUtils.FirstDayAfter(dagar.FyrraÁr.AðrirViðburðardagar.FyrstiVetrardagur.AddDays(7 * 12), DayOfWeek.Friday);
        public DateTime Konudagurinn =>
            DateUtils.FirstDayAfter(dagar.FyrraÁr.AðrirViðburðardagar.FyrstiVetrardagur.AddDays(7 * 17), DayOfWeek.Sunday);

        public DateTime Sjómannadagurinn
        {
            get
            {
                var candidate = DateUtils.FirstDayAfter(new DateTime(dagar.Ár, 6, 1), DayOfWeek.Sunday);
                if (candidate == dagar.AlmennirFrídagar.Hvítasunnudagur)
                    return DateUtils.FirstDayAfter(candidate.AddDays(1), DayOfWeek.Sunday);
                return candidate;
            }
        }

        IEnumerable<Viðburðardagur> Initialize()
        {
            var dates = new SortedList<string, Viðburðardagur>();
            void Add(DateTime date, string name, Dagarnir holidayDate)
            {
                dates.Add(date.ToString("yyyyMMdd") + name, new Viðburðardagur(date, name, holidayDate, Frídagur.Nei));
            }

            Add(Pálmasunnudagur, "Pálmasunnudagur", Dagarnir.Pálmasunnudagur);

            Add(Bolludagur, "Bolludagur", Dagarnir.Bolludagur);
            Add(Sprengidagur, "Sprengidagur", Dagarnir.Sprengidagur);
            Add(Öskudagur, "Öskudagur", Dagarnir.Öskudagur);

            Add(Sjómannadagurinn, "Sjómannadagurinn", Dagarnir.Sjómannadagurinn);
            Add(Jónsmessa, "Jónsmessa", Dagarnir.Jónsmessa);

            Add(Mæðradagurinn, "Mæðradagurinn", Dagarnir.Mæðradagurinn);
            Add(Feðradagurinn, "Feðradagurinn", Dagarnir.Feðradagurinn);
            Add(Konudagurinn, "Konudagurinn", Dagarnir.Konudagurinn);
            Add(Bóndadagurinn, "Bóndadagurinn", Dagarnir.Bóndadagurinn);

            Add(FyrstiVetrardagur, "Fyrsti vetrardagur", Dagarnir.FyrstiVetrardagur);

            Add(DagurÍslenskrarTungu, "Dagur íslenskrar tungu", Dagarnir.DagurÍslenskrarTungu);

            Add(Þorláksmessa, "Þorláksmessa", Dagarnir.Þorláksmessa);

            Add(Fullveldisdagurinn, "Fullveldisdagurinn", Dagarnir.Fullveldisdagurinn);

            Add(Vorjafndægur, "Vorjafndægur", Dagarnir.Vorjafndægur);
            Add(Haustjafndægur, "Haustjafndægur", Dagarnir.Haustjafndægur);
            Add(Sumarsólstöður, "Sumarsólstöður", Dagarnir.Sumarsólstöður);
            Add(Vetrarsólstöður, "Vetrarsólstöður", Dagarnir.Vetrarsólstöður);

            return dates.Values;
        }

        readonly Lazy<IEnumerable<Viðburðardagur>> allir;
        public IEnumerable<Viðburðardagur> Allir => allir.Value;
    }
}
