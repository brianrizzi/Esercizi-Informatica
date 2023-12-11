using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica
{
    internal class Reparto
    {
        string _nomeReparto;
        List<Paziente> _pazienti;
        Termometro termometro;
        int _cont;

        public Reparto()
        {
            _pazienti = new List<Paziente>();
            termometro = new Termometro();
            _cont = 0;

        }
        public Reparto(string nomeReparto)
        {
            _pazienti = new List<Paziente>();
            termometro = new Termometro();
            _nomeReparto = nomeReparto;
            _cont = 0;
        }

        public string GetNomeReparto(string nomeReparto)
        {
            return nomeReparto;
        }
        public void AddPaziente(Paziente p)
        {
            _pazienti.Add(p);
        }
        public void StampaPazienti()
        {
            Console.WriteLine("{0,-20} {1,-20} {2}", "NOME", "COGNOME", "TEMPERATURA (°C)\n");
            _pazienti.ForEach(p => Console.WriteLine("{0,-20} {1,-20} {2}", p.GetNome(), p.GetCognome(), p.GetTempCorporea()));
        }
        public string[] ArrPazienti()
        {
            string[] arr = new string[_pazienti.Count];

            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = _pazienti[i].ToString();
            }

            return arr;
        }
        public int NumPazienti()
        {
            return _pazienti.Count;
        }
        public void CambiaTemp(double temperatura, int indicePaziente)
        {
            _pazienti[indicePaziente].SetTempCorporea(temperatura);
        }
        public void Next()
        {
            if (_cont < NumPazienti() - 1)
            {
                _cont++;
            }  
        }
        public void Previews()
        {
            if (_cont > 0)
            {
                _cont--;
            }
        }
        public void Reset()
        {
            _cont = 0;
        }
        public Paziente PazienteCorrente()
        {
            return new Paziente(_pazienti[_cont].GetNome(), _pazienti[_cont].GetCognome(), _pazienti[_cont].GetTempCorporea());
        }
    }
}
