using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Losovani
{
    class Program
    {
        static void Main(string[] args)
        {

            Losovac losovac = new Losovac();

            Console.WriteLine("Vítejte v programu na losování čísel");

            char volba = '0';

            while (volba != '3')
            {

                Console.WriteLine("1 - Losovat další číslo");
                Console.WriteLine("2 - Vypsat čísla");
                Console.WriteLine("3 - Konec");

                volba = Console.ReadKey().KeyChar;
                Console.WriteLine();

                Console.Clear();

                switch (volba)
                {

                    case '1':
                        Console.WriteLine("Nově vzlosované číslo: {0}", losovac.Losuj());
                        break;
                    case '2':
                        Console.WriteLine("Všechny čísla: {0}", losovac.Vypis());
                        break;
                    case '3':
                        Console.WriteLine("Konec...");
                        break;
                    default:
                        Console.WriteLine("Neplatná volba, zkus to znovu: ");
                        break;

                }
                Console.WriteLine("Pokracuj stiskem enter");
                Console.ReadKey();
                Console.Clear();
            }

            /*
          static void Main(string[] args)
          {
          // Lze volat list a pri inicializaci vlozit cele pole nebo list 
              string[] poleStringu = { "První", "Druha", "Třetí" };
              List<string> l = new List<string>(poleStringu);
              Console.WriteLine(l[2]);
          }*/

            // pro výčet metod: https://www.itnetwork.cz/csharp/oop/c-sharp-tutorial-list-pridavani-mazani-polozek

        }
    }
}

