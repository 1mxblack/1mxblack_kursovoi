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

namespace _1mxblack
{
    /// <summary>
    /// Логика взаимодействия для SortTypeCar.xaml
    /// </summary>
    public partial class SortTypeCar : UserControl
    {
        public SortTypeCar()
        {
            InitializeComponent();
        }
        private void MainPageButton_Click(object sender, RoutedEventArgs e)
        {
            GridSortType.Children.Clear();
            GridSortType.Children.Add(new CarPage());
        }

        private void TypeSedanButton_Click(object sender, RoutedEventArgs e)
        {
            ClassCar.connection.Open();
            string cmd = "SELECT Id_car AS [Номер автомобиля], Model AS Марка, Color AS Цвет, Type_car AS Тип, Mileage AS Пробег, " +
                "Year_Release AS [Год выпуска], Price_Day AS [Стоимость в день]  FROM dbo.Cars WHERE(Type_car = 'Седан')"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, ClassCar.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Cars"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            ClassCar.connection.Close();
        }

        private void TypeOverdriveButton_Click(object sender, RoutedEventArgs e)
        {
            ClassCar.connection.Open();
            string cmd = "SELECT Id_car AS [Номер автомобиля], Model AS Марка, Color AS Цвет, Type_car AS Тип, Mileage AS Пробег, " +
                "Year_Release AS [Год выпуска], Price_Day AS [Стоимость в день]  FROM dbo.Cars WHERE(Type_car = 'Внедорожник')"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, ClassCar.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Cars"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            ClassCar.connection.Close();
        }

        private void TypeUniversalButton_Click(object sender, RoutedEventArgs e)
        {
            ClassCar.connection.Open();
            string cmd = "SELECT Id_car AS [Номер автомобиля], Model AS Марка, Color AS Цвет, Type_car AS Тип, Mileage AS Пробег, " +
                "Year_Release AS [Год выпуска], Price_Day AS [Стоимость в день]  FROM dbo.Cars WHERE(Type_car = 'Универсал')"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, ClassCar.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Cars"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            ClassCar.connection.Close();
        }


        private void TypeCompartmentButton_Click(object sender, RoutedEventArgs e)
        {
            ClassCar.connection.Open();
            string cmd = "SELECT Id_car AS [Номер автомобиля], Model AS Марка,  Color AS Цвет, Type_car AS Тип, Mileage AS Пробег, " +
                "Year_Release AS [Год выпуска], Price_Day AS [Стоимость в день]  FROM dbo.Cars WHERE(Type_car = 'Купе')"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, ClassCar.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Cars"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            ClassCar.connection.Close();
        }

        private void TypeCabrioletButton_Click(object sender, RoutedEventArgs e)
        {
            ClassCar.connection.Open();
            string cmd = "SELECT Id_car AS [Номер автомобиля], Model AS Марка, Color AS Цвет, Type_car AS Тип, Mileage AS Пробег, " +
                "Year_Release AS [Год выпуска], Price_Day AS [Стоимость в день]  FROM dbo.Cars WHERE(Type_car = 'Кабриолет')"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, ClassCar.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Cars"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод
                                                   // 
            ClassCar.connection.Close();
        }

        private void TypeSportCarButton_Click(object sender, RoutedEventArgs e)
        {
            ClassCar.connection.Open();
            string cmd = "SELECT Id_car AS [Номер автомобиля], Model AS Марка, Color AS Цвет, Type_car AS Тип, Mileage AS Пробег, " +
                "Year_Release AS [Год выпуска], Price_Day AS [Стоимость в день]  FROM dbo.Cars WHERE(Type_car = 'Спорткар')"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, ClassCar.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Cars"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            ClassCar.connection.Close();
        }
    }
}
