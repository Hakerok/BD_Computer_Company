using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace laba1.@class
{
    public class AddClass
    {
        readonly SqlClass _sqlclass = new SqlClass();
        public string Iduser;
        public void Add(ComboBox tj, ComboBox ad, ComboBox mast, ComboBox ml, ComboBox sp, ComboBox ds, TextBox tl, TextBox cas,CheckBox ch)
        {
            if (ch.IsChecked == false)
            {
                if  ((ad.SelectedIndex == 0) || (tj.SelectedIndex == 0) || (ml.SelectedIndex == 0) ||
                    (ad.SelectedIndex == 0) || (mast.SelectedIndex == 0) || (ds.SelectedIndex == 0)
                    || (String.IsNullOrEmpty(tl.Text)) || (String.IsNullOrEmpty(cas.Text)))
                {

                    MessageBox.Show("Необходимо корректно заполнить все поля!", "Ошибка", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
                else
                {
                    var dob = new SqlCommand {CommandType = CommandType.Text};
                    {
                        try
                        {
                            var dt = DateTime.Today;
                            dob.CommandText =
                                string.Format(@"Insert into dbo.main (id_type_job,id_malfunction, customer, 
                                                                    id_discounts,telephone,id_adress,id_master,status, date_of_completion)  
                                                                                    values ('{0}', '{1}',  N'{2}', '{3}', '{4}', '{5}', '{6}', {7},'{8}-{9}-{10}')",
                                    ((BdClass.TypeJob) tj.SelectedItem).Id, ((BdClass.Malfunction) ml.SelectedItem).Id,
                                    cas.Text, ((BdClass.Discounts) ds.SelectedItem).Id,
                                    tl.Text, ((BdClass.Adress) ad.SelectedItem).Id,
                                    ((BdClass.Master) mast.SelectedItem).Id, 0, dt.Year, dt.Month, dt.Day);
                        }

                        catch (Exception exp)
                        {
                            MessageBox.Show(exp.Message);
                        }
                        dob.Connection = _sqlclass.SqlCon;
                        _sqlclass.SqlCon.Close();
                        try
                        {
                            _sqlclass.SqlCon.Open();
                            dob.ExecuteNonQuery();
                            _sqlclass.SqlCon.Close();
                            MessageBox.Show("Добавлено", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                            
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show(exp.Message);
                        }
                    }

                }
            }
            else
            {
                if ((ad.SelectedIndex == 0) ||(sp.SelectedIndex == 0)|| (tj.SelectedIndex == 0) || (ml.SelectedIndex == 0) ||
                   (ad.SelectedIndex == 0) || (mast.SelectedIndex == 0) || (ds.SelectedIndex == 0)
                   || (String.IsNullOrEmpty(tl.Text)) || (String.IsNullOrEmpty(cas.Text)))
                {

                    MessageBox.Show("Необходимо корректно заполнить все поля!", "Ошибка", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
                else
                {
                    var dob = new SqlCommand { CommandType = CommandType.Text };
                    {
                        try
                        {
                            var dt = DateTime.Today;
                            dob.CommandText =
                                string.Format(@"Insert into dbo.main (id_type_job,id_malfunction, customer, 
                                                                    id_discounts,telephone,id_adress,id_master,status, date_of_completion,id_spare_parts)  
                                                                                    values ('{0}', '{1}',  N'{2}', '{3}', '{4}', '{5}', '{6}', {7},'{8}-{9}-{10}','{11}')",
                                    ((BdClass.TypeJob)tj.SelectedItem).Id, ((BdClass.Malfunction)ml.SelectedItem).Id,
                                    cas.Text, ((BdClass.Discounts)ds.SelectedItem).Id,
                                    tl.Text, ((BdClass.Adress)ad.SelectedItem).Id,
                                    ((BdClass.Master)mast.SelectedItem).Id, 0, dt.Year, dt.Month, dt.Day,((BdClass.SpareParts)sp.SelectedItem).Id);
                        }

                        catch (Exception exp)
                        {
                            MessageBox.Show(exp.Message);
                        }
                        dob.Connection = _sqlclass.SqlCon;
                        _sqlclass.SqlCon.Close();
                        try
                        {
                            _sqlclass.SqlCon.Open();
                            dob.ExecuteNonQuery();
                            _sqlclass.SqlCon.Close();
                            MessageBox.Show("Добавлено", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show(exp.Message);
                        }
                    }

                }
            }
        }

        public void Edit(ComboBox tj, ComboBox ad, ComboBox mast, ComboBox ml, ComboBox sp, ComboBox ds, TextBox tl,
            TextBox cas, string s, CheckBox ch)
        {
            if (ch.IsChecked == false)
            {

                var dob = new SqlCommand {CommandType = CommandType.Text};
                if (
                    MessageBox.Show("Вы действительно хотите отредактировать запись?", "Редактирование",
                        MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes) return;
                try
                {
                    var dt = DateTime.Today;
                    dob.CommandText = string.Format(@"Update dbo.main set  id_type_job = '{0}',
                                    id_malfunction = '{1}',  customer = N'{2}', id_discounts = '{3}',
                                    telephone = '{4}',  id_adress = '{5}', id_master = '{6}', status = '{7}', date_of_completion = '{8}-{9}-{10}',id_spare_parts = '{11}'
                                        where id_main = '{12}'",
                        ((BdClass.TypeJob) tj.SelectedItem).Id, ((BdClass.Malfunction) ml.SelectedItem).Id,
                        cas.Text, ((BdClass.Discounts) ds.SelectedItem).Id,
                        tl.Text, ((BdClass.Adress) ad.SelectedItem).Id, ((BdClass.Master) mast.SelectedItem).Id, 0,
                        dt.Year, dt.Month, dt.Day, null, s);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
                dob.Connection = _sqlclass.SqlCon;
                _sqlclass.SqlCon.Close();
                try
                {
                    _sqlclass.SqlCon.Open();
                    dob.ExecuteNonQuery();
                    _sqlclass.SqlCon.Close();
                    MessageBox.Show("Изменения успешно сохранены", "Информация", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
            else
            {
                var dob = new SqlCommand {CommandType = CommandType.Text};
                if (
                    MessageBox.Show("Вы действительно хотите отредактировать запись?", "Редактирование",
                        MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes) return;
                try
                {
                    var dt = DateTime.Today;
                    dob.CommandText = string.Format(@"Update dbo.main set  id_type_job = '{0}',
                                    id_malfunction = '{1}', id_spare_parts = '{2}', customer = N'{3}', id_discounts = '{4}',
                                    telephone = '{5}',  id_adress = '{6}', id_master = '{7}', status = '{8}', date_of_completion = '{9}-{10}-{11}'
                                        where id_main = '{12}'",
                        ((BdClass.TypeJob) tj.SelectedItem).Id, ((BdClass.Malfunction) ml.SelectedItem).Id,
                        ((BdClass.SpareParts) sp.SelectedItem).Id, cas.Text, ((BdClass.Discounts) ds.SelectedItem).Id,
                        tl.Text, ((BdClass.Adress) ad.SelectedItem).Id, ((BdClass.Master) mast.SelectedItem).Id, 0,
                        dt.Year, dt.Month, dt.Day, s);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
                dob.Connection = _sqlclass.SqlCon;
                _sqlclass.SqlCon.Close();
                try
                {
                    _sqlclass.SqlCon.Open();
                    dob.ExecuteNonQuery();
                    _sqlclass.SqlCon.Close();
                    MessageBox.Show("Изменения успешно сохранены", "Информация", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }

        public void Combobox(ComboBox tj, ComboBox ad, ComboBox mast, ComboBox ml, ComboBox sp, ComboBox ds, TextBox tl, TextBox cas, BdClass.Main ch)
        {
            var idF = ((BdClass.Adress)ad.SelectedItem).Id;
            {
                const string sql1 = @"SELECT id_malfunction, name_malfunction FROM dbo.malfunction";
                var sqlDa = new SqlDataAdapter(sql1, _sqlclass.SqlCon);
                var dtMain = new DataTable();
                try
                {
                    sqlDa.Fill(dtMain);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }

                var lmf1 = new List<BdClass.Malfunction> {new BdClass.Malfunction {Name = "Не выбрано"}};
                for (int i = 0; i < dtMain.Rows.Count; i++)
                {
                    var temp = new BdClass.Malfunction
                    {
                        Id = (int) dtMain.Rows[i]["id_malfunction"],
                        Name = dtMain.Rows[i]["name_malfunction"].ToString()
                    };
                    lmf1.Add(temp);
                }
                ml.ItemsSource = lmf1;
                ml.SelectedIndex = 0;
                if (ch != null)
                {
                    for (int i = 0; i < ml.Items.Count; i++)
                    {
                        var kkk = (BdClass.Malfunction)ml.Items[i];
                        if (kkk.Id == ch.Malfunction.Id)
                        {
                            ml.SelectedIndex = i;
                            break;
                        }
                    }
                }
                const string sql2 = @"SELECT * FROM dbo.spare_parts";
                sqlDa = new SqlDataAdapter(sql2, _sqlclass.SqlCon);
                dtMain = new DataTable();
                try
                {
                    sqlDa.Fill(dtMain);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }

                var lmf2 = new List<BdClass.SpareParts> {new BdClass.SpareParts {Name = "Не выбрано"}};
                for (var i = 0; i < dtMain.Rows.Count; i++)
                {
                    var temp = new BdClass.SpareParts
                    {
                        Id = (int) dtMain.Rows[i]["id_spare_parts"],
                        Name = dtMain.Rows[i]["name_spare_parts"].ToString()
                    };
                    lmf2.Add(temp);
                }
                sp.ItemsSource = lmf2;
                sp.SelectedIndex = 0;
                if (ch != null)
                {
                    for (int i = 0; i < sp.Items.Count; i++)
                    {
                        var kkk = (BdClass.SpareParts)sp.Items[i];
                        if (kkk.Id != ch.SpareParts.Id) continue;
                        sp.SelectedIndex = i;
                        break;
                    }
                }
                const string sql3 = @"SELECT id_discounts, name_discount FROM dbo.discounts";
                sqlDa = new SqlDataAdapter(sql3, _sqlclass.SqlCon);
                dtMain = new DataTable();
                try
                {
                    sqlDa.Fill(dtMain);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }

                var lmf3 = new List<BdClass.Discounts> {new BdClass.Discounts {Name = "Не выбрано"}};
                for (int i = 0; i < dtMain.Rows.Count; i++)
                {
                    var temp = new BdClass.Discounts
                    {
                        Id = (int) dtMain.Rows[i]["id_discounts"],
                        Name = dtMain.Rows[i]["name_discount"].ToString()
                    };
                    lmf3.Add(temp);
                }
                ds.ItemsSource = lmf3;
                ds.SelectedIndex = 0;
                if (ch != null)
                {
                    for (int i = 0; i < ds.Items.Count; i++)
                    {
                        var kkk = (BdClass.Discounts)ds.Items[i];
                        if (kkk.Id != ch.Discounts.Id) continue;
                        ds.SelectedIndex = i;
                        break;
                    }
                }
                string sql4 = @"SELECT * FROM dbo.master,dbo.adress WHERE master.id_adress = adress.id_adress and master.id_adress=" + idF;
                sqlDa = new SqlDataAdapter(sql4, _sqlclass.SqlCon);
                dtMain = new DataTable();
                try
                {
                    sqlDa.Fill(dtMain);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }

                var lmf4 = new List<BdClass.Master> {new BdClass.Master {Name = "Не выбрано"}};
                for (var i = 0; i < dtMain.Rows.Count; i++)
                {
                    var temp = new BdClass.Master
                    {
                        Id = (int) dtMain.Rows[i]["id_master"],
                        Name = dtMain.Rows[i]["name"].ToString()
                    };
                    lmf4.Add(temp);
                }
                mast.ItemsSource = lmf4;
                mast.SelectedIndex = 0;
                if (ch != null)
                {
                    for (var i = 0; i < mast.Items.Count; i++)
                    {
                        var kkk = (BdClass.Master)mast.Items[i];
                        if (kkk.Id != ch.Master.Id) continue;
                        mast.SelectedIndex = i;
                        break;
                    }
                }
                const string sql5 = @"SELECT * FROM dbo.type_job";
                sqlDa = new SqlDataAdapter(sql5, _sqlclass.SqlCon);
                dtMain = new DataTable();
                try
                {
                    sqlDa.Fill(dtMain);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }

                var lmf5 = new List<BdClass.TypeJob> {new BdClass.TypeJob {Name = "Не выбрано"}};
                for (var i = 0; i < dtMain.Rows.Count; i++)
                {
                    var temp = new BdClass.TypeJob
                    {
                        Id = (int) dtMain.Rows[i]["id_type_job"],
                        Name = dtMain.Rows[i]["name_type_job"].ToString()
                    };
                    lmf5.Add(temp);
                }
                tj.ItemsSource = lmf5;
                tj.SelectedIndex = 0;
                if (ch == null) return;
                for (var i = 0; i < tj.Items.Count; i++)
                {
                    var kkk = (BdClass.TypeJob)tj.Items[i];
                    if (kkk.Id != ch.Typejob.Id) continue;
                    tj.SelectedIndex = i;
                    break;
                }
            }
        }
    }
}
