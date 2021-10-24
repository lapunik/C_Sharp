using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Prepinac
{
    class Prepinac
    {

        public void Vypisuj0()
        {
            while (true)
            {
                Console.Write("0");
            }
        }

        public void Vypisuj1()
        {
            while (true)
            {
                Console.Write("1");
            }
        }

        public void Prepinej()
        {
            Thread vlakno = new Thread(Vypisuj0);
            vlakno.Start();
            Vypisuj1();
        }

    }
}
