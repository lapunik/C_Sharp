using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statika_nepoužívat_
{
    class Program
    {
        static void Main(string[] args)
        {

            Uzivatel u = new Uzivatel("Pepa z Depa", "1234");

            // Console.WriteLine(Uzivatel.minimalniDelkaHesla); // vpise minimalni delku hesla, je statická takže pisu Uzivatel.blabla a ne u.blabla 

            Console.WriteLine("ID prvního uživatele: {0}", u.VratId());
            Console.WriteLine(u);
            Uzivatel v = new Uzivatel("Maho Jako Tyč", "4321");
            Console.WriteLine("ID druhého uživatele: {0}", v.VratId());
            Console.WriteLine(v);
            Console.WriteLine("Minimální délka hesla uživatele je: {0}", Uzivatel.VratMinimalniDelkuHesla());
            Console.WriteLine("Validnost hesla \"heslo\" je: {0}", Uzivatel.KontrolaHesla("heslo"));
            Console.ReadKey();


        }
    }
}
