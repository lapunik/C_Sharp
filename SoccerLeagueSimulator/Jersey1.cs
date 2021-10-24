using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SoccerLeagueSimulator
{
    public partial class Jersey1 : Control
    {
        public Jersey1()
        {
            //InitializeComponent();
            //BackColor = Color.Transparent;
            DoubleBuffered = true;
        }

        protected Color color = Color.Black;
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                Invalidate(); //prekresli uz kdyz zmenim v návrháři 
            }
        }
        protected string playerName = "Name";
        public string PlayerName
        {
            get
            {
                return playerName;
            }
            set
            {
                playerName = value;
                Invalidate(); //prekresli uz kdyz zmenim v návrháři 
            }
        }

        public string Number { get; set; }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics graphics = pe.Graphics;
            Rectangle rectangle = this.ClientRectangle;

            Point[] points = {
                new Point((int)((double)(0.25) * (double)rectangle.Width), 0),
                new Point((int)((double)(0.75) * (double)rectangle.Width), 0),
                new Point((int)(double)rectangle.Width,(int)((double)(0.25) * (double)rectangle.Height)),
                new Point((int)((double)(0.840909) * (double)rectangle.Width),(int)((double)(0.382979) * (double)rectangle.Height)),
                new Point((int)((double)(0.75) * (double)rectangle.Width), (int)((double)(0.308511) * (double)rectangle.Height)),
                new Point((int)((double)(0.75) * (double)rectangle.Width),(int)( (double)rectangle.Height)),
                new Point((int)((double)(0.25) * (double)rectangle.Width), (int)((double)rectangle.Height)),
                new Point((int)((double)(0.25) * (double)rectangle.Width), (int)((double)(0.308511) * (double)rectangle.Height)),
                new Point((int)((double)(0.159091) * (double)rectangle.Width), (int)((double)(0.382979) * (double)rectangle.Height)),
                new Point(0,(int)((double)(0.25) * (double)rectangle.Height))};

            using (SolidBrush brush = new SolidBrush(Color))
            {
                graphics.FillPolygon(brush, points);
            }

            string s = this.PlayerName;
            SizeF sz = graphics.MeasureString(s, this.Font);

            using (SolidBrush brush = new SolidBrush(this.ForeColor))
            {

                graphics.DrawString(s, this.Font, brush, (rectangle.Width - sz.Width) / 2, ((rectangle.Height / 2) - sz.Height) / 2); //mohli bychom si udělat svuj font Font font = new font bla bla
            }

        }

        protected override void OnSizeChanged(EventArgs e)
        {
            Invalidate();
        }
    }
}
