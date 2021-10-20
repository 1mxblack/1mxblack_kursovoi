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
using System.Data;
using System.Text.RegularExpressions;

namespace _1mxblack
{
    /// <summary>
    /// Логика взаимодействия для CarPage.xaml
    /// </summary>
    public partial class CarPage : UserControl
    {
        public CarPage()
        {
            InitializeComponent();
        }
        private void PriceButton_Click(object sender, RoutedEventArgs e)
        {
            GridCars.Children.Clear();
            GridCars.Children.Add(new SortPriceCar());
        }

        private void TypeButton_Click(object sender, RoutedEventArgs e)
        {
            GridCars.Children.Clear();
            GridCars.Children.Add(new SortTypeCar());
        }
        private void FreedomCars_Click(object sender, RoutedEventArgs e)
        {
            ClassCar.connection.Open();
            string cmd = "SELECT Id_car AS [Номер автомобиля], Model AS Марка, Color AS Цвет, Type_car AS Тип, Mileage AS Пробег, " +
                "Year_Release AS [Год выпуска], Price_Day AS [Стоимость в день] " +
                " FROM dbo.Cars WHERE (NOT (Id_car IN (SELECT Car_id FROM dbo.Rent)))"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, ClassCar.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Cars"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            ClassCar.connection.Close();
        }

        public static string check(string variable)
        {
            Regex regex = new Regex(@"[A-z0-9]");
            if (!regex.IsMatch(variable))
                return "error";
            else
                return "";

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            ClassCar.connection.Open();
            string error_msg = "";
            if ((error_msg = check(tSearch.Text)) == "")
            {
                string search_value = tSearch.Text.Trim();
                //Поиск
                string Search = "Select Id_car AS [Номер автомобиля], Model AS Марка, Color AS Цвет, Type_car AS Тип, Mileage AS Пробег, " +
                "Year_Release AS [Год выпуска], Price_Day AS [Стоимость в день] FROM Cars WHERE Model LIKE '%" + search_value + "%'";
                SqlCommand cmd = new SqlCommand(Search, ClassCar.connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Cars"); // В скобках указываем название таблицы
                dataAdp.Fill(dt);
                DataGrid.ItemsSource = dt.DefaultView; // Сам вывод
                ClassCar.connection.Close();
            }
        }
        private void Changed_Click(object sender, RoutedEventArgs e)
        {
            GridCars.Children.Clear();
            GridCars.Children.Add(new Rent());
        }
    }
}


