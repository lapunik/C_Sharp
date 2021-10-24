using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Udp_sender
{
    class Sender_Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Sender start");

            UdpClient u = new UdpClient(); // prazdny UDP --> sender

            u.Connect(IPAddress.Loopback,1234); // 1234 = port, už jsem zadal end point, takže nemusím zadávat u u .Send, Loopback(--> sám sobě) 

            //192.168.1.60

            while (true)
            {
                string s = Console.ReadLine();

                if (String.IsNullOrEmpty(s))
                {
                    break;
                }

                Console.WriteLine("Posilam: {0}",s);

                byte[] data = Encoding.ASCII.GetBytes(s); // ascii kodovani ze string  

                u.Send(data, data.Length);
            }
            Console.WriteLine("Sender end");

        }
    }
}
