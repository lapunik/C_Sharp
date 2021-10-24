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
    public partial class MyDrawContorl : Control
    {
        public MyDrawContorl()
        {
            InitializeComponent();

            DoubleBuffered = true; // kdyz se meni velikost, nejdriv vykresli mimo obrazovku a potom teprve na obrazovce 
            // je protected takze neni viditelny ven
            
        }

        protected override void OnPaint(PaintEventArgs pe) //override nahrazuje nasim vykreslovanim
        {
            // base.OnPaint(pe); vraci svuj predek
            
            Graphics graphics = pe.Graphics;
            Rectangle rectangle = this.ClientRectangle;

            graphics.FillRectangle(Brushes.BlueViolet, rectangle);
            graphics.FillEllipse(Brushes.Yellow, rectangle);
            
            graphics.DrawLine(Pens.Black, 0, 0, rectangle.Width - 1, rectangle.Height - 1);
            graphics.DrawLine(Pens.Black, rectangle.Width - 1, 0, 0, rectangle.Height - 1);
            graphics.DrawLine(Pens.Black, 0, 0, 0, rectangle.Height - 1);
            graphics.DrawLine(Pens.Black, 0, 0, rectangle.Width - 1, 0);
            graphics.DrawLine(Pens.Black, rectangle.Width - 1, 0, 0, rectangle.Height - 1);
            graphics.DrawLine(Pens.Black, rectangle.Width - 1, rectangle.Height - 1, 0, rectangle.Height - 1);
            graphics.DrawLine(Pens.Black, rectangle.Width - 1, rectangle.Height - 1, rectangle.Width - 1, 0);
        }

        protected override void OnSizeChanged(EventArgs e) // kdyz menim velikost dela kraviny, protoze se meni jen casti ktere se meni proto to tady prekreslim cele
        {
            //base.OnSizeChanged(e);
            Invalidate();
        }
    }
}
