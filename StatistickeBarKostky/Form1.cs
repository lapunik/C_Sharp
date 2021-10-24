using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatistickeBarKostky
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            log.Add("Vítej v aplikaci..");

            foreach (Control control in tableLayoutPanelBar.Controls)
            {
                PercentagePointerUseControl.PercentageBar bar = control as PercentagePointerUseControl.PercentageBar;

                bar.Value = 0;
                bar.MaxValue = 1;
            }
        }

        private void buttonHod_Click(object sender, EventArgs e)
        {
            dice1.Throw();
            log.Add(String.Format("První kostka: {0}",dice1.Number));
            dice2.Throw();
            log.Add(String.Format("Druhá kostka: {0}", dice2.Number));
            dice3.Throw();
            log.Add(String.Format("Třetí kostka: {0}", dice3.Number));

            soucet.Text = (dice1.Number + dice2.Number + dice3.Number).ToString();

            bool zvetsit = false;

            foreach (Control control in tableLayoutPanelBar.Controls)
            {

                PercentagePointerUseControl.PercentageBar bar = control as PercentagePointerUseControl.PercentageBar;

                if (soucet.Text == bar.Tag.ToString())
                {
                    bar.Value++;
                }

                if (bar.Value == bar.MaxValue)
                {
                    zvetsit = true;
                }

                bar.Invalidate();

            }

            if (zvetsit)
            {
                foreach (Control control in tableLayoutPanelBar.Controls)
                {

                    PercentagePointerUseControl.PercentageBar bar = control as PercentagePointerUseControl.PercentageBar;

                    Button button = new Button();

                    bar.MaxValue++;

                    bar.Invalidate();
                    

                }
                log.Add(String.Format("Došlo k překreslení barů"));
            }


        }

        private void buttonAuto_Click_1(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                buttonAuto.Text = String.Format("Stop");
                timer1.Enabled = true;
                log.Add("Automat zapnut");
                buttonHod.Enabled = false;
            }
            else
            {
                buttonAuto.Text = String.Format("Auto");
                timer1.Enabled = false;
                log.Add("Automat vypnut");
                buttonHod.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            buttonHod_Click(null,null);
        }

        private void buttonSpeed_Click(object sender, EventArgs e)
        {
            if (timer1.Interval == 100)
            {
                buttonSpeed.Text = String.Format("Pomalu");
                timer1.Interval = 10;
                log.Add("Vysoká rychlost");
            }
            else
            {
                buttonSpeed.Text = String.Format("Rychle");
                timer1.Interval = 100;
                log.Add("Nízká rychlost");
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            log.Add(String.Format("Nuluji.."));
            foreach (Control control in tableLayoutPanelBar.Controls)
            {
                PercentagePointerUseControl.PercentageBar bar = control as PercentagePointerUseControl.PercentageBar;

                bar.Value = 0;
                bar.MaxValue = 1;
                
            }

            soucet.Text = "";

            dice1.Number = 6;
            dice2.Number = 6;
            dice3.Number = 6;
            dice1.Invalidate();
            dice2.Invalidate();
            dice3.Invalidate();
            log.Add(String.Format("Nova hra může začít!"));
        }

        private void dice1_Click(object sender, EventArgs e)
        {

        }

        private void percentageBar2_Click(object sender, EventArgs e)
        {

        }
    }
}
