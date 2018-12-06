using System;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using RestSharp;
using System.Threading;
using Dungeons_and_Dragons.Classes;

namespace Dungeons_and_Dragons
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary> 

    public partial class MainMenu : Window
    {
        private static HeroCard Hero = new HeroCard();
        Thread FPS;
        Main charMain = new Main(Hero);
        Inventory charInv = new Inventory();

        public static void GetHero()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("http://localhost:8080/");
            var request = new RestRequest();
            request.RequestFormat = RestSharp.DataFormat.Json;

            request = new RestRequest(UserInfo.UserGame + "/Hero", Method.GET);
            request.AddParameter("login", UserInfo.UserLogin);
            request.AddParameter("session", UserInfo.UserSession);

            
            IRestResponse response = client.Execute(request);

            while (response.IsSuccessful)
            {
                Hero = JsonConvert.DeserializeObject<HeroCard>(response.Content);               
                Thread.Sleep(150);
                response = client.Execute(request);
            }
            MessageBox.Show(response.Content);
        }

        public MainMenu(HeroCard hero)
        {    
            InitializeComponent();

            Hero = hero;
            UserLoginTextBlock.Text = UserInfo.UserLogin;
            charMain = new Main(Hero);

            GridMain.Children.Add(charMain);
            FPS = new Thread(new ThreadStart(GetHero));
            FPS.Start();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    GridMain.Children.Add(charMain);
                    break;
                case "ItemCreate":
                    GridMain.Children.Add(charInv);
                    break;
                default:
                    break;
            }
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            Settings settWin = new Settings();
            settWin.ShowDialog();
        }

        private void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("http://localhost:8080/");
            var request = new RestRequest();
            request.RequestFormat = RestSharp.DataFormat.Json;

            Request.UserAccount usrAcc = new Request.UserAccount();            
            usrAcc.auth.login = UserInfo.UserLogin;
            usrAcc.auth.session = UserInfo.UserSession;

            request = new RestRequest("connect", Method.DELETE);
            request.AddJsonBody(usrAcc);

            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                FPS.Abort();
                UserInfo.UserGame = "";
                GameConnectingWindow connWin = new GameConnectingWindow();
                Close();
                connWin.ShowDialog();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            FPS.Abort();
            Application.Current.Shutdown();
        }
    }
}
