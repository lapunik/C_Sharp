using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena
{
    class Mag : Bojovnik
    {
        private int mana;

        private int manaMax;

        private int magickyUtok;

        public Mag(string jmeno, int zivot, int utok, int obrana, Kostka kostka, int mana, int magickyUtok) : base(jmeno, zivot, utok, obrana, kostka)
        {
            this.mana = mana;
            this.manaMax = mana;
            this.magickyUtok = magickyUtok;
        }

        public override void Utoc(Bojovnik souper)
        {
            int uder = 0;
            // Mana není naplněna
            if (mana < manaMax)
            {
                mana += 10;
                if (mana > manaMax)
                    mana = manaMax;
                uder = utok + kostka.Hod();
                NastavZpravu(String.Format("{0} útočí s úderem za {1} hp", jmeno, uder));
            }
            else // Magický útok
            {
                uder = magickyUtok + kostka.Hod();
                NastavZpravu(String.Format("{0} použil magii za {1} hp", jmeno, uder));
                mana = 0;
            }
            souper.BranSe(uder);
        }

        public string GrafickaMana()
        {
            return GrafickyUkazatel(mana, manaMax);
        }


    }
}
