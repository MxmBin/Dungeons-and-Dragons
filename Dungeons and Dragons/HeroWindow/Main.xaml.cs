using System.Windows;
using System;
using System.Windows.Controls;
using RestSharp;

namespace Dungeons_and_Dragons
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class Main : UserControl
    {
        public HeroCard refHero = new HeroCard();
        public Main(ref HeroCard hero)
        {
            InitializeComponent();
            ref HeroCard refHero = ref hero;
            NameCharBox.Text = hero.heroInfo.name;
            PrehistoryBox.Text = hero.heroInfo.prehistory;
            ExpBox.Text = hero.heroInfo.exp.ToString();
            ACBox.Text = hero.heroInfo.AC.ToString();
            HpBox.Text = hero.heroInfo.hp.ToString();
            HpMaxBox.Text = hero.heroInfo.hpmax.ToString();
            HitBonesBox.Text = hero.heroInfo.HitBones.ToString();
            HitBonesMaxBox.Text = hero.heroInfo.HitBonesMax.ToString();
            MasterBonusBox.Text = hero.heroInfo.MasterBonus.ToString();
            TemporaryHpBox.Text = hero.heroInfo.TemporaryHP.ToString();
        }

        private void UpdateInf_Click(object sender, RoutedEventArgs e)
        {
            refHero.heroInfo.exp = Int32.Parse(ExpBox.Text);
            refHero.heroInfo.AC = Int32.Parse(ACBox.Text);
            refHero.heroInfo.hp = Int32.Parse(HpBox.Text);
            refHero.heroInfo.hpmax = Int32.Parse(HpMaxBox.Text);
            refHero.heroInfo.HitBones = Int32.Parse(HitBonesBox.Text);
            refHero.heroInfo.HitBonesMax = Int32.Parse(HitBonesMaxBox.Text);
            refHero.heroInfo.MasterBonus = Int32.Parse(MasterBonusBox.Text);
            refHero.heroInfo.TemporaryHP = Int32.Parse(TemporaryHpBox.Text);

            ClientClass client = new ClientClass();
            IRestResponse response = client.saveHero(UserInfo.UserGame, UserInfo.UserLogin, UserInfo.UserSession, refHero);
            if (response.IsSuccessful)
            {
                MessageBox.Show("Герой обновлён");
            }
            else
            {
                MessageBox.Show(response.Content);
            }
        }
    }
}
