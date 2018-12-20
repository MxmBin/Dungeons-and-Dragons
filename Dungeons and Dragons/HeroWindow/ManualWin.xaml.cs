using System.Windows;

namespace Dungeons_and_Dragons
{
    /// <summary>
    /// Логика взаимодействия для Manual.xaml
    /// </summary>
    public partial class ManualWin : Window
    {
        public ManualWin()
        {
            InitializeComponent();

            ManualVersion.Content = "Справочник v." + ManualInf.manual.version;
            ManualItem.ItemsSource = ManualInf.manual.manual.items;
            ManualWeapons.ItemsSource = ManualInf.manual.manual.weapons;
            ManualClasses.ItemsSource = ManualInf.manual.manual.classes;
            ManualArmors.ItemsSource = ManualInf.manual.manual.armors;
            ManualAbilities.ItemsSource = ManualInf.manual.manual.abilities;
        }

        private void CloseRegistration_Button(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
