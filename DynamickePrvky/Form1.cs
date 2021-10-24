using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamickePrvky
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int cnt = 0;

        private void addflow_Click(object sender, EventArgs e)
        {
            cnt++;

            Button btn = new Button()
            {
                BackColor = SystemColors.Control,
                Width = 64,
                Height = 32,
                Tag = cnt,
                Text = cnt.ToString()
            };
            btn.Click += Btn_Click;

            flowLayoutPanel1.Controls.Add(btn);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null)
            {
                return;
            }
            lblState.Text = "Btn" + btn.Text;
        }

        private void delflow_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (!int.TryParse(txIndex.Text, out id))
            {
                lblState.Text = "Neni Cislo";
                return;
            }

            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {

                Button btn = ctrl as Button;
                if (btn == null)
                {
                    continue;
                }

                if ( (btn.Tag is int) && (((int) btn.Tag) == id))
                {
                    flowLayoutPanel1.Controls.Remove(ctrl);
                    break;
                }

            }

            lblState.Text = "Del: " + id;
        }

        private void addcolumn_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnCount = tableLayoutPanel1.ColumnStyles.Count;

            foreach (ColumnStyle cs in tableLayoutPanel1.ColumnStyles)
            {
                cs.SizeType = SizeType.Percent;
                cs.Width = 100;
            }
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {

            int r = 0,c = tableLayoutPanel1.ColumnCount - 1;

            foreach(Control ctrl in tableLayoutPanel1.Controls)
                {

                if ((tableLayoutPanel1.GetRow(ctrl) == r) && (tableLayoutPanel1.GetColumn(ctrl) == c))
                {
                    lblState.Text = "Obsazeno";
                    return; // nic nedělej
                }

            }



            Button btn = new Button()
            {
                BackColor = SystemColors.Control,
                Dock = DockStyle.Fill,
                Text = "T: " + c
            };

            btn.Click += Btn_Click;

            tableLayoutPanel1.Controls.Add(btn, tableLayoutPanel1.ColumnCount - 1, 0);

        }
    }
}
