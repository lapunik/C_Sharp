using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dialogy
{
    public partial class FormNastaveni : Form
    {

        public String myText =  String.Empty;
        public Color barva = Color.White;

        public FormNastaveni()
        {
            InitializeComponent();
        }
        
        private void FormNastaveni_Load(object sender, EventArgs e)
        {
            textData.Text = myText;

            foreach (Control ctrl in groupBoxBarva.Controls)
            {
                RadioButton radioButton = ctrl as RadioButton;
                if (radioButton == null)
                {
                    continue;
                }
                if (radioButton.ForeColor == barva)
                {
                    radioButton.Checked = true;
                    break;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort; // rekne mi kdo to zavrel ze to bylo tlacitko a ne krizek
            this.Close();

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            // v návrhu jsem zmenil dialog result na ok takze vraci close

                myText = textData.Text;

            foreach (Control ctrl in groupBoxBarva.Controls)
            {
                RadioButton radioButton = ctrl as RadioButton;
                if (radioButton == null)
                {
                    continue;
                }
                if (radioButton.Checked)
                {
                    barva = radioButton.ForeColor;
                    break;
                }
            }

        }
    }
}
