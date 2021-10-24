using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klikaci_app_cv5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label_predelane_paint_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle rectangle = label_predelane_paint.ClientRectangle;

            graphics.FillRectangle(Brushes.LightGray, rectangle);
            graphics.FillEllipse(Brushes.DodgerBlue, rectangle);

        }

    }
}
