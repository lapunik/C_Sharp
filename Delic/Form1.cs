using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delic
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 2; i < 64;i++)
            { 
                comboBoxM.Items.Add(i);
            }

            for (int i = 50; i < 433; i++)
            {
                comboBoxN.Items.Add(i);
            }

            for (int i = 2; i < 16; i++)
            {
                comboBoxQ.Items.Add(i);
            }

            comboBoxM.SelectedIndex = 1;
            comboBoxN.SelectedIndex = 1;
            comboBoxP.SelectedIndex = 1;
            comboBoxQ.SelectedIndex = 1;

            textBoxVstup.Text = 10.ToString();

            log.Add("Vitej v aplikaci..");
        } 

        private void checkBoxQ_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxQ.CheckState == CheckState.Checked)
            {
             
                textBoxvystupsQ.Enabled = true;
                comboBoxQ.Enabled = true;

            }
            else
            {
                textBoxvystupsQ.Enabled = false;
                comboBoxQ.Enabled = false;
                textBoxvystupsQ.Text = "";
            }

            Vypocet();
        }


        private void textBoxVstup_TextChanged(object sender, EventArgs e)
        {
            if ((comboBoxM.Text == "") || (comboBoxN.Text == "") || (comboBoxQ.Text == "") || (comboBoxP.Text == ""))
            {
                return;
            }
            Vypocet();

        }

        private void Vypocet()
        {

           // log.Add("Probiha vypocet..");

            double M = double.Parse(comboBoxM.Text);
            double N = double.Parse(comboBoxN.Text);
            double P = double.Parse(comboBoxP.Text);
            double Q = double.Parse(comboBoxQ.Text);


            if (checkBox1.CheckState == CheckState.Unchecked)
            {
                comboBoxP.BackColor = Color.White;

                double setText;

                double.TryParse(textBoxVstup.Text, out setText);
                if ((setText < 1) || (setText > 50))
                {
                    textBoxVstup.ForeColor = Color.DarkRed;
                    textBoxVstup.BackColor = Color.LightCoral;

                    log.Add("V");
                }
                else
                {
                    textBoxVstup.BackColor = Color.White;
                    textBoxVstup.ForeColor = Color.Black;
                }
                double vysledek = setText / M;

                labelM.Text = String.Format("{0}", vysledek);

                if ((vysledek < 0.95) || (vysledek > 2.1))
                {
                    comboBoxM.BackColor = Color.LightCoral;
                }
                else
                {
                    comboBoxM.BackColor = Color.White;
                }

                vysledek = vysledek * N;

                labelN.Text = String.Format("{0}", vysledek);

                if ((vysledek < 100) || (vysledek > 430))
                {
                    comboBoxN.BackColor = Color.LightCoral;

                }
                else
                {
                    comboBoxN.BackColor = Color.White;
                }


                if (checkBoxQ.CheckState == CheckState.Checked)
                {
                    double vysledekQ;

                    for (int i = 2; i < 16; i++)
                    {
                        vysledekQ = vysledek / i;

                        if (48 == Math.Round(vysledekQ))
                        {
                            textBoxvystupsQ.Text = vysledekQ.ToString();

                            comboBoxQ.SelectedIndex = i - 2;
                        }

                    }

                    if ((textBoxvystupsQ.Text == "") || (textBoxvystupsQ.Text == "Nenalezeno"))
                    {
                        textBoxvystupsQ.Text = "Nenalezeno";
                    }
                }


                vysledek = vysledek / P;

                labelP.Text = String.Format("{0}", vysledek);


                if (vysledek > 100)
                {
                    textBoxVystup.ForeColor = Color.DarkRed;
                    textBoxVystup.BackColor = Color.LightCoral;
                }
                else
                {
                    textBoxVystup.BackColor = Color.White;
                    textBoxVystup.ForeColor = Color.Black;
                }

                textBoxVystup.Text = String.Format("{0}", vysledek);



            }
            else
            {
                comboBoxM.BackColor = Color.White;

                double setText;

                double.TryParse(textBoxVystup.Text, out setText);
                if (setText > 100)
                {
                    textBoxVystup.ForeColor = Color.DarkRed;
                    textBoxVystup.BackColor = Color.LightCoral;
                }
                else
                {
                    textBoxVystup.BackColor = Color.White;
                    textBoxVystup.ForeColor = Color.Black;
                }

                double vysledek = setText * P;

                if (checkBoxQ.CheckState == CheckState.Checked)
                {
                    double vysledekQ;

                    for (int i = 2; i < 16; i++)
                    {
                        vysledekQ = vysledek * i;

                        if (48 == Math.Round(vysledekQ))
                        {
                            textBoxvystupsQ.Text = vysledekQ.ToString();

                            comboBoxQ.SelectedIndex = i - 2;
                        }

                    }

                    if ((textBoxvystupsQ.Text == "") || (textBoxvystupsQ.Text == "Nenalezeno"))
                    {
                        textBoxvystupsQ.Text = "Nenalezeno";
                    }
                }
                                               

                labelP.Text = String.Format("{0}", vysledek);

                if ((vysledek < 100) || (vysledek > 430))
                {
                    comboBoxP.BackColor = Color.LightCoral;
                }
                else
                {
                    comboBoxP.BackColor = Color.White;
                }

                vysledek = vysledek / N;

                labelN.Text = String.Format("{0}", vysledek);

                if ((vysledek < 0.95) || (vysledek > 2.1))
                {
                    comboBoxN.BackColor = Color.LightCoral;
                }
                else
                {
                    comboBoxN.BackColor = Color.White;
                }

                vysledek = vysledek * M;

                labelM.Text = String.Format("{0}", vysledek);

                if ((vysledek < 1) || (vysledek > 50))
                {
                    textBoxVstup.ForeColor = Color.DarkRed;
                    textBoxVstup.BackColor = Color.LightCoral;
                }
                else
                {
                    textBoxVstup.BackColor = Color.White;
                    textBoxVstup.ForeColor = Color.Black;
                }

                textBoxVstup.Text = String.Format("{0}", vysledek); ;
            }

           // log.Add("Vypocet hotov");
        }

        private void textBoxVystup_TextChanged(object sender, EventArgs e)
        {
            if ((comboBoxM.Text == "") || (comboBoxN.Text == "") || (comboBoxQ.Text == "") || (comboBoxP.Text == ""))
            {
                return;
            }
            Vypocet();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboBoxM.Text == "") || (comboBoxN.Text == "") || (comboBoxQ.Text == "") || (comboBoxP.Text == ""))
            {
                return;
            }
            Vypocet();
        }
    }
}
