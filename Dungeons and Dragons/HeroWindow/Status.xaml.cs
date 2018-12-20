using System.Windows.Controls;

namespace Dungeons_and_Dragons
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class Status : UserControl
    {
        public Status(ref ReqHero hero)
        {
            InitializeComponent();

            //Strenght.Text = hero.heroInfo.Strenght.ToString();
            //Agility.Text = hero.heroInfo.Agility.ToString();
            //EnduranceBox.Text = hero.heroInfo.Endurance.ToString();
            //Intelligence.Text = hero.heroInfo.Intelligence.ToString();
            //PerceptionBox.Text = hero.heroInfo.Perception.ToString();
            //CharismaBox.Text = hero.heroInfo.Charisma.ToString();

            //SavingThrowSRadio.IsChecked = hero.heroInfo.SavingThrowS;
            //SavingThrowARadio.IsChecked = hero.heroInfo.SavingThrowA;
            //SavingThrowERadio.IsChecked = hero.heroInfo.SavingThrowE;
            //SavingThrowIRadio.IsChecked = hero.heroInfo.SavingThrowI;
            //SavingThrowPRadio.IsChecked = hero.heroInfo.SavingThrowP;
            //SavingThrowCRadio.IsChecked = hero.heroInfo.SavingThrowC;
        }
    }
}
