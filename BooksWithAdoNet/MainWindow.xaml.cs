using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;

namespace BooksWithAdoNet
{
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();
        public string ConnectionString()
            {
                SqlConnectionStringBuilder connString = new SqlConnectionStringBuilder();
                connString.DataSource = $"{ServerNameTextBox.Text}";
                connString.InitialCatalog = $"{DataBaseNameTextBox.Text}";
                connString.IntegratedSecurity = true;
                connString.Pooling = true;
            return connString.ToString();
            }
    private void FullView_Click(object sender, RoutedEventArgs e)
        {
            string connString = ConnectionString();
            ClassicView1.IsChecked = false;
            DataTable dt = SqlManeger.Execute("Select * FROM FullView",connString);
            DataGrid.ItemsSource = dt.DefaultView;
        }
        private void ClassicView_Click(object sender, RoutedEventArgs e)
        {
            FullView1.IsChecked = false;
            string connString = ConnectionString();
            DataTable dt = SqlManeger.Execute("Select * FROM ClassicView",connString);
            DataGrid.ItemsSource = dt.DefaultView;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FullView1.IsChecked = false;
            ClassicView1.IsChecked = false;
            string connString = ConnectionString();
            string query = $"{ComboBox1.Text} {TextBox.Text} {TextBlock.Text} {TextBox2.Text};";
            DataTable dt = SqlManeger.Execute(query,connString);
            DataGrid.ItemsSource = dt.DefaultView;
        }
        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem currentItem = ((ComboBoxItem)ComboBox1.SelectedItem);
            switch (currentItem.Content)
            {
                case "SELECT":
                    TextBlock.Text = "FROM";
                    TextBox2.Text = "*";
                    break;
                case "INSERT INTO":
                    TextBlock.Text = "VALUES";
                    TextBox2.Text = "('')";
                    break;
                case "UPDATE":
                    TextBlock.Text = "SET";
                    TextBox2.Text = "   WHERE   ";
                    break;
                case "DELETE FROM":
                    TextBlock.Text = "WHERE";
                    TextBox2.Text = "";
                    break;
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string connString = ConnectionString();
            SqlManeger.Execute(connString);
            ClassicView1.IsChecked = false;
            FullView1.IsChecked = false;
            DataGrid.Columns.Clear();
            DataGrid.ItemsSource = null;
        }
    }
}

