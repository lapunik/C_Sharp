using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raketka
{
    class Hra
    {

        private HraciPlocha plocha;

        private Raketa raketa;

        public Hra(Raketa raketa, HraciPlocha plocha)
        {
            this.plocha = plocha;
            this.raketa = raketa;
        }

        public void SpustHru()
        {
 while (true)
            {

                Console.WriteLine("O");

                if (Console.KeyAvailable) // since .NET 2.0
                {
                    char c = Console.ReadKey().KeyChar;
                    break;
                }
            }
        }
    }
}
