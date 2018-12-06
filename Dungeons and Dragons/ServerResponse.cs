using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons
{
    class ServerResponse
    {
        public string session { get; set; }
        public int role { get; set; }
        public string game { get; set; }
        public HeroCard hero { get; set; }
        public List<Heroes> heroes { get; set; }
    }

    class Heroes
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    //class HeroClass
    //{
    //    public HeroCard Hero;

    //    public HeroClass()
    //    {
    //        Hero = new HeroCard();
    //    }
    //}

    public class HeroCard
    {
        public HeroInfo heroInfo;
        public List<Weapons> weapons;

        public HeroCard()
        {
            heroInfo = new HeroInfo();
            weapons = new List<Weapons>();
        }

        public class HeroInfo
        {
            public int id { get; set; }
            public string name { get; set; }
            public string prehistory { get; set; }
            public int exp { get; set; }
            public int speed { get; set; }
            public int hp { get; set; }
            public int hpmax { get; set; }
            public int HitBonesMax { get; set; }
            public int HitBones { get; set; }
            public int Strenght { get; set; }
            public int Perception { get; set; }
            public int Endurance { get; set; }
            public int Charisma { get; set; }
            public int Intelligence { get; set; }
            public int Agility { get; set; }
            public int MasterBonus { get; set; }
            public int DeathSavingThrowGood { get; set; }
            public int DeatheSavingThrowBad { get; set; }
            public int TemporaryHP { get; set; }
            public int AC { get; set; }
            public int Initiative { get; set; }
            public bool PassiveAttention { get; set; }
            public bool Inspiration { get; set; }
            public int Ammo { get; set; }
            public string Languages { get; set; }
            public bool SavingThrowS { get; set; }
            public bool SavingThrowP { get; set; }
            public bool SavingThrowE { get; set; }
            public bool SavingThrowC { get; set; }
            public bool SavingThrowI { get; set; }
            public bool SavingThrowA { get; set; }
            public bool Athletics { get; set; }
            public bool Acrobatics { get; set; }
            public bool Juggle { get; set; }
            public bool Stealth { get; set; }
            public bool Magic { get; set; }
            public bool History { get; set; }
            public bool Analysis { get; set; }
            public bool Nature { get; set; }
            public bool Religion { get; set; }
            public bool AnimalCare { get; set; }
            public bool Insight { get; set; }
            public bool Medicine { get; set; }
            public bool Attention { get; set; }
            public bool Survival { get; set; }
            public bool Deception { get; set; }
            public bool Intimidation { get; set; }
            public bool Performance { get; set; }
            public bool Conviction { get; set; }
            public int WeapontFirstId { get; set; }
            public int WeaponSecondId { get; set; }
            public int ShieldId { get; set; }
        }

        public class Weapons
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Damage { get; set; }
            public string DmgType { get; set; }
            public string WeaponType { get; set; }
            public int Cost { get; set; }
            public int Weight { get; set; }
        }
    }
}
