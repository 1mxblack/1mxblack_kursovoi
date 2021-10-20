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
using System.Windows.Media.Animation;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;

namespace _1mxblack
{
    /// <summary>
    /// Логика взаимодействия для AuthUserPage.xaml
    /// </summary>
    public partial class AuthUserPage : Page
    {
        public AuthUserPage()
        {
            InitializeComponent();
            DoubleAnimation buttonAnimation = new DoubleAnimation();
            buttonAnimation.From = 0;
            buttonAnimation.To = 450;
            buttonAnimation.Duration = TimeSpan.FromSeconds(2);
            authbutton.BeginAnimation(Button.WidthProperty, buttonAnimation);
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            if (tblogin.Text.Length > 0) // проверяем введён ли логин     
            {
                if (bpass.Password.Length > 0) // проверяем введён ли пароль         
                {             // ищем в базе данных пользователя с такими данными  
                    ClassCar.connection.Open();
                    string authorization = String.Format("SELECT Client_id, Login_client, Password_client FROM [dbo].[Client] WHERE [Login_client] = @login_value AND [Password_client] = @passwd_value");
                    SqlCommand command = new SqlCommand(authorization, ClassCar.connection);
                    SqlParameter login_param = new SqlParameter("@login_value", tblogin.Text);
                    command.Parameters.Add(login_param);
                    SqlParameter passwd_param = new SqlParameter("@passwd_value", bpass.Password);
                    command.Parameters.Add(passwd_param);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ClassCar.myId = Convert.ToInt32(reader.GetValue(0));
                    }
                    if (reader.HasRows) // если такая запись существует       
                    {
                        ClassCar.MainFrame.Navigate(new UserMainPage());
                    }

                    else MessageBox.Show("Пользователь не найден"); // выводим ошибку  
                }
                else MessageBox.Show("Введите пароль"); // выводим ошибку    
            }
            else MessageBox.Show("Введите логин"); // выводим ошибку 
            ClassCar.connection.Close();
        }

        private void Button_WinReg_Click(object sender, RoutedEventArgs e)
        {
            ClassCar.MainFrame.Navigate(new RegUserPage());
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            ClassCar.MainFrame.Navigate(new StartPage());
        }
    }
}