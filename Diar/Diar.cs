using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diar
{
    class Diar
    {

        private Databaze databaze;

        public Diar()
        {

            databaze = new Databaze();

        }

        private DateTime ZjistiDatumCas()
        {
            Console.WriteLine("Zadejte datum a čas ve tvaru [1.1.2012 14:00]:");
            DateTime datumCas;
            while (!DateTime.TryParse(Console.ReadLine(), out datumCas))
                Console.WriteLine("Chybné zadání, zdajte znovu datum a čas: ");
            return datumCas;
        }

        public void VypisZaznamy(DateTime den)
        {

            List<Zaznam> zaznamy = databaze.NajdiZaznamy(den, false);
            foreach (Zaznam z in zaznamy)
            {

                Console.WriteLine(z);

            }
            
        }

        public void PridejZaznam()
        {
            DateTime datumCas = ZjistiDatumCas();
            Console.WriteLine("Zadejte text záznamu:");
            string text = Console.ReadLine();
            databaze.PridejZaznam(datumCas, text);
        }

        public void VyhledejZaznamy()
        {
            // Zadání data uživatelem
            DateTime datumCas = ZjistiDatumCas();
            // Vyhledání záznamů
            List<Zaznam> zaznamy = databaze.NajdiZaznamy(datumCas, false);
            // Výpis záznamů
            if (zaznamy.Count() > 0)
            {
                Console.WriteLine("Nalezeny tyto záznamy: ");
                foreach (Zaznam z in zaznamy)
                    Console.WriteLine(z);
            }
            else
                // Nenalezeno
                Console.WriteLine("Nebyly nalezeny žádné záznamy.");
        }

        public void VymazZaznamy()
        {
            Console.WriteLine("Budou vymazány záznamy v daný den a hodinu");
            DateTime datumCas = ZjistiDatumCas();
            databaze.VymazZaznamy(datumCas);
        }

        public void VypisUvodniObrazovku()
        {
            Console.Clear();
            Console.WriteLine("Vítejte v diáři!");
            Console.WriteLine("Dnes je: {0}", DateTime.Now);
            Console.WriteLine();
            // výpis hlavní obrazovky
            Console.WriteLine("Dnes:\n-----");
            VypisZaznamy(DateTime.Today);
            Console.WriteLine();
            Console.WriteLine("Zítra:\n------");
            VypisZaznamy(DateTime.Now.AddDays(1));
            Console.WriteLine();
        }

    }
}
