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
using _1mxblack.Resources.Admin;

namespace _1mxblack
{
    /// <summary>
    /// Логика взаимодействия для AdminDataAdmin.xaml
    /// </summary>
    public partial class AdminDataAdmin : UserControl
    {
        public AdminDataAdmin()
        {
            InitializeComponent();
        }
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            GridAdmin.Children.Clear();
            GridAdmin.Children.Add(new DataRent());
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
                    string Delete = "DELETE FROM Admin WHERE Id_Admin = (@Id_Admin)";
                    SqlCommand cmd = new SqlCommand(Delete, ClassCar.connection);
                    SqlParameter Delete_param = new SqlParameter("@Id_Admin", Delete_TextBox.Text);
                    cmd.Parameters.Add(Delete_param);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Администратор удален!!!");
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
            string cmd = "SELECT Id_admin AS [Номер администратора], Login_admin AS Логин, Password_admin AS Пароль FROM dbo.Admin"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, ClassCar.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Admin"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            ClassCar.connection.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            GridAdmin.Children.Clear();
            GridAdmin.Children.Add(new AdminSecondPage());
        }
    }
}

