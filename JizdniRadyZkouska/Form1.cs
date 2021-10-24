using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JizdniRadyZkouska
{
    public partial class Form1 : Form
    {


        BindingList<JizdniRady> rady = new BindingList<JizdniRady>();  // pokud je datovym zdrojem tak se update automaticky

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            String fileName = String.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Soubory dat (*.csv)|*.csv|Vsechny|*.*";

                if (DialogResult.OK == openFileDialog.ShowDialog())
                {
                    fileName = openFileDialog.FileName;
                }
            }

            if (!String.IsNullOrEmpty(fileName))
            {
                String[] lines = File.ReadAllLines(fileName);

                grid.Rows.Clear();
                grid.Columns.Clear();
                rady.Clear();

                foreach (String line in lines)
                {

                    JizdniRady d = new JizdniRady(line);
                    rady.Add(d);
                }

                grid.DataSource = rady;
                timer1.Enabled = true;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (JizdniRady r in rady)
            {

              

                if ((r.Prijezd.Hour == DateTime.Now.Hour) && (r.Prijezd.Minute == DateTime.Now.Minute) && (checkBox1.Checked))
                {
                    label1.BackColor = Color.Lime;
                    return;
                }
                else if ((r.Prijezd.Hour == DateTime.Now.Hour) && (r.Prijezd.Minute == DateTime.Now.Minute))
                {
                    label1.BackColor = Color.Blue;
                    return;
                }
                else
                {
                    label1.BackColor = Color.DarkRed;
                }


            }
        }
    }
}
