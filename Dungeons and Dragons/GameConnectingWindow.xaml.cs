using System;
using System.Windows;
using System.Windows.Controls;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Dungeons_and_Dragons
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class GameConnectingWindow : Window
    {
        ServerResponse heroesResponse;

        public GameConnectingWindow()
        {
            InitializeComponent();

            GreetingLabel.Content = "Добро пожаловать, " + UserInfo.UserLogin;
            ClientClass client = new ClientClass();
            IRestResponse response = client.heroList(UserInfo.UserLogin, UserInfo.UserSession);
            if(response.IsSuccessful)
            {
                MessageBox.Show(response.Content);
                heroesResponse = JsonConvert.DeserializeObject<ServerResponse>(response.Content);
                foreach (Heroes hero in heroesResponse.heroes)
                {
                    ListBoxItem item = new ListBoxItem();
                    item.Content = hero.name;
                    heroID.Items.Add(item);
                }
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
            UserInfo.UserGame = GameKey.Text;

            User user = new User();
            user.Login = UserInfo.UserLogin;
            user.Session = UserInfo.UserSession;
            user.Game = UserInfo.UserGame;
            ClientClass client = new ClientClass(); // Посылаем запрос connect

            IRestResponse responseConnect = client.Connect(user, UserInfo.UserHero);
            if (responseConnect.IsSuccessful)
            {
                ServerResponse serverResponse = JsonConvert.DeserializeObject<ServerResponse>(responseConnect.Content);
                HeroCard hero = new HeroCard();
                hero = serverResponse.hero;
                MainMenu mainMenu = new MainMenu(hero);
                Close();
                mainMenu.ShowDialog();
            }
            else
            {
                MessageBox.Show(responseConnect.Content);
            }
        }

        private void Hero_Select(object sender, SelectionChangedEventArgs args)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            foreach (Heroes hero in heroesResponse.heroes)
            {
                if (hero.name == lbi.Content.ToString())
                {
                    UserInfo.UserHero = hero.id;
                }
            }
        }
    }
}
