using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiodeUserControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            diode1.Notification = (diode1.Notification) ? false : true ;

            Timer timer = new Timer();

            timer.Interval = 2000; 
            timer.Enabled = true; 
            timer.Tick += timer_Tick;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (diode1.View3D == 0)
            {
                diode1.View3D = 1;
                diodePanel1.View3D = 1;
            }
            else if (diode1.View3D == 1)
            {
                diode1.View3D = 2;
                diodePanel1.View3D = 2;
            }
            else if (diode1.View3D == 2)
            {
                diode1.View3D = 3;
                diodePanel1.View3D = 3;
            }
            else if (diode1.View3D == 3)
            {
                diode1.View3D = 4;
                diodePanel1.View3D = 4;
            }
            else if (diode1.View3D == 4)
            {
                diode1.View3D = 0;
                diodePanel1.View3D = 0;
            }
        }

        private void timer_Tick(object sender, EventArgs e) // časovač pro zastavení vlaku
        {

            Timer tim = sender as Timer;
            if (tim==null)
            {
                return;
            }

            diodePanel1.Notification = (diodePanel1.Notification) ? false : true;

            tim.Enabled = false; //časovač pro zastavení vlaku vypni  
        }
    }
}
