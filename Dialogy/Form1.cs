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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            log.Add("buttonColor_Click");

            using (ColorDialog dlg = new ColorDialog())
            {
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    log.Add(dlg.Color);

                    this.BackColor = dlg.Color;
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            log.Add("Start App");
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {

            using (FormNastaveni frm = new FormNastaveni())
            {

                frm.myText = "Ahoj: " + DateTime.Now;

                frm.barva = buttonSet.BackColor;

                DialogResult d = frm.ShowDialog();

                log.Add("Vratilo" + d);


                if (d == DialogResult.OK)
                {
                    log.Add("TX:" + frm.myText);
                    log.Add("Barva: " + frm.barva);
                    buttonSet.BackColor = frm.barva;
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            log.Add("Tick");
        }

        private void checkBoxTimer_CheckedChanged(object sender, EventArgs e)
        {
            timer100ms.Enabled = checkBoxTimer.Checked;
        }

        private void buttonSetShow_Click(object sender, EventArgs e)
        {
            FormNastaveni frm = new FormNastaveni();

            // musel bych tady delat nejaky frm.FormClosed a co se stalo abych chytil vysledky
            frm.Show(); // vysledky nechytám


        }

        MyData hlavniData = new MyData();

        private void buttonSet2_Click(object sender, EventArgs e)
        {
            using (FormSet2 frm = new FormSet2())
            {
                frm.data = hlavniData; // do toho formu predavam referenci na tento objekt(jako kdyz delam neco neco = new neco())

                if (DialogResult.OK == frm.ShowDialog())
                {
                    log.Add("Vysledek: ");
                    log.Add(frm.data.text);
                    log.Add(frm.data.bb);
                    log.Add(frm.data.value1);
                    log.Add(frm.data.value2);

                    
                }
                else
                {
                    log.Add("Neni OK");
                }


            }
        }
    }
}
