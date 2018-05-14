using Icelandic.PublicHolidaysEnums;
using System;

namespace Icelandic.PublicHolidays
{
    public class Viðburðardagur
    {
        public DateTime Dagsetning { get; }
        public string Nafn { get; }
        public Dagarnir Dagur { get; }
        public Frídagur Frídagur { get; }

        public Viðburðardagur(DateTime dagsetning, string nafn, Dagarnir dagur, Frídagur frídagur)
        {
            Dagsetning = dagsetning;
            Nafn = nafn;
            Dagur = dagur;
            Frídagur = frídagur;
        }
    }
}
