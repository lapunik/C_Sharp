using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozhrani
{
    class Program
    {
        static void Main(string[] args)
        {
            /* přetypování nebo zkouska rozhrani
                        IPtak ptakojester = new PtakoJester(); // tpi IPtak

                        //ptakojester.

                        ((PtakoJester)ptakojester).PlazSe(); //přetypování na ptakojester
                */

            List<Zvire> zvirata = new List<Zvire>(); // List kam nahazime zvirata, misto konstruktoru udavam vahu v slozenych zavorkach
            zvirata.Add(new Ptak() { Vaha = 1 });
            zvirata.Add(new Delfin() { Vaha = 8 });
            zvirata.Add(new Delfin() { Vaha = 9 });
            zvirata.Add(new PtakoJester() { Vaha = 3 });
            zvirata.Add(new PtakoJester() { Vaha = 2 });

            foreach (Zvire zvire in zvirata) // všechny necháme dýchat a delfiny rozkáčeme
            {
                Console.WriteLine(zvire);
                zvire.Dychej();
                if (zvire is Delfin) // Operátor "is" !!!
                    ((Delfin)zvire).Vyskoc();


                // ekvivalentní zjisteni zda jde o delfina 
                /*

                if (zvire.GetType() == typeof(Delfin))
                   (zvire as Delfin).Vyskoc();

                */

               // ekvivalentní pretypovani jen v pripade neuspechu vrati null misto padu programu

                /*
             
                if (zvire is Delfin)
                  (zvire as Delfin).Vyskoc();

                */

            }
        }
    }
}
