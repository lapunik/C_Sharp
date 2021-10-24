using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sachovnice
{
    public partial class SetColor : Form
    {

        public Color color1;
        public Color color2;

        public SetColor()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            color1 = buttonColor1.BackColor;
            
            color2 = buttonColor2.BackColor;

            DialogResult = DialogResult.OK;
            this.Close();

        }

        private void buttonColor1_Click(object sender, EventArgs e)
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    this.buttonColor1.BackColor = dialog.Color;

                    if (dialog.Color.GetBrightness() < 0.5)
                    {
                        this.buttonColor1.ForeColor = Color.White;
                    }
                    else
                    {
                        this.buttonColor1.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void buttonColor2_Click(object sender, EventArgs e)
        {
            using (ColorDialog dialog= new ColorDialog())
            {
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    this.buttonColor2.BackColor = dialog.Color;

                    if (dialog.Color.GetBrightness() < 0.5)
                    {
                        this.buttonColor2.ForeColor = Color.White;
                    }
                    else
                    {
                        this.buttonColor2.ForeColor = Color.Black;
                    }

                }
            }
        }

        private void SetColor_Load(object sender, EventArgs e)
        {

            buttonColor1.BackColor = color1;
            buttonColor2.BackColor = color2;


        }
    }
}
