using System;
using System.Collections.Generic;
using static Icelandic.PublicHolidays.EventDate;

namespace Icelandic.PublicHolidays
{
    public class Generator
    {
        public Generator(DateTime date)
            : this (date.Year)
        { }

        public Generator(int year)
        {
            Year = year;

            CalculateDates();
        }

        public enum HolidayDates
        {
            Páskadagur,
            Uppstigningardagur,
            Pálmasunnudagur,
            Skírdagur,
            FöstudagurinnLangi,
            AnnarÍPáskum,
            Hvítasunnudagur,
            AnnarÍHvítasunnu,
            Jónsmessa,
            Verkalýðsdagurinn,
            Lýðveldisdagurinn,
            Fullveldisdagurinn,
            Þorláksmessa,
            Aðfangadagur,
            Jóladagur,
            AnnarÍJólum,
            Gamlársdagur,
            Nýársdagur,
            FrídagurVerslunarmanna,
            Vorjafndægur,
            Haustjafndægur,
            Sumarsólstöður,
            Vetrarsólstöður,
            SumardagurinnFyrsti,
            FyrstiVetrardagur,
            Bolludagur,
            Sprengidagur,
            Öskudagur,
            Mæðradagurinn,
            Feðradagurinn
        }

        public int Year { get; }

        public DateTime Páskadagur { get; private set;}

        public DateTime Uppstigningardagur { get { return Páskadagur.AddDays(39);} }
        public DateTime Pálmasunnudagur { get { return Páskadagur.AddDays(-7);} }
        public DateTime Skírdagur { get { return Páskadagur.AddDays(-3);} }
        public DateTime FöstudagurinnLangi { get { return Páskadagur.AddDays(-2);} }
        public DateTime AnnarÍPáskum { get { return Páskadagur.AddDays(1);} }
        public DateTime Hvítasunnudagur { get { return Páskadagur.AddDays(49);} }
        public DateTime AnnarÍHvítasunnu { get { return Páskadagur.AddDays(50);} }

        public DateTime Jónsmessa => new DateTime(Year, 6, 24);

        public DateTime Verkalýðsdagurinn => new DateTime(Year, 5, 1);
        public DateTime Lýðveldisdagurinn => new DateTime(Year, 6, 17);
        public DateTime Fullveldisdagurinn => new DateTime(Year, 12, 1);

        public DateTime Þorláksmessa => Aðfangadagur.AddDays(-1);
        public DateTime Aðfangadagur => new DateTime(Year, 12, 24);
        public DateTime Jóladagur => Aðfangadagur.AddDays(1);
        public DateTime AnnarÍJólum => Aðfangadagur.AddDays(2);
        public DateTime Gamlársdagur => Aðfangadagur.AddDays(7);
        public DateTime Nýársdagur => new DateTime(Year, 1, 1);

        public DateTime FrídagurVerslunarmanna => FirstDayAfter(new DateTime(Year, 8, 1), DayOfWeek.Monday);

        public DateTime Vorjafndægur => Solstice.VernalEquinox(Year);
        public DateTime Haustjafndægur => Solstice.AutumnalEquinox(Year);
        public DateTime Sumarsólstöður => Solstice.SummerSolstice(Year);
        public DateTime Vetrarsólstöður => Solstice.WinterSolstice(Year);

        public DateTime SumardagurinnFyrsti => FirstDayAfter(new DateTime(Year, 4, 19), DayOfWeek.Thursday);
        // Er víst 28.10 í rímspillisárum, hvað sem það er
        public DateTime FyrstiVetrardagur => FirstDayAfter(new DateTime(Year, 10, 21), DayOfWeek.Saturday);

        private DateTime Lent => Páskadagur.AddDays(-46);
        public DateTime Bolludagur => Lent.AddDays(-2);
        public DateTime Sprengidagur => Lent.AddDays(-1);
        public DateTime Öskudagur => Lent;

        public DateTime Mæðradagurinn => Year >= 1934
            ? FirstDayAfter(FirstDayAfter(new DateTime(Year, 5, 1), DayOfWeek.Sunday).AddDays(1), DayOfWeek.Sunday)
            : DateTime.MinValue;
        public DateTime Feðradagurinn =>
            Year >= 2006
            ? FirstDayAfter(FirstDayAfter(new DateTime(Year, 11, 1), DayOfWeek.Sunday).AddDays(1), DayOfWeek.Sunday)
            : DateTime.MinValue;

        private void CalculateDates()
        {
            Páskadagur = Easter.CalculateForYear(Year);
        }

        private object _syncLock = new object();
        private SortedList<string, EventDate> _holidays;
        private SortedList<string, EventDate> _otherDays;

        private void Initialize()
        {
            lock (_syncLock)
            {
                if (_holidays == null)
                {
                    _holidays = new SortedList<string, EventDate>();

                    void Add(
                        DateTime date,
                        string name,
                        HolidayDates holidayDate,
                        HolidayTypes holidayType = HolidayTypes.Full)
                    {
                        _holidays.Add(date.ToString("yyyyMMdd") + name, new EventDate(date, name, holidayDate, holidayType));
                    }

                    Add(Nýársdagur, "Nýársdagur", HolidayDates.Nýársdagur);

                    Add(Skírdagur, "Skírdagur", HolidayDates.Skírdagur);
                    Add(FöstudagurinnLangi, "Föstudagurinn langi", HolidayDates.FöstudagurinnLangi);

                    Add(Páskadagur, "Páskadagur", HolidayDates.Páskadagur);
                    Add(AnnarÍPáskum, "Annar í páskum", HolidayDates.AnnarÍPáskum);

                    Add(SumardagurinnFyrsti, "Sumardagurinn fyrsti", HolidayDates.SumardagurinnFyrsti);

                    Add(Verkalýðsdagurinn, "Verkalýðsdagurinn", HolidayDates.Verkalýðsdagurinn);

                    Add(Uppstigningardagur, "Uppstigningardagur", HolidayDates.Uppstigningardagur);

                    Add(AnnarÍHvítasunnu, "Annar í hvítasunnu", HolidayDates.AnnarÍHvítasunnu);

                    Add(Lýðveldisdagurinn, "Lýðveldisdagurinn", HolidayDates.Lýðveldisdagurinn);

                    Add(Aðfangadagur, "Aðfangadagur", HolidayDates.Aðfangadagur, HolidayTypes.Half);
                    Add(Jóladagur, "Jóladagur", HolidayDates.Jóladagur);
                    Add(AnnarÍJólum, "Annar í jólum", HolidayDates.AnnarÍJólum);
                    Add(Gamlársdagur, "Gamlársdagur", HolidayDates.Gamlársdagur, HolidayTypes.Half);

                    Add(FrídagurVerslunarmanna, "Frídagur verslunarmanna", HolidayDates.FrídagurVerslunarmanna);

                    Add(FyrstiVetrardagur, "Fyrsti vetrardagur", HolidayDates.FyrstiVetrardagur);

                    // Other days
                    _otherDays = new SortedList<string, EventDate>();
                    void AddOther(DateTime date, string name, HolidayDates holidayDate)
                    {
                        _otherDays.Add(date.ToString("yyyyMMdd") + name, new EventDate(date, name, holidayDate, HolidayTypes.None));
                    }

                    AddOther(Pálmasunnudagur, "Pálmasunnudagur", HolidayDates.Pálmasunnudagur);
                    AddOther(Hvítasunnudagur, "Hvítasunnudagur", HolidayDates.Hvítasunnudagur);

                    AddOther(Bolludagur, "Bolludagur", HolidayDates.Bolludagur);
                    AddOther(Sprengidagur, "Sprengidagur", HolidayDates.Sprengidagur);
                    AddOther(Öskudagur, "Öskudagur", HolidayDates.Öskudagur);

                    AddOther(Mæðradagurinn, "Mæðradagurinn", HolidayDates.Mæðradagurinn);
                    AddOther(Feðradagurinn, "Feðradagurinn", HolidayDates.Feðradagurinn);

                    AddOther(Þorláksmessa, "Þorláksmessa", HolidayDates.Þorláksmessa);

                    AddOther(Fullveldisdagurinn, "Fullveldisdagurinn", HolidayDates.Fullveldisdagurinn);

                    AddOther(Vorjafndægur, "Vorjafndægur", HolidayDates.Vorjafndægur);
                    AddOther(Haustjafndægur, "Haustjafndægur", HolidayDates.Haustjafndægur);
                    AddOther(Sumarsólstöður, "Sumarsólstöður", HolidayDates.Sumarsólstöður);
                    AddOther(Vetrarsólstöður, "Vetrarsólstöður", HolidayDates.Vetrarsólstöður);
                }
            }
        }

        public IEnumerable<EventDate> AlmennirFrídagar
        {
            get
            {
                Initialize();
                return _holidays.Values;
            }
        }

        public IEnumerable<EventDate> AðrirDagar
        {
            get
            {
                Initialize();
                return _otherDays.Values;
            }
        }

        private DateTime FirstDayAfter(DateTime date, DayOfWeek dow)
        {
            while (date.DayOfWeek != dow)
            {
                date = date.AddDays(1);
            }
            return date;
        }
    }
}
