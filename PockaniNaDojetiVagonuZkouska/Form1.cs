using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PockaniNaDojetiVagonuZkouska
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.BackColor = Color.DarkGreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            timer1.Enabled = true;

            label1.BackColor = Color.DarkGreen;

        }
    }
}
