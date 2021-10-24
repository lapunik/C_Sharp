using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class Cisla
    {

        private List<int> cisla = new List<int>();

        public delegate int Operace(int a);

        public Cisla()
        {
            for (int i = 0; i < 10; i++)
            {
                cisla.Add(i + 1);
            }
        }

        public void ProvedOperaci(Operace operace)
        {
            for (int i = 0; i < 10; i++)
            {
                cisla[i] = operace(cisla[i]);
            }
        }


        public override string ToString()
        {
            string vystup = "";
            foreach (int cislo in cisla)
            {
                vystup += cislo + ", ";
            }
            return vystup;
        }
    }
}

