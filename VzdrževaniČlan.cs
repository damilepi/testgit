using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNPN.Modeli
{
    internal class VzdrževaniČlan :Oseba
    {
        

        public VzdrževaniČlan(string ime, string priimek, int davčnaŠtevilka, TipČlana tip) : base(ime, priimek, davčnaŠtevilka)
        {
            Tip = tip;
        }

        public enum TipČlana
        {
            dojenček,
            otrok,
            mladoletnik,
            ostalo
        }
        public TipČlana Tip { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Tip.ToString());
            sb.AppendLine(base.ToString());
            return base.ToString();
        }
    }
}
