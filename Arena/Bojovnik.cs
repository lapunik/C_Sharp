using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena
{
    class Bojovnik
    {
        /// <summary>
        /// Jméno bojovníka
        /// </summary>
        protected string jmeno;
        /// <summary>
        /// Život v HP
        /// </summary>
        protected int zivot;
        /// <summary>
        /// Maximální zdraví
        /// </summary>
        protected int zivotMax;
        /// <summary>
        /// Útok v HP
        /// </summary>
        protected int utok;
        /// <summary>
        /// Obrana v HP
        /// </summary>
        protected int obrana;
        /// <summary>
        /// Instance hrací kostky
        /// </summary>
        protected Kostka kostka;
        /// <summary>
        /// zprava o udolosti
        /// </summary>
        private string zprava;


        public Bojovnik(string jmeno, int zivot, int utok, int obrana,Kostka kostka)
        {
            /// <summary>
            /// Jmeno bojovnika
            /// <summary>
            this.jmeno = jmeno;
            /// <summary>
            /// Zivot bojovnika
            /// <summary>
            this.zivot = zivot;
            ///<summary>
            /// Maximalni zivot bojovnika
            /// <summary>
            this.zivotMax = zivot;
            /// <summary>
            /// utok bojovnika
            /// <summary>
            this.utok = utok;
            /// <summary>
            /// obrana bojovnika
            /// <summary>
            this.obrana = obrana;
            /// <summary>
            /// Kostka
            /// <summary>
            this.kostka = kostka;

        }

        public override string ToString()
        {
            return jmeno;
        }

        public bool Nazivu()
        {
            return (zivot > 0);
        }

        protected string GrafickyUkazatel(int aktualni,int maximalni)
        {
            string s="";
            int celkem = 20;
            double pocet = Math.Round(((double)aktualni / maximalni) * celkem);
            if ((pocet == 0) && (Nazivu()))
                pocet = 1;
            for (int i = 0; i < pocet; i++)
                s += "█";
            s = s.PadRight(celkem);
            return s;
        }

        public string GrafickyZivot()
        {
            return GrafickyUkazatel(zivot, zivotMax);
        }

        public void BranSe(int uder)
        {
            int zraneni = (uder - (obrana + kostka.Hod()));
            if (zraneni > 0)
            {
                zivot -= zraneni;
                zprava = String.Format("{0} utrpěl poškození {1} hp", jmeno, zraneni);
                if (zivot <= 0)
                {
                    zivot = 0;
                    zprava += " a zemřel";
                }
            } else
                zprava = String.Format("{0} odrazil útok", jmeno);
                NastavZpravu(zprava);

    }

        public virtual void Utoc(Bojovnik souper)
        {
            int uder = utok+kostka.Hod();
            NastavZpravu(String.Format("{0} útočí s úderem za {1} hp", jmeno, uder));
            souper.BranSe(uder);
        }

        protected void NastavZpravu(string zprava)
        {
            this.zprava = zprava;
        }

        public string VypisPosledniZpravu()
        {
            return zprava;
        }


    }
}
