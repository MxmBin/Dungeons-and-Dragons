using System;
using System.Windows;
using RestSharp;
using Newtonsoft.Json;
using Dungeons_and_Dragons.Classes;

namespace Dungeons_and_Dragons
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class GameConnectingWindow : Window
    {
        public GameConnectingWindow()
        {
            InitializeComponent();

            GreetingLabel.Content = "Добро пожаловать, " + UserInfo.UserLogin;
            SessionTextBlock.Text = UserInfo.UserSession;

        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            UserInfo.DisconnetcUser();
            AuthorizationWindow authWin = new AuthorizationWindow();
            Close();
            authWin.ShowDialog();
        }

        private void CloseConnection_Button(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CopySession_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(SessionTextBlock.Text);
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("http://localhost:8080/");
            var request = new RestRequest();
            request.RequestFormat = RestSharp.DataFormat.Json;

            UserAccount usrAcc = new UserAccount();
            usrAcc.auth.login = UserInfo.UserLogin;
            usrAcc.auth.session = UserInfo.UserSession;
            request = new RestRequest("newGame", Method.POST);
            request.AddJsonBody(usrAcc);

            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var serverResponse = JsonConvert.DeserializeObject<ServerResponseNewGame>(response.Content);
                UserInfo.UserGame = serverResponse.game;
                MainMenu mainMenu = new MainMenu();
                Close();
                mainMenu.ShowDialog();
            }
        }

        private void GameConnectingButton_Click(object sender, RoutedEventArgs e)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("http://localhost:8080/");
            var request = new RestRequest();
            request.RequestFormat = RestSharp.DataFormat.Json;

            UserAccount usrAcc = new UserAccount();
            usrAcc.auth.login = UserInfo.UserLogin;
            usrAcc.auth.session = UserInfo.UserSession;
            usrAcc.game = GameKey.Text;
            usrAcc.hero = 1; // Надо будет менять

            request = new RestRequest("connect", Method.POST);
            request.AddJsonBody(usrAcc);

            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                HeroClass hero = new HeroClass();
                hero = JsonConvert.DeserializeObject<HeroClass>(response.Content);
                UserInfo.UserGame = usrAcc.game;
                MainMenu mainMenu = new MainMenu(hero);
                Close();
                mainMenu.ShowDialog();
            }
            else
            {
                MessageBox.Show(response.Content);
            }
        }
    }
}
