using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morzeovka_Split___Join___
{
    class Program
    {
        static void Main(string[] args)
        {

            
            string abecedniznaky = "abcdefghijklmnopqrstuvwxyz1234567890";

            string[] morseovyznaky = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..", ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----.", "-----" };


            /////////////////////////////////////////////////////////////////////////////////////////////////////
            
            // řetězec, který chceme dekódovat
            // string zakodovanazprava = ".. -... .-..  --. .- -.--";
            string zakodovanazprava;

            Console.WriteLine("////////////////////////////////////////////////////");

            Console.Write("Zadej zprávu v morseově abecedě: ");

            zakodovanazprava = Console.ReadLine();


            // řetězec s dekódovanou zprávou
            string odhalenazprava = "";

            string[] znakyzakodovanezpravy = zakodovanazprava.Split(' ');

            foreach (string morzeuvznak in znakyzakodovanezpravy)
            {
                char abecedniznak = ' ';

                int index = Array.IndexOf(morseovyznaky,morzeuvznak); //vraci index v poli, kdyz neni v poli, vrátí -1

                if (index >= 0)//znak je oobsazen v poli
                {
                    abecedniznak = abecedniznaky[index];
                }
                odhalenazprava += abecedniznak;
            }

            Console.WriteLine("Odhalená zpráva: {0}",odhalenazprava);

            Console.WriteLine("\n////////////////////////////////////////////////////");

            /////////////////////////////////////////////////////////////////////////////////////////////////////

            zakodovanazprava = "";

            Console.Write("Zadej zprávu kterou chceš přeložit do morzeovky: ");

            odhalenazprava = Console.ReadLine();

            for (int i = 0; i < odhalenazprava.Length; i++)
            {
                if (odhalenazprava[i] == ' ')
                {
                    zakodovanazprava += " ";
                }
                else
                {
                    for (int j = 0; j < abecedniznaky.Length; j++)
                    {
                        if (odhalenazprava[i] == abecedniznaky[j])
                        {
                            zakodovanazprava += morseovyznaky[j];
                            zakodovanazprava += " ";
                        }
                    }
                }
            }

            Console.WriteLine("Zakódovaná zpráva: {0}", zakodovanazprava);

            Console.ReadKey();

        }
    }
}
