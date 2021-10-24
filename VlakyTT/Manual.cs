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
    public partial class Manual : Form // formulář pro ovládání vlaků manuálně (lze je ovládat i přes debug, ale to je pro uživatele neznalého nepřijemné)
    {
        private List<Engine> listEngines = new List<Engine>(); // vytvořím si seznam lokomotiv
        public delegate void Operace(object sender, EventArgs e); // dále si vytvořím delegáta operace s dvěmi vstupními argumenty (budu totiž chtít použít metodu "timerSend_Tick" z Form1)       
        private Operace tickSend; 
        private bool pause = false; // v manuálním režimu lze pomocí tlačítka "pause" stopnout činost aniž by nám zmizely naše nastavené vlaky a jejich hodnoty směru a rychlostí, o tom jestli tlačítko bylo či nebylo zmáčknuto rozhoduje tato proměná
               
        public Manual(Operace tickSend) // konstruktor formuláře se vstupním agrumentemnázev funkce
        {
            InitializeComponent();
            this.tickSend = tickSend; // jak jsme již řekli, voláme si z Form1 funki tickSend, takže ji zde pouze uložíme do naší předpřipravené Operace
        }

        private void Manual_Load(object sender, EventArgs e) // při načtení formuláře 
        {
            for (int i = 0; i < 13; i++)
            {
                listEngines.Add(new Engine(null)); // dochází k nahrání všech lokomotiv do seznamu lokomotiv
                listEngines[i].Name = listEngines[0].listOfEngines[i]; // a přiřazení jejich jmen, aby se jim ve třídě Engine přiřadili ID                
                timer1.Enabled = true; // zapnutí časovače pro odesílání dat
            }            
        }

        private void buttonDirection_Click(object sender, EventArgs e) // zmáčknutí některého z tlačítek "Direction"
        {
            Button button = sender as Button;
            if (button == null) // bezpečné přetypování
            {
                return;
            }

            int tag = int.Parse(button.Tag.ToString());

            if (listEngines[tag].Direction == 1) // nastaví se hodnota směru na opačnou, která právě teď je (podrobněji ve Form1)
            {
                listEngines[tag].Direction = 0;
                button.Text = String.Format("Backward");
            }
            else
            {
                listEngines[tag].Direction = 1;
                button.Text = String.Format("Forward");
            }
        }

        private void trackBarSpeed_Scroll(object sender, EventArgs e) // obdobně jako u směru, pouze teď je to trackbar a nastavuje rchlost, více ve Form1
        {

            TrackBar trackBar = sender as TrackBar;
            if (trackBar == null)
            {
                return;
            }

            int tag = int.Parse(trackBar.Tag.ToString());

            listEngines[tag].Speed = trackBar.Value;

        }

        private void buttonStart_Click(object sender, EventArgs e) // tlačítko které, buď zumožní odelílat zprávy pomocí timeru, nebo naopak zastaví vlak  
        {
            Button button = sender as Button;
            if (button == null) // bezpečné přetypování
            {
                return;
            }

            int tag = int.Parse(button.Tag.ToString());

            if (button.Text == "Start") // nastavení příslušného tlačítka do příslušné polohy
            {
                button.Text = String.Format("Stop");
                button.BackColor = Color.Maroon;
            }
            else // situace kdy některý vlak jel a já ho chci zastavit
            {
                button.Text = String.Format("Start");
                button.BackColor = Color.ForestGreen;

                string message = ""; // pro lepší zastavení není vhodné prostě přestat posílat pakety pro jízdu, ale poslat paket s nulovou rychlostí, to se děje zde
                int speed = listEngines[tag].Speed; // vytvořím si proměnou "speed" abych neztratil nasavenou rychlost vlaku
                listEngines[tag].Speed = 0; // rychlost vlaku ale vynuluji
                message += listEngines[tag].Message + " "; // a do zprávy která se má poslat vložím zprávu konkrétního vlaku který jsem nastavoval
                listEngines[tag].Speed = speed; // vrátíme mu vlaku rychlost, ač osílat budeme zprávu s rychlostí nulovou, je to proto aby vlak dostal zprávu s nulovou rychlostí a zastavil ale zároveň aby na track baru zůstala jeho rychlost nastavená a já při zmáčknutí tlačítka start rovnou vlak zase rozjel a nemusel mu nastavovat rychlost znovu

                tickSend(message, null); // volej funkci tickSend (z Form1) se senderem jako string proměná ve které je uložená zpráva pro zastavení
            }
        }

        private void timer1_Tick(object sender, EventArgs e) // metoda vykonávná s každým tiknutím
        {
            string message = ""; // zavedení string proměné zpráva
            
            for(int i = 0;i<listEngines.Count;i++)
            {

                Button button = (tablePanelStart.Controls[12-i] as Button);

                if (button.Text != "Start") // prozkoumání všech tlačítek a zjištění, jestli jsou v režimu jeď nebo stůj
                {
                    int speed = listEngines[i].Speed; // deklarace promněné speed, kam si uložíme rychlost pro případ že by byla pauza a já musel místo rychlosti posílat zprávu o zastavení, ale hodnotu nastavené rychlosti přitom nechtěl ztratit

                    if (pause) // pokud je aktivní pauza
                    {
                        listEngines[i].Speed = 0; // nastav rychlost vlaku na 0                        
                    }

                    message += listEngines[i].Message + " "; // a do string proměné message zapiš zprávu konkrétního vlaku
                    listEngines[i].Speed = speed; // nastav rychlost zpět
                }                                
            }            
            tickSend(message,null); // odešli zprávu do metody tickSend (z Form1)
        }

        private void pictureBox_Click(object sender, EventArgs e) // u jmen vlaků jsou obrázky vlaků pro zjednodušenou identifikaci, po kliknutí na obrázek se otevře formulář ze zvětšeným obrázkem, tak aby si mohl člověk vlak pořádně prohlédnout
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox == null) // bezpečné přetypování senderu na pictureBox
            {
                return;
            }
            using (Picture form = new Picture(pictureBox.Image))
            {
                form.image = pictureBox.Image; // nastavení obrázku v otevíraném formuláři na obrázek který akci vyvolal
                form.ShowDialog(); // zobraz formulář
            }
        }

        private void buttonClose_Click(object sender, EventArgs e) // tlačítko Close jednoduše zavře formulář "Manual"
        {
            Close(); 
        }

        private void buttonPause_Click(object sender, EventArgs e) // tlačítko "pause" zase pouze nastaví hodnotu logické proměné "pause" do logické nuly nebo jedničky, vyhodnocení pauzy probíhá ve funkci timerTick
        {
            if (!pause)
            {
                buttonPause.Text = "Start";
                pause = true;
            }
            else
            {
                buttonPause.Text = "Pause";
                pause = false;
            }
        }
    }
}
