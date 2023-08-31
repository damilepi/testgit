using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNPN.Modeli
{
    internal class VečstanovanjskaStavba
    {

        public VečstanovanjskaStavba(Dictionary<string, Stanovanje> stanovanja)
        {
            Stanovanja = stanovanja;
        }
        public string Naslov { get; set; }
        public int PoštnaŠtevilka { get; set; }
        public Dictionary<string,Stanovanje> Stanovanja { get;private set; }
        public void DodajStanovanje(Stanovanje stanovanje)
        {
            if(Stanovanja.ContainsKey(stanovanje.ID))
                throw new Exception("Stanovanje s tem ID-jem že obstaja");
            Stanovanja.Add(stanovanje.ID, stanovanje);
        }
        public void OdstraniStanovanje(Stanovanje stanovanje)
        {
            Stanovanja.Remove(stanovanje.ID);
        }
        public string ID { get; set; }
    }
}
