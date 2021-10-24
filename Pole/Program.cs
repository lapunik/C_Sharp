using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pole
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] pole = new int[10];

            pole[0] = 1;

            for (int i = 0; i < 10; i++)
            {
                pole[i] = i + 1;
            }

            for (int i = 0; i < pole.Length; i++)
            {
                Console.Write("{0} ", pole[i]);
            }

            Console.WriteLine("");

            foreach (int i in pole)

                Console.Write("{0} ", pole[i - 1]);

            //////////////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("");

            string[] simpsonovi = { "Homer", "Marge", "Bart", "Lisa", "Meggie" };

            Array.Sort(simpsonovi); // Serazeni podle abecedy, cisla by seradila podle velikosti... Array jsou metody pro práci s polem


            for (int i = 0; i < simpsonovi.Length; i++)
            {
                Console.Write("{0} ", simpsonovi[i]);
            }

            Console.WriteLine("");

            Array.Reverse(simpsonovi); // Otoci poradi


            for (int i = 0; i < simpsonovi.Length; i++)
            {
                Console.Write("{0} ", simpsonovi[i]);
            }

            Console.WriteLine("");

            //////////////////////////////////////////////////////////////////////////////////////////////////////////

            Console.Write("Ahoj, zadej svého oblíbeného Simpsna (z rodiny Simpsů): ");

            string simpson = Console.ReadLine();

            int pozice = Array.IndexOf(simpsonovi, simpson); //vrací pozici (index) v poli

            Console.WriteLine("");

            if (pozice >= 0)
                Console.WriteLine("Jo, to je můj {0}. nejoblíbenější Simpson!", pozice + 1);
            else
                Console.WriteLine("Hele, tohle není Simpson!");

            //////////////////////////////////////////////////////////////////////////////////////////////////////////

            string[] cilovepole = { "Jeden", "Dva", "Tři", "Čtyři", "Pět" };

            Array.Copy(simpsonovi, cilovepole, 2); //z jakyho pole, do jakoho pole, kolik prvku

            for (int i = 0; i < cilovepole.Length; i++)
            {
                Console.Write("{0} ", cilovepole[i]);
            }

            Console.WriteLine("");

            //////////////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine(pole.Min());
            Console.WriteLine(pole.Max());
            Console.WriteLine(pole.First());
            Console.WriteLine(pole.Last());
            Console.WriteLine(pole.Sum()); //Suma
            Console.WriteLine(pole.Average()); //Průměř

            //////////////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("Ahoj, spočítám ti průměr známek. Kolik známek zadáš?");

            int pocet = int.Parse(Console.ReadLine());

            int[] cisla = new int[pocet];

            for (int i = 0; i < pocet; i++)
            {
                Console.Write("Zadejte {0}. číslo: ", i + 1);
                cisla[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Průměr tvých známek je: {0}", cisla.Average());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////

            string text = "Nejaky blbosti, je to fakt jedno";

            Console.WriteLine(text);

            text = text.ToLower();

            string souhlasky = "aeiouyéáíóúůěý";

            int pocetsouhlasek = 0;

            string samohlasky = "bcčdďfhgjklmnpqřstršťvwxzž";

            int pocetsamohlasek = 0;

            int ostatniznaky = 0;

            foreach (char c in text) {

                if (samohlasky.Contains(c))
                {
                    pocetsamohlasek++;
                }
                else {
                    if (souhlasky.Contains(c))
                    {
                        pocetsouhlasek++;
                    }
                    else {
                        ostatniznaky++;
                    }
                }


            }

            Console.WriteLine("Samohlasky: {0}\nSouhlasky: {1}\nOstatniznaky: {2}", pocetsamohlasek, pocetsouhlasek, ostatniznaky);

            //////////////////////////////////////////////////////////////////////////////////////////////////////////

            text = text.Insert(27, "totalne "); //prida slovo "totalne" na pozici 27, v retezci znaky posune

            Console.WriteLine(text);

            // mohl bch to napsat rovnou takhle:  Console.WriteLine(text.Insert(27,"totalne"));

            Console.WriteLine(text.Remove(15)); //odmaze pozice v retezci 15 az dokoce...kdybch zadal (15,16).. odmazal by jen tyto dva znaky

            Console.WriteLine(text.Substring(7,7));//vrati pouze vysec retezce.. prvni cislo od jaké pozice, druhé cislo jak dlouhy retezec

            Console.WriteLine("Až", "Brno", "Akát".CompareTo("Brno")); //dojde k porovnání abecedního pořadí..-1 jestli je první řetězec před druhým..1 jestli je opak..0 jsouli stejne



            Console.ReadKey();

        }
    }
}
