using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diar
{

    class Databaze
    {
        private List<Zaznam> zaznamy;
        public Databaze()
        {
            zaznamy = new List<Zaznam>();
        }

        public void PridejZaznam(DateTime datumCas, string text)
        {
            zaznamy.Add(new Zaznam(datumCas, text));
        }
        public List<Zaznam> NajdiZaznamy(DateTime datum, bool dleCasu)
        {

            List<Zaznam> nalezene = new List<Zaznam>();

            foreach(Zaznam z in zaznamy)
            {

                if (((dleCasu) && (z.DatumCas == datum)) || ((!dleCasu) && (z.DatumCas == datum.Date)))
                {

                    nalezene.Add(z);

                }

            }
            return nalezene;
        }

        public void VymazZaznamy(DateTime datum)
        {
            List<Zaznam> nalezeno = NajdiZaznamy(datum, true);
            foreach (Zaznam z in nalezeno)
                zaznamy.Remove(z);
        }

    }
}
