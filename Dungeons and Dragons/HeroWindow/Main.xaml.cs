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
        public Main(HeroClass hero)
        {
            InitializeComponent();
            NameCharBox.Text = hero.Hero.heroInfo.name;
            NamePlayerBox.Text = hero.Hero.heroInfo.prehistory;
            ExpBox.Text = hero.Hero.heroInfo.exp.ToString();
            ACBox.Text = hero.Hero.heroInfo.AC.ToString();
            HpBox.Text = hero.Hero.heroInfo.hp.ToString();
            HpMaxBox.Text = hero.Hero.heroInfo.hpmax.ToString();
            HitBonesBox.Text = hero.Hero.heroInfo.HitBones.ToString();
            HitBonesMaxBox.Text = hero.Hero.heroInfo.HitBonesMax.ToString();
            MasterBonusBox.Text = hero.Hero.heroInfo.MasterBonus.ToString();
            TemporaryHpBox.Text = hero.Hero.heroInfo.TemporaryHP.ToString();
            Strenght.Text = hero.Hero.heroInfo.Strenght.ToString();
            Agility.Text = hero.Hero.heroInfo.Agility.ToString();
            EnduranceBox.Text = hero.Hero.heroInfo.Endurance.ToString();
            Intelligence.Text = hero.Hero.heroInfo.Intelligence.ToString();
            PerceptionBox.Text = hero.Hero.heroInfo.Perception.ToString();
            CharismaBox.Text = hero.Hero.heroInfo.Charisma.ToString();

            SavingThrowSRadio.IsChecked = hero.Hero.heroInfo.SavingThrowS;
            SavingThrowARadio.IsChecked = hero.Hero.heroInfo.SavingThrowA;
            SavingThrowERadio.IsChecked = hero.Hero.heroInfo.SavingThrowE;
            SavingThrowIRadio.IsChecked = hero.Hero.heroInfo.SavingThrowI;
            SavingThrowPRadio.IsChecked = hero.Hero.heroInfo.SavingThrowP;
            SavingThrowCRadio.IsChecked = hero.Hero.heroInfo.SavingThrowC;
        }
    }
}
