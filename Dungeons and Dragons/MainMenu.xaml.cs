using System;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using RestSharp;
using System.Threading;
using System.ComponentModel;

namespace Dungeons_and_Dragons
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary> 

    public partial class MainMenu : Window
    {
        private static HeroCard Hero = new HeroCard();
        Thread FPS;
        public static Main charMain = new Main(Hero);
        public static Status charStatus = new Status(Hero);
        public static Inventory charInv = new Inventory();
        public static Skills charSkills = new Skills();

        public static void GetHero()
        {
            ClientClass client = new ClientClass();
            IRestResponse responseHero = client.Hero(UserInfo.UserLogin, UserInfo.UserSession, UserInfo.UserGame);
            while (responseHero.IsSuccessful)
            {
                ServerResponse serverResponseHero = JsonConvert.DeserializeObject<ServerResponse>(responseHero.Content);
                Hero = serverResponseHero.hero;
                BackgroundWorker bgW = new BackgroundWorker();
                bgW.DoWork += ListViewMenu_Update;
                Thread.Sleep(150);
                responseHero = client.Hero(UserInfo.UserLogin, UserInfo.UserSession, UserInfo.UserGame);
            }
            MessageBox.Show(responseHero.Content);
        }

        static void ListViewMenu_Update(object sender, DoWorkEventArgs e)
        {
            charMain = new Main(Hero);
            charStatus = new Status(Hero);
        }

        public MainMenu(HeroCard hero)
        {    
            InitializeComponent();

            Hero = hero;
            UserLoginTextBlock.Text = UserInfo.UserLogin;
            charMain = new Main(Hero);
            charStatus = new Status(Hero);
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
                case "Main":
                    GridMain.Children.Add(charMain);
                    break;
                case "Status":
                    GridMain.Children.Add(charStatus);
                    break;
                case "Inventory":
                    GridMain.Children.Add(charInv);
                    break;
                case "Skills":
                    GridMain.Children.Add(charSkills);
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
