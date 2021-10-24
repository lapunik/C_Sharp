using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NacteniVypis
{
    class Program
    {

        public enum ENUM
        {
           bota,
           triko,
           kalhoty
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Napis neco: "); // Vypis Textu

            //funguje uplne stejne i toho: Console.Write("Napis neco: \n");

            string vstup = Console.ReadLine(); // Nacteni z klavesnice

            Console.WriteLine(vstup); // Vypis promene

            Console.WriteLine("! " + vstup + " !"); // Vypis formatovane promenne

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("Napis cislo: ");

            vstup = Console.ReadLine();

            int cislo;

            cislo = int.Parse(vstup); //Parsovani textu na cele cilso

            Console.WriteLine(cislo + " + 5 = " + (cislo + 5)); //Vypis 

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // Kdybych z nějakýho důvodu chtěl převest "cilso" na string použijui a studio to neudela za me.. ToString()

            vstup = cislo.ToString();// Pouziti ToString

            string s = "krokonosohroch";

            Console.WriteLine(s.StartsWith("krok")); //Zacina retezec na krok?

            Console.WriteLine(s.EndsWith("hroch")); //Konci retezec na hroch?

            Console.WriteLine(s.Contains("nos")); //Obsahuje retezec ano?

            Console.WriteLine(s.Contains("roh"));

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            s = "KroKOoSOHroch";

            Console.WriteLine(s.ToUpper()); //Prevedeni na velke pismena

            Console.WriteLine(s.ToLower()); //Prevedeni na male pismena

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            s = "    text";

            Console.WriteLine(s);

            Console.WriteLine(s.Trim()); //odstraneni bilych znaku

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            s = "Ibl je dobrej";

            s = s.Replace("dobrej","k hovnu");

            Console.WriteLine(s);

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            int a = 3;

            int b = 5;

            int c = a+b;

            s = string.Format("Když sečteme {0} a {1}, dostaneme {2}", a, b, c);

            Console.WriteLine(s);

            Console.WriteLine("Když sečteme {0} a {1}, dostaneme {2}", a, b, c); // nebo jen takhle

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            s = "IbljeGay";

            Console.WriteLine(s);

            Console.WriteLine(s.Length); //Delka retezce

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("{0}, {1}",ENUM.bota.ToString(),(int)ENUM.bota);
            Console.WriteLine("{0}, {1}", ENUM.kalhoty.ToString(), (int)ENUM.kalhoty);
            Console.WriteLine("{0}, {1}", ENUM.triko.ToString(), (int)ENUM.triko);

            Console.ReadKey(); //Čeká na stisk kláveśy, jakékoliv

        }
    }
}
