using Newtonsoft.Json;
using RestSharp;
using System.Windows;

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

            // Посылаем запрос auth
            ClientClass client = new ClientClass();
            IRestResponse response = client.Authorization(login, pass);
            if (response.IsSuccessful)
            {
                ClientClass clientManual = new ClientClass();
                IRestResponse responseManual = client.Manual();
                if (responseManual.IsSuccessful)
                {
                    ManualInf.manual = JsonConvert.DeserializeObject<Manual>(responseManual.Content);
                }
                else
                {
                    MessageBox.Show(responseManual.Content);
                }

                // Запоминаем инфу юзера
                ServerResponse serverResponse = JsonConvert.DeserializeObject<ServerResponse>(response.Content);
                UserInfo.UserLogin = login;
                UserInfo.UserRole = serverResponse.role;
                UserInfo.UserSession = serverResponse.session;

                User user = new User();
                user.Login = login;
                user.Session = serverResponse.session;
                ClientClass clientReconnect = new ClientClass(); // Посылаем запрос connect
                IRestResponse responseReconnect = clientReconnect.Connect(user, 0);
                if (responseReconnect.IsSuccessful) // Проверка на реконнект
                {
                    ServerResponse serverResponseReconnect = JsonConvert.DeserializeObject<ServerResponse>(responseReconnect.Content);
                    switch (UserInfo.UserRole)
                    {
                        case 1:                            
                            UserInfo.UserGame = serverResponseReconnect.game;
                            GmConnect gmConnectWin = new GmConnect();
                            Close();
                            gmConnectWin.ShowDialog();
                            break;
                        case 2:
                            HeroCard hero = new HeroCard();
                            UserInfo.UserGame = serverResponseReconnect.game;
                            hero = serverResponseReconnect.hero;
                            MainMenu mainWin = new MainMenu(hero);
                            Close();
                            mainWin.ShowDialog();
                            break;
                    }
                }
                else // Игры не существует
                {
                    switch (UserInfo.UserRole)
                    {
                        case 1:
                            GmConnect gmConnectWin = new GmConnect();
                            Close();
                            gmConnectWin.ShowDialog();
                            break;
                        case 2:
                            GameConnectingWindow connectWin = new GameConnectingWindow();
                            Close();
                            connectWin.ShowDialog();
                            break;
                    }
                }
            }
            else // Ошибка авторизации
            {
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
