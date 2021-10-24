using System;  
using System.Net;  
using System.Net.Sockets;  
using System.Text;  
using System.Threading;

namespace AsynchroniSocketServer
{
    public class AsynchronousSocketListener
    {
        // Vlákno signálu
        public static ManualResetEvent allDone = new ManualResetEvent(false); // událost
        
        public AsynchronousSocketListener()
        {

        }

        public static void StartListening() // metoda volaná na začátku spuštění této metody
        {
            // Vytvoření místního konečného bodu pro socket 
            // Název DNS počítače  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[1];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 8080);

            // Vytvoření TCP socketu
            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Spojení socketu s koncovým bodem a naslouchání příchozích spojení  
            try
            {
                listener.Bind(localEndPoint); // spoutání posluchače s koncovým bodem
                listener.Listen(100);

                while (true)
                {
                    // Nastavení události na stav "Reset"
                    allDone.Reset();

                    // Suštění asynchronního socketu k poslouchání připojení 
                    Console.WriteLine("Waiting for a connection...");
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);

                    // Čekání, dokud se nepřipojí některé zařízení 
                    allDone.WaitOne();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();

        }

        public static void AcceptCallback(IAsyncResult ar)   // Tato metoda se spustí, pokusí-li se připojit klient
        {
            // Signál hlavního vlákna k pokračování  
            allDone.Set();

            // Získání socketu která zpracovává požadavek klienta  
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Vytvoření objektu stavu 
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
        }
        
        public static void ReadCallback(IAsyncResult ar) // Tato metoda se spustí, přijdu-li data od klienta
        {
            String content = String.Empty;

            // Získání objektu stavu a handleru ze socketu 
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            // Přečtení dat z klientského socketu   
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                // // Mohlo by existovat více dat, takže ukládá přijatá data 
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                // Kontrola značky konce souboru. Pokud ho nenajde, čti další data
                content = state.sb.ToString();

                if (content.IndexOf("<EOF>") > -1) // jestli se tam někde vysytuje "<EOF>", signalizuje konec dat
                {
                    // Všechna data byla přečtena z klienta. Zobraz je na konzoli   
                    Console.WriteLine("Read {0} bytes from socket. \n Data : {1}", content.Length, content);
                    // Dej echo klientovi, že data
                    Send(handler, content);
                }
                else
                {
                    // Nebyli přijaty všechny údaje, získej víc  
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
                }
            }
        }
        
        private static void Send(Socket handler, String data)
        {
            // Převedení řetězec na byte pomocí kódování ASCI  
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Začátek odesílání dat do vzdáleného zařízení  
            handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), handler);
        }

        private static void SendCallback(IAsyncResult ar) // Tato metoda se spustí, pokouším-li se něco odeslat klientovi
        {
            try 
            {
                // načtení socketu z objektu stavu  
                Socket handler = (Socket)ar.AsyncState;

                // Dokončení odesílání dat na vzdálené zařízení
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static int Main(String[] args)
        {
            StartListening();
            return 0;
        }
    }
}
