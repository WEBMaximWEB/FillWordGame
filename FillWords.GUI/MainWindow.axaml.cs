using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace FillWords.GUI
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        public void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            var ButtonStart = this.Find<Button>("ButtonStart");
            var StackMenu = this.Find<StackPanel>("StackMenu");

            StackMenu.IsVisible = false;
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

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
