﻿using System;
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
    /// Логика взаимодействия для ClientApplications.xaml
    /// </summary>
    public partial class ClientApplications : Page
    {
        public ClientApplications()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.frame.Navigate(new LogIn());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Singleton.DB.RepairApplication.ToList();
            table.ItemsSource = Singleton.DB.RepairApplication.Local;
        }
    }
}
