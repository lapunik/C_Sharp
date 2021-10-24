using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PercentagePointerUseControl
{
    class PercentageBar : Control
    {
        public int maxValue;
        public int MaxValue
        {
            get
            {
                return maxValue;
            }
            set
            {
                maxValue = value;
                Invalidate();
            }
        }
        public int hodnota;
        public int Value
        {
            get
            {
                return hodnota;
            }
            set
            {
                hodnota = value;
                Invalidate();
            }
        }

        public PercentageBar()
        {
            DoubleBuffered = true;
            Value = 30;
            MaxValue = 100;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics graphics = pe.Graphics;
            Rectangle rectangle = this.ClientRectangle;

            using (SolidBrush brush = new SolidBrush(Color.LightGoldenrodYellow))
            {

                graphics.FillRectangle(brush, 0, 0, rectangle.Width, rectangle.Height);

                brush.Color = Color.Maroon;

                graphics.FillRectangle(brush, 0, 0, (int)(Math.Round(((double)rectangle.Width / (double)MaxValue) * (double)Value)), rectangle.Height);

            }

            using (Pen pen = new Pen(Color.Black, 1))
            {
                if (rectangle.Width < 80)
                {
                    graphics.DrawRectangle(pen, 0, 0, rectangle.Width, rectangle.Height);
                }
                else
                {
                    pen.Width = 2;
                    graphics.DrawRectangle(pen, 0, 0, rectangle.Width, rectangle.Height);
                }
                pen.Width = 1;

                for (int i = 0; i < MaxValue; i++)
                {
                    int line = (int)(Math.Round(((double)rectangle.Width / (double)MaxValue) * (double)i));

                    if (i % 5 == 0)
                    {
                        graphics.DrawLine(pen, line - pen.Width, rectangle.Height - (rectangle.Height / 4), line - pen.Width, rectangle.Height);
                    }
                    if (i % 25 == 0)
                    {
                        graphics.DrawLine(pen, line - pen.Width, rectangle.Height - (rectangle.Height / 2), line - pen.Width, rectangle.Height);
                    }
                }
                
            }


                
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            Invalidate();
        }

    }
}
