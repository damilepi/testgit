using TestNPN;
using TestNPN.Logging;
using TestNPN.Modeli;

Logger logger = new Logger();
Oseba oseba = new SamostojniČlan("Jure", "Smolar",1888888,10000);
Oseba oseba2 = new SamostojniČlan("Janez", "Kruhar", 1024124122,12314);
Oseba oseba3 = new SamostojniČlan("Sagadin", "Merhaba", 000000001,10000000000000000000);
Oseba oseba4 = new SamostojniČlan("Pavelj", "NičDenarni",1000000 ,0);

Oseba vOseba =  new VzdrževaniČlan("Dojenček","GuguGaga",1000,VzdrževaniČlan.TipČlana.dojenček);
Oseba vOseba2 = new VzdrževaniČlan("MaliRudi", "Cmero", 1000, VzdrževaniČlan.TipČlana.dojenček);
Oseba voseba3 = new VzdrževaniČlan("Pavelj", "Edwardovski III", 10000000, VzdrževaniČlan.TipČlana.mladoletnik);
Oseba voseba4 = new VzdrževaniČlan("PadoSem", "Poštengah", 10000000, VzdrževaniČlan.TipČlana.ostalo);

Stanovanje stanovanje = new Stanovanje(100, 2, "AGH", new List<Oseba>() { oseba });
Stanovanje stanovanje2 = new Stanovanje(100, 2, "AGH134", new List<Oseba>() { oseba2,oseba4});
Stanovanje stanovanje3 = new Stanovanje(100, 2, "14f", new List<Oseba>() {});
Stanovanje stanovanje4 = new Stanovanje(100, 3, "71a", new List<Oseba>() {});
Stanovanje stanovanje5 = new Stanovanje(100, 2, "14f", new List<Oseba>() { });
Stanovanje stanovanje6 = new Stanovanje(100, 3, "71b", new List<Oseba>() { });

VečstanovanjskaStavba večstanovanjskaStavba = new VečstanovanjskaStavba(new Dictionary<string, Stanovanje> { { "AGH", stanovanje },{ "AGH134", stanovanje2 }, { "14f", stanovanje3 } })
{
    ID = "VH",
    Naslov = "Kozmonavska Ulica 11",
    PoštnaŠtevilka = 1000,
};
VečstanovanjskaStavba večstanovanjskaStavba2 = new VečstanovanjskaStavba(new Dictionary<string, Stanovanje> { { "71a", stanovanje4 }, { "14f", stanovanje5 }, { "71b", stanovanje6 } })
{
    ID = "VH2",
    Naslov = "Kozmonavska Ulica 11",
    PoštnaŠtevilka = 1000,
};
Prijava prijava = new Prijava(stanovanje3, new List<Oseba>() { oseba3, voseba3, voseba4 });
Prijava prijava2 = new Prijava(stanovanje3, new List<Oseba>() { oseba3, voseba3});
Prijava prijava3 = new Prijava(stanovanje5, new List<Oseba>() { oseba});

Prijava prijava4 = new Prijava(stanovanje6, new List<Oseba>() { oseba });

StanovanjskiSklad sklad = new StanovanjskiSklad(new Dictionary<string, VečstanovanjskaStavba>() { { "VH", večstanovanjskaStavba }, { "VH2", večstanovanjskaStavba } });
try
{
    sklad.DodajRazpis("VH", DateTime.Today.AddYears(1));
    sklad.Razpisi[0].PrijavaNaRazpis(prijava);
    sklad.Razpisi[0].PrijavaNaRazpis(prijava2);
    sklad.Razpisi[0].PrijavaNaRazpis(prijava4);

    sklad.Razpisi[0].DodeliStanovanja();
}
catch(Exception ex)
{
    logger.LogException(ex);
}