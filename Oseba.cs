using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNPN.Modeli
{
    internal abstract class Oseba
    {
        public Oseba(string ime, string priimek, int davčnaŠtevilka)
        {
            Ime = ime;
            Priimek = priimek;
            DavčnaŠtevilka = davčnaŠtevilka;
        }

        public string Ime { get; set; }
        public string Priimek { get; set; }
        public int DavčnaŠtevilka { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Ime: " + Ime);
            sb.AppendLine("Priimek: " + Priimek);
            sb.AppendLine("Davčna številka: " + DavčnaŠtevilka);
            return sb.ToString();
        }
    }
}
