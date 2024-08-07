using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_NorderneyFaehre
{
    internal class Verbindung
    {
        public enum Faehrtyp{
            Autofaehre,
            Personenfaehre
        }

        public Faehrtyp Typ { get; }
        public string Starthafen { get; }
        public string Zielhafen { get; }

        public Verbindung(Faehrtyp typ, string starthafen, string zielhafen)
        {
            Typ = typ;
            Starthafen = starthafen;
            Zielhafen = zielhafen;
        }

        public override string ToString()
        {
            return $"{Typ.ToString().Replace("ae","ä")}: {Starthafen} - {Zielhafen}";
        }


    }
}
