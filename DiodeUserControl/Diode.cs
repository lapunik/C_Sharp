using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DiodeUserControl
{
    class Diode : Control
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

        public Diode()
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

            using (SolidBrush brush = new SolidBrush(BColor))
            {

                if (rectangle.Height > rectangle.Width)
                {
                    graphics.FillEllipse(brush, 0, (rectangle.Height - rectangle.Width) / 2, rectangle.Width, rectangle.Width);

                }
                else
                {
                    graphics.FillEllipse(brush, (rectangle.Width - rectangle.Height) / 2, 0, rectangle.Height, rectangle.Height);
                }


            }

            using (SolidBrush brush = new SolidBrush(Notification?Color:SecondColor))
            {
                int mezera;

                switch (View3D)
                {
                    case 0:
                        {

                            if (rectangle.Height > rectangle.Width)
                            {
                                mezera = rectangle.Width / 15;

                                graphics.FillEllipse(brush, mezera, ((rectangle.Height - rectangle.Width) / 2) + mezera, rectangle.Width - (2 * mezera), rectangle.Width - (2 * mezera));

                            }
                            else
                            {
                                mezera = rectangle.Height / 15;

                                graphics.FillEllipse(brush, ((rectangle.Width - rectangle.Height) / 2) + mezera, mezera, rectangle.Height - (2 * mezera), rectangle.Height - (2 * mezera));
                            }
                            break;
                        }
                    case 1:
                        {

                            if (rectangle.Height > rectangle.Width)
                            {
                                mezera = rectangle.Width / 15;

                                graphics.FillEllipse(brush, mezera, ((rectangle.Height - rectangle.Width) / 2) + mezera, rectangle.Width - mezera, rectangle.Width-mezera);

                            }
                            else
                            {
                                mezera = rectangle.Height / 15;

                                graphics.FillEllipse(brush, ((rectangle.Width - rectangle.Height) / 2) + mezera, mezera, rectangle.Height - mezera, rectangle.Height - mezera);
                            }
                            break;
                        }
                    case 3:
                        {

                            if (rectangle.Height > rectangle.Width)
                            {
                                mezera = rectangle.Width / 15;

                                graphics.FillEllipse(brush,0, ((rectangle.Height - rectangle.Width) / 2), rectangle.Width - mezera, rectangle.Width - mezera);

                            }
                            else
                            {
                                mezera = rectangle.Height / 15;

                                graphics.FillEllipse(brush, ((rectangle.Width - rectangle.Height) / 2), 0, rectangle.Height - mezera, rectangle.Height - mezera);
                            }
                            break;
                        }
                    case 4:
                        {

                            if (rectangle.Height > rectangle.Width)
                            {
                                mezera = rectangle.Width / 15;

                                graphics.FillEllipse(brush, mezera, ((rectangle.Height - rectangle.Width) / 2), rectangle.Width - mezera, rectangle.Width - mezera);

                            }
                            else
                            {
                                mezera = rectangle.Height / 15;

                                graphics.FillEllipse(brush, ((rectangle.Width - rectangle.Height) / 2) + mezera, 0, rectangle.Height - mezera, rectangle.Height - mezera);
                            }
                            break;
                        }
                    case 2:
                        {

                            if (rectangle.Height > rectangle.Width)
                            {
                                mezera = rectangle.Width / 15;

                                graphics.FillEllipse(brush, 0, ((rectangle.Height - rectangle.Width) / 2) + mezera, rectangle.Width - mezera, rectangle.Width - mezera);

                            }
                            else
                            {
                                mezera = rectangle.Height / 15;

                                graphics.FillEllipse(brush, ((rectangle.Width - rectangle.Height) / 2) , mezera, rectangle.Height - mezera, rectangle.Height - mezera);
                            }
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
