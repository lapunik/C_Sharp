using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Udp_Reciever_Sender
{
    class Reciever_Sender_Program
    {

        private static void Udp_Data_Receive(IAsyncResult ar)
        {
            UdpClient udp = ar.AsyncState as UdpClient;
            if (udp == null) // bezpecne pretypovani
            {
                return;
            }

            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0); // kterákoliv IP adresa
            byte[] data = udp.EndReceive(ar, ref iPEndPoint);

            Console.WriteLine("Prijato: {0}, od: {1}, {2}", DateTime.Now, iPEndPoint.Address, Encoding.ASCII.GetString(data));

            udp.BeginReceive(new AsyncCallback(Udp_Data_Receive), udp);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Receiver and Sender start");

            UdpClient udpClient = new UdpClient(1234); // má port, to znamnená že bude poslouchat
            // nemá žádný open! spouští se automaticky --> asynchroní příjem 

            udpClient.BeginReceive(new AsyncCallback(Udp_Data_Receive), udpClient); // když přijdou data zavolej mojí funkci: a k tomu referenci na Udp client
            byte[] adresa = new byte[] { 147, 228, 138, 115 };

            while (true)
            {
                string s = Console.ReadLine();

                if (s[0] == 'P')
                {
                    byte b;
                    if (byte.TryParse(s.Substring(1), out b))
                    {
                        adresa[3] = b;

                        Console.WriteLine("Nova IP adresa: {0}", String.Join(".",adresa));
                        continue;

                    }
                }

                s.Remove(0, 1);

                if (String.IsNullOrEmpty(s))
                {
                    break;
                }

                Console.WriteLine("Posilam: {0}", s);

                byte[] data = Encoding.ASCII.GetBytes(s); // ascii kodovani ze string  

                udpClient.Send(data, data.Length,new IPEndPoint(/*new IPAddress(adresa)*/IPAddress.Loopback, 1234));
            }



            Console.WriteLine("Receiver and Sender end");

        }
    }
}
