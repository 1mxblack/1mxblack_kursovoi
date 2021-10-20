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
    /// Логика взаимодействия для SecondAdminPage.xaml
    /// </summary>
    public partial class AdminSecondPage : UserControl
    {
        public AdminSecondPage()
        {
            InitializeComponent();
        }

        private void Button_Edit_Admin(object sender, RoutedEventArgs e)
        {
            GridAdmin.Children.Clear();
            GridAdmin.Children.Add(new AdminDataAdmin());
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            ClassCar.MainFrame.Navigate(new StartPage());
        }

        private void Button_Plus_Admin(object sender, RoutedEventArgs e)
        {
            GridAdmin.Children.Clear();
            GridAdmin.Children.Add(new AdminAdd());
        }
    }
}
