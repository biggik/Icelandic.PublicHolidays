using System;

namespace Icelandic.PublicHolidays.Nordic
{
    public class Norrænt
    {
        readonly Generator gen;

        public Norrænt(Generator gen)
        {
            this.gen = gen;
        }

        private DateTime AddWeeks(DateTime dt, int weeks, DayOfWeek dow) => 
            DateUtils.FirstDayAfter(dt.AddDays(7 * weeks), dow);

        // Þorri er nafnið á fjórða mánuði vetrar að gömlu íslensku misseratali. 
        // Hann hefst á föstudegi á bilinu 19.–26. janúar og lýkur á laugardegi 
        // áður en góa tekur við. Sá laugardagur er nefndur þorraþræll.
        // þorri hefst föstudag í 13. viku vetrar (19. – 26. janúar)
        public DateTime Þorri => AddWeeks(gen.PreviousYear.FyrstiVetrardagur, 12, DayOfWeek.Friday);

        // Góan er fimmti og næstsíðasti mánuður vetrar eftir gömlu íslensku tímatali.
        // Hún tekur við af þorranum.Hún hefst á sunnudegi á bilinu 18.- 24.febrúar og 
        // stendur þar til einmánuður tekur við.
        // góa hefst sunnudag í 18. viku vetrar (18. – 25. febrúar)
        public DateTime Góa => AddWeeks(gen.PreviousYear.FyrstiVetrardagur, 17, DayOfWeek.Sunday);

        // Einmánuður er síðasti mánuður vetrar og tekur við af góu. Hann hefst á þriðjudegi
        // á bilinu 20.–26. mars og stendur þar til harpa tekur við
        public DateTime Einmánuður => AddWeeks(gen.PreviousYear.FyrstiVetrardagur, 18, DayOfWeek.Tuesday);

        // harpa hefst sumardaginn fyrsta, fimmtudag í 1. viku sumars (19. – 25. apríl)
        public DateTime Harpa => gen.SumardagurinnFyrsti;

        // Skerpla er nafn á öðrum mánuði í sumri. Hún tekur við af hörpu og hefst 
        // laugardaginn í 5.viku sumars, milli 19.og 25.maí.
        public DateTime Skerpla => AddWeeks(gen.PreviousYear.SumardagurinnFyrsti, 14, DayOfWeek.Saturday);

        // sólmánuður hefst mánudag í 9. viku sumars (18. – 24. júní)
        public DateTime Sólmánuður => AddWeeks(gen.PreviousYear.SumardagurinnFyrsti, 8, DayOfWeek.Monday);

        // TODO
        public DateTime Sumarauki => AddWeeks(gen.PreviousYear.FyrstiVetrardagur, 13, DayOfWeek.Friday);

        // heyannir hefjast á sunnudegi 23. – 30. júlí
        public DateTime Heyannir => AddWeeks(gen.PreviousYear.SumardagurinnFyrsti, 13, DayOfWeek.Sunday);

        // tvímánuður hefst þriðjudag í 18. viku sumars (22. – 29. ágúst)
        public DateTime Tvímánuður => AddWeeks(gen.PreviousYear.SumardagurinnFyrsti, 17, DayOfWeek.Tuesday);

        // Haustmánuður hefst alltaf á fimmtudegi í 23. viku sumars, á bilinu 20. til 26. september 
        // en getur lent í 24. viku ef sumarauki er. Þá hefst hann á bilinu 21. september 
        // til 27. september. Undantekningin frá þessu er á rímspilsárum, þá 28. september
        public DateTime Haustmánuður =>
            gen.ErRímspillisÁr
            ? new DateTime(gen.Year, 9, 28)
            : AddWeeks(gen.SumardagurinnFyrsti, gen.ErSumarauki ? 23 : 22, DayOfWeek.Thursday);

        // gormánuður hefst fyrsta vetrardag, laugardag í 1. viku vetrar (21. – 28. október)
        public DateTime Gormánuður => gen.FyrstiVetrardagur;

        // Ýlir er annar mánuður vetrar að íslensku misseratali. Hann tekur því við af 
        // gormánuði og hefst á mánudegi í fimmtu viku vetrar á tímabilinu 20. nóvember 
        // til 27. nóvember og nær til þess er mörsugur tekur við seint í desember
        public DateTime Ýlir => AddWeeks(gen.PreviousYear.FyrstiVetrardagur, 4, DayOfWeek.Monday);

        // Mörsugur er þriðji mánuður vetrar samkvæmt gömlu misseratali. Hann hefst 
        // miðvikudaginn í níundu viku vetrar á tímabilinu 21.-27. desember. Honum líkur 
        // á miðnætti fimmtudaginn í þrettándu viku vetrar á tímabilinu 19.-26. janúar. 
        // Þá tekur þorrinn við
        // mörsugur hefst miðvikudag í 9. viku vetrar (20. – 27. desember)
        public DateTime Mörsugur => AddWeeks(gen.PreviousYear.FyrstiVetrardagur, 8, DayOfWeek.Wednesday);
    }
}
