using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VlakyTT
{
    class DataForTimetable // data z hlavičky jízdního řádu, které říkají který vlak kde jezdí, jakou rychlostí atd..
    {        
        public string Train { get; set; } // název vlaku, musí korespondovat s aspoň jedním názvem vlaků které máme k dispozici (seznam ve třídě "Engine")
        public int Section1 { get; set; } // prví úsek, na kterém bude lokomotiva zastavovat, musím mít příslušnou lokomotivu na příslušném okruhu, jinak fyzicky nikdy na úsek nedojede
        public int  Section2 { get; set; } // druhý úsek na kterém bude lokomotiva zastavovat
        public string Type { get; set; } // pracovní název vlaku, pod tímto názvem bude vlak uveden v jízdím řádu, nesmí se shodovat s názvem jiného vlaku
        public string Station1 { get; set; } // pracovní název zastávky na prvním úseku, takto bude označená zasávka v jízdním řádu
        public string Station2 { get; set; } // pracovní název dzastávky v druhém úseku
        public double Speed { get; set; } // Rychlost kterou se má vlak pohybovat pokud vykonává jízdní řád
        public string Direction1 { get; set; } // směr kterým má vlak dojet do druhého úseku (můžu tedy místo dokola jezdit tam a couvat zase zpět)
        public string Direction2 { get; set; } // směr kterým má vlak dojet do prvního úseku
        public int WaitTime1 { get; set; } // určuje jak dlouho program počká s vysláním příkazu stop pro lokomotivu, když ho zaznamenal první úsek (aby stihli všechny vagony dojet na nástupiště)
        public int WaitTime2 { get; set; } // určuje jak dlouho program počká s vysláním příkazu stop pro lokomotivu, když ho zaznamenal druhý úsek

        public DataForTimetable(string line) // konstruktor třídy
        {

            if (String.IsNullOrEmpty(line)) // pokud je řádek prázdný, rovnou ukonči metodu
            {
                return;
            }

            String[] data = line.Split(';'); // rozdělí řádek s oddělovačem ";"

            Train = data[1].Trim(); //na indexu 0 je pouze indikátor hlavičky "***", s tím pracovat nepotřebujeme, ale na indexu jedna už je název vlaku (raději trimujeme)
            Section1 = int.Parse(data[2]); // dále jen příslušné proměnné plním hodnotami z řádku, případně přetypovávám nebo trimuji
            Section2 = int.Parse(data[3]);
            Type = data[4].Trim();
            Station1 = data[5].Trim();
            Station2 = data[6].Trim();
            Speed = double.Parse(data[7]);
            Direction1 = data[8].Trim();
            Direction2 = data[9].Trim();
            WaitTime1 = int.Parse(data[10]);
            WaitTime2 = int.Parse(data[11]);
        }
    }
}
