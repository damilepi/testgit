using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNPN.Modeli
{
    internal interface IRazpis
    {
        public void PrijavaNaRazpis(Prijava prijava);
        public void DodeliStanovanja();
    }
}
