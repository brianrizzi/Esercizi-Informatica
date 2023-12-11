using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int scelta;
            string[] opzioni = { "Inserimento", "Visualizza", "Temperature", "Precedente", "Successivo", "Reset", "Exit" };
            Reparto reparto = new Reparto();
            Console.Title = "Clinica";

            do
            {
                scelta = Menu(opzioni, "CLINICA");
                Console.Clear();

                if (reparto.NumPazienti() == 0 && scelta != 0)
                {
                    Console.WriteLine("Clinica vuota");
                }
                else
                {
                    switch (scelta)
                    {
                        case 0:
                            Inserimento(reparto);
                            break;

                        case 1:
                            reparto.StampaPazienti();
                            break;

                        case 2:
                            ModificaTemperatura(reparto);
                            break;

                        case 3:
                            reparto.Previews();
                            Console.WriteLine(reparto.PazienteCorrente());
                            break;

                        case 4:
                            reparto.Next();
                            Console.WriteLine(reparto.PazienteCorrente());
                            break;

                        case 5:
                            reparto.Reset();
                            Console.WriteLine(reparto.PazienteCorrente());
                            break;
                    }
                }

                if (scelta != opzioni.Length - 1)
                {
                    Console.WriteLine("\n\nPremi invio per tornare al menù principale");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (scelta != opzioni.Length - 1);
        }
        static int Menu(string[] opzioni, string titolo)
        {
            int scelta;
            Console.WriteLine($"======== {titolo} ========\n");

            for (int i = 0; i < opzioni.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] <<  {opzioni[i]}");
            }

            Console.WriteLine("\n=========================\n");

            scelta = InserimentoInt("Inserisci la scelta: ", opzioni.Length, 1);
            return scelta - 1;
        }
        static void Inserimento(Reparto reparto)
        {
            string nome, cognome;
            double temperatura;

            nome = InserimentoStringa("Inserisci il nome del paziente: ");

            cognome = InserimentoStringa("\nInserisci il cognome del paziente: ");

            temperatura = InserimentoDouble("\nInserisci la temperatura del paziente: ", 42, 35);

            reparto.AddPaziente(new Paziente(nome, cognome, temperatura));
        }
        static void ModificaTemperatura(Reparto reparto)
        {
            double temperatura;
            int posPazienti = Menu(reparto.ArrPazienti(), "PAZIENTI");

            temperatura = InserimentoDouble("\nInserisci la nuova temperatura: ", 42, 35);

            reparto.CambiaTemp(temperatura, posPazienti);
        }
        static string InserimentoStringa(string input)
        {
            string stringa;
            do
            {
                Console.WriteLine(input);
                stringa = Console.ReadLine();

                foreach (char c in stringa)
                {
                    if (char.IsDigit(c))
                    {
                        stringa = "";
                        break;
                    }
                }
            } while (stringa == "");

            return stringa;
        }
        static double InserimentoDouble(string input, double valMax, double valMin)
        {
            double val;

            do
            {
                Console.WriteLine(input);

            } while (!double.TryParse(Console.ReadLine(),out val) || val > valMax || val < valMin);

            return val;
        }
        static int InserimentoInt(string input, int valMax, int valMin)
        {
            int val;

            do
            {
                Console.WriteLine(input);

            } while (!int.TryParse(Console.ReadLine(), out val) || val > valMax || val < valMin);

            return val;
        }
    }
}

