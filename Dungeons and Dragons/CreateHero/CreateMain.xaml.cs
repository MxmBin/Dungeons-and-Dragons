using System;
using System.Windows;
using System.Windows.Controls;

namespace Dungeons_and_Dragons
{
    /// <summary>
    /// Логика взаимодействия для CreateMain.xaml
    /// </summary>
    public partial class CreateMain : UserControl
    {
        ReqHero Hero;

        public CreateMain(ref ReqHero hero)
        {
            InitializeComponent();

            Hero = hero;
        }

        private void UpdateInf_Click(object sender, RoutedEventArgs e)
        {
            Hero.hero.heroInfo.name = NameCharBox.Text;
            Hero.hero.heroInfo.prehistory = PrehistoryBox.Text;
            Hero.classid = Int32.Parse(ClassAndLevelBox.Text);
            Hero.hero.heroInfo.exp = Int32.Parse(ExpBox.Text);
            Hero.hero.heroInfo.AC = Int32.Parse(ACBox.Text);
            Hero.hero.heroInfo.hp = Int32.Parse(HpBox.Text);
            Hero.hero.heroInfo.hpmax = Int32.Parse(HpMaxBox.Text);
            Hero.hero.heroInfo.HitBones = Int32.Parse(HitBonesBox.Text);
            Hero.hero.heroInfo.HitBonesMax = Int32.Parse(HitBonesMaxBox.Text);
            Hero.hero.heroInfo.MasterBonus = Int32.Parse(MasterBonusBox.Text);
            Hero.hero.heroInfo.TemporaryHP = Int32.Parse(TemporaryHpBox.Text);
            Hero.hero.heroInfo.WeaponFirstId = 1;
            Hero.hero.heroInfo.WeaponSecondId = 1;
            Hero.hero.heroInfo.ArmorId = 1;
            Hero.hero.heroInfo.ShieldId = 1;
        }
    }
}
