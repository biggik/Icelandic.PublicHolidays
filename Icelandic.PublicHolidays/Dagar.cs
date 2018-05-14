using Icelandic.PublicHolidays.Utils;
using Icelandic.PublicHolidaysEnums;
using System;
using System.Collections.Generic;

namespace Icelandic.PublicHolidays
{
    public class Dagar
    {
        public Dagar(int ár)
        {
            Ár = ár;

            páskadagur = new Lazy<DateTime>(() => Easter.CalculateForYear(Ár));
            fyrraÁr = new Lazy<Dagar>(() => new Dagar(Ár - 1));

            frídagar = new Lazy<AlmennirFrídagar>(() => new AlmennirFrídagar(this));
            aðrir = new Lazy<AðrirViðburðardagar>(() => new AðrirViðburðardagar(this));
        }

        readonly Lazy<Dagar> fyrraÁr;
        internal Dagar FyrraÁr => fyrraÁr.Value;
        
        public int Ár { get; }

        readonly Lazy<AðrirViðburðardagar> aðrir;
        public AðrirViðburðardagar AðrirViðburðardagar => aðrir.Value;

        readonly Lazy<AlmennirFrídagar> frídagar;
        public AlmennirFrídagar AlmennirFrídagar => frídagar.Value;

        internal readonly Lazy<DateTime> páskadagur;

        // Rímspillisár þekkist á því að aðfarardagur ársins er laugardagur og næsta ár á eftir er hlaupár
        public bool ErRímspillisÁr =>
            new DateTime(Ár - 1, 12, 31).DayOfWeek == DayOfWeek.Saturday
            && DateTime.IsLeapYear(Ár + 1);
    }
}
