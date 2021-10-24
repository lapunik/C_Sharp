using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DrawingUserControl
{
    public class ClassDrawing : Control
    {

        public ClassDrawing()
        {
            DoubleBuffered = true;
        }

        protected Color color1 = Color.DeepSkyBlue;
        public Color Color1
        {
            get
            {
                return color1;
            }
            set
            {
                color1 = value;
                Invalidate(); //prekresli uz kdyz zmenim v návrháři 
            }
        }
        protected Color color2 = Color.DeepPink;
        public Color Color2
        {
            get
            {
                return color2;
            }
            set
            {
                color2 = value;
                Invalidate(); //prekresli uz kdyz zmenim v návrháři 
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // base.OnPaint(pe); vraci svuj predek

            Graphics graphics = pe.Graphics;
            Rectangle rectangle = this.ClientRectangle;

            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, rectangle.Height / 5), Color1, Color2)) //nebo barvu a uhel
            {
                graphics.FillRectangle(brush, rectangle);
            }

            rectangle.Inflate(-10, -10); //změň velikost vykrelovacího pole o deset menší

            using (SolidBrush brush = new SolidBrush(this.ForeColor)) // vem barvu ForeColor
            {
                graphics.FillEllipse(brush, rectangle);
            }

            rectangle.Inflate(-10, -10);
            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, rectangle.Height / 2), Color.Maroon, Color.Yellow))
            {
                using (Pen pen = new Pen(brush, 3)) // mužu vložit štětec nebo jen barvu 
                {
                    graphics.DrawEllipse(pen, rectangle);
                }
            }

        }

        protected override void OnSizeChanged(EventArgs e) // kdyz menim velikost dela kraviny, protoze se meni jen casti ktere se meni proto to tady prekreslim cele
        {
            //base.OnSizeChanged(e);
            Invalidate();
        }
    }
}
