using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prvky
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      lblInfo.Text = "Start APP";

      radioSkupina1_CheckedChanged(null, null);
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {

    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (DialogResult.No == MessageBox.Show(
        "Nemate ulozena data, opravdu zavrit ?",
        "Konec programu", MessageBoxButtons.YesNo, 
        MessageBoxIcon.Error))
        e.Cancel = true;      // zrusit zavirani okna
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      lblInfo.Text += String.Format("\nCheckbox {0} {1}",
        checkBox1.Checked, checkBox1.CheckState);
    }

    private void checkBox1_CheckStateChanged(object sender, EventArgs e)
    {
      lblInfo.Text += String.Format("\nState {0} {1}",
  checkBox1.Checked, checkBox1.CheckState);
    }

    private void radioSkupina1_CheckedChanged(object sender, EventArgs e)
    {
      // RadioButton rb = (RadioButton)sender;  // ne-bezpecne pretypovani
      RadioButton rb = sender as RadioButton;  // bezpecne pretypovani
      if (rb == null)
      {
        lblInfo.Text += "\nNeni Radio";
        return;
      }

      lblInfo.Text += String.Format("\n{0} {1} {2} od {3}", 
        rb1.Checked, rb2.Checked, rb3.Checked, rb.Text);
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      lblInfo.Text = String.Empty;  // stejne jako "";
    }

    private void btnText_Click(object sender, EventArgs e)
    {
      lblInfo.Text += String.Format("\n{0}",
        txInput.Text);
    }

    private void btnInt_Click(object sender, EventArgs e)
    {
      int i = 0;
      //i = int.Parse(txInput.Text);  // ne-bezpecne

      if (rbHex.Checked)      // hex
      {
        if (int.TryParse(txInput.Text, NumberStyles.HexNumber, 
          null, out i))
          lblInfo.Text += String.Format("\n{0} {0:X}", i);
        else
          lblInfo.Text += "\nNeni HEX cislo";
      }
      else          // DEC nebo nic
      {
        if (int.TryParse(txInput.Text, out i))
          lblInfo.Text += String.Format("\n{0} {0:X}", i);
        else
          lblInfo.Text += "\nNeni cislo";
      }
    }

    }
}
