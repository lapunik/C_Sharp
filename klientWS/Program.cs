using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klientWS
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Klient WS");

            using (mojesluzba.WebService ws = new mojesluzba.WebService()) // protoze na strane sluzby se ta trida jmenuje WebService
            {
                Console.WriteLine("Soucet: {0}",ws.Soucet(10, 100));

                Console.WriteLine("Podil: {0}", ws.Podil(10, 5)); // s nulou si neporadil, protože jsme v xml z webu čekali int a ona vratila string s hlaskou chyby

                
            }

            using (WebReference.data_ws ws = new WebReference.data_ws()) // protoze na strane sluzby se ta trida jmenuje WebService
            {

                DataTable tbl = ws.GetLastTemp(20);

            }

        }
    }
}
