using Newtonsoft.Json;
using RestSharp;
using System.Windows;

namespace Dungeons_and_Dragons
{
    /// <summary>
    /// Логика взаимодействия для GMConnect.xaml
    /// </summary>
    public partial class GmConnect : Window
    {
        public GmConnect()
        {
            InitializeComponent();

            GreetingText.Text = "Добро пожаловать, " + UserInfo.UserLogin;
        }

        private void CloseAppButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            UserInfo.DisconnetcUser();
            AuthorizationWindow authWin = new AuthorizationWindow();
            Close();
            authWin.ShowDialog();
        }

        private void CreateNewGameButton_Click(object sender, RoutedEventArgs e)
        {
            ClientClass client = new ClientClass();
            IRestResponse response = client.newGame(UserInfo.UserLogin, UserInfo.UserSession);

            if (response.IsSuccessful)
            {
                ServerResponse serverResponse = JsonConvert.DeserializeObject<ServerResponse>(response.Content);
                UserInfo.UserGame = serverResponse.game;
                GmMainMenu gmMainWin = new GmMainMenu();
                Close();
                gmMainWin.ShowDialog();
            }
            else
            {
                MessageBox.Show(response.Content);
            }
        }
    }
}
