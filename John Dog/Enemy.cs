using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace John_Dog
{
    class Enemy
    {
        public bool Dodged { get; set; }
        public int StunDuration { get; set; }
        public int TurnsSinceStun { get; set; }
        public float StunnedDuration { get; set; }
        public bool Stunned { get; set; }
        public string Name { get; set; }
        public bool Alive { get; set; }
        public int HP { get; set; }   
        public int MP { get; set; }
        public int DEF { get; set; }
        public int DamageDealt { get; set; }
        public int MinDMG { get; set; }
        public int Evasion { get; set; }
        public int MaxDMG { get; set; }
        public void Damage (Item item, Player player, Enemy enemy)
        {
            // Evasion mechanic - possibility to dodge attack
            bool dodged = JohnDog.DodgeHandler(enemy);
            if (dodged)
            {
                Dodged = true;
                Stunned = false;
                StunnedDuration = 0;
                return;
            }
            Dodged = false;
            if (Stunned) TurnsSinceStun++;
            if (TurnsSinceStun > StunnedDuration + 1) Stunned = false;
            int dmg = Item.CalculateDMG(item, player);
            enemy.HP -= Item.GetDEFDamage(dmg, enemy);
            DamageDealt = Item.GetDEFDamage(dmg, enemy);
            if (enemy.HP <= 0) enemy.Alive = false;
        }
    }
}
