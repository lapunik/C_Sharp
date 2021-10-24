using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Carcasonne
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Cinema cinema = new Cinema();

        public MainWindow()
        {
            InitializeComponent();
            cinema.Draw_Rectangles(canvas);
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Seat_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class Cinema
    {
        private bool[,] seat = new bool[30, 15];
        private const int seat_size = 16;
        private const int seat_space = 2;

        public void Draw_Rectangles(Canvas canvas)
        {
            for (int j = 0; j < seat.GetLength(1); j++)
            {
                for (int i = 0; i < seat.GetLength(0); i++)
                {
                    Rectangle rectangle = new Rectangle()
                    {
                        Height = seat_size,
                        Width = seat_size,
                    };

                    rectangle.Fill = (seat[i, j]) ? Brushes.DarkGreen :Brushes.Gray;
                    canvas.Children.Add(rectangle); // potomek canvasu, "podobrázek" asi
                    canvas.AddHandler                    

                    Canvas.SetLeft(rectangle,i*(seat_size + seat_space)); // statická metoda na nastavení místa kde ho chceme
                    Canvas.SetTop(rectangle, j * (seat_size + seat_space));
                }
            }
        }
    }
}
