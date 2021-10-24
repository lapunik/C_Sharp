using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino
{
    /*
     *	       __          __                __            
     *	  ____/ /__ _   __/ /_  ____  ____  / /__ _________
     *	 / __  / _ \ | / / __ \/ __ \/ __ \/ //_// ___/_  /
     *	/ /_/ /  __/ |/ / /_/ / /_/ / /_/ / ,< _/ /__  / /_
     *	\__,_/\___/|___/_.___/\____/\____/_/|_(_)___/ /___/
     *                                                   
     *                                                           
     *      TUTORIÁLY  <>  DISKUZE  <>  KOMUNITA  <>  SOFTWARE
     * 
     *	Tento zdrojový kód je součástí tutoriálů na programátorské 
     *	sociální síti WWW.DEVBOOK.CZ	
     *	
     *	Kód můžete upravovat jak chcete, jen zmiňte odkaz 
     *	na www.devbook.cz :-) 
     */

    public partial class KinoForm : Form
    {
        private Kinosal kinosal = new Kinosal();

        public KinoForm()
        {
            InitializeComponent();
        }

        private void kinoPictureBox_Paint(object sender, PaintEventArgs e)
        {
            kinosal.Vykresli(e.Graphics);
        }

    }
}
