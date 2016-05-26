using System.Windows;
using laba1.@class;

namespace laba1
{
    public partial class Window7
    {
        public Malfunction Ml = new Malfunction();
        public Window7()
        {
            InitializeComponent();
            Update();
        }
        private void edit_Click(object sender, RoutedEventArgs e)
        {
            var w8 = new Window8();
            w8.ShowDialog();
            Update();
        }
        private void ago_Click(object sender, RoutedEventArgs e)
        {
           Close();
        }
        private void Update()
        {
            Ml.Table(mldg);
        }
    }
}
