using System.Windows;
using laba1.@class;



namespace laba1
{
    /// <summary>
    /// Логика взаимодействия для Window5.xaml
    /// </summary>
    public partial class Window5
    {
        public SpareParts Sp = new SpareParts();
        public Window5()
        {
            InitializeComponent();
            Update();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var w6 = new Window6();
            w6.ShowDialog();
            Update();
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
           Close();
        }
        private void Update()
        {
            Sp.Table(spdg);
        }
}
  }
    
