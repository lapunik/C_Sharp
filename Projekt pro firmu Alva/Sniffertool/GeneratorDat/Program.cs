using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeneratorDat
{
    class Program
    {

        private static List<SerialPort> serial_ports_list = new List<SerialPort>(); // List pěti sériových portů

        private static List<string> mess_list = new List<string>();

        private static DateTime head_time = new DateTime();

        private static Random r = new Random();
        
        private static bool OpenSerialPort(int num)
        {

            if (serial_ports_list.ElementAt(num).IsOpen)
            {
                return true;
            }

            serial_ports_list.ElementAt(num).PortName = ("COM" + ((num * 2) + 101));

            try
            {
                serial_ports_list.ElementAt(num).Open();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        private static void SendSerialData(string mess, int num)
        {
            serial_ports_list[num].Write(mess + "\n");
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Start App");

            for (int i = 0; i < 5; i++)
            {
                serial_ports_list.Add(new SerialPort());

                if (!OpenSerialPort(i))
                {
                    Console.ReadKey();
                    Environment.Exit(0);

                }

            }
            head_time = DateTime.UtcNow;
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

                    if (consoleKeyInfo.Key == ConsoleKey.P)
                    {
                        bool bbLoop2 = true;

                        Console.WriteLine("\nPause\n");

                        while (bbLoop2)
                        {

                            if (Console.KeyAvailable)
                            {
                                ConsoleKeyInfo consoleKeyInfoo = Console.ReadKey(true);

                                if (consoleKeyInfoo.Key == ConsoleKey.P)
                                {

                                    bbLoop2 = false;
                                    break;

                                }
                            }

                        }

                    }
                }
                if (mess_list.Count > 0)
                {

                    //////////
                    ///

                    TimeSpan timeSpan = DateTime.UtcNow - head_time;

                    uint time = (uint)(timeSpan.Milliseconds + (timeSpan.Seconds * 1000) + (timeSpan.Minutes * 60000) + (timeSpan.Hours * 3600000));

                    time /= 10;

                   // if (time > 1000)
                   // {
                   //     time = 0;
                   //     head_time = DateTime.UtcNow;
                   // }
                    

                    string str = String.Format("{0}",Convert.ToString(time, 16));

                    while(str.Length < 4)
                    {
                        str = "0" + str;
                    }
                    
                    mess_list[0] = mess_list[0].Substring(0, 2) + " " + str.Substring(2, 2) + " " + str.Substring(0, 2) + mess_list[0].Substring(5);

                    /// 
                    //////////

                    char o = mess_list[0][0];

                    SendSerialData(mess_list[0], (mess_list[0])[0] - 48);

                    Console.WriteLine(mess_list[0]);

                    mess_list.RemoveAt(0);

                    Thread.Sleep(50 + (r.Next(0, 10))*10);
                }
                else
                {
                    Load_data_from_file("SniffLog_2020-07-02_08-05.txt");
                }

            }
            Console.WriteLine("\nFinish");

            Console.ReadKey();

        }

        private static void Load_data_from_file(string s)
        {

            String fileName = String.Empty;

            fileName = s;

            String[] lines = File.ReadAllLines(fileName, Encoding.GetEncoding("Windows-1250"));

            mess_list.AddRange(lines);
        }
    }
}
