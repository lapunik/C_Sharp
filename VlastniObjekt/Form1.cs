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

namespace SeriovyPort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            log.Add("Start App");
        }

        //List<cv5data> seznam = new List<cv5data>();
        BindingList<cv5data> seznam = new BindingList<cv5data>();  // pokud je datovym zdrojem tak se update automaticky

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            log.Add("Button LOAD");

            String fname = String.Empty;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Soubory dat (*.csv)|*.csv|Vsechny|*.*";

                if (DialogResult.OK == ofd.ShowDialog())
                {
                    log.Add(ofd.FileName);
                    fname = ofd.FileName;
                }
                else
                    log.Add("OFD Cancel");
            }

            if (String.IsNullOrEmpty(fname))
                log.Add("Nevybran soubor nebo chyba");
            else
            {
                String[] lines = File.ReadAllLines(fname);
                log.Add("Pocet radku: " + lines.Length);

                grid.Rows.Clear();
                grid.Columns.Clear();

                seznam.Clear();

                foreach (String s in lines)
                {
                    
                    cv5data d = new cv5data(s);
                    log.Add(d.ToString());
                    seznam.Add(d);
                }

                grid.DataSource = seznam;

            }
        }

        private void buttonFirst10_Click(object sender, EventArgs e)
        {
            log.Add("Prvnich deset");

            for (int i = 0; i < 10; i++)
            {

                if(seznam.Count > i)
                {

                    log.Add(seznam[i]);

                }

            }
        }

        private void buttonChange5_Click(object sender, EventArgs e)
        {
            log.Add("Change five");
            if (seznam.Count > 5)
            {
                seznam[5].DataX = DateTime.Now.Millisecond;
                seznam[5].DataY = DateTime.Now.Millisecond+10;
                seznam[5].DataZ = DateTime.Now.Millisecond+15;

                //grid.Invalidate();// překresli se

            }
        }

        private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            log.Add(String.Format("Grid err:{0} {1}",e.ColumnIndex,e.RowIndex));

            e.Cancel = false; // false zahodi zmeny, true nach editaci
        }

        int pocitadlo=0;

        Random random = new Random((int)DateTime.Now.Ticks);

        private void buttonAddData_Click(object sender, EventArgs e)
        {
            pocitadlo++;

            String line = String.Format("{0};{1};{2};{3};",pocitadlo,random.Next(200), random.Next(200), random.Next(-200,0));

            seznam.Add(new cv5data(line));

            if (grid.DataSource == null)
            {
                grid.DataSource = seznam;
            }
        }

        private void checkBoxAutoSet_CheckedChanged(object sender, EventArgs e)
        {

            timer1.Enabled = checkBoxAutoSet.Checked;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Enabled = checkBoxAutoSet.Checked;
            buttonAddData_Click(null, null);

        }

    }
}
