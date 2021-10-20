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
using System.Data;
using System.Data.SqlClient;

namespace _1mxblack.Resources.Admin
{
    /// <summary>
    /// Логика взаимодействия для DataRent.xaml
    /// </summary>
    public partial class DataRent : UserControl
    {
        public DataRent()
        {
            InitializeComponent();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            GridAdminDataRent.Children.Clear();
            GridAdminDataRent.Children.Add(new AddRent());
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            GridAdminDataRent.Children.Clear();
            GridAdminDataRent.Children.Add(new UpdateRent());
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
                    string Delete = "DELETE FROM Rent WHERE Rent_id = (@Rent_id)";
                    SqlCommand cmd = new SqlCommand(Delete, ClassCar.connection);
                    SqlParameter Delete_param = new SqlParameter("@Rent_id", Delete_TextBox.Text);
                    cmd.Parameters.Add(Delete_param);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Прокат удален!!!");
                }
                catch
                {

                    MessageBox.Show("Введите номер проката");
                }
                ClassCar.connection.Close();
            }
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            ClassCar.connection.Open();
            string cmd = "SELECT dbo.Rent.Rent_id AS [Номер проката], dbo.Rent.Client_id AS [Номер клиента], " +
                "dbo.Rent.Car_id AS [Номер автомобиля], DATEDIFF(dd, dbo.Rent.Date_Start, dbo.Rent.Data_End) AS [Количество дней], " +
                "dbo.Cars.Price_Day AS[Стоимость в день] FROM dbo.Rent INNER JOIN dbo.Cars ON dbo.Rent.Car_id = dbo.Cars.Id_car"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, ClassCar.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Rent"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            ClassCar.connection.Close();
        }
    }
}
