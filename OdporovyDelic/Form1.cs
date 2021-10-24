using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OdporovyDelic
{
    public partial class Form1 : Form
    {
        private double Uin;
        private double R1;
        private double R2;
        private double Uout;

        int rezim = 1; // 1 = zadavani Uin, R1, R2 
                       // 2 = zadavani Uin, Uout

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            log.Add("Vitej v aplikaci..");
            rezim = 1;
            r1.SelectedIndex = 0;
            r2.SelectedIndex = 0;
            uin.Text = 10.ToString();

            vypocitej_Click(null, null);
        }

        private void r1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rezim == 1)
            {
                vypocitej_Click(null, null);
            }
        }

        private void r2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rezim == 1)
            {
                vypocitej_Click(null, null);
            }
        }

        private void vypocitej_Click(object sender, EventArgs e)
        {
            uout.BackColor = Color.White;
            checkBox1.CheckState = CheckState.Unchecked;
            checkBox2.CheckState = CheckState.Unchecked;

            if (!double.TryParse(uin.Text, out Uin))
            {
                return;
            }

            R1 = double.Parse(r1.Text);
            R2 = double.Parse(r2.Text);

            if (rezim == 1)
            { 
                Uout = (R2 / (R1 + R2)) * Uin;

                uout.Text = Uout.ToString();
                log.Add("Výpočet úspěšný");
            }
            else if (rezim == 2)
            {

                if (!double.TryParse(uout.Text, out Uout))
                {
                    return;
                }

                double pomerU = Math.Round(Uout / Uin, 2);

                double pomerR = 0;

                int R1m=0;
                int R2m=0;
                double Chyba = double.MaxValue;

                for (int i = 0; i < r1.Items.Count; i++)
                {

                    for (int j = 0; j < r2.Items.Count; j++)
                    {
                        
                        pomerR = Math.Round(double.Parse(r2.Items[j].ToString())/(double.Parse(r2.Items[j].ToString()) + double.Parse(r1.Items[i].ToString())),1, MidpointRounding.AwayFromZero);

                        if (Chyba > Math.Abs(Uout - pomerR))
                        {
                            Chyba = Math.Abs(Uout - pomerR);
                            R1m = i;
                            R2m = j;
                        }

                        if (pomerR == pomerU)
                        {
                            r1.SelectedIndex = i;
                            r2.SelectedIndex = j;
                            log.Add("Poměr se našel, výpočet úspěšný");
                            return;
                        }
                    }

                }

                r1.SelectedIndex = R1m;
                r2.SelectedIndex = R2m;



                log.Add("Poměr se nenašel, výpočet selhal");
                uout.BackColor = Color.Coral;

                uout.Text = String.Format("Chyba");
                log.Add(String.Format("Pri zadani techto odporu je chyba od zapadeho napětí {0}V",Chyba));

            }
        }

        private void rezim1_CheckedChanged(object sender, EventArgs e)
        {
            rezim = 1;
            log.Add("Změna režimu na hledání Uout");
        }

        private void rezim2_CheckedChanged(object sender, EventArgs e)
        {
            rezim = 2;
            log.Add("Změna režimu na hledání poměru R2/R1+R2");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                r1.Enabled = false;
                log.Add("R1 zamčen");
            }
            else
            {
                r1.Enabled = true;
                log.Add("R1 odemčen");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                r2.Enabled = false;
                log.Add("R2 zamčen");
            }
            else
            {
                r2.Enabled = true;
                log.Add("R2 odemčen");
            }
        }
    }
}
