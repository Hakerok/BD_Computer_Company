using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace laba1.@class
{
    class SqlClass
    {
        public SqlConnection SqlCon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Игорь\AppData\Roaming\Company\База данных Гаечка\Database1.mdf;Integrated Security=True");
        public void Combobox(ComboBox tj, ComboBox ad, ComboBox mast)
        {
            const string sql = "SELECT * FROM dbo.type_job";
            const string sql1 = "SELECT * FROM dbo.master";
            const string sql2 = "SELECT * FROM dbo.adress";
            var sqlDa = new SqlDataAdapter(sql, SqlCon);
            var dtMain = new DataTable();
            try
            {
                sqlDa.Fill(dtMain);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            var lmf = new List<BdClass.TypeJob> {new BdClass.TypeJob {Name = "Не выбранно"}};
            for (int i = 0; i < dtMain.Rows.Count; i++)
            {
                var temp = new BdClass.TypeJob
                {
                    Id = (int) dtMain.Rows[i]["id_type_job"],
                    Name = dtMain.Rows[i]["name_type_job"].ToString()
                };
                lmf.Add(temp);
            }
            tj.ItemsSource = lmf;
            tj.SelectedIndex = 0;
            sqlDa = new SqlDataAdapter(sql2, SqlCon);
            dtMain = new DataTable();
            try
            {
                sqlDa.Fill(dtMain);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

            var lmf2 = new List<BdClass.Adress> {new BdClass.Adress {Name = "Не выбранно"}};
            for (int i = 0; i < dtMain.Rows.Count; i++)
            {
                var temp = new BdClass.Adress
                {
                    Id = (int) dtMain.Rows[i]["id_adress"],
                    Name = dtMain.Rows[i]["name_adress"].ToString()
                };
                lmf2.Add(temp);
            }
            ad.ItemsSource = lmf2;
            ad.SelectedIndex = 0;
            sqlDa = new SqlDataAdapter(sql1, SqlCon);
            dtMain = new DataTable();
            try
            {
                sqlDa.Fill(dtMain);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

            var lmf3 = new List<BdClass.Master> {new BdClass.Master {Name = "Не выбранно"}};
            for (int i = 0; i < dtMain.Rows.Count; i++)
            {
                var temp = new BdClass.Master
                {
                    Id = (int) dtMain.Rows[i]["id_master"],
                    Name = dtMain.Rows[i]["name"].ToString()
                };
                lmf3.Add(temp);
            }
            mast.ItemsSource = lmf3;
            mast.SelectedIndex = 0;
        }
        public void Filter(DataGrid dg, ComboBox tj, ComboBox ad, ComboBox mast)
        {
            String sqlDb = @"SELECT *
                FROM     
	                dbo.main 
            INNER JOIN dbo.type_job		ON dbo.main.id_type_job = dbo.type_job.id_type_job
            INNER JOIN dbo.malfunction	ON dbo.main.id_malfunction =  dbo.malfunction.id_malfunction
            INNER JOIN dbo.discounts	ON dbo.main.id_discounts = dbo.discounts.id_discounts
            INNER JOIN dbo.adress		ON dbo.main.id_adress = dbo.adress.id_adress     
            INNER JOIN dbo.master		ON dbo.main.id_master = dbo.master.id_master
            LEFT JOIN dbo.spare_parts	ON dbo.main.id_spare_parts = spare_parts.id_spare_parts ";
            if (tj.SelectedIndex > 0)
            {
                int kkkk = ((BdClass.TypeJob)tj.SelectedItem).Id;
                sqlDb += "where dbo.type_job.id_type_job =" + kkkk;
            }
            if (ad.SelectedIndex > 0)
            {
                if (tj.SelectedIndex > 0)
                {
                    int kkkk1 = ((BdClass.Adress)ad.SelectedItem).Id;
                    sqlDb += " AND dbo.adress.id_adress =" + kkkk1;
                }
                else
                {
                    int kkkk1 = ((BdClass.Adress)ad.SelectedItem).Id;
                    sqlDb += " where dbo.adress.id_adress =" + kkkk1;
                }
               }
            if (mast.SelectedIndex > 0)
            {
                if (tj.SelectedIndex > 0 || ad.SelectedIndex > 0)
                {
                    int kkkk2 = ((BdClass.Master)mast.SelectedItem).Id;
                    sqlDb += " AND dbo.master.id_master =" + kkkk2;
                }
                else
                {
                    int kkkk2 = ((BdClass.Master)mast.SelectedItem).Id;
                    sqlDb += " WHERE dbo.master.id_master =" + kkkk2;
                }
                
            }
            var sqlDa = new SqlDataAdapter(sqlDb, SqlCon);
            var dtMain = new DataTable();
            try
            {
                sqlDa.Fill(dtMain);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            var lmf4 = new List<BdClass.Main>();
            for (var i = 0; i < dtMain.Rows.Count; i++)
            {

                var temp = new BdClass.Main
                {
                    Id = (int)dtMain.Rows[i]["id_main"],
                    Telephone = dtMain.Rows[i]["telephone"].ToString(),
                    Customer = dtMain.Rows[i]["customer"].ToString(),
                    DateOfCompletion = Convert.ToDateTime(dtMain.Rows[i]["date_of_completion"].ToString())
                };
                var dateTime = dtMain.Rows[i]["time_of_completion"].ToString() != ""
                    ? (DateTime?)Convert.ToDateTime(dtMain.Rows[i]["time_of_completion"].ToString())
                    : null;
                temp.TimeOfCompletion = dateTime;
                temp.Adress = new BdClass.Adress
                {
                    Id = (int) dtMain.Rows[i]["id_adress"],
                    Name = dtMain.Rows[i]["name_adress"].ToString()
                };
                temp.Typejob = new BdClass.TypeJob
                {
                    Id = (int) dtMain.Rows[i]["id_type_job"],
                    Name = dtMain.Rows[i]["name_type_job"].ToString()
                };
                temp.Master = new BdClass.Master
                {
                    Id = (int) dtMain.Rows[i]["id_master"],
                    Name = dtMain.Rows[i]["name"].ToString(),
                    Dol = dtMain.Rows[i]["dol"].ToString()
                };
                temp.SpareParts = new BdClass.SpareParts();

                var sp = dtMain.Rows[i]["id_spare_parts"].ToString() != ""
                  ? dtMain.Rows[i]["name_spare_parts"].ToString()
                  : null;

                temp.SpareParts.Name = sp; 
                
                temp.Malfunction = new BdClass.Malfunction
                {
                    Id = (int) dtMain.Rows[i]["id_malfunction"],
                    Name = dtMain.Rows[i]["name_malfunction"].ToString()
                };
                temp.Discounts = new BdClass.Discounts
                {
                    Id = (int) dtMain.Rows[i]["id_discounts"],
                    Name = dtMain.Rows[i]["name_discount"].ToString()
                };
                lmf4.Add(temp);
            }
            dg.ItemsSource = lmf4;
        }
        public void Exit()
        {
            if (MessageBox.Show("Вы дейтвительно хотите выйти?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Exit += delegate { MessageBox.Show("Удачи", "Программа остановлена", MessageBoxButton.OK, MessageBoxImage.Information); };
                Application.Current.Shutdown();
            }
        }
        public void Del(object sender)
        {
            if (MessageBox.Show("Вы действительно хотите удалить эту запись", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    int k = Convert.ToInt32(((Button)sender).Tag);
                    var del = new SqlCommand("DELETE FROM dbo.main WHERE id_main = " + k, SqlCon);
                    SqlCon.Close();
                    SqlCon.Open();
                    del.ExecuteNonQuery();
                    SqlCon.Close();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }

            }
        }
        public void Table(DataGrid dg)
        {
            const string sqlDb = @"SELECT *
                FROM     
	                dbo.main 
            INNER JOIN dbo.type_job		ON dbo.main.id_type_job = dbo.type_job.id_type_job
            INNER JOIN dbo.malfunction	ON dbo.main.id_malfunction =  dbo.malfunction.id_malfunction
            INNER JOIN dbo.discounts	ON dbo.main.id_discounts = dbo.discounts.id_discounts
            INNER JOIN dbo.adress		ON dbo.main.id_adress = dbo.adress.id_adress     
            INNER JOIN dbo.master		ON dbo.main.id_master = dbo.master.id_master
            LEFT JOIN dbo.spare_parts	ON dbo.main.id_spare_parts = spare_parts.id_spare_parts ";
            var sqlDa = new SqlDataAdapter(sqlDb, SqlCon);
            var dtMain = new DataTable();
            try
            {
                sqlDa.Fill(dtMain);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            var lmf = new List<BdClass.Main>();
            for (int i = 0; i < dtMain.Rows.Count; i++)
            {
                var temp = new BdClass.Main
                {
                    Id = (int) dtMain.Rows[i]["id_main"],
                    Telephone = dtMain.Rows[i]["telephone"].ToString(),
                    Customer = dtMain.Rows[i]["customer"].ToString(),
                    DateOfCompletion = Convert.ToDateTime(dtMain.Rows[i]["date_of_completion"].ToString())
                };
                var dateTime = dtMain.Rows[i]["time_of_completion"].ToString() != ""
                    ? (DateTime?) Convert.ToDateTime(dtMain.Rows[i]["time_of_completion"].ToString())
                    : null;
                temp.TimeOfCompletion = dateTime;
                temp.Adress = new BdClass.Adress
                {
                    Id = (int) dtMain.Rows[i]["id_adress"],
                    Name = dtMain.Rows[i]["name_adress"].ToString()
                };
                temp.Typejob = new BdClass.TypeJob
                {
                    Id = (int) dtMain.Rows[i]["id_type_job"],
                    Name = dtMain.Rows[i]["name_type_job"].ToString()
                };
                temp.Master = new BdClass.Master
                {
                    Id = (int) dtMain.Rows[i]["id_master"],
                    Name = dtMain.Rows[i]["name"].ToString()
                };
                temp.SpareParts = new BdClass.SpareParts();

                 var sp = dtMain.Rows[i]["id_spare_parts"].ToString() != ""
                   ? dtMain.Rows[i]["name_spare_parts"].ToString()
                   : null;
                
                temp.SpareParts.Name = sp; 
                
                temp.Malfunction = new BdClass.Malfunction
                {
                    Id = (int) dtMain.Rows[i]["id_malfunction"],
                    Name = dtMain.Rows[i]["name_malfunction"].ToString()
                };
                temp.Discounts = new BdClass.Discounts
                {
                    Id = (int) dtMain.Rows[i]["id_discounts"],
                    Name = dtMain.Rows[i]["name_discount"].ToString()
                };
                lmf.Add(temp);
            }
            dg.ItemsSource = lmf;
        }
        public void Done(object sender)
        {
            try
            {
                var dat = DateTime.Now;
                var ppp = ((Button) sender).Tag.ToString();
                var dost = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText =
                        "Update dbo.main set status = 1, time_of_completion  = '" + dat.ToShortTimeString() +
                        "' where id_main =  " + ppp,
                    Connection = SqlCon
                };

                SqlCon.Open();
                dost.ExecuteNonQuery();
                SqlCon.Close();

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
         
        }
    }
}

       


          
