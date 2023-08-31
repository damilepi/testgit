using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNPN.Izjemne;

namespace TestNPN.Modeli
{
    internal class Razpis : IRazpis
    {
        public Razpis(List<Stanovanje> stanovanja, VečstanovanjskaStavba stavba, DateTime rokZaPrijavo)
        {
            Stanovanja = stanovanja;
            Stavba = stavba;
            RokZaPrijavo = rokZaPrijavo;
            Prijave = new List<Prijava>();
        }

        public List<Stanovanje> Stanovanja { get; private set; }
        public VečstanovanjskaStavba Stavba { get; set; }

        public DateTime RokZaPrijavo { get; set; }

        public List<Prijava> Prijave { get;private set; }
        public void DodajStanovanje(Stanovanje stanovanje)
        {
            Stanovanja.Add(stanovanje);
        }
        public void OdstraniStanovanje(Stanovanje stanovanje)
        {
            Stanovanja.Remove(stanovanje);
        }

        public void PrijavaNaRazpis(Prijava prijava)
        {
            Stanovanje? stanovanje = Stanovanja.Where(stan => stan.ID == prijava.Stanovanje.ID).FirstOrDefault();
            if(stanovanje == null)
            {
                throw new StanovanjeNeObstajaException("Ne obstaja stanovanje ");
            }
            Prijave.Add(prijava);
        }

        public void DodeliStanovanja()
        {
            var zanimanjePoStanovanjih = new Dictionary<string,List<Prijava>>();
            foreach(var prijava in Prijave)
            {
                Stanovanje? stanovanje = Stanovanja.Where(stanovanje => stanovanje.ID == prijava.Stanovanje.ID).FirstOrDefault();
                if(stanovanje is not null)
                {
                    if (zanimanjePoStanovanjih.ContainsKey(stanovanje.ID))
                    {
                        zanimanjePoStanovanjih[stanovanje.ID].Add(prijava);
                    }
                    else
                    {
                        zanimanjePoStanovanjih.Add(stanovanje.ID, new List<Prijava>() { prijava });
                    }
                    
                }
            }
            OvrednotiZanimanja(zanimanjePoStanovanjih);
            foreach (var zanimanje in zanimanjePoStanovanjih)
            {
                 Prijava prijava = zanimanje.Value.FirstOrDefault()!;
                 Stanovanje stanovanje = Stanovanja.Where(stan => stan.ID == zanimanje.Key).FirstOrDefault()!;
                 stanovanje.DodajČlane(prijava.Prijavitelji);
                 Stanovanja.Remove(stanovanje);
            }
        }
        private void OvrednotiZanimanja(Dictionary<string, List<Prijava>> zanimanja)
        {
            foreach(var zanimanje in zanimanja)
            {
                if(zanimanje.Value.Count > 1)
                {
                    float najboljšaPrijavaTočke = zanimanje.Value.Max(TočkujPrijavo);
                    Prijava najboljšePrijava = zanimanje.Value.Where(prijava => TočkujPrijavo(prijava) == najboljšaPrijavaTočke).FirstOrDefault()!;
                    zanimanje.Value.Clear();
                    zanimanje.Value.Add(najboljšePrijava);
                }
            }
        }
        private float TočkujPrijavo(Prijava prijava)
        {
            float točke = prijava.Prijavitelji.Count * 0.5f;
            foreach (var prijavitelj in prijava.Prijavitelji)
            {
                switch (prijavitelj)
                {
                    case VzdrževaniČlan vzdrževani:
                        if(vzdrževani.Tip == VzdrževaniČlan.TipČlana.dojenček || vzdrževani.Tip ==  VzdrževaniČlan.TipČlana.mladoletnik || vzdrževani.Tip == VzdrževaniČlan.TipČlana.otrok)
                        {
                            točke += 1;
                        }
                        else
                        {
                            točke += 0.5f;
                        }
                        break;
                    case SamostojniČlan samostojni: 
                        if(samostojni.LetniNetoDohodek < 12000)
                        {
                            točke += 0.5f;
                        }
                        break;
                    default:
                        break;
                }
            }
            return točke;
        }
    }
}
