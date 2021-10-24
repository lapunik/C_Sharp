using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//          {\
//         )]={})>
//          {/

namespace Raketka
{
    class Raketa
    {

        private int poloha;
        private int posunutiOdKraje;

        public Raketa(int poloha,int posunutiOdKraje)
        {
            this.poloha = poloha;
            this.posunutiOdKraje = posunutiOdKraje;
        }

        public string Vykresleni()
        {
            return ")]={})>";
        }
        public string VykresleniPrvniKridlo()
        {
            return " {\\";
        }
        public string VykresleniDruheKridlo()
        {
            return " {/";
        }

        public int VypisPoloha()
        {
            return poloha;
        }

        public void NastavPoloha(int poloha)
        {
            this.poloha=poloha;
        }

        public int VypisPosunuti()
        {
            return posunutiOdKraje;
        }

    }
}
