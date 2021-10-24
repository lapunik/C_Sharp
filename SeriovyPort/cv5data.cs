using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriovyPort
{
    public class cv5data : IFormattable
    {
        int poradi = 0;
        [DisplayName("Pořadí")]
        public int Poradi
        {

            get { return poradi; }
          // set { poradi = value; }

        }

        int[] data = new int[3];
        [DisplayName("Accel X")]
        public int DataX
        {
            get { return data[0]; }
            set { data[0] = value; }

        }
        [DisplayName("Accel Y")]
        public int DataY
        {
            get { return data[1]; }
            set { data[1] = value; }

        }
        [DisplayName("Accel Z")]
        public int DataZ
        {
            get { return data[2]; }
            set { data[2] = value; }

        }

        static char[] caSplit = new char[] { ';' };



        public cv5data(String line)
        {
            if (String.IsNullOrEmpty(line))
            {
                return;
            }


            String[] polozky = line.Split(caSplit);

            if (polozky.Length > 0)
            {
                if (!int.TryParse(polozky[0], out poradi))
                {
                    poradi = 0;
                }  
            }

            for (int i = 0; i < data.Length; i++)
            {

                if (polozky.Length > (i + 1))
                {

                    if (!int.TryParse(polozky[i + 1], out data[i]))
                    {
                        data[i] = 0;                     
                    }

                }
                else
                {

                    data[i] = 0;

                }

            }
        }

        public override string ToString()
        {
            return ToString(null, null);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("{0}: X={1} Y={2}  Z={3}", poradi, data[0], data[1], data[2]);

        }
    }
}
