using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using laba1.@class;

namespace laba1
{
    public partial class MainWindow
    {
        private readonly SqlClass _sqlclass = new SqlClass();
        public string S;

        public MainWindow()
        {
            InitializeComponent();
            _sqlclass.Combobox(typejob, adress, master);
            cb_Unchecked(null, null);
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            _sqlclass.Exit();
        }
        private void dob_Click(object sender, RoutedEventArgs e)
        {
            var w2 = new Window2(this);
            w2.ShowDialog();
            cb_Unchecked(null, null);
           
        }
        private void seath_Click(object sender, RoutedEventArgs e)
        {
            _sqlclass.Filter(grMain, typejob, adress, master);
        }
        private void del_Click(object sender, RoutedEventArgs e)
        {
            _sqlclass.Del(sender);
            cb_Unchecked(null, null);
        }
        private void Master_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
            var wind = new Window3();
            wind.Closed += (sender2, e2) =>
            {
                Visibility = Visibility.Visible;
            };
            wind.ShowDialog();
            _sqlclass.Combobox(typejob, adress, master);
        }
        private void Spare_parts_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
            var w5 = new Window5();
            w5.Closed += (sender2, e2) =>
            {
               Visibility = Visibility.Visible;
            };
            w5.ShowDialog();
        }
        private void edit_Click(object sender, RoutedEventArgs e)
        {
            S = ((Button) sender).Tag.ToString();
            foreach (var w2 in from BdClass.Main kk in grMain.Items where kk.Id.ToString(CultureInfo.InvariantCulture) == S select new Window2(this, kk))
            {
                w2.ShowDialog();
                cb_Unchecked(null, null);
                break;
            }
        }
        private void Malfunction_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
            var wind = new Window7();
            wind.Closed += (sender2, e2) =>
            {
                Visibility = Visibility.Visible;
            };
            wind.ShowDialog();
        }
        private void print_Click(object sender, RoutedEventArgs e)
        {
            var printdlg = new PrintDialog();

            var pageSize = new Size(printdlg.PrintableAreaWidth, printdlg.PrintableAreaHeight);
            grMain.Measure(pageSize);
            grMain.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
            printdlg.PrintVisual(grMain, Title);
        }
        private void cb_Unchecked(object sender, RoutedEventArgs e)
        {
            cb.Content = "Включить фильтр";
            seath.Visibility = Visibility.Hidden;
            typejob.Visibility = Visibility.Hidden;
            adress.Visibility = Visibility.Hidden;
            master.Visibility = Visibility.Hidden;
            _sqlclass.Table(grMain);
        }
        private void cb_Checked(object sender, RoutedEventArgs e)
        {
            cb.Content = "Выключить фильтр";
            seath.Visibility = Visibility.Visible;
            typejob.Visibility = Visibility.Visible;
            adress.Visibility = Visibility.Visible;
            master.Visibility = Visibility.Visible;
            typejob.SelectedIndex = 0;
            adress.SelectedIndex = 0;
            master.SelectedIndex = 0;
        }
        private void help_Click(object sender, RoutedEventArgs e)
        {
            var w9 = new Window9();
            w9.ShowDialog();
        }
        private void about_Click(object sender, RoutedEventArgs e)
        {
            var w1 = new Window1();
            w1.ShowDialog();
        }
         private void Done_Click(object sender,RoutedEventArgs e)
        {
            _sqlclass.Done(sender);
            cb_Unchecked(null, null);
        }
}
}
