using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabazeUzivatelu
{
    class Uzivatel
    {

        public string jmeno;

        public int vek;

        public Uzivatel(string jmeno, int vek)
        {
            this.jmeno = jmeno;
            this.vek = vek;
        }

        public override string ToString()
        {
            return jmeno;
        }

    }
}
