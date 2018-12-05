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
using RestSharp;
using Dungeons_and_Dragons.Classes;
using Newtonsoft.Json;

namespace Dungeons_and_Dragons
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void CloseRegistration_Button(object sender, RoutedEventArgs e)
        {         
            this.Close();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {            
            string login = loginText.Text;
            string pass = passText.Password;
            string token = "lol";

            ClientClass client = new ClientClass();
            IRestResponse response = client.Registration(login, pass, token);
            if (response.IsSuccessful)
            {
                MessageBox.Show("Регистрация прошла успешно");
                Close();
            }
            else
            {
                MessageBox.Show(response.Content);
            }
        }
    }
}
