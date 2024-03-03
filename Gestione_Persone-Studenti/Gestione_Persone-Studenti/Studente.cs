using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestione_Persone_Studenti
{
    internal class Studente : Persona
    {
        int _matricola;
        Random r = new Random();

        public Studente(string nome, string cognome, string anni) : base(nome, cognome, anni)
        {
            _matricola = r.Next(1, 1000);
        }
        public Studente(): this("", "", "")
        {
        }
        public int Matricola
        {
            get => _matricola; private set => _matricola = value;
        }
        new public string Stampa()
        {
            return ($"{base.Stampa()}, MATRICOLA: {Matricola}");
        }
    }
}
