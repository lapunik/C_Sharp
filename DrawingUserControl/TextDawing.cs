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
    class TextDawing : Control
    {

        public TextDawing()
        {
            DoubleBuffered = true;
            timer = new Timer() {Interval = 100 };
            timer.Tick += timer_tick;
            timer.Start();

        }

        private void timer_tick(object sender,EventArgs e)
        {
            Invalidate();
        }


         private Timer timer = null;

        protected override void OnPaint(PaintEventArgs pe)
        {
            // base.OnPaint(pe); vraci svuj predek

            Graphics graphics = pe.Graphics;
            Rectangle rectangle = this.ClientRectangle;

            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {

                graphics.FillRectangle(brush, rectangle);

            }
            string s = this.Text;
            SizeF sz = graphics.MeasureString(s, this.Font);

            using (SolidBrush brush = new SolidBrush(this.ForeColor))
            {

                graphics.DrawString(s, this.Font,brush, (rectangle.Width-sz.Width)/2,((rectangle.Height/2)-sz.Height)/2); //mohli bychom si udělat svuj font Font font = new font bla bla
            }

             s = DateTime.Now.ToString("HH:mm:ss.fff");
             sz = graphics.MeasureString(s, this.Font);

            using (SolidBrush brush = new SolidBrush(this.ForeColor))
            {

                graphics.DrawString(s, this.Font, brush, (rectangle.Width - sz.Width) / 2, (((rectangle.Height / 2) - sz.Height) / 2 ) + rectangle.Height/2); //mohli bychom si udělat svuj font Font font = new font bla bla
            }

        }


        protected override void OnSizeChanged(EventArgs e) // kdyz menim velikost dela kraviny, protoze se meni jen casti ktere se meni proto to tady prekreslim cele
        {
            //base.OnSizeChanged(e);
            Invalidate();
        }
    }
}
