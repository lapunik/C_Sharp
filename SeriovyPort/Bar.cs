using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeriovyPort
{
    public class Bar : Control
    {

        [DefaultValue(-1600)]
        public int Min { get; set; } = -1600;
        [DefaultValue(1600)]
        public int Max { get; set; } = 1600;

        int value = 1000;
        [DefaultValue(1000)]
        public int Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value ;
                Invalidate(); //kdyz se zmeni hodnota, prekresli se
            }
        }
        


        public Bar()
        {
            DoubleBuffered = true;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle rectangle = this.ClientRectangle;

            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                graphics.FillRectangle(brush, rectangle);

            }

            double k = (Max - Min) / rectangle.Width; //velikost baru v pixelech 
            int w = (int)Math.Abs(Value / k); //rozmer v pixelech a aby nebyla nikdy zaporna tak absolutni hodnota 


            using (SolidBrush brush = new SolidBrush(this.ForeColor))
            {
                if (Value > 0)
                {
                    graphics.FillRectangle(brush, rectangle.Width / 2, 0, w, rectangle.Height); //kdyby minimum a maximum nebylo symetricke, nebude fungovat, musel bych zmeni rectangle.Width
                }
                else
                {
                    graphics.FillRectangle(brush, (rectangle.Width / 2) - w, 0, w, rectangle.Height);
                }
            }


        }

    }
}
