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

namespace NacistSoubor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            log.Add("Start APP");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log.Add("Button LOAD");


            String fname = String.Empty;

            using (OpenFileDialog ofd = new OpenFileDialog()) // by mel dispose, ale lenost tak da do using bloku
            {
                ofd.Filter = "Soubory dat(*.csv)|*.csv|Vsechny|*.*";

                if (DialogResult.OK == ofd.ShowDialog())
                {
                    log.Add(ofd.FileName);
                    fname = ofd.FileName;
                    
                }
                else
                    log.Add("OFD Cancel");
            }
            if (String.IsNullOrEmpty(fname))
                log.Add("Not picked file or error");
            else
            {
                String[] lines = File.ReadAllLines(fname);
                log.Add("Pocet radku:" + lines.Length);


                //**

                grid.Rows.Clear();
                grid.Columns.Clear();

                foreach (String s in lines)

                    ProcessLine(s);
                    //log.Add(s);

            }


        }
        char[] caSplit = new char[] { ';' };
        bool ProcessLine(String line)
        {

            //kontrola
            if (String.IsNullOrEmpty(line))
                return false;

            String[] polozky=line.Split(caSplit); //misto caSplit bylo predtim new char[] { ';'}
                                                  // log.Add(polozky.Length);

            //grid.Rows.Add(polozky);

            //vse smazat **, podle prvniho radku pridat pocet sloupcu a ze maji stejne pocet polozek jako prvin

            if (grid.Columns.Count ==0) //smazane sloupce
            {
                for(int i=0; i< polozky.Length; i++) // kdyby nefungovalo da if(chkFirstColumns.Checked) grid.Columns.Add("Col" +i, polozky[i]); else grid.Columns.Add("Col" + i,i.ToString());
                {
                    
                    grid.Columns.Add("Col" + i, i.ToString());

                }
                // if(chkFirstColumns.Checked) prvni radek nejsou data, ale 
                // return true;
            }
            
            
            return true; //tak uz nic
            grid.Rows.Add(polozky);
        }
       
    }
}
