using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ClientTCP
{
    class Program
    {

        static void Main(string[] args)
        {

            while (true)
            {
                Console.Write("Zadej text : ");
                string q = Console.ReadLine();

                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


                try
                {
                    s.Connect(IPAddress.Parse("127.0.0.1"), 6666);

                    byte[] data = Encoding.Default.GetBytes(q);
                    int i = s.Send(data);

                }
                catch
                {

                }

            }
        }
    }
}