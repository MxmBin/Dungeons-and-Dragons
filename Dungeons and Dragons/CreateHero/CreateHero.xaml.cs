using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RestSharp;

namespace Dungeons_and_Dragons
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class CreateHero : Window
    {
        CreateMain creMain;
        CreateStatus creStatus;
        ReqHero Hero = new ReqHero();

        public CreateHero()
        {
            InitializeComponent();

            creMain = new CreateMain(ref Hero);
            creStatus = new CreateStatus();
            GridMain.Children.Add(creMain);
        }

        private void CloseCreate_Click(object sender, RoutedEventArgs e)
        {
            GameConnectingWindow connWin = new GameConnectingWindow();
            Close();
            connWin.Show();
        }

        private void CreateMain_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            GridMain.Children.Add(creMain);
        }

        private void CreateStatus_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            GridMain.Children.Add(creStatus);
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            ClientClass client = new ClientClass();
            IRestResponse response = client.newHero(UserInfo.UserLogin, UserInfo.UserSession, Hero);
            if (response.IsSuccessful)
            {
                MessageBox.Show(response.Content);
                GameConnectingWindow connWin = new GameConnectingWindow();
                Close();
                connWin.Show();
            }
            else
            {
                MessageBox.Show(response.Content);
            }
        }
    }
}
