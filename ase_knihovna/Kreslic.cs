using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ase_knihovna
{
    public class Kreslic
    {
        public static void Kresli(Graphics graphics, Rectangle rectangle) // mueli jsme přidat odkaz na System.Drawing v odkazech abychom mohli pouzivat jmeny prostor
        {
            graphics.FillRectangle(Brushes.LightGray, rectangle);
            graphics.FillEllipse(Brushes.DodgerBlue, rectangle);

            using (Font font = new Font(FontFamily.GenericMonospace, 14))
            {
                graphics.DrawString(DateTime.Now.ToString(),font,Brushes.Black,16,rectangle.Height/2);
            }
        }

    }
}
