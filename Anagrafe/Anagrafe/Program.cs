using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Anagrafe
{
    enum sesso
    {
        uomo,
        donna,
    }

    enum statoCivile
    {
        celibe,
        nubile,
        coniugato,
        vedovo,
        separato
    }

    struct persona
    {
        public string codFiscale;
        public string cognome;
        public string nome;
        public DateTime nascita;
        public statoCivile stato;
        public string cittadinanza;
        public sesso genere;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int scelta = 0, nPersone, pos = 0, r;
            string codFiscale = "";

            Console.Write("Quante persone vuoi registrare? ");
            nPersone = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            persona[] persone = new persona[nPersone];
            do
            {
                Console.WriteLine("========== ANAGRAFE ==========\n");
                Console.WriteLine("[1] <<  Inserimento\n\n[2] <<  Visualizza\n\n[3] <<  Età\n\n[4] <<  Modifica\n\n[5] <<  Elimina\n\n[6] <<  Exit");
                Console.WriteLine("\n==============================\n");

                Console.WriteLine("Inserisci la scelta: ");
                scelta = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (scelta)
                {
                    case 1:
                        r = Inserimento(persone, ref pos);

                        switch (r)
                        {
                            case 0:
                                Console.WriteLine("Inserimento completato");
                                break;

                            case 1:
                                Console.WriteLine("Persona già presente all'interno dell'anagrafe");
                                break;

                            case 2:
                                Console.WriteLine("Anagrafe al completo");
                                break;
                        }
                        break;

                    case 2:

                        if (pos != 0)
                        {
                            Visualizza(persone, pos);

                        }
                        else
                        {
                            Console.WriteLine("L'anagrafe è vuota");
                        }
                        break;

                    case 3:
                        if (pos != 0)
                        {
                            switch (MenuEta(persone))
                            {
                                case 1:

                                    EtaPersona(persone, codFiscale);
                                    break;

                                case 2:

                                    Archivio(persone, pos);
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("L'anagrafe è vuota");
                        }
                        break;

                    case 4:
                        if (pos != 0)
                        {
                            Modifica(persone, codFiscale);
                        }
                        else
                        {
                            Console.WriteLine("L'anagrafe è vuota");
                        }
                        break;

                    case 5:
                        if (pos != 0)
                        {
                            Cancella(persone, codFiscale, ref pos);
                        }
                        else
                        {
                            Console.WriteLine("L'anagrafe è vuota");
                        }
                        break;
                }
                if (scelta != 6)
                {
                    Console.WriteLine("Premi invio per tornare al menù principale");
                    Console.ReadLine();
                    Console.Clear();
                }

            } while (scelta != 6);
        }

        static int Inserimento(persona[] persone, ref int pos)
        {
            if (pos < persone.Length)
            {
                string codFiscale = "";

                Console.WriteLine("Inserisci il nome:");
                persone[pos].nome = Console.ReadLine();

                Console.WriteLine("\nInserisci il cognome:");
                persone[pos].cognome = Console.ReadLine();

                Console.WriteLine("\nInserisci la data di nascita (gg/mm/aaaa):");
                persone[pos].nascita = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("\nInserisci la cittadinanza:");
                persone[pos].cittadinanza = Console.ReadLine();

                Console.WriteLine("\nInserisci il codice fiscale:");
                codFiscale = Console.ReadLine();

                if (ControlloCodFiscale(codFiscale, persone))
                {
                    return 1;

                }
                else
                {
                    persone[pos].codFiscale = codFiscale;
                }

                switch (SceltaGenere(persone))
                {
                    case 1:
                        persone[pos].genere = sesso.uomo;
                        break;

                    case 2:
                        persone[pos].genere = sesso.donna;
                        break;
                }

                switch (SceltaStatoCivile(persone))
                {
                    case 1:
                        persone[pos].stato = statoCivile.celibe;
                        break;

                    case 2:
                        persone[pos].stato = statoCivile.nubile;
                        break;

                    case 3:
                        persone[pos].stato = statoCivile.coniugato;
                        break;

                    case 4:
                        persone[pos].stato = statoCivile.vedovo;
                        break;

                    case 5:
                        persone[pos].stato = statoCivile.separato;
                        break;
                }
            }
            else
            {
                return 2;
            }
            pos++;
            return 0;
        }

        static bool ControlloCodFiscale(string codFiscale, persona[] persone)
        {
            for (int i = 0; i < persone.Length; i++)
            {
                if (codFiscale == persone[i].codFiscale)
                {
                    return true;
                }
            }

            return false;
        }

        static int SceltaGenere(persona[] persone)
        {
            int scelta;
            string[] generi = Enum.GetNames(typeof(sesso));

            Console.WriteLine("\nInserisci il genere:\n");
            for (int i = 0; i < generi.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] <<  {generi[i]}");
            }

            scelta = Convert.ToInt32(Console.ReadLine());

            return scelta;
        }

        static int SceltaStatoCivile(persona[] persone)
        {
            int scelta;
            string[] stato = Enum.GetNames(typeof(statoCivile));

            Console.WriteLine("\nInserisci lo stato civile:\n");
            for (int i = 0; i < stato.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] <<  {stato[i]}");
            }

            scelta = Convert.ToInt32(Console.ReadLine());

            return scelta;
        }

        static void Visualizza(persona[] persone, int pos)
        {
            for (int i = 0; i < pos; i++)
            {
                Console.WriteLine($"========== {i + 1}° PERSONA ==========\n");
                Console.WriteLine($"Nome: {persone[i].nome}");
                Console.WriteLine($"Cognome: {persone[i].cognome}");
                Console.WriteLine($"Nascita: {persone[i].nascita}");
                Console.WriteLine($"Cittadinanza: {persone[i].cittadinanza}");
                Console.WriteLine($"Codice fiscale: {persone[i].codFiscale}");
                Console.WriteLine($"Genere: {persone[i].genere}");
                Console.WriteLine($"Stato civile: {persone[i].stato}");
                Console.WriteLine("================================\n\n");

            }
        }

        static void EtaPersona(persona[] persone, string codFiscale)
        {
            DateTime data = DateTime.Now;
            int eta = -1;

            Console.Write("Inserisci il codice fiscale della persona della quale vuoi sapere l'età: ");
            codFiscale = Console.ReadLine();

            foreach (var persona in persone)
            {
                if (persona.codFiscale == codFiscale)
                {
                    eta = Anni(persona.nascita, data);
                    Console.WriteLine($"\nNome: {persona.nome}\nCognome: {persona.cognome}\nEtà: {eta}\n");
                    break;
                }
            }

            if (eta == -1)
            {
                Console.WriteLine("\nNessuna persona trovata all'iterno dell'Anagrafe con questo codice fiscale\n");
            }
        }

        static int Anni(DateTime nascita, DateTime data)
        {
            int eta;

            eta = data.Year - nascita.Year;

            if (data < nascita.AddYears(eta))
            {
                eta--;
            }

            return eta;
        }

        static int MenuEta(persona[] persone)
        {
            int scelta;

            Console.WriteLine("Inserisci la scelta:\n");
            Console.WriteLine("[1] <<  persona");
            Console.WriteLine("[2] <<  archivio");

            scelta = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            return scelta;

        }

        static void Archivio(persona[] persone, int pos)
        {
            DateTime data = DateTime.Now;

            for (int i = 0; i < pos; i++)
            {
                Console.WriteLine($"========== {i + 1}° PERSONA ==========\n");
                Console.WriteLine($"Nome: {persone[i].nome}");
                Console.WriteLine($"Cognome: {persone[i].cognome}");
                Console.Write($"Età: ");
                Console.Write(Anni(persone[i].nascita, data));
                Console.WriteLine("\n================================\n\n");
            }
        }

        static void Modifica(persona[] persone, string codFiscale)
        {
            bool trovato = false;
            int pos = 0;

            Console.Write("Inserisci il codice fiscale della persona della quale vuoi modificare lo stato civile: ");
            codFiscale = Console.ReadLine();

            foreach (var persona in persone)
            {
                if (persona.codFiscale == codFiscale)
                {
                    trovato = true;
                    switch (SceltaStatoCivile(persone))
                    {
                        case 1:
                            persone[pos].stato = statoCivile.celibe;
                            break;

                        case 2:
                            persone[pos].stato = statoCivile.nubile;
                            break;

                        case 3:
                            persone[pos].stato = statoCivile.coniugato;
                            break;

                        case 4:
                            persone[pos].stato = statoCivile.vedovo;
                            break;

                        case 5:
                            persone[pos].stato = statoCivile.separato;
                            break;
                    }
                    break;
                }
                else
                {
                    pos++;
                }
            }
            if (!trovato)
            {
                Console.WriteLine("\nNessuna persona trovata all'interno dell'Anagrafe con questo codice fiscale");
            }
            else
            {
                Console.WriteLine("\nModifica completata");
            }
        }

        static void Cancella(persona[] persone, string codFiscale, ref int pos)
        {
            bool trovato = false;

            Console.Write("Inserisci il codice fiscale della persona della persona che vuoi rimuovere dall'archivio: ");
            codFiscale = Console.ReadLine();

            for (int i = 0; i < persone.Length; i++)
            {
                if (persone[i].codFiscale == codFiscale)
                {
                    trovato = true;

                    if (i == persone.Length - 1)
                    {
                        persone[pos - 1] = new persona();
                        pos--;
                        break;
                    }
                    else
                    {
                        for (int j = i; j < persone.Length - 1; j++)
                        {
                            persone[j] = persone[j + 1];
                        }
                        persone[pos - 1] = new persona();
                        pos--;
                        break;
                    }
                }
            }
            if (!trovato)
            {
                Console.WriteLine("\nNessuna persona trovata all'interno dell'Anagrafe con questo codice fiscale");
            }
            else
            {
                Console.WriteLine("\nCancellazione completata");
            }
        }
    }
}

