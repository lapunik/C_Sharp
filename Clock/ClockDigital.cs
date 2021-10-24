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
    class ClockDigital : Control
    {

        public bool Second { set; get; }

        private Timer timer = null;

        public ClockDigital()
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

        protected override void OnPaint(PaintEventArgs pe)
        {

            Graphics graphics = pe.Graphics;
            Rectangle rectangle = this.ClientRectangle;

            using (SolidBrush brush = new SolidBrush(Color.Black))
            {



                //  graphics.FillRectangle(brush, rectangle);

            }
        }

        private void timer_tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e) // kdyz menim velikost dela kraviny, protoze se meni jen casti ktere se meni proto to tady prekreslim cele
        {
            Invalidate();
        }

    }
}
