using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKEY_new
{
    public partial class Filter : Form
    {

        public int filter_minimum_length_HF = 1;

        public int filter_minimum_length_LF = 1;

        public bool wup_bb = false;

        public List<int> filter_id = new List<int>();

        public List<int> filter_com = new List<int>();

        public byte[] wup;

        public void FillCheckBoxes()
        {
            numericUpDown1.Value = filter_minimum_length_HF;
            numericUpDown2.Value = filter_minimum_length_LF;

            foreach (CheckBox c in tableLayoutPanel2.Controls)
            {

                c.CheckState = CheckState.Unchecked;

            }

            foreach (CheckBox c in tableLayoutPanel3.Controls)
            {

                c.CheckState = CheckState.Unchecked;

            }

            foreach (CheckBox c in tableLayoutPanel7.Controls)
            {

                c.CheckState = CheckState.Unchecked;

            }

            foreach (int i in filter_com)
            {
                if (i == 0)
                {
                    checkBox27.CheckState = CheckState.Checked;
                }
                if (i == 1)
                {
                    checkBox28.CheckState = CheckState.Checked;
                }
                if (i == 2)
                {
                    checkBox25.CheckState = CheckState.Checked;
                }
                if (i == 3)
                {
                    checkBox26.CheckState = CheckState.Checked;
                }
                if (i == 4)
                {
                    checkBox29.CheckState = CheckState.Checked;
                }
            }

            foreach (int i in filter_id)
            {
                if (i == 0x72D)
                {
                    checkBox0.CheckState = CheckState.Checked;
                }
                if (i == 0x72C)
                {
                    checkBox1.CheckState = CheckState.Checked;
                }
                if (i == 0x601)
                {
                    checkBox2.CheckState = CheckState.Checked;
                }
                if (i == 0x602)
                {
                    checkBox3.CheckState = CheckState.Checked;
                }
                if (i == 0x604)
                {
                    checkBox4.CheckState = CheckState.Checked;
                }
                if (i == 0x605)
                {
                    checkBox5.CheckState = CheckState.Checked;
                }
                if (i == 0x610)
                {
                    checkBox6.CheckState = CheckState.Checked;
                }
                if (i == 0x611)
                {
                    checkBox7.CheckState = CheckState.Checked;
                }
                if (i == 0x613)
                {
                    checkBox8.CheckState = CheckState.Checked;
                }
                if (i == 0x614)
                {
                    checkBox9.CheckState = CheckState.Checked;
                }
                if (i == 0x615)
                {
                    checkBox10.CheckState = CheckState.Checked;
                }
                if (i == 0x616)
                {
                    checkBox11.CheckState = CheckState.Checked;
                }
                if (i == 0x724)
                {
                    checkBox12.CheckState = CheckState.Checked;
                }
                if (i == 0x802)
                {
                    checkBox13.CheckState = CheckState.Checked;
                }
                if (i == 0x801)
                {
                    checkBox14.CheckState = CheckState.Checked;
                }
                if (i == 0x723)
                {
                    checkBox15.CheckState = CheckState.Checked;
                }
                if (i == 0x718)
                {
                    checkBox16.CheckState = CheckState.Checked;
                }
                if (i == 0x711)
                {
                    checkBox17.CheckState = CheckState.Checked;
                }
                if (i == 0x710)
                {
                    checkBox18.CheckState = CheckState.Checked;
                }
                if (i == 0x115)
                {
                    checkBox19.CheckState = CheckState.Checked;
                }
                if (i == 0x110)
                {
                    checkBox20.CheckState = CheckState.Checked;
                }
                if (i == 0x102)
                {
                    checkBox21.CheckState = CheckState.Checked;
                }
                if (i == 0x101)
                {
                    checkBox22.CheckState = CheckState.Checked;
                }
                if (i == 0x70A)
                {
                    checkBox30.CheckState = CheckState.Checked;
                }
                if (i == 0x0)
                {
                    checkBox23.CheckState = CheckState.Checked;
                }

            }

        }

        public Filter(int min_HF, int min_LF, List<int> l, byte[] wupp, bool wuppp, List<int> k)
        {
            InitializeComponent();

            filter_id = l;
            filter_com = k;
            filter_minimum_length_HF = min_HF;
            filter_minimum_length_LF = min_LF;
            wup = wupp;
            FillCheckBoxes();
            wup_bb = wuppp;

            if (wup_bb)
            {
                checkBox24.CheckState = CheckState.Checked;
            }
            else
            {
                checkBox24.CheckState = CheckState.Unchecked;
            }

            if (wupp != null)
            {
                ///*

                string s = "";

                for (int i = 0; i < wup.Length; i++)
                {
                    s += String.Format("{0,2:X2}", wupp[i]);
                    
                }//*/

                textBox1.Text = s;

                //textBox1.Text += String.Format("{0,2:X2   1,2:X2   2,2:X2   3,2:X2}", wupp[0], wupp[1], wupp[2], wupp[3]);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            foreach (CheckBox c in tableLayoutPanel2.Controls)
            {

                    c.CheckState = CheckState.Unchecked;
                
            }
            foreach (CheckBox c in tableLayoutPanel3.Controls)
            {
                    c.CheckState = CheckState.Unchecked;
            }

           // foreach (CheckBox c in tableLayoutPanel7.Controls)
           // {
           //     c.CheckState = CheckState.Unchecked;
           // }

           // checkBox24.CheckState = CheckState.Unchecked;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            filter_minimum_length_HF = (int)numericUpDown1.Value;
            filter_minimum_length_LF = (int)numericUpDown2.Value;
            List<int> list = FillList();

            filter_id = list;

            List<int> list2 = FillList2();
            
            filter_com = list2;

            string[] d = textBox1.Text.Split(' ');

            List<byte> listt = new List<byte>();

            for (int i = 0; i < d.Length; i++)
            {
                if (d[i] != "")
                    try
                    {
                        listt.Add(Convert.ToByte(d[i], 16));
                    }
                    catch (Exception ex)
                    {
                        return;
                    }
            }

            wup = listt.ToArray();

            Close(); 
        }

        private List<int> FillList()
        {
            List<int> list = new List<int>();

            if (checkBox0.CheckState == CheckState.Checked)
            {
                list.Add(0x72D);
            }
            if (checkBox1.CheckState == CheckState.Checked)
            {
                list.Add(0x72C);
            }
            if (checkBox2.CheckState == CheckState.Checked)
            {
                list.Add(0x601);
            }
            if (checkBox3.CheckState == CheckState.Checked)
            {
                list.Add(0x602);
            }
            if (checkBox4.CheckState == CheckState.Checked)
            {
                list.Add(0x604);
            }
            if (checkBox5.CheckState == CheckState.Checked)
            {
                list.Add(0x605);
            }
            if (checkBox6.CheckState == CheckState.Checked)
            {
                list.Add(0x610);
            }
            if (checkBox7.CheckState == CheckState.Checked)
            {
                list.Add(0x611);
            }
            if (checkBox8.CheckState == CheckState.Checked)
            {
                list.Add(0x613);
            }
            if (checkBox9.CheckState == CheckState.Checked)
            {
                list.Add(0x614);
            }
            if (checkBox10.CheckState == CheckState.Checked)
            {
                list.Add(0x615);
            }
            if (checkBox11.CheckState == CheckState.Checked)
            {
                list.Add(0x616);
            }
            if (checkBox12.CheckState == CheckState.Checked)
            {
                list.Add(0x724);
            }
            if (checkBox13.CheckState == CheckState.Checked)
            {
                list.Add(0x802);
            }
            if (checkBox14.CheckState == CheckState.Checked)
            {
                list.Add(0x801);
            }
            if (checkBox15.CheckState == CheckState.Checked)
            {
                list.Add(0x723);
            }
            if (checkBox16.CheckState == CheckState.Checked)
            {
                list.Add(0x718);
            }
            if (checkBox17.CheckState == CheckState.Checked)
            {
                list.Add(0x711);
            }
            if (checkBox18.CheckState == CheckState.Checked)
            {
                list.Add(0x710);
            }
            if (checkBox19.CheckState == CheckState.Checked)
            {
                list.Add(0x115);
            }
            if (checkBox20.CheckState == CheckState.Checked)
            {
                list.Add(0x110);
            }
            if (checkBox21.CheckState == CheckState.Checked)
            {
                list.Add(0x102);
            }
            if (checkBox22.CheckState == CheckState.Checked)
            {
                list.Add(0x101);
            }
            if (checkBox23.CheckState == CheckState.Checked)
            {
                list.Add(0x0);
            }
            if (checkBox30.CheckState == CheckState.Checked)
            {
                list.Add(0x70A);
            }


            return list;
        }

        private List<int> FillList2()
        {
            List<int> list = new List<int>();

            if (checkBox25.CheckState == CheckState.Checked)
            {
                list.Add(2);
            }
            if (checkBox26.CheckState == CheckState.Checked)
            {
                list.Add(3);
            }
            if (checkBox27.CheckState == CheckState.Checked)
            {
                list.Add(0);
            }
            if (checkBox28.CheckState == CheckState.Checked)
            {
                list.Add(1);
            }
            if (checkBox29.CheckState == CheckState.Checked)
            {
                list.Add(4);
            }
           
            
            return list;
        }

        private void buttonSellectAll_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            foreach (CheckBox c in tableLayoutPanel2.Controls)
            {

                c.CheckState = CheckState.Checked;

            }
            foreach (CheckBox c in tableLayoutPanel3.Controls)
            {
                c.CheckState = CheckState.Checked;
            }

           // foreach (CheckBox c in tableLayoutPanel7.Controls)
           // {
           //     c.CheckState = CheckState.Checked;
           // }

            //checkBox24.CheckState = CheckState.Checked;
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            wup_bb = (checkBox24.CheckState == CheckState.Checked ? true : false );
        }

    }
}
