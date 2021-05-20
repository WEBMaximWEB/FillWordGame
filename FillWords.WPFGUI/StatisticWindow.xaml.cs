using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FillWords.Logic;

namespace FillWords.WPFGUI
{
    /// <summary>
    /// Логика взаимодействия для StatisticWindow.xaml
    /// </summary>
    public partial class StatisticWindow : Window
    {
        public StatisticWindow()
        {
            InitializeComponent();
            string[] Arr = Rating.GetRating();
            for (int i = 1; i <= Arr.Length; i++)
            {
                var textRating = new TextBlock();
                textRating.Text = i.ToString() + ") " + Arr[i - 1];
                field.Children.Add(textRating);
            }
        }
    }
}
