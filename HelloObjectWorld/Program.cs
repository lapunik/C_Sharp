using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloObjectWorld
{
    class Program
    {
        static void Main(string[] args)
        {

            Zdravic zdravic = new Zdravic(); // promnená s názvem zdravic obsahující instanci Zdravic = nová šablona Zdravic

            zdravic.Pozdrav();

            zdravic.Pozdrav("Karel");

        }
    }
}
