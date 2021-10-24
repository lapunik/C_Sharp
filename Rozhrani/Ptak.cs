using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozhrani
{
    class Ptak: Zvire ,IPtak
    {

        public void Pipni()
        {
            Console.WriteLine("Píp..");
        }

        public void Klovni()
        {
            Console.WriteLine("Klov..");
        }


    }
}
