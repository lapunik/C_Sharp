using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sachovnice
{
    public partial class Form1 : Form
    {

        public Color color1 = Color.LightBlue;
        public Color color2 = Color.LightPink;
        public int numberOfColumn = 2;
        public int numberOfRow = 2;


        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            CreateChessBoard();
        }
        private void CreateChessBoard()
        {

            while (tablePanelChessboard.Controls.Count > 1)
            {

                tablePanelChessboard.Controls.RemoveAt((tablePanelChessboard.Controls.Count) - 1);

            }

            while (tablePanelChessboard.ColumnStyles.Count != 1)
            {
                tablePanelChessboard.ColumnStyles.RemoveAt((tablePanelChessboard.ColumnStyles.Count) - 1);
                tablePanelChessboard.ColumnCount = tablePanelChessboard.ColumnStyles.Count;
            }

            while (tablePanelChessboard.RowStyles.Count != 1)
            {
                tablePanelChessboard.RowStyles.RemoveAt((tablePanelChessboard.RowStyles.Count) - 1);
                tablePanelChessboard.RowCount = tablePanelChessboard.RowStyles.Count;
            }


            while (numberOfRow > tablePanelChessboard.RowStyles.Count)
            {
                tablePanelChessboard.RowStyles.Add(new RowStyle());
                tablePanelChessboard.RowCount = tablePanelChessboard.RowStyles.Count;


            }


            while (numberOfColumn > tablePanelChessboard.ColumnStyles.Count)
            {
                tablePanelChessboard.ColumnStyles.Add(new ColumnStyle());
                tablePanelChessboard.ColumnCount = tablePanelChessboard.ColumnStyles.Count;

            }

            foreach (ColumnStyle cs in tablePanelChessboard.ColumnStyles)
            {
                cs.SizeType = SizeType.Percent;
                cs.Width = 100;
            }

            foreach (RowStyle rs in tablePanelChessboard.RowStyles)
            {
                rs.SizeType = SizeType.Percent;
                rs.Height = 100;
            }
            

            while (tablePanelChessboard.Controls.Count != 0)
            {
                tablePanelChessboard.Controls.RemoveAt(0);
            }


            for (int i = 0; i < tablePanelChessboard.RowStyles.Count; i++)
            {
                for (int j = 0; j < tablePanelChessboard.ColumnStyles.Count; j++)
                {

                    Button button = new Button()
                    {
                        BackColor = SystemColors.Control,
                        Text = "",
                        Dock = DockStyle.Fill,
                        Tag = String.Format("{0},{1}",i,j),
                    };
                    

                    string[] souradnice = (String.Format("{0}", button.Tag)).Split(',');
                    
                    if (((int.Parse(souradnice[0])+int.Parse(souradnice[1]))%2)==0)
                    {
                            button.BackColor = color1;
                    }
                    else
                    {
                            button.BackColor = color2;
                    }
                        
                        button.Click += button_Click;
                        tablePanelChessboard.Controls.Add(button);
                                       
                }
            }

        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            using (SetColor form = new SetColor())
            {
                
                form.color1 = color1;
                form.color2 = color2;

                DialogResult result = form.ShowDialog();
                
                if (result == DialogResult.OK)
                {
                    log.Add("Barva 1: " + form.color1);
                    log.Add("Barva 2: " + form.color2);

                    color1 = form.color1;
                    color2 = form.color2;
                }
            }

            CreateChessBoard();

        }

        private void buttonCaR_Click(object sender, EventArgs e)
        {
            using (SetColumnAndRow form = new SetColumnAndRow()) 
            {

                form.numberOfColumn = numberOfColumn;
                form.numberOfRow = numberOfRow;

                DialogResult result = form.ShowDialog();
                
                if (result == DialogResult.OK)
                {
                    log.Add("Sloupce: " + form.numberOfColumn);
                    log.Add("Řádky: " + form.numberOfRow);

                    numberOfColumn = form.numberOfColumn;
                    numberOfRow = form.numberOfRow;
                }
            }
            CreateChessBoard();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;  
            if (button == null)
            {
                return;
            }

            log.Add("Tlacitko cislo: " + button.Tag);

        }
    }
}
