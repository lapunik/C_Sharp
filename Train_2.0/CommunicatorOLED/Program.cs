using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainTTLibrary;
using System.IO.Ports;
using CommunicatorOLED.Properties;

namespace CommunicatorOLED
{
    class Program
    {
        private static TCPClient client = null;
        private static bool IsConnect = false;
        private static SerialPort serialPort = new SerialPort();

        private static void ConnectToSerialPort()
        {
            try
            {

                serialPort.PortName = Settings.Default.Port;
                serialPort.BaudRate = 38400;
                serialPort.Open();
                serialPort.DataReceived += SerialDataReceived;

                Console.WriteLine(String.Format("Connected to Nucleo on serial port: {0}", serialPort.PortName));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                Console.ReadKey();

                Environment.Exit(0);

            }
        }

        private static bool StartTCPClient()
        {

            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[1];

            client = new TCPClient(ipAddress, 8080);

            client.DataType = eRecvDataType.dataStringNL;
            client.OnClientConnected += ClientConnected;
            client.OnClientDisconnected += TCPDisconnectClient;
            client.DataReceived += TCP_DataRecv;
            
            if (!client.Connect())
            {
                ClientCleanUp();
                return false;
            }
            else
            {
                Console.WriteLine("TCP client conected on port " + 8080);
                return true;
            }

        }

        private static void ClientConnected(object sender, TCPClientConnectedEventArgs e)
        {

            if (e == null)
            {
                IsConnect = false;

                ClientCleanUp();

            }
            else
            {
                IsConnect = true;
            }


        }

        private static void ClientCleanUp()
        {
            if (client != null)
            {
                client.Disconnect();

                client.OnClientConnected -= ClientConnected;
                client.DataReceived -= TCP_DataRecv;
                client.OnClientDisconnected -= TCPDisconnectClient;

                client.Dispose();
                client = null;
            }

        }

        private static void TCP_DataRecv(object sender, TCPReceivedEventArgs e)
         {
            if (e.data is String)
            {
                String s = e.data as String;

                 if (Packet.RecognizeTCPType(s) == Packet.dataType.oled_info) 
                   {

                      OLEDInformationPacket oLEDInformationPacket = new OLEDInformationPacket(s);

                      serialPort.Write(String.Format("{0}\n", oLEDInformationPacket.Time));

                    //  serialPort.Write("reset\n");
                    
                   } 

            }

        }
               
        private static void TCPDisconnectClient(object sender, TCPClientConnectedEventArgs e)
        {
            IsConnect = false;
        }

        private static void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            if (e.EventType == SerialData.Chars)
            {

                while ((serialPort.IsOpen) && (serialPort.BytesToRead > 0)) // dokud je co èíst z portu a zároveò je pot otevøený tak provádìj cyklus
                {
                    //...
                }     
            }

        }

        static void Main(string[] args)
        {

            while (!StartTCPClient())
            {
                Thread.Sleep(100);
            }

            ConnectToSerialPort();

            bool bbLoop = true;
            while (bbLoop)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);

                    if (cki.Key == ConsoleKey.Q)
                    {

                        bbLoop = false;
                        break;

                    }

                    if (cki.Key == ConsoleKey.B)
                    {

                        client.Send("Ahoj");

                    }
                }

                Thread.Sleep(10);

            }

            Console.WriteLine("\nFinish");

            client.Dispose();
            client = null; // client
        }
    }
}
