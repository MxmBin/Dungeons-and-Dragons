using RestSharp;
using System.Windows;
using System.Windows.Controls;

namespace Dungeons_and_Dragons
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary> 

    public partial class MainMenu : Window
    {
        static ReqHero Hero = new ReqHero();
        public static Main charMain = new Main(ref Hero);
        public static Status charStatus = new Status(ref Hero);
        public static Inventory charInv = new Inventory(ref Hero);
        public static Skills charSkills = new Skills(ref Hero);


        public MainMenu(HeroCard hero)
        {    
            InitializeComponent();

            Hero.hero = hero;
            UserLoginTextBlock.Text = UserInfo.UserLogin;
            charMain = new Main(ref Hero);
            charStatus = new Status(ref Hero);
            charInv = new Inventory(ref Hero);
            charSkills = new Skills(ref Hero);
            GridMain.Children.Add(charMain);
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
            ClientClass client = new ClientClass();
            IRestResponse response = client.DelConnect(UserInfo.UserLogin, UserInfo.UserSession);
            if (response.IsSuccessful)
            {
                UserInfo.UserGame = "";
                GameConnectingWindow connWin = new GameConnectingWindow();
                Close();
                connWin.ShowDialog();
            }
            else
            {
                MessageBox.Show(response.Content);
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            ClientClass client = new ClientClass();
            IRestResponse response = client.DelConnect(UserInfo.UserLogin, UserInfo.UserSession);
            if (response.IsSuccessful)
            {
                //FPS.Abort();
                Application.Current.Shutdown();
            }
            else
            {
                //FPS.Abort();
                MessageBox.Show(response.Content);
                Application.Current.Shutdown();
            }
        }

        private void Manual_Click(object sender, RoutedEventArgs e)
        {
            ManualWin manWin = new ManualWin();
            manWin.ShowDialog();
        }
    }
}
