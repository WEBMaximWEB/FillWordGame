using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    public static class Board
    {
        public static int Size = 8;
        public static char[,] Letters = WordGeneration.GetWordGeneration(Size);
        public static char[,] SelectLetters = new char[Size, Size];
        public static char[,] GuessedLetters = new char[Size, Size];
        public static string Word = string.Empty;
        public static int LastSelectCellX = 0;
        public static int LastSelectCellY = 0;
        public static int Score = 0;
    }

    public partial class MainWindow : Window
    {
        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            Game.Visibility = Visibility.Visible;
            StackMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Game.Visibility = Visibility.Hidden;
            StackMenu.Visibility = Visibility.Visible;
            Rating.CheckRating(Board.Score, Player.Text);
            Continue.WriteOnFile(Board.Letters, Board.Size);
        }

        private void ButtonContinue_Click(object sender, RoutedEventArgs e)
        {
            char[,] board = Continue.StartContinue();
            if (Continue.CheckFile())
                Board.Letters = Continue.StartContinue();
            ButtonStart_Click(sender, e);
        }

        private void ButtonStatistic_Click(object sender, RoutedEventArgs e)
        {
            var window1 = new StatisticWindow();
            window1.Show();
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            StackSettings.Visibility = Visibility.Visible;
            StackMenu.Visibility = Visibility.Hidden;
        }

        private void ButtonMusic_Click(object sender, RoutedEventArgs e)
        {
            var sp = new SoundPlayer();
            sp.SoundLocation = "Shopen.wav";
            sp.Load();
            sp.PlayLooping();
        }

        private void ButtonBackSettings_Click(object sender, RoutedEventArgs e)
        {
            StackSettings.Visibility = Visibility.Hidden;
            StackMenu.Visibility = Visibility.Visible;
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonSelectWord_Click(object sender, RoutedEventArgs e)
        {
            if (Sneak.listWords.Contains(Board.Word))
            {
                Sneak.listWords.Remove(Board.Word);
                Board.Score += 5 * Board.Word.Length;
                Score.Text = "Счет: " + Board.Score.ToString();
                for(int i = 0; i < Board.Size; i++)
                {
                    for(int j = 0; j < Board.Size; j++)
                    {
                        if (Board.SelectLetters[i, j] == 's')
                            Board.GuessedLetters[i, j] = 's';
                    }
                }
                if (Sneak.listWords.Count == 0)
                    Board.Score += 100;
            }
            else
            {
                DrawLetters();
                Board.Word = String.Empty;
            }
            Board.LastSelectCellX = 0;
            Board.LastSelectCellY = 0;
            Board.SelectLetters = new char[Board.Size, Board.Size];
        }

        private void Canvas_Click(object sender, MouseEventArgs e)
        {
            Point pt = e.GetPosition(this);
            var width = canvas.ActualWidth;
            int cellX = (int)Math.Ceiling(pt.X / (width / Board.Size) - 0.13);
            int cellY = (int)Math.Ceiling(pt.Y / (width / Board.Size) - 0.13);
            SelectCell(cellX, cellY);
        }

        private void SelectCell(int cellX, int cellY)
        {
            if (CheckDeraction(cellX, cellY))
            {
                var text = new TextBlock()
                {
                    FontSize = 60,
                    Text = Board.Letters[cellY - 1, cellX - 1].ToString(),
                    Margin = new Thickness(20 + (cellX - 1) * 70, -10 + (cellY - 1) * 70, 0, 0),
                    Foreground = Brushes.Yellow,
                    HorizontalAlignment = HorizontalAlignment.Left
                };
                canvas.Children.Add(text);
                Board.SelectLetters[cellY - 1, cellX - 1] = 's';
                Board.LastSelectCellX = cellX;
                Board.LastSelectCellY = cellY;
                Board.Word += Board.Letters[cellY - 1, cellX - 1].ToString();
            }    
        }

        private bool CheckDeraction(int cellX, int cellY)
        {
            if (Board.LastSelectCellX == 0)
                return true;
            else if (Board.SelectLetters[cellY - 1, cellX - 1] == 's')
                return false;
            else if (Math.Abs(cellX - Board.LastSelectCellX) <= 1 &&
                     Math.Abs(cellY - Board.LastSelectCellY) == 0)
                return true;
            else if (Math.Abs(cellX - Board.LastSelectCellX) <= 0 &&
                     Math.Abs(cellY - Board.LastSelectCellY) == 1)
                return true;
            return false;
        }

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

            for (int i = 0; i < width; i += Convert.ToInt32(width / Board.Size))
                DrawField(i, 0, i, height);
            for (int i = 0; i < height; i += Convert.ToInt32(height / Board.Size))
                DrawField(0, i, width, i);
            canvas.Height = width;

            DrawLetters();
        }

        private void DrawField(double x1, double y1, double x2, double y2)
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

        private void DrawLetters()
        {
            for (int i = 0; i < Board.Size; i++)
            {
                for (int j = 0; j < Board.Size; j++)
                {
                    var text = new TextBlock()
                    {
                        FontSize = 60,
                        Text = Board.Letters[i, j].ToString(),
                        Margin = new Thickness(20 + j * 70, -10 + i * 70, 0, 0),
                        HorizontalAlignment = HorizontalAlignment.Left
                    };
                    if (Board.GuessedLetters[i, j] == 's')
                        text.Foreground = Brushes.Gray;
                    canvas.Children.Add(text);
                }
            }
        }
    }
}
