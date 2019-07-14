using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace BooksWithAdoNet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    DataTable dt = SqlManeger.Execute(TB.Text);
        //    DataGrid.ItemsSource = dt.DefaultView;
        //}
        private void FullView_Click(object sender, RoutedEventArgs e)
        {
            ClassicView1.IsChecked = false;
            DataTable dt = SqlManeger.Execute("Select * FROM FullView");
            DataGrid.ItemsSource = dt.DefaultView;
        }
        private void ClassicView_Click(object sender, RoutedEventArgs e)
        {
            FullView1.IsChecked = false;
            DataTable dt = SqlManeger.Execute("Select * FROM ClassicView");
            DataGrid.ItemsSource = dt.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FullView1.IsChecked = true;
            ClassicView1.IsChecked = true;
            string query = $"{ComboBox1.Text} {TextBox1.Text} {TextBlock.Text} {TextBox2.Text};";
            DataTable dt = SqlManeger.Execute(query);
            DataGrid.ItemsSource = dt.DefaultView;
        }
        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem currentItem = ((ComboBoxItem)ComboBox1.SelectedItem);
            switch (currentItem.Content)
            {
                case "SELECT":
                    TextBlock.Text = "FROM";
                    break;
                case "INSERT INTO":
                    TextBlock.Text = "VALUES";
                    break;
                case "UPDATE":
                    TextBlock.Text = "SET";
                    break;
                case "DELATE FROM":
                    TextBlock.Text = "WHERE";
                    break;
            }    
        }
    }
}
