using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Dice
{
    public class Dice : Control
    {

        public Dice()
        {
            DoubleBuffered = true;
            Number = 6;
        }

        public int Number { get; set; }

        private Random randomNumber; 

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics graphics = pe.Graphics;
            Rectangle rectangle = this.ClientRectangle;

            int rectangleSize;

            if (rectangle.Height < rectangle.Width)
            {
                rectangleSize = rectangle.Height;
            }
            else
            {
                rectangleSize = rectangle.Width;
            }

            using (SolidBrush brush = new SolidBrush(Color.LightGoldenrodYellow))
            {
                int rectangleWidth = (rectangle.Width / 2) - (rectangleSize / 2);
                int rectangleHeight = (rectangle.Height / 2) - (rectangleSize / 2);

                graphics.FillRectangle(brush, rectangleWidth, rectangleHeight , rectangleSize, rectangleSize);

                brush.Color = Color.Black;

                int radius = rectangleSize / 4;

                if ((Number == 1) || (Number == 3) || (Number == 5))
                    graphics.FillEllipse(brush, (rectangle.Width / 2) - radius / 2, (rectangle.Height / 2) - radius / 2, radius, radius); // střed střed
                
                if ((Number == 4) || (Number == 5) || (Number == 6))
                    graphics.FillEllipse(brush, rectangleWidth + (rectangleSize / 4) - (radius / 2),(rectangleHeight) + (rectangleSize / 4) - (radius / 2), radius, radius); // levá horní
                
                if ((Number == 6))
                    graphics.FillEllipse(brush, rectangleWidth + (rectangleSize / 4) - (radius / 2), (rectangleHeight) + (rectangleSize / 2) - (radius / 2), radius, radius); // levá střed
                
                if ((Number == 2) || (Number == 3) || (Number == 4) || (Number == 5) ||(Number == 6))
                    graphics.FillEllipse(brush, rectangleWidth + (rectangleSize / 4) - (radius / 2), (rectangleHeight) + ((rectangleSize*3) / 4) - (radius / 2), radius, radius); // levá dolní
    
                if ((Number == 2) || (Number == 3) || (Number == 4) || (Number == 5) || (Number == 6))
                    graphics.FillEllipse(brush, rectangleWidth + ((rectangleSize*3) / 4) - (radius / 2), (rectangleHeight) + (rectangleSize / 4) - (radius / 2), radius, radius); // pravá horní

                if (Number == 6)
                    graphics.FillEllipse(brush, rectangleWidth + ((rectangleSize*3) / 4) - (radius / 2), (rectangleHeight) + (rectangleSize / 2) - (radius / 2), radius, radius); // pravá střed

                if ((Number == 4) || (Number == 5) || (Number == 6))
                    graphics.FillEllipse(brush, rectangleWidth + ((rectangleSize*3) / 4) - (radius / 2), (rectangleHeight) + ((rectangleSize * 3) / 4) - (radius / 2), radius, radius); // pravá dolní

            }
                       
        }

        public void Throw()
        {
            randomNumber = new Random();
            System.Threading.Thread.Sleep(randomNumber.Next(5, 10));
            
            int number = randomNumber.Next(1, 5); // od 1 do 4, protože kostka se může z jedné strany přetočit jen na čtyři jiné strany

            if ((Number == 1) || (Number == 6))
            {
                if (number == 1)
                    number = 5;
            }
            else if ((Number == 2) || (Number == 5))
            {
                if (number == 2)
                    number = 6;
            }

            else if ((Number == 3) || (Number == 4))
            {
                if (number == 4)
                    number = 5;
                if (number == 3)
                    number = 6;
            }

            Number = number;
            Invalidate();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            Invalidate();
        }

    }
}
