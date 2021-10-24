using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _PrvniKlikacka
{
    public partial class Form1 : Form
    {

        int cnt;
        bool i = true;

        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            cnt = 1;

            PressMe_Click(null,null);

        }

        private void btnDruhej_MouseHover(object sender, EventArgs e)
        {

            btnDruhej.BackColor = Color.Gold;

        }

        private void btnDruhej_MouseLeave(object sender, EventArgs e)
        {

            btnDruhej.BackColor = Color.Black;

        }

        private void Konec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PressMe_Click(object sender, EventArgs e)
        {
            PressMe.Text = "Again!";

            btnDruhej.Text += "Hello";

            cnt++;

            lblPocet.Text = cnt.ToString("X"); // sestnactkova soustava... kdyz chcu desitkovou dam tam D

            /*  if ((cnt & 1) != 0)

              {
                  lblPocet.BlackColor = Color.GreenYellow;
              }
              else

              {
                  lbl.Pocet.BlackColor = Color.Orange;
              }

      */

            if (lblPocet.BackColor != Color.GreenYellow)

            {
                lblPocet.BackColor = Color.GreenYellow;
            }
            else

            {
                lblPocet.BackColor = Color.Orange;
            }
        }

        private void lblPocet_Click(object sender, EventArgs e)
        {

        }

        private void Magic_Click(object sender, EventArgs e)
        {
            if (i == true)
            {
                picture.Image = Image.FromFile("C:\\Users\\Lapunik\\Dropbox\\C#\\CSharp\\PrvniKlikacka\\PrvniKlikacka\\Resources\\wizard-1454385_960_720.png");
                i = false;
            }
            else
            {
                picture.Image = Image.FromFile("C:\\Users\\Lapunik\\Dropbox\\C#\\CSharp\\PrvniKlikacka\\PrvniKlikacka\\Resources\\wizard-36676_960_720.png");
                i = true;
            }


        }

        private void picture_Click(object sender, EventArgs e)
        {

            //picture.BackColor = Color.LightGreen;

            //picture.Image = Image.FromFile("C:\\Users\\Lapunik\\Dropbox\\C#\\CSharp\\PrvniKlikacka\\PrvniKlikacka\\Resources\\wizard-1454385_960_720.png");

            if (picture.BackColor != Color.LightGreen)

            {
                picture.BackColor = Color.LightGreen;
            }
            else

            {
                picture.BackColor = Color.LightPink;
            }



        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
