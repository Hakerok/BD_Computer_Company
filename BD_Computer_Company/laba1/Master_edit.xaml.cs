using System.Windows;
using laba1.@class;

namespace laba1
{
    /// <summary>
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4
    {
        readonly Master _master = new Master();
        public Window4()
        {
            InitializeComponent();
            _master.Combobox(adress);
        }
        private void Clean_Click(object sender, RoutedEventArgs e)
        {
           FIO.Text = "";
           dol.Text = "";
           adress.SelectedIndex = 0;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            _master.Add(FIO,adress,dol);
            Close();
        }
    }
}

