using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spocteni_radu_cifry
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Zadej hodnotu: ");

            string vstup = Console.ReadLine();

            int velicina_u_ktere_zkoumam_rad;

            if (int.TryParse(vstup, out velicina_u_ktere_zkoumam_rad) == false)
            {
                Console.WriteLine("Špatně zadané parametry");

                Console.ReadKey();

                return;
            }

            int pomocna = velicina_u_ktere_zkoumam_rad;

            int rad = 1;

            int nasobitel = 1;

            while (velicina_u_ktere_zkoumam_rad != 0)
            {

                if ((velicina_u_ktere_zkoumam_rad % (10 * nasobitel)) == 0)
                {
                    nasobitel *= 10;

                    rad++;

                }

                velicina_u_ktere_zkoumam_rad = velicina_u_ktere_zkoumam_rad - nasobitel;

            }

            Console.WriteLine("\tČíslo {0} je řádu: {1}", pomocna, rad);

            Console.ReadKey();
        }
    }
}
