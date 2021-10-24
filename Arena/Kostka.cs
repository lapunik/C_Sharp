using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena
{
    // Třída reprezentuje hrací kostku
    class Kostka
    {
        // Generátor náhodných čísel
        private Random nahodneCislo;
        // Počet stěn kostky
        private int pocetSten;

        //Konstruktor
        public Kostka(int PocetSten) //Tohle je to co se asi zavolá... myslím 
        {
            this.pocetSten = PocetSten; //this.pocetSten zaridi ze bereme promenou vytvorenou ve tride zatimco druhy pocetSten je atribut konstruktoru
            nahodneCislo = new Random();
        }

        public Kostka() //Tohle je to co se asi zavolá... myslím 
        {
            pocetSten = 6;
            nahodneCislo = new Random();
        }

        public int VratPocetSten() //ztrácí smysl ve chvíli kdy zavedeme to string
        {
            return pocetSten; //Vrati pocet sten
        }

        public int Hod()
        {
            return nahodneCislo.Next(1,pocetSten+1); //Generator nahodnych cisel
        }

        public override string ToString() //override protože ji přepisujeme (ne) 
        {
            return String.Format("Kostka s {0} stěnami", pocetSten);
        }
    }
}
