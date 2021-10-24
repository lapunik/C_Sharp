using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warzone
{
    public partial class Form1 : Form
    {
        private int Primary_num { set; get; }
        private int Secondary_num { set; get; }

        private List<string> Primary;
        private List<string> Secondary;

        private List<string> Primary_active;
        private List<string> Secondary_active;


        private Random random;


        public Form1()
        {
            InitializeComponent();
            random = new Random();
            Primary = new List<string>();
            Secondary = new List<string>();
            Primary_active = new List<string>();
            Secondary_active = new List<string>();


            Primary.Add("Kilo 141");
            Primary.Add("FAL");
            Primary.Add("M4A1");
            Primary.Add("FR 5.56");
            Primary.Add("Oden");
            Primary.Add("M13");
            Primary.Add("FN SCAR 17");
            Primary.Add("AK-47");
            Primary.Add("Ram-7");
            Primary.Add("Grau 5.56");
            Primary.Add("CR-56 AMAX");
            Primary.Add("AN-94");
            Primary.Add("Bruen MK9");
            Primary.Add("PKM");
            Primary.Add("Holger-26");
            Primary.Add("M92");
            Primary.Add("MG-34");
            Primary.Add("SA87");
            Primary.Add("FiNN");

            Secondary.Add("AUG");
            Secondary.Add("P90");
            Secondary.Add("MP5");
            Secondary.Add("PP19 Bizon");
            Secondary.Add("MP7");
            Secondary.Add("Striker 45");
            Secondary.Add("Fennec");
            Secondary.Add("ISO");
            Secondary.Add("X16");
            Secondary.Add("1911");
            Secondary.Add(".357");
            Secondary.Add("M19");
            Secondary.Add("Renetti");

            for (int i = 0; i < Primary.Count; i++)
            {
                table_Panel_Primary.RowStyles.Add(new RowStyle());
                table_Panel_Primary.RowCount = table_Panel_Primary.RowStyles.Count;

                this.Height += 29;

                CheckBox checkBox = new CheckBox()
                {
                    Text = Primary.ElementAt(i),
                    Font = new Font("Microsoft Sans Serif", 10),
                    Dock = DockStyle.Top,
                    CheckState = CheckState.Checked,
                };
                
                table_Panel_Primary.Controls.Add(checkBox);

            }

            foreach (RowStyle rs in table_Panel_Primary.RowStyles)
            {
                rs.SizeType = SizeType.Absolute;
                rs.Height = 30;
            }

            for (int i = 0; i < Secondary.Count; i++)
            {
                table_Panel_Secondary.RowStyles.Add(new RowStyle());
                table_Panel_Secondary.RowCount = table_Panel_Secondary.RowStyles.Count;

                CheckBox checkBox = new CheckBox()
                {
                    Text = Secondary.ElementAt(i),
                    Font = new Font("Microsoft Sans Serif", 10),
                    Dock = DockStyle.Top,
                    CheckState = CheckState.Checked,
                };

                table_Panel_Secondary.Controls.Add(checkBox);

            }

            foreach (RowStyle rs in table_Panel_Secondary.RowStyles)
            {
                rs.SizeType = SizeType.Absolute;
                rs.Height = 30;
            }
        }

        private void Update_Weapons_list()
        {
            Primary_active.Clear();

            foreach (CheckBox cb in table_Panel_Primary.Controls)
            {
                if(cb.CheckState == CheckState.Checked)
                {
                    Primary_active.Add(cb.Text);
                }                
            }

            Secondary_active.Clear();

            foreach (CheckBox cb in table_Panel_Secondary.Controls)
            {
                if (cb.CheckState == CheckState.Checked)
                {
                    Secondary_active.Add(cb.Text);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox_prim.Text = "";
            textBox_sek.Text = "";

            Update_Weapons_list();

            if (Primary_active.Count == 0)
            {
                return;
            }

            if (Secondary_active.Count == 0)
            {
                return;
            }

            Primary_num = random.Next(Primary_active.Count);
            Secondary_num = random.Next(Secondary_active.Count);
            textBox_prim.Text = Primary_active.ElementAt(Primary_num);
            textBox_sek.Text = Secondary_active.ElementAt(Secondary_num);

        }

        private void button_Un_Click(object sender, EventArgs e)
        {

            foreach (CheckBox cb in table_Panel_Primary.Controls)
            {
                cb.CheckState = CheckState.Unchecked;
            }

            foreach (CheckBox cb in table_Panel_Secondary.Controls)
            {
                cb.CheckState = CheckState.Unchecked;
            }


        }
    }
}
