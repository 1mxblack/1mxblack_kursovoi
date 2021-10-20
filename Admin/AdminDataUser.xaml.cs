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
    /// Логика взаимодействия для AdminDataUser.xaml
    /// </summary>
    public partial class AdminDataUser : UserControl
    {
        public AdminDataUser()
        {
            InitializeComponent();
        }
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            GridAdminDataUser.Children.Clear();
            GridAdminDataUser.Children.Add(new UpdateUser());
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
                    string Delete = "DELETE FROM Client WHERE Client_id = (@Client_id)";
                    SqlCommand cmd = new SqlCommand(Delete, ClassCar.connection);
                    SqlParameter Delete_param = new SqlParameter("@Client_id", Delete_TextBox.Text);
                    cmd.Parameters.Add(Delete_param);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Пользователь удален!!!");
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
            string cmd = "SELECT Client_id AS [Номер клиента], Surname AS Фамилия, Name AS Имя, " +
                " Driver_license AS [Водительское удостоверение], " +
                "Login_client AS Логин, Password_client AS Пароль FROM dbo.Client"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, ClassCar.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Client"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            ClassCar.connection.Close();
        }
    }
}
