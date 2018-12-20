using RestSharp;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Dungeons_and_Dragons
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class Main : UserControl
    {
        static ReqHero Hero = new ReqHero();
        public Main(ref ReqHero hero)
        {
            InitializeComponent();
            Hero = hero;
            NameCharBox.Text = Hero.hero.heroInfo.name;
            PrehistoryBox.Text = Hero.hero.heroInfo.prehistory;
            ExpBox.Text = Hero.hero.heroInfo.exp.ToString();
            ACBox.Text = Hero.hero.heroInfo.AC.ToString();
            HpBox.Text = Hero.hero.heroInfo.hp.ToString();
            HpMaxBox.Text = Hero.hero.heroInfo.hpmax.ToString();
            HitBonesBox.Text = Hero.hero.heroInfo.HitBones.ToString();
            HitBonesMaxBox.Text = Hero.hero.heroInfo.HitBonesMax.ToString();
            MasterBonusBox.Text = Hero.hero.heroInfo.MasterBonus.ToString();
            TemporaryHpBox.Text = Hero.hero.heroInfo.TemporaryHP.ToString();
        }

        private void UpdateInf_Click(object sender, RoutedEventArgs e)
        {
            Hero.hero.heroInfo.exp = Int32.Parse(ExpBox.Text);
            Hero.hero.heroInfo.AC = Int32.Parse(ACBox.Text);
            Hero.hero.heroInfo.hp = Int32.Parse(HpBox.Text);
            Hero.hero.heroInfo.hpmax = Int32.Parse(HpMaxBox.Text);
            Hero.hero.heroInfo.HitBones = Int32.Parse(HitBonesBox.Text);
            Hero.hero.heroInfo.HitBonesMax = Int32.Parse(HitBonesMaxBox.Text);
            Hero.hero.heroInfo.MasterBonus = Int32.Parse(MasterBonusBox.Text);
            Hero.hero.heroInfo.TemporaryHP = Int32.Parse(TemporaryHpBox.Text);

            ClientClass client = new ClientClass();
            IRestResponse response = client.saveHero(UserInfo.UserGame, UserInfo.UserLogin, UserInfo.UserSession, Hero);
            if (response.IsSuccessful)
            {
                MessageBox.Show(response.Content);
            }
            else
            {
                MessageBox.Show(response.Content);
            }
        }

        // Настроить все кнопки
        private void ExpBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show("hello"); 
        }
    }
}
