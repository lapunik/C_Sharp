using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabazeUzivatelu
{
    class Program
    {
        static void Main(string[] args)
        {


            // založení proměnných
            int a = 56;
            int b = 28;
            Uzivatel u = new Uzivatel("Jan Novák", 28);
            Uzivatel v = new Uzivatel("Josef Nový", 32);
            Console.WriteLine("a: {0}\nb: {1}\nu: {2}\nv: {3}\n", a, b, u, v);
            // přiřazování - ukazujeme si že zatímco u int budu mít dvě stejná čísla, u objektu budu mít jenom stejnou referenci na jeden a ten samý objekt
            a = b;
            u = v;
            Console.WriteLine("a: {0}\nb: {1}\nu: {2}\nv: {3}\n", a, b, u, v);

            // změna jména v provede zmenu u obou výpisů
            v.jmeno = "Arnošt Pokorný";
            v = null; //smazání reference
            Console.WriteLine("u: {0}\nv: {1}\n", u, v); //ale u nám normálně vypíše arnošta

            Console.ReadKey();

        }
    }
}
