using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CustomForm
{
    public partial class Form2 : Form
    {

        public string TextPoznamky = "";
        private string PuvodniText = "";

        public Form2(string text)
        {
            InitializeComponent();
            TextPoznamky = text;
            PuvodniText = text;
            textBox1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextPoznamky = PuvodniText;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextPoznamky = textBox1.Text;
            Close();
        }
    }
}
