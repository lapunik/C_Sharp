using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Arena
{
    class Arena
    {

        private Bojovnik bojovnik1;

        private Bojovnik bojovnik2;

        private Kostka kostka;

        public Arena(Bojovnik bojovnik1, Bojovnik bojovnik2, Kostka kostka)
        {
            this.bojovnik1 = bojovnik1;
            this.bojovnik2 = bojovnik2;
            this.kostka = kostka;
        }

        private void Vykresli()
        {
            Console.Clear();
            VypisBojovnika(bojovnik1);
            Console.WriteLine();
            VypisBojovnika(bojovnik2);
            Console.WriteLine();
        }

        private void VypisBojovnika(Bojovnik b)
        {
            Console.WriteLine(b);
            Console.Write("Zivot: ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(b.GrafickyZivot());
            Console.ResetColor();
            if (b is Mag)
            {
                Console.Write("Mana:  ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(((Mag)b).GrafickaMana());
                Console.ResetColor();
            }
        }

        private void VypisZpravu(string zprava)
        {
            Thread.Sleep(1000);
            Console.WriteLine(zprava);
        }

        public void Zapas()
        {
            // původní pořadí
            Bojovnik b1 = bojovnik1;
            Bojovnik b2 = bojovnik2;
            Console.WriteLine("Vítejte v aréně!");
            Console.WriteLine("Dnes se utkají {0} s {1}! \n", bojovnik1, bojovnik2);
            // prohození bojovníků
            bool zacinaBojovnik2 = (kostka.Hod() <= kostka.VratPocetSten() / 2);
            if (zacinaBojovnik2)
            {
                b1 = bojovnik2;
                b2 = bojovnik1;
            }
            Console.WriteLine("Začínat bude bojovník {0}! \nZápas může začít...", b1);
            Console.ReadKey();
            // cyklus s bojem
            while (b1.Nazivu() && b2.Nazivu())
            {
                Vykresli();
                b1.Utoc(b2);
                VypisZpravu(b1.VypisPosledniZpravu()); // zpráva o útoku
                VypisZpravu(b2.VypisPosledniZpravu()); // zpráva o obraně
                Vykresli();
                Console.WriteLine(b1.VypisPosledniZpravu());
                Console.WriteLine(b2.VypisPosledniZpravu());
                Console.ReadKey();
                if (b2.Nazivu())
                {
                    Vykresli();
                    b2.Utoc(b1);
                    VypisZpravu(b2.VypisPosledniZpravu()); // zpráva o útoku
                    VypisZpravu(b1.VypisPosledniZpravu()); // zpráva o obraně
                    Vykresli();
                    Console.WriteLine(b2.VypisPosledniZpravu());
                    Console.WriteLine(b1.VypisPosledniZpravu());
                    Console.ReadKey();
                }
                Console.WriteLine();
            }
        }
    }
}
