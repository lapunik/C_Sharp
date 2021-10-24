using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrevodnikMeziCiselnymiSoustavami
{
    public partial class Form1 : Form
    {

        // otočit bity 

        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            while (tablePanelCheckBox.ColumnStyles.Count != 0)
            {
                tablePanelCheckBox.Controls.RemoveAt((tablePanelCheckBox.ColumnStyles.Count) - 1);
                tablePanelCheckBox.ColumnStyles.RemoveAt((tablePanelCheckBox.ColumnStyles.Count) - 1);
                tablePanelCheckBox.ColumnCount = tablePanelCheckBox.ColumnStyles.Count;

            }

            while (int.Parse(comboBox1.Text) > tablePanelCheckBox.ColumnStyles.Count)
            {
                tablePanelCheckBox.ColumnStyles.Add(new ColumnStyle());
                tablePanelCheckBox.ColumnCount = tablePanelCheckBox.ColumnStyles.Count;


                CheckBox checkBox = new CheckBox()
                {
                    BackColor = SystemColors.Control,
                    // Text = (tablePanelCheckBox.ColumnStyles.Count).ToString(),
                    Text = (int.Parse(comboBox1.Text)-(tablePanelCheckBox.ColumnStyles.Count)).ToString(),
                    TextAlign = ContentAlignment.BottomCenter,
                    CheckAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,

                };

                checkBox.CheckedChanged += checkBox_CheckedChanged;

                tablePanelCheckBox.Controls.Add(checkBox);



            }

            foreach (ColumnStyle cs in tablePanelCheckBox.ColumnStyles)
            {
                cs.SizeType = SizeType.Percent;
                cs.Width = 100;
            }

            checkBox_CheckedChanged(null,null);

        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            labelBin.Text = "";

            for (int i = tablePanelCheckBox.ColumnStyles.Count-1; i != (-1);i--)
            {
                CheckBox checkBox = tablePanelCheckBox.Controls[i] as CheckBox;
                if (checkBox == null)
                {
                    return;
                }

                if (checkBox.CheckState == CheckState.Checked)
                {

                    labelBin.Text = String.Format("1{0}", labelBin.Text);

                }
                else
                {
                    labelBin.Text = String.Format("0{0}", labelBin.Text);
                }

            }

            int dec = Convert.ToInt32(labelBin.Text, 2);
            labelDec.Text = String.Format("{0}", dec);
            labelHex.Text = String.Format("{0:X}",dec);
           


        }

        private void buttonSet_Click(object sender, EventArgs e)
        {

            int.TryParse(textBoxNum.Text, out int setText);
            if ((setText > ((Math.Pow(2, tablePanelCheckBox.Controls.Count))-1)) || ((setText) < 0)) //od nuly do 2 na n
            {

                //textBoxNum.Text = "";
                return;
            }
            else
            {
                string s = Convert.ToString(setText, 2);

                while (s.Length < tablePanelCheckBox.ColumnStyles.Count)
                {
                    s = "0" + s; 
                }

                textBoxNum.Text = "";

                for (int i = 0; i < tablePanelCheckBox.ColumnStyles.Count; i++)
                {
                    CheckBox checkBox = tablePanelCheckBox.Controls[i] as CheckBox;
                    if (checkBox == null)
                    {
                        return;
                    }

                    checkBox.CheckState = CheckState.Unchecked;

                    if (s[i] =='1')
                    {

                        checkBox.CheckState = CheckState.Checked;

                    }


                }

            }

            
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            comboBox1.SelectedIndex = 0;
        }
    }
}
