using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cv5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            log.Add("Start APP");

            log.Items.Add("Start APP");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            log.Add("tick");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            log.AddToTop = checkBox1.Checked;
        }
    }
}
