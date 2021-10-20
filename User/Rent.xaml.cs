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
using System.Data.Sql;
using System.IO;

namespace _1mxblack
{
    /// <summary>
    /// Логика взаимодействия для Rent.xaml
    /// </summary>
    public partial class Rent : UserControl
    {
        public Rent()
        {
            InitializeComponent();
        }
        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if (Car_id_TextBox.Text == "" || Date_start.DisplayDate == null || Date_end.DisplayDate == null)
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
                        string cmd = String.Format("insert into Rent VALUES(@myID, @Car_id_value, @Date_start_value, @Date_end_value)");
                        SqlCommand command = new SqlCommand(cmd, ClassCar.connection);
                        command.Parameters.Add("@myID", SqlDbType.Int);
                        command.Parameters["@myID"].Value = ClassCar.myId;
                        SqlParameter Car_id_param = new SqlParameter("@Car_id_value", Car_id_TextBox.Text);
                        command.Parameters.Add(Car_id_param);
                        SqlParameter Date_start_param = new SqlParameter("@Date_start_value", Date_start.SelectedDate);
                        command.Parameters.Add(Date_start_param);
                        string select = "Select @Price_Day AS [Стоимость в день] FROM Cars WHERE Car_id = @Car_id_value";
                        SqlParameter Price_Day_param = new SqlParameter("@Price_Day", select);
                        if (Date_start.SelectedDate.Value > Date_end.SelectedDate.Value)
                        {
                            MessageBox.Show("Дата начала проката не может быть больше даты окончания проката");
                        }
                        else
                        {
                            SqlParameter Date_end_param = new SqlParameter("@Date_end_value", Date_end.SelectedDate);
                            command.Parameters.Add(Date_end_param);
                            MessageBox.Show(Date_start.SelectedDate.ToString() + " " + Date_end.SelectedDate.ToString());
                            command.ExecuteNonQuery();
                            MessageBox.Show("Прокат зарегистрирован!!!");
                            string fileName = System.IO.Path.Combine(Environment.CurrentDirectory, "Мои машины");
                            DirectoryInfo dirInfo = new DirectoryInfo(fileName);
                            using (StreamWriter sw = new StreamWriter(fileName, true, System.Text.Encoding.Default))
                            {
                                sw.WriteLineAsync("\n\n");
                                sw.WriteLineAsync("Номер Клиента");
                                sw.WriteLine(ClassCar.myId.ToString());
                                sw.WriteLineAsync("Номер автомобиля");
                                sw.WriteLine(Car_id_TextBox.Text.ToString());
                                sw.WriteLineAsync("Дата начала проката");
                                sw.WriteLine(Date_start.SelectedDate.ToString());
                                sw.WriteLineAsync("Дата окончания проката");
                                sw.WriteLine(Date_end.SelectedDate.ToString());
                            }
                            MessageBox.Show("Данные о прокате были записаны в раздел 'Мои машины'");
                            ClassCar.MainFrame.Navigate(new UserMainPage());
                        }
                    }
                }
                catch
                {

                    MessageBox.Show("Данные введены некорректно");
                }
                ClassCar.connection.Close();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            GridRent.Children.Clear();
            GridRent.Children.Add(new CarPage());
        }
    }
}
