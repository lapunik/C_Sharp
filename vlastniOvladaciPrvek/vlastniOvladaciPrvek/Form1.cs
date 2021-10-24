using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vlastniOvladaciPrvek
{
	public partial class Form1 : Form
	{
		MujProgressBar prog = new MujProgressBar();
		public Form1()
		{
			InitializeComponent();
			prog.Location = new Point(12, 43);
			Controls.Add(prog);
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				if (numericUpDown1.Value > 1) {
					prog.Increment(int.Parse(numericUpDown1.Value.ToString()));
					mujProgressBar1.Increment(int.Parse(numericUpDown1.Value.ToString()));
				} else {
					prog.Increment();
					mujProgressBar1.Increment();
				}
			}
			catch (ArgumentOutOfRangeException ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				if (numericUpDown1.Value > 1)
				{
					prog.Decrement(int.Parse(numericUpDown1.Value.ToString()));
					mujProgressBar1.Decrement(int.Parse(numericUpDown1.Value.ToString()));
				}
				else
				{
					prog.Decrement();
					mujProgressBar1.Decrement();
				}
			}
			catch (ArgumentOutOfRangeException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
