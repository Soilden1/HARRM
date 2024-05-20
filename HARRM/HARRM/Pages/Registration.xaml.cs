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

namespace HARRM.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.frame.Navigate(new LogIn());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (username.Text == "" || password.Password == "" || confirmPassword.Password == "")
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }

            if (password.Password != confirmPassword.Password)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            if (password.Password.Length < 6)
            {
                MessageBox.Show("Минимальная длина пароля должна составлять не менее 6 символов");
            }

            int roleInt = 0;
            if (role.IsChecked == true) 
            {
                roleInt = 1;
            }
            else
            {
                roleInt = 2;
            }
           
            Singleton.DB.User.Add(new User()
            {
                Username = username.Text,
                Password = password.Password,
                RoleID = roleInt

            });
            Singleton.DB.SaveChanges();
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (roleInt == 1)
            {
                mainWindow.frame.Navigate(new ManagerApplications());
            }
            else
            {
                mainWindow.frame.Navigate(new ClientApplications());
            }
        }
    }
}
