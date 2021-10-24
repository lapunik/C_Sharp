using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace AsynchroniSocketKlient
{
    public class AsynchronousClient
    {
        // Číslo portu vzdáleného zařízení 
        private const int port = 8080;

        // Instance událostí
        private static ManualResetEvent connectDone = new ManualResetEvent(false);
        private static ManualResetEvent sendDone = new ManualResetEvent(false);
        private static ManualResetEvent receiveDone = new ManualResetEvent(false);

        // Odpoveď ze vzdáleného zařízení 
        private static String response = String.Empty;

        private static void StartClient()
        {
            // Zkus se připojit ke vzdálenému zařízení
            try
            {
                // Vytvoření vzdáleného koncového bodu pro socket   
                // Vzdálené zařízení je tento počítač na nějaké ip, tady potom bude potřeba nějaký "xyz.com"   
                   IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                   IPAddress ipAddress = ipHostInfo.AddressList[1];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress,port);

                // Vytvoření socketu
                Socket client = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                // Připojení na vzdálený bod  
                client.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), client);
                connectDone.WaitOne();

                // Odeslání dat do vzdáleného zařízení  
                Send(client, "This is a test<EOF>");
                sendDone.WaitOne();

                // Získání odpovědi ze vzdáleného zařízení  
                Receive(client);
                receiveDone.WaitOne();

                // Odpověď vypiš na konzoli  
                Console.WriteLine("Response received : {0}", response);

                // Uvolnit zásuvku
                client.Shutdown(SocketShutdown.Both);
                client.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Načtení zásuvky ze stavu objektu  
                Socket client = (Socket)ar.AsyncState;

                // Dokončení připojení
                client.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}",
                    client.RemoteEndPoint.ToString());

                // Signál, že připojení bylo provedeno  
                connectDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Receive(Socket client)
        {
            try
            {
                // Vytvoření stavu objekt  
                StateObject state = new StateObject();
                state.workSocket = client;

                // Začátek přijmání dat ze vzdáleného zařízení  
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Načtení objektu stavu a klientova socketu z asynchronního stavu objektu      
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;

                // Přečtení dat ze vzdáleného zařízení  
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // Mohlo by existovat více dat, takže ukládá přijatá data 
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                    // Získání zbytku dat  
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    // Ne všechna data přišla, pošli odezvu  
                    if (state.sb.Length > 1)
                    {
                        response = state.sb.ToString();
                    }
                    // Signál že byli přijaty všechny data
                    receiveDone.Set();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Send(Socket client, String data)
        {
            // Převedení dat řetězce na data byte pomocí kódování ASCII  
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Začátek odesílání dat do vzdálen´ého zařízení  
            client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), client);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Načtení socketu ze stavu objektu  
                Socket client = (Socket)ar.AsyncState;

                // Dokončení odeslání dat na vzdálené zařízení 
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signál že všechny byte byli odeslány 
                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static int Main(String[] args)
        {
            StartClient();
            return 0;
        }
    }
}
