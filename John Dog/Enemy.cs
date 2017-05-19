using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace John_Dog
{
    class Enemy
    {
        public string Name { get; set; }
        public bool Alive { get; set; }
        public int HP { get; set; }   
        public int MP { get; set; }
        public int DEF { get; set; }
        public int DamageDealt { get; set; }
        public int MinDMG { get; set; }
        public int MaxDMG { get; set; }
        public void Damage (Item item, Player player, Enemy enemy)
        {
            int dmg = Item.CalculateDMG(item, player);
            enemy.HP -= Item.GetDEFDamage(dmg, enemy);
            DamageDealt = Item.GetDEFDamage(dmg, enemy);
            if (enemy.HP <= 0) enemy.Alive = false;
        }
    }
}
