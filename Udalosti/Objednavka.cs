using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udalosti
{

    class Objednavka
    {
        public event EventHandler ZmenaStavu; // událost detekující změnu stavu
        //EventHander je deklarován takto: public delegate void EvenHandler(object sender, EventArgs e); 

        public enum EStav
        {
            Doruceno,
            Expedovano,
            Potvrzeno,
            Nepotvrzeno,
        }

        public EStav Stav { get; private set; }

        private EStav staryStav;
        public string Zbozi { get; private set; }

        public Objednavka(string zbozi)
        {
            Zbozi = zbozi;
            Stav = EStav.Nepotvrzeno;
            staryStav = Stav;
        }

        protected void PriZmeneStavu(EventArgs e) // eventy nejsou veřejné, proto, pokud chceme volat eventy potomkami této třídy, je potřeba taková spojovací metoda která zavolá událost
        {
            if (Stav != staryStav) // kontrola pokud měníme stav objednávky na stejný stav
            {
                ZmenaStavu(this, e); // zavolání metody delegátu (události) se vstupními argumenty této instance třídy a agrumentů stejnými jako tuto fuknci zavolali
            }
        }

        public void ZmenStav(EStav stav) // metoda pro zmenu stavu objednavky
        {
            staryStav = Stav;
            Stav = stav;
            PriZmeneStavu(EventArgs.Empty);
        }

        public override string ToString()
        {
            return "Objednavka: " + Zbozi;
        }

    }
}
