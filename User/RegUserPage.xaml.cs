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
using System.Windows.Media.Animation;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;

namespace _1mxblack
{
    /// <summary>
    /// Логика взаимодействия для RegUserPage.xaml
    /// </summary>
    public partial class RegUserPage : Page
    {
        public RegUserPage()
        {
            InitializeComponent();
            DoubleAnimation buttonAnimation = new DoubleAnimation();
            buttonAnimation.From = 0;
            buttonAnimation.To = 400;
            buttonAnimation.Duration = TimeSpan.FromSeconds(2);
            regbutton.BeginAnimation(Button.WidthProperty, buttonAnimation);
        }
        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            if (tbsname.Text == "" || tbname.Text == "" ||tDriverlicense.Text == "" || tblogin.Text == "" || password.Password == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля!!!");
            }
            else
            {
                try
                {
                    ClassCar.connection.Open();
                    string registration = "insert into Client VALUES(@Surname_value, @Name_value, @Driver_license_value, @login_value, @passwd_value )";
                    SqlCommand cmd = new SqlCommand(registration, ClassCar.connection);
                    SqlParameter Surname_param = new SqlParameter("@Surname_value", tbsname.Text);
                    cmd.Parameters.Add(Surname_param);
                    SqlParameter Name_param = new SqlParameter("@Name_value", tbname.Text);
                    cmd.Parameters.Add(Name_param);
                    SqlParameter Driver_license_param = new SqlParameter("@Driver_license_value", tDriverlicense.Text);
                    cmd.Parameters.Add(Driver_license_param);
                    SqlParameter login_param = new SqlParameter("@login_value", tblogin.Text);
                    cmd.Parameters.Add(login_param);
                    SqlParameter passwd_param = new SqlParameter("@passwd_value", password.Password);
                    cmd.Parameters.Add(passwd_param);
                    if (password.Password.Length < 5)
                    {
                        MessageBox.Show("Пароль не может быть меньше 5 символов!!!");
                    }
                    else
                    {
                        int symbols_count = 0;
                        for (int i = 0; i < password.Password.Length; i++) // перебираем символы
                        {
                            if (password.Password[i] >= 'A' || password.Password[i] <= 'Z' || password.Password[i] >= '0' || password.Password[i] <= '9')
                                symbols_count++;  // если русская раскладка
                        }
                        if (symbols_count < password.Password.Length)
                        {
                            MessageBox.Show("Пароль должен состоять только из английских букв и/или цифр!!!");
                        }
                        else
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Пользователь зарегистрирован!!!");
                            ClassCar.MainFrame.GoBack();
                        }
                    }

                }
                catch (SqlException er)
                {

                    MessageBox.Show(er.Number + " " + er.Message);
                }
                ClassCar.connection.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClassCar.MainFrame.Navigate(new AuthUserPage());

        }
    }
}
