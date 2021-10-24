using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace InregularShapeButton
{
    public partial class Jersey : UserControl
    {

        private int number;
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;

                MainColor.Text = number.ToString();
            }
        }
        private string playerName;
        public string PlayerName
        {
            get
            {
                return playerName;
            }
            set
            {
                playerName = value;

                PlayersName.Text = playerName;
            }
        }
        private Color mainJerseyColor;
        public Color MainJerseyColor
        {
            get
            {
                return mainJerseyColor;
            }
            set
            {
                mainJerseyColor = value;

                MainColor.BackColor = mainJerseyColor;
            }
        }

        public Jersey()
        {
            InitializeComponent();
            {
                // Define the points in the polygonal path.
                Point[] pts = {
        new Point(27,12),
        new Point(70,12),
        new Point(92,34),
        new Point(78,48),
        new Point(70,42),
        new Point(70,105),
        new Point(27,105),
        new Point(27,42),
        new Point(19,48),
        new Point(5,34)

        };

                // Make the GraphicsPath.
                GraphicsPath polygon_path = new GraphicsPath(FillMode.Winding);
                polygon_path.AddPolygon(pts);

                // Convert the GraphicsPath into a Region.
                Region polygon_region = new Region(polygon_path);

                // Constrain the button to the region.
                MainColor.Region = polygon_region;


                // Make the button big enough to hold the whole region.
                MainColor.SetBounds(MainColor.Location.X, MainColor.Location.Y, pts[2].X + 5, pts[5].Y + 5);

                MainColor.BackColor = Color.Transparent;
            }

        }

        private void MainColor_Click(object sender, EventArgs e)
        {

        }
    }
}
