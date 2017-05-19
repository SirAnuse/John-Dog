using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace John_Dog.Items
{
    class Shields
    {
        public static Item WoodenShield = new Item();
        public static Item IronShield = new Item();
        public static void SetShields()
        {
            // Wooden Shield
            WoodenShield.Name = "Wooden Shield";
            WoodenShield.Description = "A shield made of sturdy wood.";
            WoodenShield.Tier = 0;
            WoodenShield.MinDamage = 55;
            WoodenShield.MaxDamage = 90;
            WoodenShield.DefBonus = 2;
            WoodenShield.ManaCost = 80;
            WoodenShield.StunDuration = 3;
            WoodenShield.Shield = true;
            WoodenShield.Ability = true;
            // Iron Shield
            IronShield.Name = "Iron Shield";
            IronShield.Description = "A shield made of well forged iron.";
            IronShield.Tier = 1;
            IronShield.MinDamage = 200;
            IronShield.MaxDamage = 280;
            IronShield.DefBonus = 4;
            IronShield.ManaCost = 85;
            IronShield.StunDuration = 3;
            IronShield.Shield = true;
            IronShield.Ability = true;
        }
    }
}
