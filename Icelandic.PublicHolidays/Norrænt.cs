using Icelandic.PublicHolidays.Utils;
using System;

namespace Icelandic.PublicHolidays
{
    // http://www.almanak.hi.is/rim.html
    // https://vefir.nams.is/komdu/thjodhaetti/frodl_thjodhaetti/manudir_dagar.html
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

        // Lagfæringin er framkvæmd á þann hátt að einni viku (sumarauka) er skotið inn á eftir aukanóttum svo 
        // að miðsumar, og þar með næsta sumarkoma níu mánuðum (270 dögum) síðar, verður viku seinna en ella 
        // hefði orðið. Eftir núgildandi reglu (í gregoríanska tímatalinu eða nýja stíl) má sumardagurinn fyrsti 
        // ekki koma fyrr en 19. apríl. Sumaraukanum er því skotið inn í hvert sinn sem fyrirsjáanlegt er að 
        // sumardagurinn fyrsti myndi annars koma of snemma næsta ár (18. eða 17. apríl). Hægt er að sýna fram á 
        // að sumarauki hefst alltaf 22. júlí ef sá dagur er sunnudagur, en 23. júlí ef sá dagur er sunnudagur 
        // og hlaupár fer í hönd. 
        // ****
        // Sumaraukaár verða öll ár sem enda á mánudegi, svo og ár sem enda á sunnudegi ef 
        // hlaupár fer í hönd. Sumaraukinn verður ýmist á 5 eða 6 ára fresti, en örsjaldan á 7 ára fresti (það 
        // kemur fyrir einu sinni á hverjum 400 árum).
        // ****
        // Í prentuðum almanökum íslenskum fram til 1928 var sumarauka bætt aftan við síðasta sumarmánuð, en 
        // eftir það var horfið að þeim eldri reglum sem að ofan greinir.
        // Í gamla stíl(júlíanska tímatalinu) var sumarauka skotið inn þau ár sem enduðu á fimmtudegi, svo og 
        // þau ár sem enduðu á miðvikudegi, ef næsta ár var hlaupár.Með þessu móti var sumardagurinn fyrsti
        // aldrei fyrr en 9. apríl.
        public bool ErSumarauki =>
            (new DateTime(dagar.Ár, 12, 31).DayOfWeek == DayOfWeek.Monday)
            || (DateTime.IsLeapYear(dagar.Ár + 1)
                && new DateTime(dagar.Ár, 12, 31).DayOfWeek == DayOfWeek.Sunday);

        public bool ErSumaraukis =>
            (DateTime.IsLeapYear(dagar.Ár)
                ? new DateTime(dagar.Ár, 1, 1).DayOfWeek == DayOfWeek.Sunday
                : new DateTime(dagar.Ár - 1, 12, 31).DayOfWeek == DayOfWeek.Sunday)
            || dagar.ErRímspillisÁr;

        // TODO
        public DateTime Sumarauki => DateUtils.FirstDateAfterWeeks(
            dagar.FyrraÁr.AðrirViðburðardagar.FyrstiVetrardagur,
            13,
            DayOfWeek.Friday);

        // Þorri er nafnið á fjórða mánuði vetrar að gömlu íslensku misseratali. 
        // Hann hefst á föstudegi á bilinu 19.–26. janúar og lýkur á laugardegi 
        // áður en góa tekur við. Sá laugardagur er nefndur þorraþræll.
        // þorri hefst föstudag í 13. viku vetrar (19. – 26. janúar)
        public DateTime Þorri => DateUtils.FirstDateAfterWeeks(
            dagar.FyrraÁr.AðrirViðburðardagar.FyrstiVetrardagur,
            12,
            DayOfWeek.Friday);

        // Góan er fimmti og næstsíðasti mánuður vetrar eftir gömlu íslensku tímatali.
        // Hún tekur við af þorranum.Hún hefst á sunnudegi á bilinu 18.- 24.febrúar og 
        // stendur þar til einmánuður tekur við.
        // góa hefst sunnudag í 18. viku vetrar (18. – 25. febrúar)
        public DateTime Góa => DateUtils.FirstDateAfterWeeks(
            dagar.FyrraÁr.AðrirViðburðardagar.FyrstiVetrardagur,
            17,
            DayOfWeek.Sunday);

        // Einmánuður er síðasti mánuður vetrar og tekur við af góu. Hann hefst á þriðjudegi
        // á bilinu 20.–26. mars og stendur þar til harpa tekur við
        public DateTime Einmánuður => DateUtils.FirstDateAfterWeeks(
            dagar.FyrraÁr.AðrirViðburðardagar.FyrstiVetrardagur,
            21,
            DayOfWeek.Tuesday);

        // harpa hefst sumardaginn fyrsta, fimmtudag í 1. viku sumars (19. – 25. apríl)
        public DateTime Harpa => dagar.AlmennirFrídagar.SumardagurinnFyrsti;

        // Skerpla er nafn á öðrum mánuði í sumri. Hún tekur við af hörpu og hefst 
        // laugardaginn í 5.viku sumars, milli 19. og 25.maí.
        public DateTime Skerpla => DateUtils.FirstDateAfterWeeks(
            dagar.AlmennirFrídagar.SumardagurinnFyrsti,
            4,
            DayOfWeek.Saturday);

        // sólmánuður hefst mánudag í 9. viku sumars (18. – 24. júní)
        public DateTime Sólmánuður => DateUtils.FirstDateAfterWeeks(
            dagar.AlmennirFrídagar.SumardagurinnFyrsti,
            8,
            DayOfWeek.Monday);

        // heyannir, fjórði mánuður sumars að forníslensku tímatali.
        // Hefst á sunnudegi 23.-29. júlí, nema í rímspillisárum: 30. júlí
        public DateTime Heyannir =>
            dagar.ErRímspillisÁr
            ? new DateTime(dagar.Ár, 7, 30)
            : DateUtils.FirstDayAfter(
                new DateTime(dagar.Ár, 7, 23),
                DayOfWeek.Sunday);

        // tvímánuður, fimmti mánuður sumars eftir íslensku tímatali.
        // Hefst með þriðjudeginum í 18. viku sumars, en í 19. viku ef sumarauki er 
        // (þ.e. 22.-28. ágúst, nema í rímspillisárum: 29. ágúst). 
        public DateTime Tvímánuður => 
            dagar.ErRímspillisÁr
            ? new DateTime(dagar.Ár, 8, 29)
            : DateUtils.FirstDateAfterWeeks(
                dagar.AlmennirFrídagar.SumardagurinnFyrsti,
                ErSumarauki ? 18 : 17,
                DayOfWeek.Tuesday);

        // Haustmánuður hefst alltaf á fimmtudegi í 23. viku sumars, á bilinu 20. til 26. september 
        // en getur lent í 24. viku ef sumarauki er. Þá hefst hann á bilinu 21. september 
        // til 27. september. Undantekningin frá þessu er á rímspilsárum, þá 28. september
        public DateTime Haustmánuður =>
            dagar.ErRímspillisÁr
            ? new DateTime(dagar.Ár, 9, 28)
            : DateUtils.FirstDateAfterWeeks(
                dagar.AlmennirFrídagar.SumardagurinnFyrsti,
                ErSumarauki
                    ? 23
                    : 22,
                DayOfWeek.Thursday);

        // gormánuður hefst fyrsta vetrardag, laugardag í 1. viku vetrar (21. – 28. október)
        public DateTime Gormánuður => dagar.AðrirViðburðardagar.FyrstiVetrardagur;

        // Ýlir er annar mánuður vetrar að íslensku misseratali. Hann tekur því við af 
        // gormánuði og hefst á mánudegi í fimmtu viku vetrar á tímabilinu 20. nóvember 
        // til 26. nóvember (27. nóv í rímspillisárum) og nær til þess er mörsugur tekur 
        // við seint í desember
        public DateTime Ýlir =>
            dagar.ErRímspillisÁr
            ? new DateTime(dagar.Ár, 11, 27)
            : DateUtils.FirstDateAfterWeeks(
                dagar.AðrirViðburðardagar.FyrstiVetrardagur,
                4,
                DayOfWeek.Monday);

        // Mörsugur er þriðji mánuður vetrar samkvæmt gömlu misseratali. Hann hefst 
        // miðvikudaginn í níundu viku vetrar á tímabilinu 21.-27. desember. Honum líkur 
        // á miðnætti fimmtudaginn í þrettándu viku vetrar á tímabilinu 19.-26. janúar. 
        // Þá tekur þorrinn við
        // mörsugur hefst miðvikudag í 9. viku vetrar (20. – 27. desember)
        public DateTime Mörsugur => DateUtils.FirstDateAfterWeeks(
            dagar.AðrirViðburðardagar.FyrstiVetrardagur,
            8,
            DayOfWeek.Wednesday);
    }
}
