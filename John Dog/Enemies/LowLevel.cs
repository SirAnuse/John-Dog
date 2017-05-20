using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using John_Dog.Items;

namespace John_Dog.Enemies
{
    class LowLevel
    {
        public static Enemy Slime = new Enemy();
        public static Enemy Pirate = new Enemy();
        public static void SetSlime()
        {
            Slime.Alive = true;
            Slime.DEF = 0;
            Slime.MinDMG = 10;
            Slime.MaxDMG = 25;
            Slime.HP = 250;
            Slime.MP = 0;
            Loot.Amount.Add(1, 1);
            Loot.ItemToDrop.Add(1, Swords.LongSword);
            Loot.DropRate.Add(1, 0.35f);
            
        }
        public static void SetPirate()
        {
            // Pirate
            Pirate.Alive = true;
            Pirate.DEF = 5;
            Pirate.MinDMG = 5;
            Pirate.MaxDMG = 15;
            Pirate.HP = 125;
            Pirate.MP = 75;
            Pirate.Name = "John the Pirate";
            Loot.Amount.Add(1, 1);
            Loot.ItemToDrop.Add(1, Swords.Saber);
            Loot.DropRate.Add(1, 0.5f);
        }
    }
}
