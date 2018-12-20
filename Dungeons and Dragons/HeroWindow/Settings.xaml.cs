using System.Windows;

namespace Dungeons_and_Dragons
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();

            GameKeyTextBlock.Text = UserInfo.UserGame;
        }

        private void CopyKey_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(GameKeyTextBlock.Text);
        }

        private void CloseRegistration_Button(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
