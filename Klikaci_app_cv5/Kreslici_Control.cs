using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klikaci_app_cv5
{
    public class Kreslici_Control : Control
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle rectangle = this.ClientRectangle;

            graphics.FillRectangle(Brushes.DodgerBlue, rectangle);
            graphics.FillEllipse(Brushes.LightGray, rectangle);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            Invalidate();
        }
    }
}
