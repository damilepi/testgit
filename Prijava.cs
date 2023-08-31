using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNPN.Modeli
{
    internal class Prijava
    {
        public Prijava(Stanovanje stanovanje, List<Oseba> prijavitelji)
        {
            Stanovanje = stanovanje;
            Prijavitelji = prijavitelji;
        }

        public Stanovanje Stanovanje { get; set; }
        public List<Oseba> Prijavitelji { get;private set; }
        public void DodajPrijavitelja(Oseba prijavitelj)
        {
            Prijavitelji.Add(prijavitelj);
        }
        public void OdstraniPrijavitelja(Oseba prijavitelj)
        {
            Prijavitelji.Remove(prijavitelj);
        }
    }
}
