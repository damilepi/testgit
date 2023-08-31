using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNPN.Modeli
{
    internal class SamostojniČlan :Oseba
    {
        public SamostojniČlan(string ime, string priimek, int davčnaŠtevilka, decimal letniDohodek) : base(ime, priimek, davčnaŠtevilka)
        {
            LetniNetoDohodek = letniDohodek;
        }

        public decimal LetniNetoDohodek { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine("Letni neto dohodek: " + LetniNetoDohodek);
            return sb.ToString();
        }
    }
}
