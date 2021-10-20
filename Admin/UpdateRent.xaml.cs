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

namespace _1mxblack.Resources.Admin
{
    /// <summary>
    /// Логика взаимодействия для UpdateRent.xaml
    /// </summary>
    public partial class UpdateRent : UserControl
    {
        public UpdateRent()
        {
            InitializeComponent();
        }
        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if (Client_id_TextBox.Text == "" || Car_id_TextBox.Text == "" || Date_start.DisplayDate == null || Date_end.DisplayDate == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля!!!");
            }
            else
            {
                try
                {
                    if (true)
                    {
                        ClassCar.connection.Open();
                        string registration = "UPDATE Rent SET Client_id = @Client_id_value, Id_car = @Id_car_value,  Date_end = @Date_end_value, Date_start = @Date_start_value WHERE (Rent_id = @ID_value)";
                        SqlCommand cmd = new SqlCommand(registration, ClassCar.connection);
                        SqlParameter ID_param = new SqlParameter("@ID_value", Id_TextBox.Text);
                        cmd.Parameters.Add(ID_param);
                        SqlParameter Client_id_param = new SqlParameter("@Client_id_value", Client_id_TextBox.Text);
                        cmd.Parameters.Add(Client_id_param);
                        SqlParameter Id_car_param = new SqlParameter("@Id_car_value", Car_id_TextBox.Text);
                        cmd.Parameters.Add(Id_car_param);
                        SqlParameter Date_start_param = new SqlParameter("@Date_start_value", Date_start.SelectedDate);
                        cmd.Parameters.Add(Date_start_param);
                        if (Date_start.SelectedDate.Value > Date_end.SelectedDate.Value)
                        {
                            MessageBox.Show("Дата начала проката не может быть больше даты окончания проката");
                        }
                        else
                        {
                            SqlParameter Date_end_param = new SqlParameter("@Date_end_value", Date_end.SelectedDate);
                            cmd.Parameters.Add(Date_end_param);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Прокат зарегистрирован!!!");
                            ClassCar.MainFrame.Navigate(new DataRent());
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

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            GridUpdateRent.Children.Clear();
            GridUpdateRent.Children.Add(new DataRent());
        }
    }
}
