using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raketka
{
    class Program
    {
        static void Main(string[] args)
        {
            Raketa raketa = new Raketa(8,2);

            HraciPlocha plocha = new HraciPlocha(60,16,raketa);

            Hra hra = new Hra(raketa,plocha);

        }
    }
}
