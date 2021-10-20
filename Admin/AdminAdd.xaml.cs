using _1mxblack.Resources.Admin;
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
    /// Логика взаимодействия для AdminAdd.xaml
    /// </summary>
    public partial class AdminAdd : UserControl
    {
        public AdminAdd()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            GridAdminAdd.Children.Clear();
            GridAdminAdd.Children.Add(new AdminSecondPage());
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginAdm_TextBox.Text == "" || PasswordAdm_TextBox.Password == "" )
            {
                MessageBox.Show("Пожалуйста, заполните все поля!!!");
            }
            else
            {
                try
                {
                    ClassCar.connection.Open();
                    string registration = "insert into Administration VALUES(@login_value, @passwd_value )";
                    SqlCommand cmd = new SqlCommand(registration, ClassCar.connection);
                    SqlParameter login_param = new SqlParameter("@login_value", LoginAdm_TextBox.Text);
                    cmd.Parameters.Add(login_param);
                    SqlParameter passwd_param = new SqlParameter("@passwd_value", PasswordAdm_TextBox.Password);
                    cmd.Parameters.Add(passwd_param);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Администратор зарегистрирован!!!");
                    ClassCar.MainFrame.Navigate(new AdminDataAdmin());
                }
                catch (SqlException er)
                {

                    MessageBox.Show(er.Number + " " + er.Message);
                }
                ClassCar.connection.Close();
            }
        }
    }
}
