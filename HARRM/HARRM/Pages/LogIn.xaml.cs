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
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = Singleton.DB.User.FirstOrDefault(u =>
            u.Username == username.Text && u.Password == password.Password);
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;

            if (user == null)
            {
                MessageBox.Show("Неверный логин или пароль");
            }
            else if (password.Password.Length < 6) 
            {
                MessageBox.Show("Минимальная длина пароля 6 символов");
            }
            else
            {
                if (user.RoleID == 1)
                {
                    mainWindow.frame.Navigate(new ManagerApplications());
                }
                else if (user.RoleID == 2)
                {
                    mainWindow.frame.Navigate(new ClientApplications());
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.frame.Navigate(new Registration());
        }
    }
}
