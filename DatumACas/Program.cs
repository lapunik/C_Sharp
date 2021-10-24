using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatumACas
{
    class Program
    {
        static void Main(string[] args)
        {

            DateTime datumCas = new DateTime(2018,9,1,21,8,0); // manuálně

            datumCas = DateTime.Now; // současný

            Console.WriteLine(datumCas);

            Console.WriteLine(datumCas.Month);  // přístup k jednotlivým složkám (Day,Mouth, Year, Hour, Minute, Second, Milisecond, Ticks(desetina milionu vteřiny) )

            Console.WriteLine(datumCas.DayOfWeek); // (DayofYear)

            Console.WriteLine(datumCas.AddDays(3)); // + 3 dny, nemneni v instanci, pouze pro tento vypis.... (Day,Mouth, Year, Hour, Minute, Second, Milisecond, Ticks(desetina milionu vteřiny) )

            Console.WriteLine(datumCas.IsDaylightSavingTime()); 

            Console.WriteLine(DateTime.DaysInMonth(2018,9)); // statické metody(proto DateTime.BlaBla) (IsLeapYear(2018) je prestupny rok?,)

           // DateTime datum = DateTime.Parse(Console.ReadLine()); // z klavesnice

           // Console.WriteLine(datum);

            Console.WriteLine(datumCas.ToString("dd. MMMM yyyy")); //vypis jak chceme

            Console.WriteLine(datumCas.ToLongTimeString()); // (ToShortTimeString, -//- Date -//-)

            Console.ReadKey();
            /////////////////////////////////////////////////////////
            Console.WriteLine("Zadej datum narození: ");
            DateTime narozen = DateTime.Parse(Console.ReadLine());
            TimeSpan vek = DateTime.Today - narozen;
            Console.WriteLine("Je ti {0} let", Math.Floor(vek.Days / 365.255));
            Console.WriteLine("To je ve dnech {0} a v hodinách {1}", vek.TotalDays, vek.TotalHours);
            Console.ReadKey();

        }
    }
}
