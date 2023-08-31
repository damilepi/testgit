using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNPN.Izjemne
{
    internal class StanovanjeNeObstajaException : Exception
    {
        public StanovanjeNeObstajaException(string message) : base(message)
        {
            
        }
    }
}
