using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Prepinac
{
    class Program
    {
        static void Main(string[] args)
        {

           // Thread.CurrentThread.Name = "Hlavní vlákno";
           // Console.WriteLine(Thread.CurrentThread.Name);

            Prepinac prepinac = new Prepinac();
            prepinac.Prepinej();


        }
    }
}
