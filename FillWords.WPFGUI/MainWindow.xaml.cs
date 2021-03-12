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
        }

        private void ButtonContinue_Click(object sender, RoutedEventArgs e)
        {
            //Click
        }

        private void ButtonStatistic_Click(object sender, RoutedEventArgs e)
        {
            //Click
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            //Click
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            canvas.Children.Clear();

            foreach (var boardCell in boardCells)
            {
                boardCell.Render();
            }
        }
    }
}
