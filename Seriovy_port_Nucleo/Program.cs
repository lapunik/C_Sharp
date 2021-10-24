using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seriovy_port_Nucleo
{
    class Program
    {

        private static List<char> listReceived = new List<char>();

        private static List<char> listSend = new List<char>();

        public static SerialPort uart = new SerialPort();
       
       ////////////////////////////////////////////////////////////////////////////
       
        private static bool OpenSerialPort()
        {

            uart.PortName = "COM5";

            try
            {
                uart.BaudRate = 38400;
                uart.Open();
                uart.DataReceived += DataReceived;
                Console.WriteLine(uart.PortName + " " + uart.IsOpen);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Port is closed");
                return false;
            }

        }

        private static void SendData(List<char> p)
        {
            Console.WriteLine("\nData send: ");

            for (int i = 0; i < listSend.Count; i++)
            {
                Console.Write(listSend[i]);
            }

            p.Add('\n'); //příznak ukončení zprávy

            char[] array = p.ToArray();

            for (int i = 0; i < p.Count; i++)
            {
                uart.Write(array, 0, array.Length);

            }

            listSend.Clear();


        }

        private static void DataReceived(object sender, SerialDataReceivedEventArgs e) // metoda která reaguje na přijmutá data po sériovém portu (vždy když se data dostaví a jsou smysluplná, uloží je do frony)
        {

            if (e.EventType == SerialData.Chars)
            {

                while ((uart.IsOpen) && (uart.BytesToRead > 0)) // dokud je co číst z portu a zároveň je pot otevřený tak prováděj cyklus
                {
                    listReceived.Add((char)uart.ReadByte());
                    // Console.WriteLine("Data received: " + (char)byteList[byteList.Count - 1]);

                    if (listReceived[listReceived.Count - 1] == '\n')
                    {
                        // Console.Write("Data received: ");
                        for (int i = 0; i < listReceived.Count; i++)
                        {
                            Console.Write(listReceived[i]);
                        }
                        listReceived.Clear();
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Start App");

            if (!OpenSerialPort())
            {
                Console.ReadKey();
                Environment.Exit(0);

            }

            bool bbLoop = true;
            while (bbLoop)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);

                    if (consoleKeyInfo.Key == ConsoleKey.Escape)
                    {
                        bbLoop = false;
                        break;
                    }
                    if (consoleKeyInfo.Key == ConsoleKey.Enter)
                    {
                        SendData(listSend);
                    }

                    listSend.Add(consoleKeyInfo.KeyChar);

                }

                Thread.Sleep(10);

            }

            Console.WriteLine("\nFinish");

            Console.ReadKey();
        }
    }
}
