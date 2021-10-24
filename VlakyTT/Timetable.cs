using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VlakyTT
{
    public partial class Timetable : Form
    {
        BindingList<NoteInTimetable> timetable = null; // list ve kterém jsou uloženy informace o načteném jízdním řád
        BindingList<NoteInTimetable> timetableRecovery = null; // kopie jízdního na celý den 
        BindingList<NoteInTimetable> lastThreeConnections = new BindingList<NoteInTimetable>(); // list posledních tří spojů které už jely, ale i tak je chci mít zobrazené v jízdním řádu 

        public delegate void Operace(object sender, EventArgs e); // vytvořím si delegáta operace s dvěmi vstupními argumenty (budu totiž chtít použít metodu "timerSend_Tick" a "timerRead_Tick" z Form1)

        private Operace tickSend; // operace pro posílání z "Form1"
        private Operace tickRead; // operace pro přijmání z "Form1"
        private string pause = "timetable"; // v režimu jízdího řádu lze pomocí tlačítka "pause" stopnout činost, k tomu slouží tato proměná jako indikátor 

        public Timetable(BindingList<NoteInTimetable> notes, BindingList<NoteInTimetable> copy, Operace tickSend, Operace tickRead) // konstruktor třídy do kterého přichází jako vstupní argument jízdní řád a jeho kopie a fuknce z "Form1" pro timerSend a timerRead
        {
            InitializeComponent();
            timetable = notes; //uložíme jízdní řád do zdejší proměnné
            timetableRecovery = copy; // stejně tam i jeho kopii
            dataGridTimetable.DataSource = notes; // jako zdroj pro daztaGridViewTimetable použijeme jízdní řád
            LastThreeConnectionsRecovery(); // zjisti která poslední tři spojení jsem už zmeškal
            dataGridNow.DataSource = lastThreeConnections; // jako zdroj pro daztaGridViewNow použij právě list "lastThreeConnections"
            dataGridTimetable.Columns[3].DefaultCellStyle.Format = "HH:mm:ss"; // v jízdních řádek použij formát pro zobrazování času "HH:mm:ss" 
            dataGridNow.Columns[3].DefaultCellStyle.Format = "HH:mm:ss"; // stejně tak i u posledních tří spojení
            timer1.Enabled = true; // zapni časovač pro cylkus čtení a zápisu
            this.tickSend = tickSend; // obě metody které jsem získal jako vstupní argumenty z Formu1 si uložím do svých předpřipravených proměných Operace
            this.tickRead = tickRead;
           

        }

        private void LastThreeConnectionsRecovery() // funkce která najde v kopii jízdního řádu vždy jen tři poslední spojení které se vykonaly nebo se vykonávají a zobrazí je v dataGridVieNow
        {
            if (lastThreeConnections != null)
            {
                lastThreeConnections.Clear(); //pokud se proměná nerovná nule, vynuluj ji
            }
            int j = timetableRecovery.Count - timetable.Count-1; // najdi poslední spojení které v hlavním jízdním řádu už není 
            for (int i = 2; i >= 0; i--) // zobraz od spodu tři spojení až po spojení které popisuji o řádek výš
            {
                if ((j - i) >= 0) // pokud takové spojení existuje
                {
                    lastThreeConnections.Add(timetableRecovery[j - i]); // přidá ho do listu "lastThreeConnections"
                }
            }
        }
        public void timer1_Tick(object sender, EventArgs e) // funkce opakující se s intervalem 25ms, posílá příkazy do Formu1 a naopak od něj sbírá informace o obsazenosti
        {
           /* if (DateTime.Now.Second%1 == 0) // každou sekundu se obnuvují tři poslední spoje, aby byli aktuální
            {
                LastThreeConnectionsRecovery(); 
            }*/

            tickSend(pause, null); // metoda z Form1 pro odeslání zprávy             
            tickRead(null, null); // metoda z Form1 pro přijmání zprávy
            
            for (int i = 0; i < timetable.Count; i++) // promazávání všech vlaků z jízdího řádu které už jely
            {
                if (((timetable[i].Departure.Second < DateTime.Now.Second) && (timetable[i].Departure.Minute == DateTime.Now.Minute) && (timetable[i].Departure.Hour == DateTime.Now.Hour)) || (timetable[i].Departure.Hour < DateTime.Now.Hour) || ((timetable[i].Departure.Minute < DateTime.Now.Minute) && (timetable[i].Departure.Hour == DateTime.Now.Hour))) // šílená podmínka kter říká vlastně jen, pokud je čas v jízdním řadu menší než časa právě teď
                {
                   timetable.Remove(timetable[i]); //odstraň takový záznam v jízdním řádu
                   i--;
                   LastThreeConnectionsRecovery(); // Přepočítej poslední tři spojení
                }
            }
        }

        private void buttonStop_Click(object sender, EventArgs e) // klasické ukončení formuláře
        {
            Close();
        }

        private void buttonPause_Click(object sender, EventArgs e) // tlačítko "pause" zase pouze nastaví hodnotu logické proměné "pause" do logické nuly nebo jedničky, vyhodnocení pauzy probíhá ve funkci timerTick
        {
            if (pause == "timetable")
            {
                buttonPause.Text = "Start";
                pause = "pause";
            }
            else
            {
                buttonPause.Text = "Pause";
                pause = "timetable";
            }
        }

    }
}
