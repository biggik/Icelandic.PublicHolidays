using Icelandic.PublicHolidays.Utils;
using System;

namespace Icelandic.PublicHolidays
{
    public class Norrænt
    {
        readonly Dagar dagar;

        public Norrænt(Dagar gen)
        {
            this.dagar = gen;
        }

        // Sumarauki verður þegar aðfarardagur ársins(í hlaupári: seinni aðfarardagurinn) er sunnudagur, 
        // svo og þegar hann er laugardagur og hlaupár fer í hönd, en þá er rímspillir.
        // Sumaraukaár eru ýmist á 5 eða 6 ára fresti, en örsjaldan á 7 ára fresti 
        // (það kemur fyrir einu sinni á hverjum 400 árum).
        public bool ErSumarauki =>
            (DateTime.IsLeapYear(dagar.Ár)
                ? new DateTime(dagar.Ár, 1, 1).DayOfWeek == DayOfWeek.Sunday
                : new DateTime(dagar.Ár - 1, 12, 31).DayOfWeek == DayOfWeek.Sunday)
            || dagar.ErRímspillisÁr;

        private DateTime AddWeeks(DateTime dt, int weeks, DayOfWeek dow) => 
            DateUtils.FirstDayAfter(dt.AddDays(7 * weeks), dow);

        // Þorri er nafnið á fjórða mánuði vetrar að gömlu íslensku misseratali. 
        // Hann hefst á föstudegi á bilinu 19.–26. janúar og lýkur á laugardegi 
        // áður en góa tekur við. Sá laugardagur er nefndur þorraþræll.
        // þorri hefst föstudag í 13. viku vetrar (19. – 26. janúar)
        public DateTime Þorri => AddWeeks(dagar.FyrraÁr.AðrirViðburðardagar.FyrstiVetrardagur, 12, DayOfWeek.Friday);

        // Góan er fimmti og næstsíðasti mánuður vetrar eftir gömlu íslensku tímatali.
        // Hún tekur við af þorranum.Hún hefst á sunnudegi á bilinu 18.- 24.febrúar og 
        // stendur þar til einmánuður tekur við.
        // góa hefst sunnudag í 18. viku vetrar (18. – 25. febrúar)
        public DateTime Góa => AddWeeks(dagar.FyrraÁr.AðrirViðburðardagar.FyrstiVetrardagur, 17, DayOfWeek.Sunday);

        // Einmánuður er síðasti mánuður vetrar og tekur við af góu. Hann hefst á þriðjudegi
        // á bilinu 20.–26. mars og stendur þar til harpa tekur við
        public DateTime Einmánuður => AddWeeks(dagar.FyrraÁr.AðrirViðburðardagar.FyrstiVetrardagur, 18, DayOfWeek.Tuesday);

        // harpa hefst sumardaginn fyrsta, fimmtudag í 1. viku sumars (19. – 25. apríl)
        public DateTime Harpa => dagar.AlmennirFrídagar.SumardagurinnFyrsti;

        // Skerpla er nafn á öðrum mánuði í sumri. Hún tekur við af hörpu og hefst 
        // laugardaginn í 5.viku sumars, milli 19.og 25.maí.
        public DateTime Skerpla => AddWeeks(dagar.FyrraÁr.AlmennirFrídagar.SumardagurinnFyrsti, 14, DayOfWeek.Saturday);

        // sólmánuður hefst mánudag í 9. viku sumars (18. – 24. júní)
        public DateTime Sólmánuður => AddWeeks(dagar.FyrraÁr.AlmennirFrídagar.SumardagurinnFyrsti, 8, DayOfWeek.Monday);

        // TODO
        public DateTime Sumarauki => AddWeeks(dagar.FyrraÁr.AðrirViðburðardagar.FyrstiVetrardagur, 13, DayOfWeek.Friday);

        // heyannir hefjast á sunnudegi 23. – 30. júlí
        public DateTime Heyannir => AddWeeks(dagar.FyrraÁr.AlmennirFrídagar.SumardagurinnFyrsti, 13, DayOfWeek.Sunday);

        // tvímánuður hefst þriðjudag í 18. viku sumars (22. – 29. ágúst)
        public DateTime Tvímánuður => AddWeeks(dagar.FyrraÁr.AlmennirFrídagar.SumardagurinnFyrsti, 17, DayOfWeek.Tuesday);

        // Haustmánuður hefst alltaf á fimmtudegi í 23. viku sumars, á bilinu 20. til 26. september 
        // en getur lent í 24. viku ef sumarauki er. Þá hefst hann á bilinu 21. september 
        // til 27. september. Undantekningin frá þessu er á rímspilsárum, þá 28. september
        public DateTime Haustmánuður =>
            dagar.ErRímspillisÁr
            ? new DateTime(dagar.Ár, 9, 28)
            : AddWeeks(dagar.AlmennirFrídagar.SumardagurinnFyrsti, ErSumarauki ? 23 : 22, DayOfWeek.Thursday);

        // gormánuður hefst fyrsta vetrardag, laugardag í 1. viku vetrar (21. – 28. október)
        public DateTime Gormánuður => dagar.AðrirViðburðardagar.FyrstiVetrardagur;

        // Ýlir er annar mánuður vetrar að íslensku misseratali. Hann tekur því við af 
        // gormánuði og hefst á mánudegi í fimmtu viku vetrar á tímabilinu 20. nóvember 
        // til 27. nóvember og nær til þess er mörsugur tekur við seint í desember
        public DateTime Ýlir => AddWeeks(dagar.FyrraÁr.AðrirViðburðardagar.FyrstiVetrardagur, 4, DayOfWeek.Monday);

        // Mörsugur er þriðji mánuður vetrar samkvæmt gömlu misseratali. Hann hefst 
        // miðvikudaginn í níundu viku vetrar á tímabilinu 21.-27. desember. Honum líkur 
        // á miðnætti fimmtudaginn í þrettándu viku vetrar á tímabilinu 19.-26. janúar. 
        // Þá tekur þorrinn við
        // mörsugur hefst miðvikudag í 9. viku vetrar (20. – 27. desember)
        public DateTime Mörsugur => AddWeeks(dagar.FyrraÁr.AðrirViðburðardagar.FyrstiVetrardagur, 8, DayOfWeek.Wednesday);
    }
}
