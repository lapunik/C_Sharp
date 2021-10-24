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
    public partial class Menu : Form
    {
        public Menu() // Hlavní menu obsahuje pouze 4 tlačítka
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e) // Button exit pouze ukončí aplikaci
        {
            Close();
        }

        private void buttonDebug_Click(object sender, EventArgs e) // Tlačítko pro odlaďování
        {
            Visible = false; // zneviditelnění formuláře Menu

            using (Form1 form = new Form1("debug")) // zavolání Form1 v módu "debug" (Form 1 zůstane viditelný aby bylo možné posílat pakety natvrdo, číst přijaté pakety a na grafu vidět obsazenost úseků)
            {
                form.ShowDialog(); // zobraz formulář "Form1"
            }
            Visible = true; // znovuzviditelnění formuláře Menu
        }

        private void buttonTimetableControl_Click(object sender, EventArgs e) // Tlačítko pro jízdní řád
        {

            Visible = false; // zneviditelnění formuláře Menu

            using (Form1 form = new Form1("timetable")) // pouhé zavolání Form1 který poté vybere mód "timetable", ten zavolá formulář Timetable a Form1 nechá bežet neviditelný na pozadí
            {

            }
            Visible = true; // znovuzviditelnění formuláře Menu
        }

        private void buttonManualControl_Click(object sender, EventArgs e) // Tlačítko pro manuální řízení
        {

            Visible = false; // zneviditelnění formuláře Menu

            using (Form1 form = new Form1("manual")) // pouhé zavolání Form1 který zobrazí formulář "Manual" a sám zůstane běžet na pozadí neviditelný 
            {

            }
            Visible = true; // znovuzviditelnění formuláře Menu
        }
    }
}
