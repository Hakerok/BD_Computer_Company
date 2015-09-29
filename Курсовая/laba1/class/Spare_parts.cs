using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace laba1.@class
{
   public class SpareParts
    {
       readonly SqlClass _sqlclass = new SqlClass();
       public void Table(DataGrid dg)
       {
           const string sqlDb = @"SELECT id_spare_parts, name_spare_parts,number,cost FROM dbo.spare_parts";
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
           var lmf = new List<BdClass.SpareParts>();
           for (var i = 0; i < dtMain.Rows.Count; i++)
           {
               var temp = new BdClass.SpareParts
               {
                   Id = (int) dtMain.Rows[i]["id_spare_parts"],
                   Name = dtMain.Rows[i]["name_spare_parts"].ToString(),
                   Cost = dtMain.Rows[i]["cost"].ToString(),
                   Number = dtMain.Rows[i]["number"].ToString()
               };
               lmf.Add(temp);
           }
           dg.ItemsSource = lmf;
       }
       public void Add(TextBox nam,TextBox co, TextBox cou )
       {
           if ((String.IsNullOrEmpty(nam.Text)) || (String.IsNullOrEmpty(co.Text)) || (String.IsNullOrEmpty(cou.Text)))
           {
               MessageBox.Show("Необходимо корректно заполнить все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
           }
           else
           {
               var dob = new SqlCommand {CommandType = CommandType.Text};
               {
                   try
                   {
                       dob.CommandText = string.Format(@"Insert into dbo.spare_parts (name_spare_parts, number, cost) 
                                      values (N'{0}', {1}, {2})",
                          nam.Text, co.Text, cou.Text);
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
}
