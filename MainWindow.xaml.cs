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
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace _1mxblack
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"DESKTOP-LV78N2J\SQLEXPRESS"; //NOTEBOOK-MAX\SQLEXPRESS KOMP\SQLEXPRESS PC-MAX\SQLEXPRESS
            builder.InitialCatalog = "Cars";
            builder.IntegratedSecurity = true;
            ClassCar.connection = new SqlConnection(builder.ConnectionString);
            MainFrame.Navigate(new StartPage());
            ClassCar.MainFrame = MainFrame;
        }
        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void ButtonHidePage_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
