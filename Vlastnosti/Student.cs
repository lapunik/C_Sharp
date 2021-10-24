using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vlastnosti
{
    class Student
    {

        public string Jmeno { get; private set; } //velká písmeno!
        public bool Muz { get; private set; } // privat set aby vlastnost nešla měnit z venčí
        public bool Plnolety { get; private set; }
        private int vek;
        public int Vek
        {
            get
            {
                return vek;
            }
            set
            {
                vek = value; // value = zadaná hodnota která přijde z venčí
                Plnolety = true;
                if (vek < 18) { Plnolety = false; }
            }
        }

        public Student(string jmeno, bool pohlavi, int vek)
        {

            EditujStudenta(jmeno, pohlavi, vek);

        }

        public void EditujStudenta(string jmeno, bool pohlavi, int vek)
        {
            Jmeno = jmeno;
            Muz = pohlavi;
            Vek = vek;
        }
        ///////////////////////////////////// takhle nějak by to vypadalo bez vlastnosti

        /*
        private string jmeno;
        private int vek;
        private bool muz;
        private bool plnolety = false;

        public Student(string jmeno, string pohlavi, int vek)
        {

            this.jmeno = jmeno;
            this.vek = vek;
            if (pohlavi == "muz")
            {
                this.muz = true;
            }
            else if (pohlavi == "žena")
            {
                this.muz = false;
            }
            if (vek >= 18)
            {
                this.plnolety = true;
            }
        }

        public string VypisJmeno()
        {
            return jmeno;
        }

        public int VypisVek ()
        {
            return vek;
        }

        public bool VypisPohlavi()
        {
            return muz;
        }

        public bool VypisPlnoletost ()
        {
            return plnolety;
        }
        */
        public override string ToString()
        {
            string jsemPlnolety = "jsem";
            if (!Plnolety)
                jsemPlnolety = "nejsem";
            string pohlavi = "muž";
            if (!Muz)
                pohlavi = "žena";
            return String.Format("Jsem {0}, {1}. Je mi {2} let a {3} plnoletý.", Jmeno, pohlavi, Vek, jsemPlnolety);
        }
    }
}
