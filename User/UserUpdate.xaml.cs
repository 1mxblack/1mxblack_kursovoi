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
using System.Data.Sql;

namespace _1mxblack
{
    /// <summary>
    /// Логика взаимодействия для UserUpdate.xaml
    /// </summary>
    public partial class UserUpdate : UserControl
    {
        public UserUpdate()
        {
            InitializeComponent();
        }

        private void UpdteButton_Click(object sender, RoutedEventArgs e)
        {
            if ( Driver_license_TextBox.Text == "" || textBox_login.Text == "" || password.Password == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля для регистрации!!!");
            }
            else
            {
                try
                {
                    ClassCar.connection.Open();
                    string registration = "Update Client SET  Driver_license = @Driver_license_value, Login_client = @Login_value, Password_client = @passwd_value WHERE (Client_id = @myID)";
                    SqlCommand cmd = new SqlCommand(registration, ClassCar.connection);
                    SqlParameter Driver_license_param = new SqlParameter("@Driver_license_value", Driver_license_TextBox.Text);
                    cmd.Parameters.Add(Driver_license_param);
                    SqlParameter login_param = new SqlParameter("@login_value", textBox_login.Text);
                    cmd.Parameters.Add(login_param);
                    SqlParameter passwd_param = new SqlParameter("@passwd_value", password.Password);
                    cmd.Parameters.Add(passwd_param);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные обновлены!!!");
                    ClassCar.MainFrame.Navigate(new UserSecondPage());
                }
                catch (SqlException er)
                {

                    MessageBox.Show(er.Number + " " + er.Message);
                }
                ClassCar.connection.Close();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            GridAdminDataUser.Children.Clear();
            GridAdminDataUser.Children.Add(new UserSecondPage());
        }
    }
}