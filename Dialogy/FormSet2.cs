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
    public partial class FormSet2 : Form
    {

        public FormSet2()
        {
            InitializeComponent();
        }

        public MyData data = null;

        private void FormNastaveni_Load(object sender, EventArgs e)
        {
            if (data != null)
            {
                checkBox1.Checked = data.bb;
                textBox1.Text = data.text;
                numericUpDown1.Value = data.value1;
                numericUpDown2.Value = data.value2;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort; 
            this.Close();

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {

            if (data == null)
                data = new MyData();

            data.bb = checkBox1.Checked;
            data.text = textBox1.Text;
            data.value1 = (int)numericUpDown1.Value;
            data.value2 = (int)numericUpDown2.Value;


            DialogResult = DialogResult.OK;
            this.Close();

        }

    }
}
