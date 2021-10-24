using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protokol
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        void AddProkotol(object o)
        {
            String s = String.Format("{0:HH:mmm:ss.fff} {1}", DateTime.Now, o);

            if (chkAddToTop.Checked)
            {
                lbProtokol.Items.Insert(0, s);
                lbProtokol.SelectedIndex = 0;

                while (lbProtokol.Items.Count > numericPocet.Value)
                {
                    lbProtokol.Items.RemoveAt(lbProtokol.Items.Count-1);
                }
            }
            else
            {
                while (lbProtokol.Items.Count > numericPocet.Value)
                {
                    lbProtokol.Items.RemoveAt(0);
                }

                lbProtokol.Items.Add(s);
                lbProtokol.SelectedIndex = lbProtokol.Items.Count - 1;
                lbProtokol.SelectedIndex = -1; //aby nebyl modrej(odvybrat)
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            AddProkotol("Akce");
            AddProkotol(DateTime.Now);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddProkotol("Start programu");
        }

        private void timer100ms_Tick(object sender, EventArgs e)
        {
            AddProkotol("Tick");
        }

        private void chkRunTimer_CheckedChanged(object sender, EventArgs e)
        {
            timer100ms.Enabled = chkRunTimer.Checked;
        }

    }
}
