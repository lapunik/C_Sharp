using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statika_nepoužívat_
{
    class Uzivatel
    {

        private string jmeno;
        private string heslo;
        private bool prihlaseny;
        private int id;

        public static int minimalniDelkaHesla = 4;//Sttické atributy.. minimalni delku hesla znamm az po tom co vytvorim instanci ale tu musim uzivateli zdelit uz pred 
        public static int dalsiID = 1; // ...zalozenim instance nebo cislovani id... abych nemusel slozite hlidat z venci


        public Uzivatel(string jmeno, string heslo)
        {

            this.jmeno = jmeno;
            this.heslo = heslo;
            prihlaseny = false;
            id = dalsiID;
            dalsiID++;

        }

        public static bool KontrolaHesla(string heslo)  //kontroluje delku hesla proto je static protoze spravnost hesal je potreba u registrace, po vytvoreni instance je uz pozde
        {

            if (heslo.Length >= minimalniDelkaHesla)
            {
                return true;
            }
            return false;

        }

        public static int VratMinimalniDelkuHesla()
        {
            return minimalniDelkaHesla;
        }

        public int VratId()
        {
            return id;
        }

        public override string ToString()
        {
            return jmeno;
        }
        public bool PrihlasSe(string zadaneHeslo)
        {
            if (zadaneHeslo == heslo)
            {

                prihlaseny = true;
                return true;

            }
            else
            {

                return false;

            }
        }

    }
}
