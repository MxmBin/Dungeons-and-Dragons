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
        }

        private void CopyKey_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(GameKeyTextBlock.Text);
        }
    }
}
