
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace JizdniRadyZkouska
{
    class JizdniRady
    {
        public string Od { get; set; }
        public string Do { get; set; }
        public DateTime Odjezd { get; set; }
        public DateTime Prijezd { get; set; }

        public JizdniRady(string line)
        {

            if (String.IsNullOrEmpty(line))
            {
                return;
            }

            String[] polozky = line.Split(';');

            Od = polozky[0];
            Do = polozky[1];
            Odjezd = DateTime.ParseExact(polozky[2], "HH:mm", null);
            Prijezd = DateTime.ParseExact(polozky[3], "HH:mm", null);

        }


    }

}
