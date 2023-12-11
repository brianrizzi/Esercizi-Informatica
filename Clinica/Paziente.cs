using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clinica
{
    internal class Paziente
    {
        string _nome, _cognome;
        double _tempCorporea;

        public Paziente(string nome, string cognome, double tempCorporea)
        {
            _nome = nome;
            _cognome = cognome;
            _tempCorporea = tempCorporea;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} (°C)", _nome, _cognome, _tempCorporea);
        }

        public void SetNome(string nome)
        {
            _nome = nome;
        }
        public void SetCognome(string cognome)
        {
            _cognome = cognome;
        }
        public void SetTempCorporea(double tempCorporea)
        {
            _tempCorporea = tempCorporea;
        }
        public string GetNome()
        {
            return _nome;
        }
        public string GetCognome()
        {
            return _cognome;
        }
        public double GetTempCorporea()
        {
            return _tempCorporea;
        }

    }
}
