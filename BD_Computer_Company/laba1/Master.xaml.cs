using System.Windows;
using laba1.@class;

namespace laba1
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3
    {
        readonly Master _master = new Master();
        public Window3()
        {
            InitializeComponent();
            Update();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var w4 = new Window4();
            w4.ShowDialog();
            Update();
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Update()
        {
            _master.Table(msdg);
        }

      
        }
    }

