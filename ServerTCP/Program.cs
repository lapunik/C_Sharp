using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServerTCP
{
    class Program
    {
        static byte[] data;
        static Socket socket;
        static void Main(string[] args)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // nový socket s IP adres rodinou, Socket type je pro TCP prostě Stream   


            socket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6666)); // nový IP koncový bod v nějaký IP adrese a nějakym portu, vubec nvim jak na tom záleží
      
            socket.Listen(1); // poslouchej 

            Console.WriteLine("Byl zapnut TCP server na adrese 127.0.0.1 s portem 6666");

            while (true)
            {
                Socket accepteddata = socket.Accept(); // nějakej novej socket pro přijatá data, přijmi data(asi)
                data = new byte[accepteddata.SendBufferSize]; // velikost byte pole data musí být stejně velká jako velikost zásobníku socketu přijatá data 
                int j = accepteddata.Receive(data); // předám přijatá data ze socketu accepteddata do bytového pole data (nejspíš tahle operace ještě vrácí kolik se dat přeneslo)
                byte[] adata = new byte[j]; // udělám si nové byte pole do kterého budu později kopírovat všechny data        
                for (int i = 0; i < j; i++) //  z proměné data ve které jsou přijatá data ze socketu, předám do nové proměné atada
                {
                    adata[i] = data[i];
                }
                string dat = Encoding.Default.GetString(adata); // dekóduje data jako string 
                Console.WriteLine(dat); // a vypíše v konzoli                          
            }
        }
    }
}