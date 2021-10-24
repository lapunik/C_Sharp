using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Vypisovac
{
    class Program
    {
        static void Main(string[] args)
        {

            Vypisovac vypisovac = new Vypisovac();
            Thread vlakno1 = new Thread(vypisovac.Vypisuj0);
            Thread vlakno2 = new Thread(vypisovac.Vypisuj1);
            vlakno1.Start();
            vlakno2.Start();
            vlakno1.Join(); // zablokuje hlavní vláknio dokud se nedokončí vlakno1
            vlakno2.Join();

            // Thread.Sleep(0); nulové spaní funguje jako vynucení přepnutí do jiného vlákna 
            // stejně funguje i Thread.Yield()

            Console.WriteLine("Hotovo");

        }
    }
}
