using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloObjectWorld
{
    class Zdravic
    {
        public void Pozdrav()
        {
            Console.WriteLine("Bem madafaka");
        }

        public void Pozdrav(string jmeno)
        {
            Console.WriteLine("Ha {0}, no na tebe jsem čekal",jmeno);
        }
    }
}
