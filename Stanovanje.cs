using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNPN.Modeli
{
    internal class Stanovanje
    {
        public double Velikost { get; set; }
        public float ŠteviloSob { get; set; }
        public string ID { get; set; }
        public List<Oseba> Člani { get; private set; }


        public Stanovanje(double velikost, float številoSob, string iD, List<Oseba> člani)
        {
            Velikost = velikost;
            ŠteviloSob = številoSob;
            ID = iD;
            Člani = člani;
        }

        public void DodajČlan(Oseba član)
        {
            Člani.Add(član);
        }
        public void DodajČlane(List<Oseba> člani)
        {
            Člani.AddRange(člani);
        }
        public void OdstraniČlana(Oseba član)
        {
            Člani.Remove(član);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ID: " + ID);
            sb.AppendLine("Velikost: " + Velikost);
            sb.AppendLine("Število sob: " + ŠteviloSob);
            sb.AppendLine("Člani: ");
            foreach (var item in Člani)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
    }
}
