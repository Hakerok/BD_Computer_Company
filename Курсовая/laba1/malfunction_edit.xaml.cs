using System.Windows;
using laba1.@class;

namespace laba1
{
    /// <summary>
    /// Логика взаимодействия для Window8.xaml
    /// </summary>
    public partial class Window8
    {
        readonly Malfunction _ml = new Malfunction();
        public Window8()
        {
            InitializeComponent();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            _ml.Add(name_mal);
            Close();
        }
    }
}
