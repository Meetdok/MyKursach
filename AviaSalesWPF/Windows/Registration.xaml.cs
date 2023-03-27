﻿using AviaSalesWPF.Tools;
using AviaSalesWPF.ViewModels;
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
using System.Windows.Shapes;
using WebAviaSalesProject.Models;

namespace AviaSalesWPF.Windows
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();           
        }
       
        private void Back(object sender, MouseButtonEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private async void Register(object sender, RoutedEventArgs e)
        {
            var json = await HttpApi.GetInstance().PostSave("Users", "SaveUser", new User { FirstName = txt_Name.Text, LastName = txt_LastName.Text, PatronomycName = txt_PatronomycName.Text,
            PhoneNumber = long.Parse(txt_Phone.Text), Mail = txt_Email.Text, Login = txt_Login.Text, Password = txt_Password.Text, PostId = 4});
            User result = HttpApi.GetInstance().Deserialize<User>(json);

            MessageBox.Show("Сохранилось");

            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
           

        }
    }
}
