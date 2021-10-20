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

namespace _1mxblack
{
    /// <summary>
    /// Логика взаимодействия для AdminDataCar.xaml
    /// </summary>
    public partial class AdminDataCar : UserControl
    {
        public AdminDataCar()
        {
            InitializeComponent();
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (Delete_TextBox.Text == "")
            {
                MessageBox.Show("Пожалуйста, заполните поле для удаления!!!");
            }
            else
            {
                try
                {
                    ClassCar.connection.Open();
                    string Delete = "DELETE FROM Cars WHERE Id_car = (@Id_car)";
                    SqlCommand cmd = new SqlCommand(Delete, ClassCar.connection);
                    SqlParameter Delete_param = new SqlParameter("@Id_car", Delete_TextBox.Text);
                    cmd.Parameters.Add(Delete_param);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Автомобиль удален!!!");
                }
                catch (SqlException er)
                {

                    MessageBox.Show(er.Number + " " + er.Message);
                }
                ClassCar.connection.Close();
            }
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            ClassCar.connection.Open();
            string cmd = "SELECT Id_car AS [Номер автомобиля],  Model AS Модель, Color AS Цвет, Type_car AS Тип, Mileage AS Пробег, " +
                "Year_Release AS [Год выпуска], Price_Day AS [Стоимость в день] FROM dbo.Cars"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, ClassCar.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Cars"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            ClassCar.connection.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            GridAdminDataCar.Children.Clear();
            GridAdminDataCar.Children.Add(new AddCar());
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            GridAdminDataCar.Children.Clear();
            GridAdminDataCar.Children.Add(new UpdateCar());
        }
    }
}
