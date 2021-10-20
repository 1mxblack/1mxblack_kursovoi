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
    /// Логика взаимодействия для UpdateUser.xaml
    /// </summary>
    public partial class UpdateUser : UserControl
    {
        public UpdateUser()
        {
            InitializeComponent();
        }
        private void UpdteButton_Click(object sender, RoutedEventArgs e)
        {
            if (Surname_TextBox.Text == "" || Surname_TextBox.Text == "" || Name_TextBox.Text == "" || Email_TextBox.Text == "" || Driver_license_TextBox.Text == "" || textBox_login.Text == "" || password.Password == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля для регистрации!!!");
            }
            else
            {
                try
                {
                    ClassCar.connection.Open();
                    string registration = "Update Client SET Surname = @Surname_value, Name = @Name_value,Email_client = @Email_client_value , Driver_license = @Driver_license_value, Login_client = @Login_value, Password_client = @passwd_value WHERE (Client_id = @ID_value)";
                    SqlCommand cmd = new SqlCommand(registration, ClassCar.connection);
                    SqlParameter ID_param = new SqlParameter("@ID_value", Id_TextBox.Text);
                    cmd.Parameters.Add(ID_param);
                    SqlParameter Surname_param = new SqlParameter("@Surname_value", Surname_TextBox.Text);
                    cmd.Parameters.Add(Surname_param);
                    SqlParameter Name_param = new SqlParameter("@Name_value", Name_TextBox.Text);
                    cmd.Parameters.Add(Name_param);
                    SqlParameter Email_param = new SqlParameter("@Email_client_value", Email_TextBox.Text);
                    cmd.Parameters.Add(Email_param);
                    SqlParameter Driver_license_param = new SqlParameter("@Driver_license_value", Driver_license_TextBox.Text);
                    cmd.Parameters.Add(Driver_license_param);
                    SqlParameter login_param = new SqlParameter("@Login_value", textBox_login.Text);
                    cmd.Parameters.Add(login_param);
                    SqlParameter passwd_param = new SqlParameter("@passwd_value", password.Password);
                    cmd.Parameters.Add(passwd_param);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные обновлены!!!");
                    GridAdminDataUser.Children.Clear();
                    GridAdminDataUser.Children.Add(new AdminDataUser());
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
            GridAdminDataUser.Children.Add(new AdminDataUser());
        }
    }
}
