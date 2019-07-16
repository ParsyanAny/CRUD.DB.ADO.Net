using BooksWithAdoNet;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

    public static class SqlManeger
    {
    public static DataTable Execute(string query, string connString)
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
    public static void Execute(string connString)
    {
        using (SqlConnection connection = new SqlConnection(connString))
            try
            {
                connection.Open();
                if (connString.Length != 67)
                MessageBox.Show($"You connect to {connection.Database.ToString()}");
                else
                    MessageBox.Show("Please select your DataSource and DataName");

            }
            catch (Exception ex)
            {
            MessageBox.Show(ex.Message);
            }    
    }
}

