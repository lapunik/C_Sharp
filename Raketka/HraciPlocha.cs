using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raketka
{
    class HraciPlocha
    {

        private int delka;
        private int sirka;
        private Raketa raketa;

        public HraciPlocha(int delka, int sirka,Raketa raketa)
        {
            this.delka = delka;
            this.sirka = sirka;
            this.raketa = raketa;
        }

        public void Vykresli()
        {
            Console.Write("\n    ");
            for (int i = 0; i < delka; i++)
            {
                Console.Write("▄");
            }
            Console.WriteLine("");
            for (int i = 0; i < sirka; i++)
            {

                Console.Write("    █");
                for (int j = 0; j < delka - 2; j++)
                {


                    if ((raketa.VypisPoloha() == i) && (j == raketa.VypisPosunuti()))
                    {
                        Console.Write(raketa.Vykresleni());
                    }
                    else if ((raketa.VypisPoloha() == i) && (j > raketa.VypisPosunuti()) && (j < ((raketa.Vykresleni().Length)+ raketa.VypisPosunuti()))){}
                    else if ((raketa.VypisPoloha() == i + 1) && (j == raketa.VypisPosunuti()))
                    {
                        Console.Write(raketa.VykresleniPrvniKridlo());
                    }
                    else if ((raketa.VypisPoloha() == i - 1) && (j == raketa.VypisPosunuti()))
                    {
                        Console.Write(raketa.VykresleniDruheKridlo());
                    }
                    else if (((raketa.VypisPoloha() == i + 1)|| (raketa.VypisPoloha() == i - 1)) && (j > raketa.VypisPosunuti()) && (j < ((raketa.VykresleniPrvniKridlo().Length) + raketa.VypisPosunuti()))){}
                    else
                    {
                        Console.Write(" ");
                    }


                }
                Console.WriteLine("█");
            }
            Console.Write("    ");
            for (int i = 0; i < delka; i++)
            {
                Console.Write("▀");
            }
            Console.WriteLine("");
        }


    }
}
