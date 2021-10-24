using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Linq;


namespace TcpTestServer
{
    class TcpTestServer
    {

        static void Main(string[] args)
        {
            // Listener umožňuje přijímat připojující se klienty
            TcpListener listener = null;
            try
            {
                listener = new TcpListener(IPAddress.Any, 8080);
                listener.Start();
            }
            catch (SocketException se)
            {
                Console.WriteLine(se.ErrorCode + ": " + se.Message);
                Environment.Exit(se.ErrorCode);
            }

            List<TcpClient> klienti = new List<TcpClient>();
            List<string> prezdivky = new List<string>();

            Console.WriteLine("Server běží, čekám na 2 klienty");
            // Připojení klientů
            while (klienti.Count < 2)
            {
                try
                {
                    // Někdo čeká na připojení
                    if (listener.Pending())
                    {
                        // Vrátí klienta, co se připojuje
                        TcpClient klient = listener.AcceptTcpClient(); 
                        klienti.Add(klient);
                        // Čeká na poslání přezdívky
                        string prezdivka = PosilacRetezcu.PrijmiString(klient); 
                        prezdivky.Add(prezdivka);
                        Console.WriteLine("Klient {0} se připojil", prezdivka);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("Připraveno pro chat");

            // Hlavní cyklus
            while (true)
            {
                foreach (TcpClient klient in klienti)
                    try
                    {
                        // Přijetí zprávy od klienta
                        if (klient.GetStream().DataAvailable)
                        {
                            string zprava = PosilacRetezcu.PrijmiString(klient);
                            // Poslání zprávy všem ostatním
                            foreach (TcpClient k2 in klienti)
                            {
                                if (k2 != klient)
                                {
                                    PosilacRetezcu.PosliString(k2, zprava);
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
            }

        }
    }
}
