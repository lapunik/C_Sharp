using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podminky
{
    class Program
    {
        static void Main(string[] args)
        {
            int volba1=0,volba2=0;
            int x = 0;
            string odpoved = "b";

            while ((volba1 < 1) || (volba1 > 3)) {

                Console.Write("Vyber jednu u možností:");

                if (x!=0) { Console.Write("(Vybral jsi blbost!)"); }

                Console.Write("\n1 - Modrý\n2 - Zelený\n3 - Červený\n");

                volba1 = int.Parse(Console.ReadLine());


                Console.Clear();

                x++;
            }

            x = 0;

            while ((volba2 < 1) || (volba2 > 3))
            {


                Console.Write("Vyber jednu u možností:");

                if (x!=0) { Console.Write("(Vybral jsi blbost!)"); }

                Console.Write("\n1 - Trojúhelník\n2 - Čtverec\n3 - Obdelník\n");

                volba2 = int.Parse(Console.ReadLine());

                Console.Clear();
                x++;

            }
            switch (volba2) {

                case 1:
                    odpoved = "a Trojúhelník";
                break;

                case 2:
                    odpoved = "a Čtverec";
                break;

                case 3:
                    odpoved = "a Obdélník";
                break;

            }

            switch (volba1) {

                case 1:
                    odpoved = odpoved.Replace("a","Modrý");
                    break;

                case 2:
                    odpoved = odpoved.Replace("a", "Zelený");
                    break;

                case 3:
                    odpoved = odpoved.Replace("a", "Červený");
                    break;

            }

            Console.WriteLine("Tvá volba: " + odpoved);

            for (int i = 0; i < 10; i++)
            {

                if (i == 5)
                {

                    return;

                }

                Console.WriteLine(i);

                

            }


            Console.ReadKey();
        }
    }
}
