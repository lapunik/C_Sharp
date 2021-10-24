using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Losovani
{
    class Losovac
    {
        private List<int> cisla; //inicializace typu list
        private Random random; // inicializace nahodneho cisla

        public Losovac() //konstruktor kde ozije objekty list a random
        {
            random = new Random();

            cisla = new List<int>();
        }

        public int Losuj()
        {

            int cislo = random.Next(100) + 1;
            cisla.Add(cislo);
            return cislo;
        }

        public string Vypis()
        {
            string s = "";
            cisla.Sort();
            foreach (int i in cisla)
            {
                s += i + " ";
            }
            return s;
        }

        
    }
}
