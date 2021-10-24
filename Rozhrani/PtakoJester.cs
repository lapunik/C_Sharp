using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozhrani
{
    class PtakoJester : Zvire ,IJester, IPtak
    {
        public void PlazSe()
        {
            Console.WriteLine("Plazím se..");
        }

        public void Pipni()
        {
            Console.WriteLine("Píp..");
        }
    }
}
