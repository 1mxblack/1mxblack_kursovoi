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
using System.IO;

namespace _1mxblack.Resources.Admin
{
    /// <summary>
    /// Логика взаимодействия для AddRent.xaml
    /// </summary>
    public partial class AddRent : UserControl
    {
        public AddRent()
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
                        string registration = "insert into Rent VALUES(@Client_id_value, @Id_car_value, @Date_start_value, @Date_end_value)";
                        SqlCommand cmd = new SqlCommand(registration, ClassCar.connection);
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
                            MessageBox.Show(Date_start.SelectedDate.ToString() + " " + Date_end.SelectedDate.ToString());
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Прокат зарегистрирован!!!");
                            string fileName = System.IO.Path.Combine(Environment.CurrentDirectory, "rent.txt");
                            DirectoryInfo dirInfo = new DirectoryInfo(fileName);
                            using (StreamWriter sw = new StreamWriter(fileName, true, System.Text.Encoding.Default))
                            {
                                sw.WriteLineAsync("Номер клиента");
                                sw.WriteLine(Client_id_TextBox.Text.ToString());
                                sw.WriteLineAsync("Номер автомобиля");
                                sw.WriteLine(Car_id_TextBox.Text.ToString());
                                sw.WriteLineAsync("Дата начала проката");
                                sw.WriteLine(Date_start.SelectedDate.ToString());
                                sw.WriteLineAsync("Дата окончания проката");
                                sw.WriteLine(Date_end.SelectedDate.ToString());
                            }

                            MessageBox.Show("Данные о прокате записаны в файл");
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
            GridRent.Children.Clear();
            GridRent.Children.Add(new DataRent());
        }
    }
}
