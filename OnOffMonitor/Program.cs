using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnOffMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            WinLowLevel.SetDisplayState(WinLowLevel.eMonitorState.On);

            Console.WriteLine("Monitor se uspí za 3s...");

            System.Threading.Thread.Sleep(3000);

            WinLowLevel.SetDisplayState(WinLowLevel.eMonitorState.Off);

            // System.Threading.Thread.Sleep(3000);

            // WinLowLevel.SetDisplayState(WinLowLevel.eMonitorState.Standby); // zustaň jak si

            System.Threading.Thread.Sleep(5000);

            Console.WriteLine("Monitor spal 5s...");

            WinLowLevel.SetDisplayState(WinLowLevel.eMonitorState.On);

            Console.ReadKey();
        }
    }
}
