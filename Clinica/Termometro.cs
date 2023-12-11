using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica
{
    internal class Termometro
    {
        double _temperatura;

        public Termometro()
        {
            _temperatura = 36;
        }
        
        public double GetTemperatura()
        {
            return _temperatura;
        }
    }
}
