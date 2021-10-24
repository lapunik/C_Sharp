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
    public partial class ClockDigi : Control
    {
        public bool Second { set; get; }

        private Timer timer = null;

        public ClockDigi()
        {
            DoubleBuffered = true;
            BackColor = Color.LightGoldenrodYellow;
            ForeColor = Color.Black;
            Second = true;
            timer = new Timer()
            {
                Interval = 10
            };
            timer.Tick += timer_tick;
            timer.Start();

        }

        private void timer_tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {

            Graphics graphics = pe.Graphics;
            Rectangle rectangle = this.ClientRectangle;

            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {

                graphics.FillRectangle(brush, rectangle);

            }

            string s = null;

            if (Second)
            {
                s = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                s = DateTime.Now.ToString("HH:mm");
            }

            //int fontSize = (rectangle.Width * rectangle.Height) / 4000;

            int fontSize = (rectangle.Width) /10 ;

            if (fontSize == 0)
            {
                fontSize = 1;
            }

            Font font = new Font(new FontFamily("Microsoft Tai Le"),fontSize);
            
            SizeF sz = graphics.MeasureString(s, font);

            using (SolidBrush brush = new SolidBrush(this.ForeColor))
            {
                graphics.DrawString(s, font, brush, (rectangle.Width - sz.Width)/2, ((rectangle.Height - sz.Height) / 2)); //mohli bychom si udělat svuj font Font font = new font bla bla
            }

        }


        protected override void OnSizeChanged(EventArgs e) // kdyz menim velikost dela kraviny, protoze se meni jen casti ktere se meni proto to tady prekreslim cele
        {
            Invalidate();
        }
    }
}
