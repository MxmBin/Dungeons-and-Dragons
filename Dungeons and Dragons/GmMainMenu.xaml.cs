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
using Newtonsoft.Json;
using System.Threading;

namespace Dungeons_and_Dragons
{
    /// <summary>
    /// Логика взаимодействия для GmMainMenu.xaml
    /// </summary>
    public partial class GmMainMenu : Window
    {
        public GmMainMenu()
        {
            InitializeComponent();

            GameKeyTextBlock.Text = UserInfo.UserGame;

            ClientClass client = new ClientClass();
            IRestResponse response = client.OthersPlayers(UserInfo.UserLogin, UserInfo.UserSession, UserInfo.UserGame);
            if (response.IsSuccessful)
            {
                ServerResponse serverResponse = JsonConvert.DeserializeObject<ServerResponse>(response.Content);
                serverResponse.OtherPlayers.RemoveAt(0);
                if (serverResponse.OtherPlayers != null)
                {
                    foreach (OtherPlayers player in serverResponse.OtherPlayers)
                    {
                        ListBoxItem item = new ListBoxItem();
                        item.Content = player.hero.heroInfo.name + " (" + player.login + ")";
                        PlayerList.Items.Add(item);
                    }
                }
            }
            else
            {
                MessageBox.Show(response.Content);
            }
        }

        private void CopyKey_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(GameKeyTextBlock.Text);        
        }

        private void CloseGmMenuButton_Click(object sender, RoutedEventArgs e)
        {
            ClientClass client = new ClientClass();
            IRestResponse response = client.delGame(UserInfo.UserLogin, UserInfo.UserSession);
            if (response.IsSuccessful)
            {
                Application.Current.Shutdown();
            }        
            else
            {
                MessageBox.Show(response.Content);
            }
        }

        private void LootButton_Click(object sender, RoutedEventArgs e)
        {
            RootObject loot = new RootObject();
            loot.loot.weapons.Add(new RootObject.Weapon { id = 1, count = 1 });
            loot.loot.items.Add(new RootObject.Item { id = 2, count = 1 });
            loot.loot.armors.Add(new RootObject.Armor { id = 1 });
            ClientClass client = new ClientClass();
            IRestResponse response = client.Loot(UserInfo.UserLogin, UserInfo.UserSession, UserInfo.UserGame, loot);
            if (response.IsSuccessful)
            {
                MessageBox.Show(response.Content);
            }
            else
            {
                MessageBox.Show(response.Content);
            }
        }

        private void DeleteLootButton_Click(object sender, RoutedEventArgs e)
        {
            ClientClass client = new ClientClass();
            IRestResponse response = client.DelLoot(UserInfo.UserLogin, UserInfo.UserSession, UserInfo.UserGame);
            if (response.IsSuccessful)
            {
                MessageBox.Show(response.Content);
            }
            else
            {
                MessageBox.Show(response.Content);
            }
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authWin = new AuthorizationWindow();
            Close();
            authWin.Show();
        }
    }
}
