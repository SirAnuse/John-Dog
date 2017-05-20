using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using John_Dog.Items;

namespace John_Dog
{
    class Player
    {
        public int TurnsSinceStun { get; set; }
        public bool Stunned { get; set; }
        public int StunnedDuration { get; set; }
        public bool ArmorBroken { get; set; }
        public bool Armored { get; set; }
        public bool Damaging { get; set; }
        public bool Berserk { get; set; }
        public bool Weak { get; set; }
        public bool Evasive { get; set; }
        public bool Slowed { get; set; }
        public bool Bleeding { get; set; }
        public bool Paralyzed { get; set; }
        public int BattleTurnsCounter { get; set; }
        public bool Dodged { get; set; }
        
        public Dictionary<int, Item> Inventory = new Dictionary<int, Item>();
        public int TotalDefenseBonus { get; set; }
        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public int Evasion { get; set; }
        private bool isVisible { get; set; } // for invisibility
        public int DEX { get; set; }
        public int ATT { get; set; }
        public int DEF { get; set; }
        public int WIS { get; set; }
        public int DamageTaken { get; set; }
        public bool Alive { get; set; }
        public int CalculateMPRegen (Player player)
        {
            float mpreg = player.WIS * 1.5f / 5;
            return Convert.ToInt32(Math.Round(mpreg, 0));
        }
        public void CalculateDefBonus (Player player)
        {
            player.TotalDefenseBonus = 0;
            player.TotalDefenseBonus += player.Inventory[1].DefBonus;
            player.TotalDefenseBonus += player.Inventory[2].DefBonus;
        }
        public void SetPlayerDefaults (Player player)
        {
            player.HP = 200;
            player.MP = 100;
            player.Evasion = 20;
            player.DEX = 12;
            player.ATT = 12;
            player.DEF = 0;
            player.WIS = 10;
            player.Inventory.Add(1, Swords.ShortSword);
            player.Inventory.Add(2, Shields.WoodenShield);
        }
        public void Damage (Enemy enemy, Player player)
        {
            bool dodged = JohnDog.DodgeHandler(enemy);
            if (dodged)
            {
                Dodged = true;
                Stunned = false;
                return;
            }
            Dodged = false;
            if (Stunned) TurnsSinceStun++;
            if (TurnsSinceStun > StunnedDuration + 1) Stunned = false;
            int dmg = new Random().Next(enemy.MinDMG, enemy.MaxDMG);
            DamageTaken = JohnDog.GetDEFDamage(dmg, player);
            if (player.HP - DamageTaken < 0) player.Alive = false;
            HP -= JohnDog.GetDEFDamage(dmg, player);
        }
    }
}
