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
    public partial class SetColumnAndRow : Form
    {

        public int numberOfColumn;
        public int numberOfRow;

        public SetColumnAndRow()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            numberOfColumn = (int)numericUpDownColumn.Value;
            numberOfRow = (int)numericUpDownRow.Value;
            DialogResult = DialogResult.OK;
            this.Close();


        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void SetColumnAndRow_Load(object sender, EventArgs e)
        {
           numericUpDownColumn.Value = numberOfColumn;
           numericUpDownRow.Value = numberOfRow;
        }

        private void numericUpDownRow_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownRow.Value < 1)
            {
                numericUpDownRow.Value = 1;
            }
            if (numericUpDownRow.Value > 20)
            {
                numericUpDownRow.Value = 20;
            }
        }

        private void numericUpDownColumn_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownColumn.Value < 1)
            {
                numericUpDownColumn.Value = 1;
            }
            if (numericUpDownColumn.Value > 20)
            {
                numericUpDownColumn.Value = 20;
            }
        }
    }
}
