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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTest
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

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      Button btnGrow = sender as Button;
      if (btnGrow == null)
        return;

      bool zoomIn = btnFull.Visibility == Visibility.Hidden;    // neni zatim videt

      double secDuration = zoomIn ? 0.3 : 2;

      Point pntTopLeft = btnGrow.TranslatePoint(new Point(0, 0), cnvFull);      // kde je ?

      Canvas.SetLeft(btnFull, pntTopLeft.X);
      Canvas.SetTop(btnFull, pntTopLeft.Y);
      btnFull.Width = btnGrow.ActualWidth;
      btnFull.Height = btnGrow.ActualHeight;

      btnFull.Visibility = Visibility.Visible;

      DoubleAnimation animLeft = new DoubleAnimation
      {
        From = zoomIn ? pntTopLeft.X : 0,
        To = zoomIn ? 0 : pntTopLeft.X,
        Duration = TimeSpan.FromSeconds(secDuration)
      };

      Storyboard.SetTargetProperty(animLeft, new PropertyPath(Canvas.LeftProperty));
      Storyboard.SetTarget(animLeft, btnFull);

      DoubleAnimation animTop = new DoubleAnimation
      {
        From = zoomIn ? pntTopLeft.Y : 0,
        To = zoomIn ? 0 : pntTopLeft.Y,
        Duration = TimeSpan.FromSeconds(secDuration)
      };

      Storyboard.SetTargetProperty(animTop, new PropertyPath(Canvas.TopProperty));
      Storyboard.SetTarget(animTop, btnFull);

      DoubleAnimation animWidth = new DoubleAnimation
      {
        From = zoomIn ? btnGrow.ActualWidth : cnvFull.ActualWidth,
        To = zoomIn ? cnvFull.ActualWidth : btnGrow.ActualWidth,
        Duration = TimeSpan.FromSeconds(secDuration)
      };

      Storyboard.SetTargetProperty(animWidth, new PropertyPath(UserControl.WidthProperty));
      Storyboard.SetTarget(animWidth, btnFull);

      DoubleAnimation animHeight = new DoubleAnimation
      {
        From = zoomIn ? btnGrow.ActualHeight : cnvFull.ActualHeight,
        To = zoomIn ? cnvFull.ActualHeight : btnGrow.ActualHeight,
        Duration = TimeSpan.FromSeconds(secDuration)
      };

      Storyboard.SetTargetProperty(animHeight, new PropertyPath(UserControl.HeightProperty));
      Storyboard.SetTarget(animHeight, btnFull);

      Storyboard s = new Storyboard();
      s.Children.Add(animLeft);
      s.Children.Add(animTop);
      s.Children.Add(animWidth);
      s.Children.Add(animHeight);
      s.Completed += ZoomInOut_Completed;
      s.Begin();
    }

    private void ZoomInOut_Completed(object sender, EventArgs e)
    {
      if (btnFull.ActualWidth > (cnvFull.ActualWidth * 3 / 4))  
        // je zvetseno (pozor, neni presne, proto 3/4) ?
      {
      }
      else            // je zmenseno ?
      {
        btnFull.Visibility = Visibility.Hidden;
      }

      Storyboard s = sender as Storyboard;
      if (s != null)
        s.Completed -= ZoomInOut_Completed; // utrhnout, aby to neblokovalo GC ... ?? je to nutne ?
    }

    private void btnFull_Click(object sender, RoutedEventArgs e)
    {

    }
  }
}
