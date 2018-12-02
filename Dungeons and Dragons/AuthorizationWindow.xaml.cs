using System;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Serializers;
using Dungeons_and_Dragons.Classes;

namespace Dungeons_and_Dragons
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void Authorization_Button(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();
            auth.login = loginText.Text;
            string pass = passText.Password;
            Md5Hash md5 = new Md5Hash();
            //Получение хеша
            auth.hash = md5.GetHash(pass);

            //Отправка запроса на логирование
            var client = new RestClient();
            client.BaseUrl = new Uri("http://localhost:8080/");
            var request = new RestRequest();
            request.RequestFormat = RestSharp.DataFormat.Json;

            request = new RestRequest("auth", Method.POST);
            request.AddJsonBody(auth);

            IRestResponse response = client.Execute(request);         
            if (response.IsSuccessful)
            {
                // Запоминаем инфу юзера
                var serverResponse = JsonConvert.DeserializeObject<ServerResponse>(response.Content);
                UserInfo.UserLogin = auth.login;
                UserInfo.UserSession = serverResponse.response;

                // Проверка на реконнект
                var client1 = new RestClient();
                client1.BaseUrl = new Uri("http://localhost:8080/");
                var request1 = new RestRequest();
                request.RequestFormat = RestSharp.DataFormat.Json;

                UserAccount usrAcc = new UserAccount();
                usrAcc.auth.login = UserInfo.UserLogin;
                usrAcc.auth.session = UserInfo.UserSession;
                //usrAcc.game = "";
                //usrAcc.hero = 0; // Надо будет менять

                request = new RestRequest("connect", Method.POST);
                request.AddJsonBody(usrAcc);

                IRestResponse response1 = client.Execute(request);
                if (response1.IsSuccessful)
                {
                    // Переподключаемся к существующей игре
                    HeroClass hero = new HeroClass();
                    hero = JsonConvert.DeserializeObject<HeroClass>(response1.Content);
                    MainMenu mainMenuWin = new MainMenu(hero);
                    Close();
                    mainMenuWin.ShowDialog();
                }
                else
                {
                    // Игры не существует
                    GameConnectingWindow gameConnectingWindow = new GameConnectingWindow();
                    Close();
                    gameConnectingWindow.ShowDialog();
                }             
            }
            else
            {
                // Ошибка авторизации
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ResponseStatus);
            }
        }

        private void Registration_Button(object sender, RoutedEventArgs e)
        {
            RegistrationWindow RegWin = new RegistrationWindow();
            this.Visibility = Visibility.Collapsed;
            RegWin.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void CloseAutharization_Button(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
