using System;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using RestSharp;
using Dungeons_and_Dragons.Classes;

namespace Dungeons_and_Dragons
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class MainMenu : Window
    {

        Main charMain = new Main();
        Inventory charInv = new Inventory();

        //Классы для создания игры
        public class Pers
        {
            public string login { get; set; }
            public string session { get; set; }

            public Pers(string login, string session)
            {
                this.login = login;
                this.session = session;
            }
        }

        public class Aut
        {
            public Pers auth { get; set; }

            public Aut(string login, string session)
            {
                auth = new Pers(login, session);
            }
        }
        //

        public MainMenu()
        {    
            InitializeComponent();

            UserLoginTextBlock.Text = UserInfo.UserLogin;
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

            UserAccount usrAcc = new UserAccount();
            usrAcc.auth.login = UserInfo.UserLogin;
            usrAcc.auth.session = UserInfo.UserSession;

            request = new RestRequest("connect", Method.DELETE);
            request.AddJsonBody(usrAcc);

            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                UserInfo.UserGame = "";
                GameConnectingWindow connWin = new GameConnectingWindow();
                Close();
                connWin.ShowDialog();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
