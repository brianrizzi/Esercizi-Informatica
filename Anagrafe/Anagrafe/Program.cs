using System;
using System.Collections.Generic;
using System.IO;
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
            const int NPERSONE = 4;
            int scelta = 0, pos = 0, r;
            string codFiscale = "", directory = Environment.CurrentDirectory + "\\log";
            string[] opzioni = { "Inserimento", "Visualizza", "Età", "Modifica", "Elimina", "Leggi log", "Exit" }, opzioni2 = { "Persona", "Archivio" };
            persona[] persone = new persona[NPERSONE];

            do
            {
                scelta = Menu(opzioni, "ANAGRAFE");
                Console.Clear();

                switch (scelta)
                {
                    case 0:

                        if (pos < persone.Length)
                        {
                            r = Inserimento(persone, ref pos);

                            switch (r)
                            {
                                case 0:
                                    Console.WriteLine("Inserimento completato");
                                    ScriviFile(directory, "Inserimento completato");
                                    break;

                                case 1:
                                    Console.WriteLine("Persona già presente all'interno dell'anagrafe");
                                    break;
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Anagrafe al completo");
                        }
                        break;

                    case 1:
                        if (pos != 0)
                        {
                            Visualizza(persone, pos);
                        }
                        else
                        {
                            Console.WriteLine("L'anagrafe è vuota");
                        }
                        break;

                    case 2:
                        if (pos != 0)
                        {
                            scelta = (Menu(opzioni2, "  ETA'  "));
                            Console.Clear();

                            switch (scelta)
                            {
                                case 0:
                                    Console.Write("Inserisci il codice fiscale della persona della quale vuoi sapere l'età: ");
                                    codFiscale = Console.ReadLine();

                                    if (CheckCF(persone, ref pos, codFiscale))
                                    {
                                        for (int i = 0; i < pos; i++)
                                        {
                                            if (persone[i].codFiscale == codFiscale)
                                            {
                                                Console.WriteLine($"\nNome: {persone[i].nome}\nCognome: {persone[i].cognome}\nEtà: {Anni(persone[i].nascita)}\n");
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Non è stato trovato nessuno con questo codice fiscale");
                                    }
                                    break;

                                case 1:
                                    for (int i = 0; i < pos; i++)
                                    {
                                        Console.WriteLine($"Nome: {persone[i].nome}\nCognome: {persone[i].cognome}\nEtà: {Anni(persone[i].nascita)}\n\n");
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("L'anagrafe è vuota");
                        }
                        break;

                    case 3:
                        if (pos != 0)
                        {
                            Console.Write("Inserisci il codice fiscale della persona della quale vuoi modificare lo stato civile: ");
                            codFiscale = Console.ReadLine();
                            Console.WriteLine();

                            if (CheckCF(persone, ref pos, codFiscale))
                            {
                                Modifica(persone, codFiscale, ref pos);
                                Console.WriteLine("\nModifica completata");
                            }
                            else
                            {
                                Console.WriteLine("Non è stato trovato nessuno con questo codice fiscale");
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
                            Console.Write("Inserisci il codice fiscale della persona che vuoi eliminare dall'anagrafe: ");
                            codFiscale = Console.ReadLine();

                            if (CheckCF(persone, ref pos, codFiscale))
                            {
                                Cancella(persone, codFiscale, ref pos);
                                Console.WriteLine("\nCancellazione completata");
                            }
                            else
                            {
                                Console.WriteLine("Non è stato trovato nessuno con questo codice fiscale");
                            }
                        }
                        else
                        {
                            Console.WriteLine("L'anagrafe è vuota");
                        }
                        break;

                    case 5:
                        if (Directory.GetFiles(directory).Length != 0)
                        {
                            LeggiFile(SceltaFile(directory));
                        }
                        else
                        {
                            Console.WriteLine("Non sono presenti file");
                        }
                        break;
                }
                if (scelta != opzioni.Length - 1)
                {
                    Console.WriteLine("Premi invio per tornare al menù principale");
                    Console.ReadLine();
                    Console.Clear();
                }

            } while (scelta != opzioni.Length - 1);
        }

        static int Menu(string[] opzioni, string titolo)
        {
            int scelta;
            Console.WriteLine($"========== {titolo} ==========\n");

            for (int i = 0; i < opzioni.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] <<  {opzioni[i]}\n");
            }

            Console.WriteLine("==============================\n");

            Console.WriteLine("Inserisci la scelta: ");
            scelta = Convert.ToInt32(Console.ReadLine());

            return scelta - 1;
        }

        static int Inserimento(persona[] persone, ref int pos)
        {
            Console.WriteLine("Inserisci il nome:");
            persone[pos].nome = Console.ReadLine();

            Console.WriteLine("\nInserisci il cognome:");
            persone[pos].cognome = Console.ReadLine();

            Console.WriteLine("\nInserisci la data di nascita (gg/mm/aaaa):");
            persone[pos].nascita = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("\nInserisci il codice fiscale:");
            string codFiscale = Console.ReadLine();

            if (CheckCF(persone, ref pos, codFiscale))
            {
                return 1;
            }
            persone[pos].codFiscale = codFiscale;

            Console.WriteLine("\nInserisci la cittadinanza:");
            persone[pos].cittadinanza = Console.ReadLine();

            Console.WriteLine("\nInserisci il genere:");
            persone[pos].genere = SceltaGenere(persone, ref pos);

            Console.WriteLine("\nInserisci lo stato civile:");
            persone[pos].stato = SceltaStatoCivile(persone, ref pos);

            pos++;
            return 0;
        }

        static bool CheckCF(persona[] persone, ref int pos, string codFiscale)
        {
            for (int i = 0; i < pos; i++)
            {
                if (codFiscale == persone[i].codFiscale)
                {
                    return true;
                }
            }
            return false;
        }

        static sesso SceltaGenere(persona[] persone, ref int pos)
        {
            string[] generi = Enum.GetNames(typeof(sesso));

            for (int i = 0; i < generi.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] <<  {generi[i]}");
            }
            int scelta = Convert.ToInt32(Console.ReadLine());

            switch (scelta)
            {
                case 0:
                    persone[pos].genere = sesso.uomo;
                    break;

                case 1:
                    persone[pos].genere = sesso.donna;
                    break;
            }
            return persone[pos].genere;
        }

        static statoCivile SceltaStatoCivile(persona[] persone, ref int pos)
        {
            string[] stato = Enum.GetNames(typeof(statoCivile));

            for (int i = 0; i < stato.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] <<  {stato[i]}");
            }
            int scelta = Convert.ToInt32(Console.ReadLine());

            switch (scelta)
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
            return persone[pos].stato;
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

        static int Anni(DateTime nascita)
        {
            int eta;
            DateTime data = DateTime.Now;

            eta = data.Year - nascita.Year;

            if (data < nascita.AddYears(eta))
            {
                eta--;
            }
            return eta;
        }

        static statoCivile Modifica(persona[] persone, string codFiscale, ref int pos)
        {
            int p = 0;

            for (int i = 0; i < pos; i++)
            {
                if (persone[i].codFiscale == codFiscale)
                {
                    p = i;
                }
            }
            return SceltaStatoCivile(persone, ref p);
        }

        static void Cancella(persona[] persone, string codFiscale, ref int pos)
        {
            for (int i = 0; i < pos; i++)
            {
                if (persone[i].codFiscale == codFiscale)
                {
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
        }

        static void ScriviFile(string path, string stringa)
        {
            path += "\\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt";

            StreamWriter sw = File.AppendText(path);
            sw.WriteLine(DateTime.Now.ToString() + " " + stringa);
            sw.Close();
        }

        static void LeggiFile(string path)
        {
            StreamReader sr = File.OpenText(path);
            string linea;
            linea = sr.ReadLine();
            while (linea != null)
            {
                Console.WriteLine(linea);
                linea = sr.ReadLine();
            }
            sr.Close();
        }

        static string SceltaFile(string path)
        {
            string[] file = Directory.GetFiles(path);
            string[] nomi = new string[file.Length];

            for (int i = 0; i < file.Length; i++)
            {
                nomi[i] = Path.GetFileName(file[i]);
            }
            return file[Menu(nomi, "  FILE  ")];
        }
    }
}

