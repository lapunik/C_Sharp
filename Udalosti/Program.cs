using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udalosti
{
    class Program
    {
        static void Main(string[] args)
        {
            Zakaznik zakaznik1 = new Zakaznik();
            Objednavka objednavka1 = new Objednavka("triko");
            Objednavka objednavka2 = new Objednavka("kalhoty");

            zakaznik1.PridejObjednavku(objednavka1);
            zakaznik1.PridejObjednavku(objednavka2);

            objednavka1.ZmenStav(Objednavka.EStav.Potvrzeno);
                       
            Console.ReadKey();
        }
    }
}
