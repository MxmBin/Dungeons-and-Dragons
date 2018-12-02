using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons
{
    public static class Hero
    {
        public static HeroInfo heroInfo { get; set; }
        public static List<Weapons> weapons { get; set; }
    }

    public class HeroInfo
    {
        public static int id { get; set; }
        public static string name { get; set; }
        public static string prehistory { get; set; }
        public static int exp { get; set; }
        public static int speed { get; set; }
        public static int hp { get; set; }
        public static int hpmax { get; set; }
        public static int HitBonesMax { get; set; }
        public static int HitBones { get; set; }
        public static int Strenght { get; set; }
        public static int Perception { get; set; }
        public static int Endurance { get; set; }
        public static int Charisma { get; set; }
        public static int Intelligence { get; set; }
        public static int Agility { get; set; }
        public static int MasterBonus { get; set; }
        public static int DeathSavingThrowGood { get; set; }
        public static int DeatheSavingThrowBad { get; set; }
        public static int TemporaryHP { get; set; }
        public static int AC { get; set; }
        public static int Initiative { get; set; }
        public static bool PassiveAttention { get; set; }
        public static bool Inspiration { get; set; }
        public static int Ammo { get; set; }
        public static string Languages { get; set; }
        public static bool SavingThrowS { get; set; }
        public static bool SavingThrowP { get; set; }
        public static bool SavingThrowE { get; set; }
        public static bool SavingThrowC { get; set; }
        public static bool SavingThrowI { get; set; }
        public static bool SavingThrowA { get; set; }
        public static bool Athletics { get; set; }
        public static bool Acrobatics { get; set; }
        public static bool Juggle { get; set; }
        public static bool Stealth { get; set; }
        public static bool Magic { get; set; }
        public static bool History { get; set; }
        public static bool Analysis { get; set; }
        public static bool Nature { get; set; }
        public static bool Religion { get; set; }
        public static bool AnimalCare { get; set; }
        public static bool Insight { get; set; }
        public static bool Medicine { get; set; }
        public static bool Attention { get; set; }
        public static bool Survival { get; set; }
        public static bool Deception { get; set; }
        public static bool Intimidation { get; set; }
        public static bool Performance { get; set; }
        public static bool Conviction { get; set; }
        public static int WeapontFirstId { get; set; }
        public static int WeaponSecondId { get; set; }
        public static int ShieldId { get; set; }
    }

    public class Weapons
    {
        public static int Id { get; set; }
        public static string Name { get; set; }
        public static int Damage { get; set; }
        public static string DmgType { get; set; }
        public static string WeaponType { get; set; }
        public static int Cost { get; set; }
        public static int Weight { get; set; }
    }

}
