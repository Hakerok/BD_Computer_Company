using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace laba1.@class
{
    public class Malfunction
    {
        readonly SqlClass _sqlclass = new SqlClass();
        public void Table(DataGrid dg)
        {
            string sqlDB = @"SELECT id_malfunction,name_malfunction FROM dbo.malfunction";
            var sqlDa = new SqlDataAdapter(sqlDB, _sqlclass.SqlCon);
            var dtMain = new DataTable();
            try
            {
                sqlDa.Fill(dtMain);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            var lmf = new List<BdClass.Malfunction>();
            for (var i = 0; i < dtMain.Rows.Count; i++)
            {
                var temp = new BdClass.Malfunction
                {
                    Id = (int) dtMain.Rows[i]["id_malfunction"],
                    Name = dtMain.Rows[i]["name_malfunction"].ToString()
                };
                lmf.Add(temp);
            }
            dg.ItemsSource = lmf;
        }
        public void Add(TextBox name)
        {
            if ((String.IsNullOrEmpty(name.Text)))
            {
                MessageBox.Show("Необходимо корректно заполнить все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var dob = new SqlCommand {CommandType = CommandType.Text};
                {
                    try
                    {
                        dob.CommandText = string.Format(@"Insert into dbo.malfunction (name_malfunction) 
                                      values (N'{0}')",
                           name.Text);
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
