using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using laba1.@class;

namespace laba1
{
    public partial class Window2
    {
        public MainWindow B;
        public BdClass.Main Ch;
        readonly AddClass _adclass = new AddClass();
        public Window2(MainWindow b)
        {
            InitializeComponent();
            B = b;
            btOK.Content = "Добавить";
            adress.ItemsSource = B.adress.ItemsSource;
            adress.SelectedIndex = 0;
            SPCH_Unchecked(null, null);
        }
        public Window2(MainWindow per, BdClass.Main ch)
        {
            InitializeComponent();
            B = per;
            adress.ItemsSource = B.adress.ItemsSource;
            btOK.Content = "Изменить";
            Ch = ch;
            try
            {
                for (int i = 0; i < adress.Items.Count; i++)
                {
                    var kkk = (BdClass.Adress)adress.Items[i];
                    if (kkk.Id == Ch.Adress.Id)
                    {
                        adress.SelectedIndex = i;
                        break;
                    }
                }
                if (Ch != null)
                telephone.Text = Ch.Telephone;
                if (Ch != null) castomer.Text = Ch.Customer;
                if (Ch != null) SPCH_Unchecked(null, null);

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }
        private void Сlean_Click(object sender, RoutedEventArgs e)
        { 
            adress.SelectedIndex = 0;
            typejob.SelectedIndex = 0;
            castomer.Text = "";
            malfunction.SelectedIndex = 0;
            master.SelectedIndex = 0;
            telephone.Text = "";
            spareparts.SelectedIndex = 0;
            discount.SelectedIndex = 0;
           }
        private void add_edit_Click(object sender, RoutedEventArgs e)
        {
              if (Ch == null)
                {
                    _adclass.Add(typejob, adress, master, malfunction, spareparts, discount, telephone, castomer, SPCH);
                  
                }
                else
                {
                    _adclass.Edit(typejob, adress, master, malfunction, spareparts, discount, telephone, castomer,B.S,SPCH);
                    
                }
              
            } 
        private void adress_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _adclass.Combobox(typejob, adress, master, malfunction, spareparts, discount, telephone, castomer, Ch);
        }
        private void castomer_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
           // if (!System.Text.RegularExpressions.Regex.Match(castomer.ToString(),@"[a-z]").Success)
           // {
           //     e.Handled = false;
           // }
        }
        private void telephone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.Text, 0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
            var wind = new Window7();
            wind.Closed += (sender2, e2) =>
            {
                Visibility = Visibility.Visible;
            };
            wind.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
            var wind = new Window3();
            wind.Closed += (sender2, e2) =>
            {
                Visibility = Visibility.Visible;
            };
            wind.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
            var wind = new Window5();
            wind.Closed += (sender2, e2) =>
            {
                Visibility = Visibility.Visible;
            };
            wind.ShowDialog();
        }

        private void SPCH_Unchecked(object sender, RoutedEventArgs e)
        {
            sp.Visibility = Visibility.Hidden;
            spareparts.Visibility = Visibility.Hidden;
            SP.Visibility = Visibility.Hidden;
            spareparts.SelectedIndex = 0;
        }
        private void SPCH_Checked_1(object sender, RoutedEventArgs e)
        {
            sp.Visibility = Visibility.Visible;
            spareparts.Visibility = Visibility.Visible;
            SP.Visibility = Visibility.Visible;
        }

       
        }
    }


   
