using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lode
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        Color barvaLode = Color.Black;

        Color barvaVody = Color.LightSteelBlue;

        public Form1()
        {
            InitializeComponent();
        }

        private int VlozLod(int pocetLodi,int pocitadloLodi,int x1, int x2, int y1, int y2)
        {
            int x;
            int y;

            int pojistka = 0;

            while (pocetLodi > 0)
            {
                pojistka++;
                x = random.Next(1, 9-x2);
                y = random.Next(1, 9-y2);

                bool jeMisto = true;

                foreach (Button button in tablePanelHraciPlocha.Controls)
                {
                    for (int i = x1-1; i < x2 + 2; i++)
                    {
                        for (int j = y1-1; j < y2 + 2; j++)
                        {
                            if (button.Tag.ToString() == ((x+i) + "," + (y+j)))
                            {

                                if (button.BackColor == barvaLode)
                                {
                                    jeMisto = false;
                                }

                            }
                        }
                    }
                    
                }

                if (jeMisto == true)
                {
                    pocetLodi--;
                    pocitadloLodi++;
                    foreach (Button button in tablePanelHraciPlocha.Controls)
                    {

                        for (int i = x1; i < x2 + 1; i++)
                        {
                            for (int j = y1; j < y2 + 1; j++)
                            {

                                if (button.Tag.ToString() == ((x+i) + "," + (y+j)))
                                {
                                    
                                     button.BackColor = barvaLode;
                                     button.Text = pocitadloLodi.ToString();

                                }
                            }
                        }

                    }
                }
                else
                {
                    jeMisto = true;
                }

                if (pojistka > 1000)
                {                  

                    MessageBox.Show("Program neyvladl rozmisteni lodi", "Ukoncovani..", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return 0;
                }

            }

            return pocitadloLodi;

        }

        private void buttonAkce_Click(object sender, EventArgs e)
        {
            Clear();

            log.Add("Rozmistuji lode...");

            int pocitadloLodi = 0;

            pocitadloLodi = VlozLod((int)Ship3.Value, pocitadloLodi, 0, 0, 0, 2);

            pocitadloLodi = VlozLod((int)Ship5.Value, pocitadloLodi, 0, 2, 0, 0);

            pocitadloLodi = VlozLod((int)Ship2.Value, pocitadloLodi, 0, 0, 0, 1);

            pocitadloLodi = VlozLod((int)Ship4.Value, pocitadloLodi, 0, 1, 0, 0);

            pocitadloLodi = VlozLod((int)Ship1.Value, pocitadloLodi, 0, 0, 0, 0);

            if (pocitadloLodi < ((int)Ship1.Value + (int)Ship2.Value + (int)Ship3.Value + (int)Ship4.Value + (int)Ship5.Value))
            {
                Clear();
                log.Add("Rozmisteni selhalo...");
            }
            else if (pocitadloLodi==0)
            {
                log.Add("Žádné lodě k rozmístění");
            }
            else
            {
                log.Add("Hotovo");
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {

            log.Add("Vitej..");

            button1.BackColor = barvaLode;
            button2.BackColor = barvaLode;
            button3.BackColor = barvaLode;
            button4.BackColor = barvaLode;
            button5.BackColor = barvaLode;

            tablePanelHraciPlocha.BackColor = Color.LightSteelBlue;

            for (int i = 0; i < tablePanelHraciPlocha.RowStyles.Count; i++)
            {
                for (int j = 0; j < tablePanelHraciPlocha.ColumnStyles.Count; j++)
                {

                    Button button = new Button()
                    {
                        BackColor = SystemColors.Control,
                        Text = "",
                        Dock = DockStyle.Fill,
                        Tag = String.Format("{0},{1}", i+1, j+1),
                        ForeColor = Color.White,
                        
                    };

                    string[] souradnice = (String.Format("{0}", button.Tag)).Split(',');

                    button.BackColor = Color.LightSteelBlue;


                    button.Click += button_Click;
                    tablePanelHraciPlocha.Controls.Add(button);

                }
            }
        }

        private void Clear()
        {
            foreach (Button button in tablePanelHraciPlocha.Controls)
            {

                button.Text = "";

                string[] souradnice = (String.Format("{0}", button.Tag)).Split(',');

                button.BackColor = barvaVody;


            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            if (button.BackColor == barvaLode)
            {
                log.Add("Loď na souřadnicích: " + button.Tag);
            }
            else
            {
                log.Add("Voda na souřadnicích: " + button.Tag);
            }
        }

        private void Ship_ValueChanged(object sender, EventArgs e)
        {


            NumericUpDown numericUpDown = sender as NumericUpDown;
            if (numericUpDown == null)
            {
                return;
            }

            if (numericUpDown.Value < 0)
            {
                numericUpDown.Value = 0;
            }
            if (numericUpDown.Value > 5)
            {
                numericUpDown.Value = 5;
            }


        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    log.Add(dlg.Color);

                    this.barvaLode = dlg.Color;
                }
            }

            button1.BackColor = barvaLode;
            button2.BackColor = barvaLode;
            button3.BackColor = barvaLode;
            button4.BackColor = barvaLode;
            button5.BackColor = barvaLode;

            Clear();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    log.Add(dlg.Color);

                    barvaVody = dlg.Color;


                }

                this.tablePanelHraciPlocha.BackColor = dlg.Color;
                this.tableLayoutPanel10.BackColor = dlg.Color;
                this.tableLayoutPanel9.BackColor = dlg.Color;
                this.tableLayoutPanel8.BackColor = dlg.Color;
                this.tableLayoutPanel7.BackColor = dlg.Color;
                this.tableLayoutPanel6.BackColor = dlg.Color;

                foreach (Button button in tablePanelHraciPlocha.Controls)
                {


                        button.BackColor = barvaVody;


                }

            }

            
            

            Clear();
        }
    }
}
