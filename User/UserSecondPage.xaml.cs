using _1mxblack.Resources.User;
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

namespace _1mxblack
{
    /// <summary>
    /// Логика взаимодействия для UserSecondPage.xaml
    /// </summary>
    public partial class UserSecondPage : UserControl
    {
        public UserSecondPage()
        {
            InitializeComponent();
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            ClassCar.MainFrame.Navigate(new StartPage());
        }

        private void Button_Edit_User(object sender, RoutedEventArgs e)
        {
            GridPersonalPage.Children.Clear();
            GridPersonalPage.Children.Add(new UserUpdate());
        }

        private void Button_MyCar_User(object sender, RoutedEventArgs e)
        {
            GridPersonalPage.Children.Clear();
            GridPersonalPage.Children.Add(new MyCar());
        }
    }
}
