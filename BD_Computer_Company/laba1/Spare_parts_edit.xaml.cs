using System;
using System.Windows;
using System.Windows.Input;
using laba1.@class;

namespace laba1
{
    /// <summary>
    /// Логика взаимодействия для Window6.xaml
    /// </summary>
    public partial class Window6
    {
        readonly SpareParts _sp = new SpareParts();
        public Window6()
        {
           InitializeComponent();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            _sp.Add(name, col, count);
            Close();
        }
        private void col_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.Text, 0);
        }

        private void count_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.Text, 0);
        }
    }
}
