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


namespace _1mxblack.Resources.User
{
    /// <summary>
    /// Логика взаимодействия для MyCar.xaml
    /// </summary>
    public partial class MyCar : UserControl
    {
        public MyCar()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            GridMyCar.Children.Clear();
            GridMyCar.Children.Add(new UserSecondPage());
        }

        private void VievCars_Click(object sender, RoutedEventArgs e)
        {
            {
                ClassCar.connection.Open();
                string cmd = String.Format("SELECT dbo.Rent.Rent_id AS [Номер проката]," +
                    "dbo.Rent.Car_id AS [Номер автомобиля],dbo.Rent.Date_Start AS[Дата начала бронирования],dbo.Rent.Data_end AS[Окончания бронирования], DATEDIFF(dd, dbo.Rent.Date_Start, dbo.Rent.Data_End) AS [Количество дней], " +
                    "dbo.Cars.Price_Day AS[Стоимость в день] FROM dbo.Rent INNER JOIN dbo.Cars ON dbo.Rent.Car_id = dbo.Cars.Id_car WHERE Client_id = @myID");
                SqlCommand command = new SqlCommand(cmd, ClassCar.connection);
                command.Parameters.Add("@myID", SqlDbType.Int);
                command.Parameters["@myID"].Value = ClassCar.myId;
                command.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(command);
                DataTable dt = new DataTable("Rent"); // В скобках указываем название таблицы
                dataAdp.Fill(dt);
                DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
                ClassCar.connection.Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
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
                        MessageBox.Show("Прокат отменен!!!");
                    }
                    catch
                    {

                        MessageBox.Show("Введите номер проката");
                    }
                    ClassCar.connection.Close();
                }
            }
        }
    }
}
