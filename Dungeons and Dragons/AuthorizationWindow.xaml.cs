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
            string login = loginText.Text;
            string pass = passText.Password;

            ClientClass client = new ClientClass();
            IRestResponse response = client.Authorization(login, pass);
            if (response.IsSuccessful)
            {
                // Запоминаем инфу юзера
                ServerResponse.ServerResponseAuth serverResponse = JsonConvert.DeserializeObject<ServerResponse.ServerResponseAuth>(response.Content);
                UserInfo.UserLogin = login;
                UserInfo.UserRole = serverResponse.role;
                UserInfo.UserSession = serverResponse.session;

                // Поменять на case выборку роли
                if (UserInfo.UserRole == 1)
                {
                    GmConnect gmConnectWin = new GmConnect();
                    Close();
                    gmConnectWin.ShowDialog();
                }
                else
                {
                    // Проверка на реконнект
                    var client1 = new RestClient();
                    client1.BaseUrl = new Uri("http://localhost:8080/");
                    var request1 = new RestRequest();
                    request1.RequestFormat = RestSharp.DataFormat.Json;

                    Request.UserAccount usrAcc = new Request.UserAccount();
                    usrAcc.auth.login = UserInfo.UserLogin;
                    usrAcc.auth.session = UserInfo.UserSession;

                    request1 = new RestRequest("connect", Method.POST);
                    request1.AddJsonBody(usrAcc);

                    IRestResponse response1 = client1.Execute(request1);
                    if (response1.IsSuccessful)
                    {
                        MessageBox.Show(response1.Content);
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
            }
            else
            {
                // Ошибка авторизации
                MessageBox.Show(response.Content);
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
