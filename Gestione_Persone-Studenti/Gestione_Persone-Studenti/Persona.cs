using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestione_Persone_Studenti
{
    internal class Persona
    {
        protected string _nome, _cognome, _anni;

        public Persona(string nome, string cognome, string anni)
        {
            _nome = nome;
            _cognome = cognome;;
            _anni = anni;
        }
        public Persona(): this("", "", "") 
        {
        }
        public string Nome
        {
            get => _nome; private set => _nome = value;
        }
        public string Cognome
        {
            get => _cognome; private set => _cognome = value;
        }
        public string Anni
        {
            get => _anni; private set => _anni = value;
        }
        public string Stampa()
        {
            return ($"NOME: {Nome}, COGNOME: {Cognome}, ANNI: {Anni}");
        }

    }
}
