using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRC
{
    class Program
    {
        private static byte VypocetCRC(List<byte> paket) // výpočet CRC
        {
            byte crc = 0;
            byte icrc, ucrc;

            byte CRC_POLYNOM = 0xd8;
            byte TOP_BIT = 0x80;

            for (ucrc = 0; ucrc < paket.Count; ucrc++)
            {
                crc ^= paket[ucrc];

                for (icrc = 8; icrc > 0; --icrc)
                {


                    if ((crc & TOP_BIT) != 0)
                    {
                        crc = (byte)(crc << 1);
                        crc = (byte)(crc ^ CRC_POLYNOM);
                    }
                    else
                    {
                        crc <<= 1;
                    }
                }
            }

            return (byte)crc;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                string str = Console.ReadLine();

                string[] st = str.Split(' ');

                List<byte> s = new List<byte>();

                for (int i = 0; i < st.Length; i++)
                {
                    s.Add(Convert.ToByte(st[i], 16));
                }

                byte crc = VypocetCRC(s);

                Console.WriteLine("{0}   (0x{1:X})", crc, crc);

                Console.ReadKey();
            }
        }
    }
}