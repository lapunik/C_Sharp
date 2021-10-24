using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            int n = Int32.Parse(Console.ReadLine());
            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = i;
            }

            Console.WriteLine("Velikost pole je {0} ",n);

            Console.WriteLine("Pole obsahuje: ");

            for (int i = 0; i < n; i++)
            {
                Console.Write("{0},",array[i]);
            }
            */

            Car auto = new Car("Ferrari", 301);

            Car autoDva = new Car("Lamborghini", 298);

            Car kamion = new Truck("Tatra",3000);

            Console.WriteLine(auto);

            Console.WriteLine(autoDva);

            Console.WriteLine(kamion);

            Console.WriteLine("Rychlejší je: {0}",auto.Porovnej(autoDva));
        }
    }
}
