using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_NorderneyFaehre.Model
{
    internal class Faehrfahrt
    {
        public Verbindung Verbindung { get; }
        public DateOnly Datum { get; }
        public TimeOnly Zeit { get; }
        public double Auslastung { get; set; }

        

        public Faehrfahrt(Verbindung verbindung, DateOnly datum, TimeOnly zeit, double auslastung)
        {
            Verbindung = verbindung;
            Datum = datum;
            Zeit = zeit;
            Auslastung = auslastung;
        }

        
    }
}
