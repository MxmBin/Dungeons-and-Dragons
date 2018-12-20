using Newtonsoft.Json;
using RestSharp;
using System.Windows;
using System.Windows.Controls;

namespace Dungeons_and_Dragons
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class GameConnectingWindow : Window
    {
        ServerResponse heroesResponse, gamesResponse;

        public GameConnectingWindow()
        {
            InitializeComponent();

            GreetingLabel.Content = "Добро пожаловать, " + UserInfo.UserLogin;
            ClientClass client = new ClientClass();
            IRestResponse response = client.heroList(UserInfo.UserLogin, UserInfo.UserSession);
            if (response.IsSuccessful) 
            {
                heroesResponse = JsonConvert.DeserializeObject<ServerResponse>(response.Content);
                if (heroesResponse.heroes != null)
                {
                    bool firstItem = true;
                    foreach (Heroes hero in heroesResponse.heroes)
                    {
                        ListBoxItem item = new ListBoxItem();
                        item.Content = hero.name;
                        if (firstItem)
                        {
                            item.IsSelected = true;
                        }
                        heroID.Items.Add(item);
                        firstItem = false;
                    }
                }              
            }
            else
            {
                MessageBox.Show(response.Content);
            }

            client = new ClientClass();
            IRestResponse responseGames = client.Games(UserInfo.UserLogin, UserInfo.UserSession);
            if (responseGames.IsSuccessful)
            {
                gamesResponse = JsonConvert.DeserializeObject<ServerResponse>(responseGames.Content);
                if (gamesResponse.games != null)
                {
                    foreach (var game in gamesResponse.games)
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Content = game.Key;
                        AllGames.Items.Add(item);
                    }
                }
            }
            else
            {
                MessageBox.Show(responseGames.Content);
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

        private void AllGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = ((sender as ComboBox).SelectedItem as ComboBoxItem);
            GameKey.Text = cbi.Content.ToString();
        }

        private void CreateHero_Click(object sender, RoutedEventArgs e)
        {
            CreateHero creHero = new CreateHero();
            Close();
            creHero.ShowDialog();
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
