using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Testovaci
{
    class Program
    {

        static void Main(string[] args)
        {
            string sTring = "This is a test<EOF>";

            Console.WriteLine("String před kodováním: {0}",sTring);

            byte[] byteData = Encoding.ASCII.GetBytes(sTring);

            Console.WriteLine("Byte data: ");
            foreach (byte b in byteData)
            {
                Console.WriteLine("ASCII {0}",b);
            }

            string s = Encoding.ASCII.GetString(byteData, 0, byteData.Length);

            Console.WriteLine("\nString po kodování: {0}", s);

            Console.ReadKey();
        }
   
    }
}