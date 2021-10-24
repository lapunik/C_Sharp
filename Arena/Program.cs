using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena
{
    class Program
    {
        static void Main(string[] args)
        {
            /*//Tady jsme si hráli s kostkou, ted je to nepodstatne////////////////////////////////////////////////////////////////////////////////////
            Kostka sestiStenaKostka = new Kostka(); //volame konstruktor bez parametru tudiz se zavola sestistena kostka

            Kostka namiZadanaKostka = new Kostka(10); // preteceni..stejny nazev konstruktoru jen se lisi pocetm argumentu

            //Console.WriteLine(sestiStenaKostka.VratPocetSten());

            //Console.WriteLine(namiZadanaKostka.VratPocetSten());

            Console.WriteLine(sestiStenaKostka);

            for (int i = 0;i<=8;i++) {

                Console.Write(sestiStenaKostka.Hod() + " ");//nahodne cislo od jedne do sesti
            }
            Console.WriteLine();

            Console.WriteLine(namiZadanaKostka);

            for (int i = 0; i <= 8; i++)
            {
                Console.Write(namiZadanaKostka.Hod() + " ");//nahodne cislo od jedne do sesti 
            }
            Console.WriteLine();
            */

            /*//Tady jsme si hráli s bojovnikem, ted je to nepodstatne////////////////////////////////////////////////////////////////////////////////////
            Kostka sestistennaKostka = new Kostka();

            Bojovnik bojovnik = new Bojovnik("Marco Van Basten", 100, 20, 10, sestistennaKostka);

            Bojovnik souper = new Bojovnik("Ngolo Kante",60,45,15,sestistennaKostka);

            Console.WriteLine("Bojovník: {0}", bojovnik); // test ToString();
            Console.WriteLine("Naživu: {0}", bojovnik.Nazivu()); // test Nazivu();
            Console.WriteLine("Život: {0}", bojovnik.GrafickyZivot()); // test GrafickyZivot();
                souper.Utoc(bojovnik);

            Console.WriteLine(souper.VypisPosledniZpravu());
            Console.WriteLine(bojovnik.VypisPosledniZpravu());

            Console.WriteLine("Život po utoku: {0}", bojovnik.GrafickyZivot()); // 
            */

            // vytvoření objektů
            Kostka kostka = new Kostka(10);

            Bojovnik jeden = new Bojovnik("Thomas Lemar", 140, 20, 10, kostka);
            //Bojovnik druhy = new Bojovnik("Ngolo Kante", 50, 12, 40, kostka);
            Bojovnik druhy = new Mag("Kylian Mbappe", 80, 15, 12, kostka, 30, 45);
            Arena arena = new Arena(jeden,druhy, kostka);
            // zápas
            arena.Zapas();
            Console.ReadKey();
            
        }
    }
}
