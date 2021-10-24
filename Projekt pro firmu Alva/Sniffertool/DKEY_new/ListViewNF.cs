using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKEY_new
{
    class ListViewNF : System.Windows.Forms.ListView
    {
        public ListViewNF()
        {
            //Activate double buffering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            //Enable the OnNotifyMessage event so we get a chance to filter out 
            // Windows messages before they get to the form's WndProc
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
        }

        protected override void OnNotifyMessage(System.Windows.Forms.Message m)
        {
            if(m.Msg != 0x14)
            base.OnNotifyMessage(m);
        }
       
    }
}
