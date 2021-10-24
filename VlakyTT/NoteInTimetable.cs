using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VlakyTT
{
    public class NoteInTimetable
    {
       
        public string Type { get; set; } // vlastnost typu vlaku (v podstatě pouze pracovní název spoje)
        [DisplayName("Start station")] // Aby se v dataGridView napsala mezi slovy mezera
        public string StartStation { get; set; } // vlastost říkající od kud vlak vyjíždí
        [DisplayName("Final station")]
        public string FinalStation { get; set; } // vlastost říkající kam vlak jede
        public DateTime Departure { get; set; } // čas odjezdu


        public NoteInTimetable(string line) // konstruktor třídy
        {

            if (String.IsNullOrEmpty(line)) // nejprve se zjistí zda řádek z jízdního řádu není prázdný
            {
                return; // pokud je, rovnou konstrktor končí
            }

            String[] data = line.Split(';'); // rozdělím data s oddělovačem ";"

            Type =  data[0]; // přiřazení informací z řádku do jednotlivých proměných ( string trimuji a časová data parsuji) 
            StartStation = data[1].Trim();
            FinalStation = data[2].Trim();
            Departure = DateTime.Parse(data[3]);
        }


    }
}
