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
            var client = new RestClient();
            client.BaseUrl = new Uri("http://localhost:8080/");
            var request = new RestRequest();
            request.RequestFormat = RestSharp.DataFormat.Json;

            Request.Auth auth = new Request.Auth();
            auth.login = loginText.Text;
            auth.hash = passText.Password;
            auth.token = "lol";
            request = new RestRequest("reg", Method.POST);
            request.AddJsonBody(auth);

            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                //var serverResponse = JsonConvert.DeserializeObject<ServerResponse>(response.Content);
                Close();
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ResponseStatus);
            }
        }
    }
}
