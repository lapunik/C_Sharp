using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kostky
{
    public partial class Form1 : Form
    {

        Color barva = new Color();
        public Form1()
        {
            InitializeComponent();
            log.Add("Vítej");
            barva = Color.DarkGreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random randomNumber = new Random();

            stred.Throw();

            if ((stred.Number == 1) || (stred.Number == 6))
            {
                if (stred.Number == 1)
                {
                    vicprava.Number = 6;
                    label1.Text = (int.Parse(label1.Text) + 1).ToString();
                }
                else
                {
                    vicprava.Number = 1;
                    label6.Text = (int.Parse(label6.Text) + 1).ToString();
                }

                leva.Number = 2;
                prava.Number = 5;
                horni.Number = 3;
                spodni.Number = 4;

            }
            if ((stred.Number == 2) || (stred.Number == 5))
            {
                if (stred.Number == 2)
                {
                    vicprava.Number = 5;
                    label2.Text = (int.Parse(label2.Text) + 1).ToString();
                }
                else
                {
                    vicprava.Number = 2;
                    label5.Text = (int.Parse(label5.Text) + 1).ToString();
                }

                leva.Number = 3;
                prava.Number = 4;
                horni.Number = 1;
                spodni.Number = 6;

            }
            if ((stred.Number == 3) || (stred.Number == 4))
            {
                if (stred.Number == 3)
                {
                    vicprava.Number = 4;
                    label3.Text = (int.Parse(label3.Text) + 1).ToString();
                }
                else
                {
                    vicprava.Number = 3;
                    label4.Text = (int.Parse(label4.Text) + 1).ToString();
                }

                leva.Number = 1;
                prava.Number = 6;
                horni.Number = 2;
                spodni.Number = 5;

            }

            horni.Invalidate();
            spodni.Invalidate();
            leva.Invalidate();
            prava.Invalidate();
            vicprava.Invalidate();

            log.Add(String.Format("Proběhl hod, hodnota je: {0}",stred.Number));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (timer1.Interval == 100)
            {
                button2.Text = String.Format("Pomalu");
                timer1.Interval = 10;
                log.Add("Vysoká rychlost");
            }
            else
            {
                button2.Text = String.Format("Rychle");
                timer1.Interval = 100;
                log.Add("Nízká rychlost");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
            label2.Text = "0";
            label3.Text = "0";
            label4.Text = "0";
            label5.Text = "0";
            label6.Text = "0";
            log.Add("Proběhl reset");
        }

        private void auto_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                auto.Text = String.Format("Stop");
                timer1.Enabled = true;
                log.Add("Automat zapnut");
            }
            else
            {
                auto.Text = String.Format("Auto");
                timer1.Enabled = false;
                log.Add("Automat vypnut");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            button1_Click(null, null);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    log.Add(dlg.Color);

                    barva = dlg.Color;

                }

                tableLayoutPanel1.BackColor = barva;
                tableLayoutPanel2.BackColor = barva;
                tableLayoutPanel3.BackColor = barva;
                tableLayoutPanel4.BackColor = barva;

            }
        }
    }
}

