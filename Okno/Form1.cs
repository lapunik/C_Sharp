using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Okno
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      cnt = -1;
      PressMe_Click(null, null);
    }

    int cnt;

    private void PressMe_Click(object sender, EventArgs e)
    {
      btnDruhej.Text += "Ahoj";

      cnt++;
      lblPocet.Text = cnt.ToString("X");

      //      if ((cnt % 2) != 0)
      /*
      if ((cnt & 1) != 0)
        lblPocet.BackColor = Color.GreenYellow;
      else
        lblPocet.BackColor = Color.Orange;
        */

      // lblPocet.BackColor = ((cnt % 2) != 0) ? Color.GreenYellow : Color.Orange;

      if (lblPocet.BackColor != Color.GreenYellow)
        lblPocet.BackColor = Color.GreenYellow;
      else
        lblPocet.BackColor = Color.Orange;
    }

    private void btnQuit_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btnDruhej_MouseHover(object sender, EventArgs e)
    {
      btnDruhej.BackColor = Color.FromArgb(0,255,128); // Color.GreenYellow;
    }

    private void btnDruhej_MouseLeave(object sender, EventArgs e)
    {
      btnDruhej.BackColor = SystemColors.ControlDark;
    }
  }
}
