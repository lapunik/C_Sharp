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

namespace DruhaKlikacka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Tlacitkokonec_Click(object sender, EventArgs e)
        {

            Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) // tady už proces zavírání nezastavím.. mohu pomocí FormClosing
        {
            // CloseReason dává informaci o zavření
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("Jsi si jistý?", "Ukoncovani..", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))//Show..ukaz, text, nadpis, muzu si vybrat tlačítka messagebox
            {

                e.Cancel = true; // zrusit zavirani... e jako vstup funkce
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text += String.Format("CheckBox: {0} {1}\n", checkBox1.Checked, checkBox1.CheckState);

            //pokud chci mit tri stavy, musim nastavit true v navrhu threestate
        }

        private void buttontext_Click(object sender, EventArgs e)
        {
            label1.Text += String.Format("\n{0}", textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;

            // i = int.Parse(textBox1.Text); // ne uplne bezpecne
            //label1.Text += String.Format("\n{0}", i);


            if (int.TryParse(textBox1.Text, out i))
            //if (int.TryParse(textBox1.Text,NumberStyles.HexNumber,null, out i)) // to samý hexadecimálně
            {
                label1.Text += String.Format("\n{0}", i);
            }
            else
            {
                label1.Text += "\nNeni Cislo!";
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        { 

            label1.Text += String.Format("RadioButton: 1:{0} 2:{1} 3:{2} \n", radioButton1.Checked, radioButton2.Checked, radioButton5.Checked); //nefunguje protoze nevypisuje stav pokud prepinam mezi 2 a 5 ... musim udelat jinak:

        }

    }
}
