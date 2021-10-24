using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace Clock
{
    class ClockAnalog : Control
    {
        public bool Second { set; get; }
        public ClockAnalog()
        {
            
            DoubleBuffered = true;
            timer = new Timer()
            {
                Interval = 10
            };
            timer.Tick += timer_tick;
            timer.Start();
            BackColor = Color.White;
            ForeColor = Color.Black;
            Second = true;
        }

        protected Color colorBackground = Color.LightGoldenrodYellow;
        public Color ColorBackground
        {
            get
            {
                return colorBackground;
            }
            set
            {
                colorBackground = value;
                Invalidate(); 
            }
        }
        protected Color colorSec = Color.DarkRed;
        public Color ColorSec
        {
            get
            {
                return colorSec;
            }
            set
            {
                colorSec = value;
                Invalidate(); 
            }
        }
        protected Color colorOtherwise = Color.Black;
        public Color ColorOtherwise
        {
            get
            {
                return colorOtherwise;
            }
            set
            {
                colorOtherwise = value;
                Invalidate(); 
            }
        }


        private void timer_tick(object sender, EventArgs e)
        {
            Invalidate();
        }


        private Timer timer = null;

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics graphics = pe.Graphics;
            Rectangle rectangle = this.ClientRectangle;


            using (SolidBrush brush = new SolidBrush(ColorBackground)) 
            {

                if (rectangle.Height > rectangle.Width)
                {
                    graphics.FillEllipse(brush, 0, (rectangle.Height-rectangle.Width)/2, rectangle.Width, rectangle.Width);

                }
                else
                {
                    graphics.FillEllipse(brush, (rectangle.Width - rectangle.Height) / 2, 0, rectangle.Height, rectangle.Height);
                }


            }

            using (Pen pen = new Pen(ColorOtherwise, 8))
            {

                int penWidth;

                if (rectangle.Height > rectangle.Width)
                {
                    penWidth = rectangle.Width / 80;
                    pen.Width = penWidth;
                    graphics.DrawEllipse(pen, (penWidth / 4), ((rectangle.Height - rectangle.Width) / 2) + (penWidth / 3), rectangle.Width - (penWidth - (penWidth / 3)), rectangle.Width - (penWidth - (penWidth / 3)));

                }
                else
                {
                    penWidth = rectangle.Height / 60;
                    pen.Width = penWidth;
                    graphics.DrawEllipse(pen, ((rectangle.Width - rectangle.Height) / 2) + (penWidth / 4), (penWidth / 3), rectangle.Height - (penWidth - (penWidth / 3)), rectangle.Height - (penWidth - (penWidth / 3)));
                }

                Point center = new Point(rectangle.Width / 2, rectangle.Height / 2);

                double sec = DateTime.Now.Second / 60.0;
                double min = DateTime.Now.Minute / 60.0 + (DateTime.Now.Second / 3600.0);
                double h = DateTime.Now.Hour / 12.0 + (DateTime.Now.Minute / 720.0);

                graphics.DrawLine(pen, center, GetPoint(center, h, 0.4));
                graphics.DrawLine(pen, center, GetPoint(center, min, 0.8));

                if (Second)
                {
                    pen.Color = ColorSec;
                    pen.Width = penWidth / 2;
                    graphics.DrawLine(pen, center, GetPoint(center, sec, 0.8));
                }
                pen.Color = ColorOtherwise;
                for (int i = 0; i < 60; i++)
                {
                    if ((i % 5) == 0)
                    {
                        pen.Width = penWidth;
                        graphics.DrawLine(pen, GetPoint(center, ((double)i) / 60, 0.85), GetPoint(center, ((double)i) / 60, 1));
                    }
                    else
                    {
                        pen.Width = penWidth / 2;
                        graphics.DrawLine(pen, GetPoint(center, ((double)i) / 60, 0.90), GetPoint(center, ((double)i) / 60, 1));

                    }

                }

                Font font = null;
                int fontSize;

                if (rectangle.Height > rectangle.Width)
                {
                    fontSize = rectangle.Width / 16;
                    if (fontSize == 0)
                    {
                        fontSize = 1;
                    }
                    font = new Font(new FontFamily("Microsoft Tai Le"), fontSize);
                }
                else
                {
                    fontSize = rectangle.Height / 16;
                    if (fontSize == 0)
                    {
                        fontSize = 1;
                    }
                    font = new Font(new FontFamily("Microsoft Tai Le"), fontSize);
                }

                for (int i = 0; i < 12; i++)
                {
                    
                    if (i == 0)
                    {
                        i = 12;
                    }

                    SizeF sz = graphics.MeasureString(i.ToString(), font);

                    using (SolidBrush brush = new SolidBrush(ColorOtherwise))
                    {
                       

                        graphics.DrawString(i.ToString(),font, brush, (GetPoint(center, ((double)i) / 12, 0.7).X)-(sz.Width/2), (GetPoint(center, ((double)i) / 12, 0.7).Y) - (sz.Height / 2)); //mohli bychom si udělat svuj font Font font = new font bla bla

                    }

                    if (i == 12)
                    {
                        i = 0;
                    }
                }


            }

            using (SolidBrush brush = new SolidBrush(ColorOtherwise)) 
            {

                if (rectangle.Height > rectangle.Width)
                {
                    graphics.FillEllipse(brush, (rectangle.Width / 2 - rectangle.Width / 40), (rectangle.Height / 2 - rectangle.Width / 40), rectangle.Width / 20, rectangle.Width / 20);

                }
                else
                {
                    graphics.FillEllipse(brush, (rectangle.Width / 2 - rectangle.Height / 40), (rectangle.Height / 2 - rectangle.Height / 40), rectangle.Height / 20, rectangle.Height / 20);
                }


            }


        }

        private Point GetPoint(Point center, double time,double i)
        {
            Point point = new Point();

            double length;

            if (center.X > center.Y)
            {
                length = center.Y*i;
            }
            else
            {
                length = center.X*i ;
            }

            double uhel = ((time - 0.25) * 2 * Math.PI); //-0.25 protože chceme nulu mit nahoře a ne vpravo a 2 PI protože 2PI = 360 stupnu a nase hodnota time nabývá hodnot 0 - 1
            point.X = center.X + (int)Math.Round(Math.Cos(uhel) * length);
            point.Y = center.Y + (int)Math.Round(Math.Sin(uhel) * length);
            
            return point;
        }

        protected override void OnSizeChanged(EventArgs e) 
        {
            Invalidate();
        }
    }
}

