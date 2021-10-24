using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VlakyTT
{
    public partial class Picture : Form
    {
        public Image image; // veřejná proměná typu obrázek

        public Picture(Image image) // konstruktor třídy, pouze do pictureBoxu uloží obrázek a tím ho zobrazí
        {
            InitializeComponent();
            pictureBox1.Image = image; // díky tomu že je picture box větší než ten na který jsme klikali v formuláři "Manual", obrázek se zvětší a je lépe vidět
        }
    }
}
