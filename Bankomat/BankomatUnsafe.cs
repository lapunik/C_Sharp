using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Bankomat
{
    class BankomatUnsafe
    {
        private decimal hotovost = 100;
        
        private void Vyber100()
        {
            lock (new object()) { //tímto příkazem zamkneme tuto část kódu tak aby z ní nešlo přepnout mezi vlákny, jako argument stačí prázdný objekt
                if (hotovost >= 100)
                {
                    Console.WriteLine("Vybírám 100");
                    hotovost -= 100;
                    Console.WriteLine("na účtu máte ještě {0}.", hotovost);
                }
            }
        }
        public void VyberVlakny()
        {
            Thread vlakno1 = new Thread(Vyber100); //založím vlákno které volá metodu vyber stovku
            vlakno1.Start(); // vlákno spustím
            Vyber100(); // potom se snažím vybrat 100kč v vláknu ve kterém se právě nacházím
            if (hotovost < 0) // mám tam podmínku (line 16) že nelze vybrat stovku pokud tam nemám peníze, ale stejně se to občas stane, je to tím že jak se vlákna střídají a je možné že že jedno z vláken došlo až za podmínku jestli tam peníze jsou, v tu chvíli se přeplo vlákno a vybralo peníze a pak se přeplo zpět na vlákno za podmínku (která se už splnila předtím) a vybere peníze znovu, tentokrát už ale z prázdného účtu
                Console.WriteLine("Hotovost je v mínusu, okradli nás.");
        }

    }
}
