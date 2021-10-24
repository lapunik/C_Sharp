using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KontejneryPrizpusobeniVelikostiPrvku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            label1.Text = String.Format("{0} z {1}x{2}", splitContainer1.SplitterDistance, splitContainer1.Width, splitContainer1.Height);
        }
    }
}
