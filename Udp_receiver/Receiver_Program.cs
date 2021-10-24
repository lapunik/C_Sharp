using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Udp_receiver
{
    class Receiver_Program
    {        
        private static void Udp_Data_Receive(IAsyncResult ar)
        {
            UdpClient udp = ar.AsyncState as UdpClient;
            if (udp == null) // bezpecne pretypovani
            {
                return;
            }

            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0); // kterákoliv IP adresa
            byte[] data = udp.EndReceive(ar,ref iPEndPoint);

            Console.WriteLine("Prijato: {0}, od: {1}, {2}",DateTime.Now,iPEndPoint.Address,Encoding.ASCII.GetString(data));

            udp.BeginReceive(new AsyncCallback(Udp_Data_Receive), udp);
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Receiver start");

            UdpClient udpClient = new UdpClient(1234); // má port, to znamnená že bude poslouchat
            // nemá žádný open! spouští se automaticky --> asynchroní příjem 

            udpClient.BeginReceive(new AsyncCallback(Udp_Data_Receive),udpClient); // když přijdou data zavolej mojí funkci: a k tomu referenci na Udp client



            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true); // Precte klavesnici, true = nezobrazuj na obrazovce, read key je blokující..kdybychom potrebovali je tady moznost KeyAliveble
                if ((consoleKeyInfo.Key == ConsoleKey.Q)||(consoleKeyInfo.Key == ConsoleKey.Escape))
                {
                    break;
                }
            }

            udpClient.Close();

            Console.WriteLine("Receiver end");

        }

    }
}
