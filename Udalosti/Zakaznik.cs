using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udalosti
{
    class Zakaznik
    {
        private List<Objednavka> objednavky = new List<Objednavka>();

        public void PridejObjednavku(Objednavka objednavka)
        {

            objednavky.Add(objednavka);
            objednavka.ZmenaStavu += Upomen;

        }

        public void Upomen(object sender, EventArgs e)
        {
            Console.WriteLine("Byla zaznamenána změna stavu objednávky {0} na {1}", sender, (sender as Objednavka).Stav);
        }
    }
}
