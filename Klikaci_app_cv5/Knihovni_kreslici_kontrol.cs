using ase_knihovna;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klikaci_app_cv5
{
    public class Knihovni_kreslici_Control : Control
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle rectangle = this.ClientRectangle;

            Kreslic.Kresli(graphics, rectangle); // pouzivam knihovnu ase_knihovna

        }

        protected override void OnSizeChanged(EventArgs e)
        {
            Invalidate();
        }
    }
}
