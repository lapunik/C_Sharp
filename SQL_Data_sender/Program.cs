using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SQL_Data_sender
{
    class Program
    {

        private static string received = ""; 

        public static SerialPort uart = new SerialPort();
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

        private static void DataReceived(object sender, SerialDataReceivedEventArgs e) // metoda která reaguje na přijmutá data po sériovém portu (vždy když se data dostaví a jsou smysluplná, uloží je do frony)
        {

            if (e.EventType == SerialData.Chars)
            {

                while ((uart.IsOpen) && (uart.BytesToRead > 0)) // dokud je co číst z portu a zároveň je pot otevřený tak prováděj cyklus
                {

                    received += String.Format("{0}",(char)uart.ReadByte());
                                        
                    if (received.Last() == '\n')
                    {

                        int value;

                        if (!int.TryParse(received, out value))
                        {
                            received = "";
                            return;
                        }

                        received = "";

                        Console.WriteLine("Temperature for database: {0}",value);

                        using (SqlConnection connection = new SqlConnection("Data Source=147.228.90.71;Initial Catalog=ase;Persist Security Info=True;User ID=ase;Password=ase")) // using blok abych nemusel dělat na konci dispose
                        {                                                                                                                                                                // connection string jsem ukradl v properties na serveru kae-virtual bla bla.. (heslo je ase)
                            connection.Open();

                            using (SqlCommand sqlCommand = connection.CreateCommand())
                            {

                                sqlCommand.Parameters.AddWithValue("@tep", value);

                                sqlCommand.CommandText = "INSERT INTO teploty(teplota,cas,stanice) VALUES (@tep, GETDATE(),1907)";

                                if (sqlCommand.ExecuteNonQuery() == 0)
                                {
                                    Console.WriteLine("FAILED");
                                }
                                

                            }

                            connection.Close();
                        }
                                                
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

                }

                Thread.Sleep(10);

            }

            Console.WriteLine("\nFinish");

            Console.ReadKey();

        }
    }
}
