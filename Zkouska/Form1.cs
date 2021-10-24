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

namespace Zkouska
{
    public partial class Form1 : Form
    {

        List<String> slova = new List<String>();
        List<char> pouzite = new List<char>();
        String hledane_slovo;
        int chyby = 0;
        int trefa = 0;
        Color barvicka = Color.ForestGreen;



        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            buttonTry.Enabled = false;
            textBoxIn.Enabled = false;

            String fileName = String.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Soubory dat (*.csv)|*.csv|Vsechny|*.*";

                if (DialogResult.OK == openFileDialog.ShowDialog())
                {
                    fileName = openFileDialog.FileName;
                }

                if (!String.IsNullOrEmpty(fileName))
                {
                    String[] lines = File.ReadAllLines(fileName, Encoding.GetEncoding("Windows-1250"));

                    foreach (string line in lines)
                    {
                        slova.Add(line);
                    }

                }
                else
                {
                    Environment.Exit(0);
                }
            }

            log.Add("Soubor se slovy nahrán");

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {

            Random random = new Random();

            hledane_slovo = slova[random.Next(0, slova.Count)];

            buttonTry.Enabled = true;
            textBoxIn.Enabled = true;

            NoveSlovo();

            chyby = 0;
            trefa = 0;
            pouzite.Clear();

            for (int i = 0;i < tableLayoutBar.Controls.Count; i++) { 
                tableLayoutBar.Controls[i].Text = "";
                tableLayoutBar.Controls[i].BackColor = barvicka;
            }

            log.Add("Zahájena nová hra, slovo má " + hledane_slovo.Length + " písmen");
        }

        private void NoveSlovo()
        {
            while (tableLayoutPanelUkazSlovo.Controls.Count > 1)
            {

                tableLayoutPanelUkazSlovo.Controls.RemoveAt((tableLayoutPanelUkazSlovo.Controls.Count) - 1);

            }

            while (tableLayoutPanelUkazSlovo.ColumnStyles.Count != 1)
            {
                tableLayoutPanelUkazSlovo.ColumnStyles.RemoveAt((tableLayoutPanelUkazSlovo.ColumnStyles.Count) - 1);
                tableLayoutPanelUkazSlovo.ColumnCount = tableLayoutPanelUkazSlovo.ColumnStyles.Count;
            }



            while (hledane_slovo.Length > tableLayoutPanelUkazSlovo.ColumnStyles.Count)
            {
                tableLayoutPanelUkazSlovo.ColumnStyles.Add(new ColumnStyle());
                tableLayoutPanelUkazSlovo.ColumnCount = tableLayoutPanelUkazSlovo.ColumnStyles.Count;

            }

            foreach (ColumnStyle cs in tableLayoutPanelUkazSlovo.ColumnStyles)
            {
                cs.SizeType = SizeType.Percent;
                cs.Width = 100;
            }

            while (tableLayoutPanelUkazSlovo.Controls.Count != 0)
            {
                tableLayoutPanelUkazSlovo.Controls.RemoveAt(0);
            }

            for (int i = 0; i < tableLayoutPanelUkazSlovo.ColumnStyles.Count; i++)
            {

                Label label = new Label()
                {
                    Text = "",
                    Dock = DockStyle.Fill,
                    Font = new Font("Microsoft Sans Serif", 12),
                    BackColor = Color.LightGray,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                tableLayoutPanelUkazSlovo.Controls.Add(label);

            }

        }

        private void buttonTry_Click(object sender, EventArgs e)
        {

            foreach (char c in pouzite)
            {
                if (Convert.ToChar(textBoxIn.Text) == c)
                {
                    return;
                }
            }

            pouzite.Add(Convert.ToChar(textBoxIn.Text));

            
            bool hit = false;
            int i = 0;

            foreach (char c in hledane_slovo)
            {

                if (c == Convert.ToChar(textBoxIn.Text))
                {

                    Label label = new Label()
                    {
                        Text = "",
                        Dock = DockStyle.Fill,
                        Font = new Font("Microsoft Sans Serif", 12)
                    };

                    (tableLayoutPanelUkazSlovo.Controls[i] as Label).Text = c + "";

                    hit = true;


                    ////////
                    trefa++;
                    ////////
                }


                i++;
            }

            if (trefa == hledane_slovo.Length)
            {
                log.Add("Výhra!");

                DialogResult d = MessageBox.Show("Vyhrál si!", "Výhra", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (d == DialogResult.Yes)
                {
                    chyby = 0;
                    trefa = 0;
                    buttonStart_Click(null, null);
                    return;
                }
                else
                {
                    Environment.Exit(0);
                }
            }

            if (!hit)
            {
                log.Add("Vedle! Pismeno \"" + textBoxIn.Text + "\" není správně ");

                (tableLayoutBar.Controls[6 - chyby] as Label).BackColor = Color.Maroon;

                chyby++;

                if (chyby == 7)
                {
                    log.Add("Prohra!");

                    DialogResult d = MessageBox.Show("Prohrál si! hledané slovo bylo: "+ hledane_slovo +" ", "Prohra", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (d == DialogResult.Yes)
                    {

                        chyby = 0;
                        trefa = 0;
                        buttonStart_Click(null, null);
                        return;
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
            }
            else
            {
                log.Add("Trefa! Pismeno \"" + textBoxIn.Text + "\" je správně ");
                
            }

        }

        private void textBoxIn_TextChanged(object sender, EventArgs e)
        {
            if (textBoxIn.Text.Length > 1)
            {
                textBoxIn.Text = textBoxIn.Text[0] + "";
            }
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    log.Add(dlg.Color);

                    barvicka = dlg.Color;

                    int i = 0;

                    foreach (Label label in tableLayoutBar.Controls)
                    {
                        if (i <= (6-chyby))
                        {
                            label.BackColor = barvicka;
                        }
                        i++;
                    }
                }
            }
        }
    }
}
