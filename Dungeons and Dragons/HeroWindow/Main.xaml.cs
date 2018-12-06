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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Dungeons_and_Dragons.Classes;

namespace Dungeons_and_Dragons
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class Main : UserControl
    {
        public Main(HeroCard hero)
        {
            InitializeComponent();
            NameCharBox.Text = hero.heroInfo.name;
            NamePlayerBox.Text = hero.heroInfo.prehistory;
            ExpBox.Text = hero.heroInfo.exp.ToString();
            ACBox.Text = hero.heroInfo.AC.ToString();
            HpBox.Text = hero.heroInfo.hp.ToString();
            HpMaxBox.Text = hero.heroInfo.hpmax.ToString();
            HitBonesBox.Text = hero.heroInfo.HitBones.ToString();
            HitBonesMaxBox.Text = hero.heroInfo.HitBonesMax.ToString();
            MasterBonusBox.Text = hero.heroInfo.MasterBonus.ToString();
            TemporaryHpBox.Text = hero.heroInfo.TemporaryHP.ToString();
            Strenght.Text = hero.heroInfo.Strenght.ToString();
            Agility.Text = hero.heroInfo.Agility.ToString();
            EnduranceBox.Text = hero.heroInfo.Endurance.ToString();
            Intelligence.Text = hero.heroInfo.Intelligence.ToString();
            PerceptionBox.Text = hero.heroInfo.Perception.ToString();
            CharismaBox.Text = hero.heroInfo.Charisma.ToString();

            SavingThrowSRadio.IsChecked = hero.heroInfo.SavingThrowS;
            SavingThrowARadio.IsChecked = hero.heroInfo.SavingThrowA;
            SavingThrowERadio.IsChecked = hero.heroInfo.SavingThrowE;
            SavingThrowIRadio.IsChecked = hero.heroInfo.SavingThrowI;
            SavingThrowPRadio.IsChecked = hero.heroInfo.SavingThrowP;
            SavingThrowCRadio.IsChecked = hero.heroInfo.SavingThrowC;
        }
    }
}
