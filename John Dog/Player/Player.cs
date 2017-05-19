using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace John_Dog
{
    class Player
    {
        public Dictionary<int, Item> Inventory = new Dictionary<int, Item>();
        public string Name { get; set; }
        public int HP = 200;
        public int MP = 100;
        private bool isVisible = true; // for invisibility
        public int DEX = 10;
        public int ATT = 10;
        public int DEF = 15;
        public bool Armored;
        public bool ArmorBroken;
        public int DamageTaken { get; set; }
        public bool Alive { get; set; }
        public void Damage (Enemy enemy, Player player)
        {
            int dmg = new Random().Next(enemy.MinDMG, enemy.MaxDMG);
            DamageTaken = Item.GetDEFDamage(dmg, player);
            if (player.HP - DamageTaken < 0) player.Alive = false;
            HP -= Item.GetDEFDamage(dmg, player);
        }
    }
}
