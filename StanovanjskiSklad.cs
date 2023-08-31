using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNPN.Izjemne;
using TestNPN.Modeli;

namespace TestNPN
{
    internal class StanovanjskiSklad
    {
        public StanovanjskiSklad(Dictionary<string, VečstanovanjskaStavba> stanovanja)
        {
            Stanovanja = stanovanja;
            Razpisi = new List<Razpis>();
        }

        public Dictionary<string,VečstanovanjskaStavba> Stanovanja { get; private set; }
        public List<Razpis> Razpisi { get; private set; }

        public void dodajStavbo(VečstanovanjskaStavba stavba)
        {
            if (Stanovanja.ContainsKey(stavba.ID))
                throw new StavbaNeObstajaException($"stavba:{stavba.ID} je polna.");
            Stanovanja.Add(stavba.ID, stavba);
        }
        public void DodajRazpis(string idStavbe, DateTime rokPrijave)
        {
            VečstanovanjskaStavba? stavba = Stanovanja.Where(stanovanje => stanovanje.Key == idStavbe).FirstOrDefault().Value;
            if (stavba == null)
                throw new ArgumentException($"Stavba {idStavbe} ne obstaja");
            List<Stanovanje> prostaStanovanja = stavba.Stanovanja.Values.Where(stanovanje => stanovanje.Člani.Count == 0).ToList();
            if(prostaStanovanja.Count == 0)
            {
                throw new StavbaPolnaException($"Stavba {idStavbe} nima prostih stanovanj");
            }
            Razpisi.Add(new Razpis(prostaStanovanja,stavba,rokPrijave));

        }
    }
}
