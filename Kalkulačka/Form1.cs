using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulačka
{
    public partial class Formular : Form
    {

        //List<int> Cisla = new List<int>();
        List<float> Cisla = new List<float>();
        List<string> Znamenka = new List<string>();
        private bool dalsivypocet = true;
        private bool chytrakalkulacka = true;
        string displejtext1;
        string displejtext2;

        float posledniCislo;
        string posledniZnamenko;
        float posledniVysledek;
        

        public Formular()
        {
            InitializeComponent();
        }

        private void Formular_Load(object sender, EventArgs e)
        {
            displej.Text = "";
            displej2.Text = "";
        }


        private void vsechnycisla_Click(object sender, EventArgs e)
        {

            //AkceCisla(cislo1.Text);

            Button bt = sender as Button;  // bezpecne pretypovani
           /* if (bt == null)
            {
                return;
            }*/

         AkceCisla(bt.Tag as string);

        }


        private void clearall_Click(object sender, EventArgs e) ////////////////////////////////////////////////////////////////////////////////////
        {
            VymazVse();
            dalsivypocet = true;

        }

        private void carka_Click(object sender, EventArgs e) ////////////////////////////////////////////////////////////////////////////////////
        {
            if (!(displej.Text.Contains(",")))
            {
                if ((displej.Text == "") || (dalsivypocet == true))
                {
                    AkceCisla(cislo0.Text);
                    AkceCisla(carka.Text);
                }
                else
                {
                    AkceCisla(carka.Text);
                }
            }
        }

        
        private void AkceRovnaSe() // Zunkce zpracovávající vysledku 
        {
            if (Znamenka.Count != 0)
            {
                posledniZnamenko = Znamenka[Znamenka.Count - 1];

                posledniCislo = Cisla[Cisla.Count - 1];
            }

            if (OsetreniNuly())
            {
                if (chytrakalkulacka)
                {
                    ChytraKalKulacka();
                }
                HloupaKalkulacka();
            }
            else
            {
                //MessageBox.Show("Nelze dělit číslem \"0\" !", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


        }
        private bool OsetreniNuly() ////////////////////////////////////////////////////////////////////////////////////
        {
            bool dobry = true;

            if (Znamenka.Count != Cisla.Count)
            {

                for (int i = 0; i < Znamenka.Count; i++)
                {

                    if ((Znamenka[i] == "÷") && (Cisla[i + 1] == 0))
                    {
                        dobry = false;
                    }


                }
            }
            else
            {
                for (int i = 0; i < Znamenka.Count-1; i++)
                {

                    if ((Znamenka[i] == "÷") && (Cisla[i + 1] == 0))
                    {
                        dobry = false;
                    }


                }
            }
            return dobry;
        }

        private void AkceCisla(string cislo) // Funkce zpracovávající číslice 
        {
            if (dalsivypocet == true)
            {
                displej.Text = "";
                displejtext1 = "";
                dalsivypocet = false;
            }
            displej.Text += cislo;
            displejtext1 += cislo;

        }

        private void AkceZnamenka(string znamenko) // Funkce zpracovávající znaménko 
        {

            dalsivypocet = false;

            if ((displejtext1 == "") && (displejtext2 == ""))
            {
                if (znamenko == "-")
                {
                    AkceCisla(znamenko);
                }
            }
            else if ((displejtext1 == ""))
            {

                if (znamenko == "-")
                {
                    AkceCisla(znamenko);
                }
                else
                {

                    Znamenka.RemoveAt(Znamenka.Count - 1);
                    Znamenka.Add(znamenko);
                    displej2.Text = "";
                    displejtext2 = "";
                    for (int i = 0; i < Znamenka.Count; i++)
                    {
                        displej2.Text += (Cisla[i]).ToString();
                        displej2.Text += (Znamenka[i]).ToString();

                    }
                    displej.Text = "";
                    displejtext1 = "";

                }
            }
            else if (displejtext1 == "-")
            {

                if (Znamenka.Count!=0) {
                    Znamenka.RemoveAt(Znamenka.Count - 1);
                    Znamenka.Add(znamenko);
                    displej2.Text = "";
                    displejtext2 = "";
                    for (int i = 0; i < Znamenka.Count; i++)
                    {
                        displej2.Text += (Cisla[i]).ToString();
                        displej2.Text += (Znamenka[i]).ToString();

                    }
                    displej.Text = "";
                    displejtext1 = "";
                }
            }
            else
            {

                //Cisla.Add(int.Parse(displej.Text));
                Cisla.Add(float.Parse(displej.Text));
                Znamenka.Add(znamenko);
                displej.Text += znamenko;
                displejtext1 += znamenko;
                displej2.Text += displej.Text;
                displejtext2 += displejtext1;
                displej.Text = "";
                displejtext1 = "";
            }



        }

        private void znamenka_Click(object sender, EventArgs e) ////////////////////////////////////////////////////////////////////////////////////
        {
            
            Button bt = sender as Button;  // bezpecne pretypovani
            if (bt == null)
            {
                return;
            }

            AkceZnamenka(bt.Tag as string);

        }


        private void rovnase_Click(object sender, EventArgs e) ////////////////////////////////////////////////////////////////////////////////////
        {
            if (dalsivypocet)
            {
                Znamenka.Add(posledniZnamenko);
                Cisla.Add(posledniVysledek);
                Cisla.Add(posledniCislo);
                AkceRovnaSe();
            }
            else if (displej.Text != "")
            {
                //Cisla.Add(int.Parse(displej.Text));
                Cisla.Add(float.Parse(displej.Text));

                if (OsetreniNuly())
                {
                    displej2.Text += displej.Text;
                    displej.Text = "";
                }
                else
                {
                    Cisla.RemoveAt(Cisla.Count - 1);
                }
                AkceRovnaSe();
            }
            else if ((displej.Text == "") && (displej2.Text != ""))
            {
                if (Znamenka.Count==Cisla.Count)
                {
                    Znamenka.RemoveAt(Znamenka.Count - 1);
                }
                AkceRovnaSe();

            }


            
            

        }

        private void HloupaKalkulacka() ////////////////////////////////////////////////////////////////////////////////////
        {

            //int vysledek = Cisla[0];
            float vysledek = Cisla[0];

            for (int i = 0; i < Znamenka.Count; i++)
            {

                switch (Znamenka[i])
                {

                    case "+":
                        vysledek += Cisla[i + 1];
                        break;

                    case "-":
                        vysledek -= Cisla[i + 1];
                        break;

                    case "×":
                        vysledek *= Cisla[i + 1];
                        break;

                    case "÷":
                        vysledek /= Cisla[i + 1];
                        break;

                    default:
                        displej.Text = "Neco se posralo";
                        break;

                }
            }

            posledniVysledek = vysledek;

            displej.Text = vysledek.ToString();
            VymazVse();
            displej.Text = vysledek.ToString();
            dalsivypocet = true;


        }

        private void ChytraKalKulacka() ////////////////////////////////////////////////////////////////////////////////////
        {
            for (int i = 0; i < Znamenka.Count; i++)
            {
                if (Znamenka[i] == "×")
                {
                    Cisla[i] = Cisla[i] * Cisla[i + 1];
                    Cisla.RemoveAt(i + 1);
                    Znamenka.RemoveAt(i);
                    i--;
                }
                else if (Znamenka[i] == "÷")
                {
                    Cisla[i] = Cisla[i] / Cisla[i + 1];
                    Cisla.RemoveAt(i + 1);
                    Znamenka.RemoveAt(i);
                    i--;
                }

            }
        }
        private void VymazVse() ////////////////////////////////////////////////////////////////////////////////////
        {
            displej.Text = "";
            displej2.Text = "";

            Cisla.Clear();
            Znamenka.Clear();

        }

        private void Formular_FormClosing(object sender, FormClosingEventArgs e) ////////////////////////////////////////////////////////////////////////////////////
        {
            if (!dalsivypocet)
            {
                if (DialogResult.No == MessageBox.Show("Nemáš dopočtený příklad, opravdu chceš ukončit kalkulačku?", "Ukoncovani..", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))//Show..ukaz, text, nadpis, muzu si vybrat tlačítka messagebox
                {

                    e.Cancel = true; // zrusit zavirani v pridape ze se pocita priklad
                }
            }
        }

        private void clear_Click(object sender, EventArgs e) ////////////////////////////////////////////////////////////////////////////////////
        {
            if (displej.Text != "")
            {
                displej.Text = displej.Text.Remove((displej.Text.Count()) - 1);
            }
            else if (displej2.Text != "")
            {
                if (Cisla.Count == Znamenka.Count)
                {

                    Znamenka.RemoveAt(Znamenka.Count - 1);
                    displej2.Text = "";
                    for (int i = 0; i < Znamenka.Count; i++)
                    {
                        displej2.Text += (Cisla[i]).ToString();
                        displej2.Text += (Znamenka[i]).ToString();

                    }
                    displej2.Text += (Cisla[Znamenka.Count]).ToString();

                }
                else if (Cisla.Count > Znamenka.Count)
                {

                    Cisla.RemoveAt(Cisla.Count - 1);
                    displej2.Text = "";
                    for (int i = 0; i < Znamenka.Count; i++)
                    {
                        displej2.Text += (Cisla[i]).ToString();
                        displej2.Text += (Znamenka[i]).ToString();

                    }

                }
            }

            if ((displej.Text == "") && (displej2.Text == ""))
            {
                dalsivypocet = true;
            }
        }

        private void anochk_CheckedChanged(object sender, EventArgs e) ////////////////////////////////////////////////////////////////////////////////////
        {
            chytrakalkulacka = true;
        }

        private void nechk_CheckedChanged_1(object sender, EventArgs e) ////////////////////////////////////////////////////////////////////////////////////
        {
            chytrakalkulacka = false;
        }

        private void rovnase_MouseEnter(object sender, EventArgs e) ////////////////////////////////////////////////////////////////////////////////////
        {
            if (Znamenka.Count != 0) {
                if ((!OsetreniNuly()) || ((Znamenka.Last() == "÷") && (float.Parse(displej.Text) == 0)))
                {
                    Cursor = Cursors.No;
                }
            }
        }

        private void rovnase_MouseLeave(object sender, EventArgs e) ////////////////////////////////////////////////////////////////////////////////////
        {
            Cursor = Cursors.Default;
        }
    }
}