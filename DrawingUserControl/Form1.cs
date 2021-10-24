using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingUserControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {
            //  e.Graphics.FillEllipse(bla bla) //parametr PaintEventArgs
            Graphics graphics = e.Graphics;
            //label1.ClientRectangle.bla bla //paramet velikosti poe kam kreslím
            //Rectangle rectangle = label1.ClientRectangle;

            /* milion problemu, udelame si user control
            graphics.FillRectangle(Brushes.BlueViolet, rectangle);

            graphics.DrawLine(Pens.Black,0,0,rectangle.Width-1,rectangle.Height-1);
            graphics.DrawLine(Pens.Black, rectangle.Width - 1, 0, 0, rectangle.Height - 1);
            graphics.DrawLine(Pens.Black, 0, 0, 0, rectangle.Height - 1);
            graphics.DrawLine(Pens.Black, 0, 0, rectangle.Width - 1,0);
            graphics.DrawLine(Pens.Black, rectangle.Width - 1, 0,0, rectangle.Height - 1);
            graphics.DrawLine(Pens.Black, rectangle.Width - 1, rectangle.Height - 1, 0, rectangle.Height - 1);
            graphics.DrawLine(Pens.Black, rectangle.Width - 1, rectangle.Height - 1, rectangle.Width - 1,0);

            */
        }

    }
}
