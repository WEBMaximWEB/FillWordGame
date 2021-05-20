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
using FillWords.Logic;

namespace FillWords.WPFGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            StackMenu.Visibility = Visibility.Collapsed;
            canvas.Visibility = Visibility.Visible;
            ButtonBack.Visibility = Visibility.Visible;
        }

        public void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            StackMenu.Visibility = Visibility.Visible;
            canvas.Visibility = Visibility.Hidden;
            ButtonBack.Visibility = Visibility.Hidden;
        }

        private void ButtonContinue_Click(object sender, RoutedEventArgs e)
        {
            char[,] board = Continue.StartContinue();
            if (board.Length == 0)
            {
                ButtonStart_Click(sender, e);
            }
            else
            {
                //  
            }
        }

        private void ButtonStatistic_Click(object sender, RoutedEventArgs e)
        {
            //Rating.CheckRating(100, "Max");
            var window1 = new StatisticWindow();
            window1.Show();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

/*        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            StackMenu.Visibility = Visibility.Visible;
            canvas.Visibility = Visibility.Collapsed;
            ButtonBack.Visibility = Visibility.Collapsed;
        }*/

        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow.Height = 700;
            Application.Current.MainWindow.Width = 600;
        }

        private void Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            canvas.Children.Clear();

            var width = canvas.ActualWidth;
            var height = canvas.ActualHeight;

            for (int i = 0; i < width; i += Convert.ToInt32(width / 8))
                DrawField(i, 0, i, height);
            for (int i = 0; i < height; i += Convert.ToInt32(height / 8))
                DrawField(0, i, width, i);
            canvas.Height = width;

            string letter = "а";
            var text = new TextBlock()
            {
                FontSize = 0.1 * width,
                Text = letter,
                Padding = new Thickness(0, 0, 0, 0),
                Margin = new Thickness(0, 0, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left
            };
            canvasPanel.Children.Add(text);
        }

        void DrawField(double x1, double y1, double x2, double y2)
        {
            var line = new Line(){
                X1 = x1,
                Y1 = y1,
                X2 = x2,
                Y2 = y2,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                SnapsToDevicePixels = true
            };
            canvas.Children.Add(line);
        }
    }
}
