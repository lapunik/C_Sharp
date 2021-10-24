using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTTLibrary;

namespace TimetableControlTrainTT
{
    public class DataForTimetable // data z hlavičky jízdního řádu, které říkají který vlak kde jezdí, jakou rychlostí atd..
    {
        public Locomotive Locomotive { get; set; } // název vlaku, musí korespondovat s aspoň jedním názvem vlaků které máme k dispozici (seznam ve třídě "Engine")
        public string Type { get; set; } // pracovní název vlaku, pod tímto názvem bude vlak uveden v jízdím řádu, nesmí se shodovat s názvem jiného vlaku
        public Section Station1 { get; set; } // pracovní název zastávky na prvním úseku, takto bude označená zasávka v jízdním řádu
        public Section Station2 { get; set; } // pracovní název dzastávky v druhém úseku
        public double Speed { get; set; } // Rychlost kterou se má vlak pohybovat pokud vykonává jízdní řád
        public bool Reverse1 { get; set; } // směr kterým má vlak dojet do druhého úseku (můžu tedy místo dokola jezdit tam a couvat zase zpět)
        public bool Reverse2 { get; set; } // směr kterým má vlak dojet do prvního úseku
        public uint WaitTime1 { get; set; } // určuje jak dlouho program počká s vysláním příkazu stop pro lokomotivu, když ho zaznamenal první úsek (aby stihli všechny vagony dojet na nástupiště)
        public uint WaitTime2 { get; set; } // určuje jak dlouho program počká s vysláním příkazu stop pro lokomotivu, když ho zaznamenal druhý úsek
        public string Line { get; set; }

        public DataForTimetable(string line) // konstruktor třídy
        {
            
            if (String.IsNullOrEmpty(line)) // pokud je řádek prázdný, rovnou ukonči metodu
            {
                return;
            }

            Line = line;

            String[] data = line.Split(';'); // rozdělí řádek s oddělovačem ";"

            Locomotive = new Locomotive(data[1].Trim()); //na indexu 0 je pouze indikátor hlavičky "***", s tím pracovat nepotřebujeme, ale na indexu jedna už je název vlaku (raději trimujeme)


            Type = data[2].Trim();
            Station1 = new Section(data[3].Trim());
            Station2 = new Section(data[4].Trim());
            Speed = double.Parse(data[5]);
            Reverse1 = (data[6].Trim() == "ahead") ? false : true; 
            Reverse2 = (data[7].Trim() == "ahead") ? false : true;
            WaitTime1 = uint.Parse(data[8]);
            WaitTime2 = uint.Parse(data[9]);
        }
        public DataForTimetable(Locomotive locomotive, string type, Section section1, Section section2, double speed, bool reverse1, bool reverse2, uint waitTime1, uint waitTime2) // konstruktor třídy
        {
            Locomotive = locomotive;
            Type = type;
            Station1 = section1;
            Station2 = section2;
            Speed = speed;
            Reverse1 = reverse1;
            Reverse2 = reverse2;
            WaitTime1 = waitTime1;
            WaitTime2 = waitTime2;

            Line = String.Format("***;{0};{1};{2};{3};{4};{5};{6};{7};{8}", locomotive.Name, type, section1.Name, section2.Name,Speed,((!reverse1)?"ahead":"reverse"), ((!reverse2) ? "ahead" : "reverse"),waitTime1,waitTime2);
        }
    }

    public class NoteInTimetable
    {

        public string Type { get; set; } // vlastnost typu vlaku (v podstatě pouze pracovní název spoje)
        [DisplayName("Start station")] // Aby se v dataGridView napsala mezi slovy mezera
        public Section StartStation { get; set; } // vlastost říkající od kud vlak vyjíždí
        [DisplayName("Final station")]
        public Section FinalStation { get; set; } // vlastost říkající kam vlak jede
        public DateTime Departure { get; set; } // čas odjezdu

        public string Line;

        public NoteInTimetable(string line) // konstruktor třídy
        {

            if (String.IsNullOrEmpty(line)) // nejprve se zjistí zda řádek z jízdního řádu není prázdný
            {
                return; // pokud je, rovnou konstrktor končí
            }

            Line = line;

            String[] data = line.Split(';'); // rozdělím data s oddělovačem ";"

            Type = data[0]; // přiřazení informací z řádku do jednotlivých proměných ( string trimuji a časová data parsuji) 
            StartStation = new Section(data[1].Trim());
            FinalStation = new Section(data[2].Trim());
            Departure = DateTime.Parse(data[3]);
        }

        public NoteInTimetable(string type, Section startSection, Section finalSection, DateTime departure)
        {
            Type = type;
            StartStation = startSection;
            FinalStation = finalSection;
            Departure = departure;

            Line = String.Format("{0};{1};{2};{3}",type,startSection,finalSection,departure.ToString("HH:mm:ss"));

        }



    }
}
