using RestSharp;
using System.Windows;

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
            Close();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {            
            string login = loginText.Text;
            string pass = passText.Password;
            string token = "";
            if (GMRadio.IsChecked.Value)
            {
                token = "lol";  //Выяснить про токен
            }          

            ClientClass client = new ClientClass();
            IRestResponse response = client.Registration(login, pass, token);
            if (response.IsSuccessful)
            {                
                Close();
                if (PlayerRadio.IsChecked.Value)
                {
                    MessageBox.Show("Регистрация игрока прошла успешно");
                }
                else
                {
                    MessageBox.Show("Регистрация гейм мастера прошла успешно");
                }               
            }
            else
            {
                MessageBox.Show(response.Content);
            }
        }
    }
}
