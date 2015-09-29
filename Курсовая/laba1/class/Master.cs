using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace laba1.@class
{
  public class Master
    {
      readonly SqlClass _sqlclass = new SqlClass();
      public void Table(DataGrid dg)
      {
          const string sqlDb = @"SELECT * FROM dbo.master, dbo.adress WHERE master.id_adress = adress.id_adress";
          var sqlDa = new SqlDataAdapter(sqlDb, _sqlclass.SqlCon);
          var dtMain = new DataTable();
          try
          {
              sqlDa.Fill(dtMain);
          }
          catch (Exception exp)
          {
              MessageBox.Show(exp.Message);
          }
          var lmf = new List<BdClass.Master>();
          for (var i = 0; i < dtMain.Rows.Count; i++)
          {
              var temp = new BdClass.Master
              {
                  Id = (int) dtMain.Rows[i]["id_master"],
                  Name = dtMain.Rows[i]["name"].ToString(),
                  Dol = dtMain.Rows[i]["dol"].ToString(),
                  Adress =
                      new BdClass.Adress
                      {
                          Id = (int) dtMain.Rows[i]["id_adress"],
                          Name = dtMain.Rows[i]["name_adress"].ToString()
                      }
              };
              lmf.Add(temp);
          }
          dg.ItemsSource = lmf;
      }
      public void Combobox(ComboBox ad)
      {
          const string sql = @"SELECT id_adress, name_adress FROM dbo.adress";
          var sqlDa = new SqlDataAdapter(sql, _sqlclass.SqlCon);
          var dtMain = new DataTable();

          try
          {
              sqlDa.Fill(dtMain);
          }
          catch (Exception exp)
          {
              MessageBox.Show(exp.Message);
          }
          var lmf = new List<BdClass.Adress> {new BdClass.Adress {Name = "Не выбранно"}};
          for (int i = 0; i < dtMain.Rows.Count; i++)
          {
              var temp = new BdClass.Adress
              {
                  Id = (int) dtMain.Rows[i]["id_adress"],
                  Name = dtMain.Rows[i]["name_adress"].ToString()
              };
              lmf.Add(temp);
          }
          ad.ItemsSource = lmf;
          ad.SelectedIndex = 0;
      }
      public void Add(TextBox name,ComboBox ad,TextBox d)
      {
          if ((String.IsNullOrEmpty(name.Text)) || (ad.SelectedIndex == 0) || (String.IsNullOrEmpty(d.Text)) || (ad.SelectedIndex == -1))
          {
              MessageBox.Show("Необходимо корректно заполнить все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
          }
          else
          {
              var dob = new SqlCommand {CommandType = CommandType.Text};
              try
              {
                  dob.CommandText = string.Format(@"Insert into dbo.master (name, id_adress, dol) 
                                      values (N'{0}', {1}, N'{2}')",
                      name.Text, ((BdClass.Adress)ad.SelectedItem).Id, d.Text);
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
              }
              catch (Exception exp)
              {
                  MessageBox.Show(exp.Message);
              }
          }
      }
      
    }
}
