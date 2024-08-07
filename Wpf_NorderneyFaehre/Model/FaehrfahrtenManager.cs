using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_NorderneyFaehre.Model
{
    internal class FaehrfahrtenManager
    {
        public List<Verbindung> NorderneyFaehren { get; }

        public FaehrfahrtenManager()
        {
            NorderneyFaehren = new List<Verbindung>();
            AktuelleFaehrverbindungen();
        }

        public List<Faehrfahrt> Faehrfahrten (Verbindung verbindung, DateTime datum)
        {
            if (datum < DateTime.Today)
            {
                return new List<Faehrfahrt>();
            }

            return LadeFaehrfahrten(verbindung, datum);
        }

        private List<Faehrfahrt> LadeFaehrfahrten(Verbindung verbindung, DateTime datum)
        {
            List<Faehrfahrt> faehrfahrten = new List<Faehrfahrt>();

            TimeOnly startZeit = new TimeOnly(8, 45);
            if (verbindung.Starthafen == "Norddeich")
                startZeit = new TimeOnly(7,15);

            while (datum == DateTime.Today && startZeit < TimeOnly.FromDateTime(DateTime.Now))
                startZeit = startZeit.AddHours(3);

            
            while (startZeit < new TimeOnly(21,30))
            {   
                faehrfahrten.Add(new Faehrfahrt(verbindung, DateOnly.FromDateTime(datum), startZeit, Random.Shared.Next(3,11) * 0.1));
                startZeit = startZeit.Add(new TimeSpan(3, 0, 0));
            }


            return faehrfahrten;

        }

        private void AktuelleFaehrverbindungen()
        {
            NorderneyFaehren.Add(new Verbindung(Verbindung.Faehrtyp.Autofaehre, "Norddeich", "Norderney"));
            NorderneyFaehren.Add(new Verbindung(Verbindung.Faehrtyp.Autofaehre, "Norderney", "Norddeich"));
        }
    }
}
