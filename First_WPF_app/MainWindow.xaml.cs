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

namespace First_WPF_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {

            if (btn.Foreground == Brushes.LightGoldenrodYellow)
            {
                btn.Foreground = Brushes.Maroon;
                btn.Background = Brushes.LightGoldenrodYellow;
            }
            else
            {
                btn.Background = Brushes.Maroon;
                btn.Foreground = Brushes.LightGoldenrodYellow;
            }
        }

        private void combo_btn_Click(object sender, RoutedEventArgs e)
        {
            if (led.Background == Brushes.Red)
            {
                led.Background = Brushes.Green;
            }
            else
            {
                led.Background = Brushes.Red;
            }
           
        }
    }
}
