using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vlastnosti
{
    class Program
    {
        static void Main(string[] args)
        {

            Student s = new Student("Pepa z Depa", true, 19);

            Console.WriteLine(s);

            s.Vek = 15;

            Console.WriteLine(s);

            Console.ReadKey();
        }
    }
}
