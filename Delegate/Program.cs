using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class Program
    {
        static void Main(string[] args)
        {

            Cisla cisla = new Cisla();
            Console.WriteLine(cisla);

            cisla.ProvedOperaci(NaDruhou);
            Console.WriteLine(cisla);

        }

        static int NaDruhou(int a)
        {
            return a * a;
        }
    }
}
