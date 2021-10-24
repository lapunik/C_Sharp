using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKEY_new
{
    public partial class Form_Loading : Form
    {
        public Form_Loading(int length, string window_name)
        {
            InitializeComponent();
            this.Text = window_name;
            progressBar1.Maximum = length;
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            
        }

        public void Progre()
        {
            progressBar1.Increment(1);
        }
    }
}
