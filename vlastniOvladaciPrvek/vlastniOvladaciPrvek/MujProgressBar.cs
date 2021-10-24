using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vlastniOvladaciPrvek
{
	public partial class MujProgressBar : UserControl
	{
		public MujProgressBar()
		{
			InitializeComponent();
		}

		private int _value = 0;
		public int Value 
		{ 
			get { return _value; } 
			set { _value = value;  ProgressBar_Paint(null, null); } 
		}
		private int minValue = 0;
		private int _maxValue = 100;
		public int maxValue 
		{ 
			get { return _maxValue; }
			set { _maxValue = value; ProgressBar_Paint(null, null); } 
		}

		public void Increment(int Value)
		{
			if (this.Value + Value > maxValue)
				throw new ArgumentOutOfRangeException("Hodnota překročila maximum");
			this.Value += Value;
			
		}

		public void Increment()
		{
			if (this.Value + 1 > maxValue)
				throw new ArgumentOutOfRangeException("Hodnota překročila maximum");
			this.Value += Value;
		}

		public void Decrement(int Value)
		{
			if (this.Value - Value < minValue)
				throw new ArgumentOutOfRangeException("Hodnota klesla pod minimum");
			this.Value -= Value;
		}

		public void Decrement()
		{
			if (this.Value - 1 < minValue)
				throw new ArgumentOutOfRangeException("Hodnota klesla pod minimum");
			this.Value -= 1;
		}

		private void ProgressBar_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = pictureBox1.CreateGraphics();
			double vykreslovanaDelka = (double)this.Value * 100.0 / (double)maxValue / 100.0 * (double)this.Width;
			g.Clear(Color.Green);
			g.FillRectangle(Brushes.White, new Rectangle(0, 0, this.Width - int.Parse(vykreslovanaDelka.ToString()), this.Height));
		}

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
