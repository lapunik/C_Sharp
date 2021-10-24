using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace VisualDebugControlTrainTT
{
    class DiodePanel : Control
    {

        private bool notification = false;
        public bool Notification
        {
            get
            {
                return notification;
            }
            set
            {
                notification = value;
                Invalidate();
            }
        }

        private int view3D = 0;
        public int View3D
        {
            get
            {
                return view3D;
            }
            set
            {
                view3D = value;
                Invalidate();
            }
        }

        protected Color color = Color.Lime;
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                Invalidate();
            }
        }
        protected Color secondColor = Color.Lime;
        public Color SecondColor
        {
            get
            {
                return secondColor;
            }
            set
            {
                secondColor = value;
                Invalidate();
            }
        }
        protected Color bColor = Color.DarkGray;
        public Color BColor
        {
            get
            {
                return bColor;
            }
            set
            {
                bColor = value;
                Invalidate();
            }
        }

        public DiodePanel()
        {
            DoubleBuffered = true;
            Notification = false;
            view3D = 0;
            color = Color.Lime;
            bColor = Color.DarkGray;
            SecondColor = Color.DarkGray;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics graphics = pe.Graphics;
            Rectangle rectangle = this.ClientRectangle;


            string s = this.Text;

            SizeF sz = graphics.MeasureString(s, this.Font);

            using (SolidBrush brush = new SolidBrush(this.ForeColor))
            {

                graphics.DrawString(s, this.Font, brush, 0, (rectangle.Height - sz.Height) / 2); //mohli bychom si udělat svuj font Font font = new font bla bla
            }


            using (SolidBrush brush = new SolidBrush(BColor))
            {

                graphics.FillEllipse(brush, (rectangle.Width - rectangle.Height), 0, rectangle.Height, rectangle.Height);

            }

            using (SolidBrush brush = new SolidBrush(Notification ? Color : SecondColor))
            {
                int mezera = rectangle.Height / 10;

                switch (View3D)
                {
                    case 0:
                        {
                            graphics.FillEllipse(brush, ((rectangle.Width - rectangle.Height)) + mezera, mezera, rectangle.Height - (2 * mezera), rectangle.Height - (2 * mezera));
                            break;
                        }
                    case 1:
                        {
                            graphics.FillEllipse(brush, ((rectangle.Width - rectangle.Height)) + mezera, mezera, rectangle.Height - mezera, rectangle.Height - mezera);
                            break;
                        }
                    case 2:
                        {
                            graphics.FillEllipse(brush, ((rectangle.Width - rectangle.Height)), mezera, rectangle.Height - mezera, rectangle.Height - mezera);
                            break;
                        }
                    case 3:
                        {
                            graphics.FillEllipse(brush, ((rectangle.Width - rectangle.Height)), 0, rectangle.Height - mezera, rectangle.Height - mezera);
                            break;
                        }
                    case 4:
                        {
                            graphics.FillEllipse(brush, ((rectangle.Width - rectangle.Height)) + mezera, 0, rectangle.Height - mezera, rectangle.Height - mezera);
                            break;
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
