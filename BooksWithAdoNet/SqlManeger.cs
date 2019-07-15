using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BooksWithAdoNet
{
    public static class SqlManeger
    {
        private const string connString = @"Data Source=(local);Initial Catalog=BookDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Pooling=true";
        public static DataTable Execute(string query)
        {
            var ds = new DataTable();

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                using (var adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = new SqlCommand(query, connection);
                    try
                    {
                         adapter.Fill(ds);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            return ds;
        }
    }
}
