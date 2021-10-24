using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            buttonAnalogDigi_Click(null, null);
        }

        private void buttonSecond_Click(object sender, EventArgs e)
        {

            ClockAnalog clock = tableLayoutPanel2.Controls[0] as ClockAnalog; 
             
            if (clock != null)
            {

                if (clock.Second)
                {
                    clock.Second = false;
                    buttonSecond.Text = "On Second";
                }
                else
                {
                    buttonSecond.Text = "Off Second";
                    clock.Second = true;
                }
            }
            else
            {
                 ClockDigi clockDigi = tableLayoutPanel2.Controls[0] as ClockDigi;

                if (clockDigi.Second)
                {
                    clockDigi.Second = false;
                    buttonSecond.Text = "On Second";
                }
                else
                {
                    buttonSecond.Text = "Off Second";
                    clockDigi.Second = true;
                }


            }

            
        }

        private void buttonAnalogDigi_Click(object sender, EventArgs e)
        {

            ClockAnalog clocka = tableLayoutPanel2.Controls[0] as ClockAnalog;

            if (clocka != null) 
            {
                buttonAnalogDigi.Text = "Analog";

                tableLayoutPanel2.Controls.RemoveAt(0);

                ClockDigi clock = new ClockDigi() // udelam si svuj usercontrol
                {
                    Dock = DockStyle.Fill,

                };

                tableLayoutPanel2.Controls.Add(clock);
            }
            else
            {
                
                buttonAnalogDigi.Text = "Digital";

                tableLayoutPanel2.Controls.RemoveAt(0);

                ClockAnalog clock = new ClockAnalog()
                {
                    Dock = DockStyle.Fill,

                };

                tableLayoutPanel2.Controls.Add(clock);



            }

        }

    }
}
