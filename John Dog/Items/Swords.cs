using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace John_Dog.Items
{
    class Swords
    {
        public static Item ShortSword = new Item();
        public static Item BroadSword = new Item();
        public static Item Saber = new Item();
        public static Item LongSword = new Item();
        public static Item AncientStoneSword = new Item();
        public static void SetSwords ()
        {
            // Short Sword
            ShortSword.Name = "Short Sword";
            ShortSword.Description = "A steel short sword.";
            ShortSword.Tier = 0;
            ShortSword.MinDamage = 45;
            ShortSword.MaxDamage = 90;
            ShortSword.RateOfFire = 1f;
            ShortSword.Weapon = true;
            // Broadsword
            BroadSword.Name = "Broad Sword";
            BroadSword.Description = "A broad-bladed steel sword.";
            BroadSword.Tier = 1;
            BroadSword.MinDamage = 60;
            BroadSword.MaxDamage = 105;
            BroadSword.RateOfFire = 1f;
            BroadSword.Weapon = true;
            // Saber
            Saber.Name = "Saber";
            Saber.Description = "A single-edged light sword.";
            Saber.Tier = 2;
            Saber.MinDamage = 75;
            Saber.MaxDamage = 105;
            Saber.RateOfFire = 1f;
            Saber.Weapon = true;
            // Long Sword
            LongSword.Name = "Long Sword";
            LongSword.Description = "A well-made sword with a double edged blade.";
            LongSword.Tier = 3;
            LongSword.MinDamage = 75;
            LongSword.MaxDamage = 125;
            LongSword.RateOfFire = 1f;
            LongSword.Weapon = true;
            // Ancient Stone Sword
            AncientStoneSword.Name = "Ancient Stone Sword";
            AncientStoneSword.Description = "A slow but powerful sword that is a relic of a long forgotten age.";
            AncientStoneSword.MinDamage = 340;
            AncientStoneSword.MaxDamage = 390;
            AncientStoneSword.RateOfFire = 0.60f;
            AncientStoneSword.Untiered = true;
            AncientStoneSword.Weapon = true;
        }
    }
}
