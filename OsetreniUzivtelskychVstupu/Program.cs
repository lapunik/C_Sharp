using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsetreniUzivtelskychVstupu
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Zadej číslo: ");
            int a;
            while (!int.TryParse(Console.ReadLine(), out a))
                Console.Write("\nNeplatné číslo, zadejte prosím znovu: ");

            /////////////////////////////////////////////////////////////////////////////

            Console.Write("Zadej číslo: ");
            int b;
            while (!int.TryParse(Console.ReadLine(), out b))
                Console.Write("\nNeplatné číslo, zadejte prosím znovu: ");


            Console.Write("Zadej operaci:\n1 - Soucet\n2 - Rozdil\n3 - Soucin\n4 - Podil\n");

            char volba = Console.ReadKey().KeyChar; //nepotvrzuji entrem, pouze jeden znak
            float vysledek = 0;
            bool platnaVolba = true;
            switch (volba)
            {
                case '1':
                    vysledek = a + b;
                    break;
                case '2':
                    vysledek = a - b;
                    break;
                case '3':
                    vysledek = a * b;
                    break;
                case '4':
                    vysledek = a / b;
                    break;
                default:
                    platnaVolba = false;
                    break;
            }
            if (platnaVolba)
                Console.WriteLine("/nVýsledek: {0}", vysledek);
            else
                Console.WriteLine("Neplatná volba");

        }
    }
}
