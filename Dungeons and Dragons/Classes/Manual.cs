using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons
{
    public class Manual
    {
        public ManualClass manual { get; set; }
        public int version { get; set; }

        public Manual()
        {
            manual = new ManualClass();
        }


        public class ManualClass
        {
            public List<Role> roles { get; set; }
            public List<Weapon> weapons { get; set; }
            public List<Dmgtype> dmgtype { get; set; }
            public List<Weapontype> weapontypes { get; set; }
            public List<Class> classes { get; set; }
            public List<Armor> armors { get; set; }
            public List<Armortype> armortypes { get; set; }
            public List<Ability> abilities { get; set; }
            public List<Item> items { get; set; }

            public ManualClass()
            {
                roles = new List<Role>();
                weapons = new List<Weapon>();
                dmgtype = new List<Dmgtype>();
                weapontypes = new List<Weapontype>();
                classes = new List<Class>();
                armors = new List<Armor>();
                armortypes = new List<Armortype>();
                abilities = new List<Ability>();
                items = new List<Item>();
            }
        }

        public class Role
        {
            public int id { get; set; }
            public string name { get; set; }
            public string about { get; set; }
        }

        public class Weapon
        {
            public int id { get; set; }
            public string name { get; set; }
            public string damage { get; set; }
            public int dmgtype { get; set; }
            public int type { get; set; }
            public int cost { get; set; }
            public int weight { get; set; }
        }

        public class Dmgtype
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Weapontype
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Class
        {
            public int id { get; set; }
            public string name { get; set; }
            public string about { get; set; }
            public string bonehit { get; set; }
        }

        public class Armor
        {
            public int id { get; set; }
            public string name { get; set; }
            public int ac { get; set; }
            public int type { get; set; }
            public int cost { get; set; }
            public int weight { get; set; }
        }

        public class Armortype
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Ability
        {
            public int id { get; set; }
            public string name { get; set; }
            public string about { get; set; }
            public int exp { get; set; }
        }

        public class Item
        {
            public int id { get; set; }
            public string name { get; set; }
            public string about { get; set; }
            public int cost { get; set; }
        }
    }
}
