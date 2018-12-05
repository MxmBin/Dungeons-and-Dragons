using System;
using System.Windows;
using System.Windows.Controls;
using RestSharp;
using Newtonsoft.Json;

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
            ClientClass client = new ClientClass();
            IRestResponse response = client.heroList(UserInfo.UserLogin, UserInfo.UserSession);
            if(response.IsSuccessful)
            {
                MessageBox.Show(response.Content);
                ServerResponse serverResponse = JsonConvert.DeserializeObject<ServerResponse>(response.Content);

            }           
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

        private void GameConnectingButton_Click(object sender, RoutedEventArgs e)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("http://localhost:8080/");
            var request = new RestRequest();
            request.RequestFormat = RestSharp.DataFormat.Json;

            Request.UserAccount usrAcc = new Request.UserAccount();
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

        private void Hero_Select(object sender, SelectionChangedEventArgs args)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            //UserInfo.UserHero = (int)lbi.Content;

        }
    }
}
