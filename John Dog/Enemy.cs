using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace John_Dog
{
    class Enemy
    {
        public int StunDuration { get; set; }
        public int TurnsSinceStun { get; set; }
        public float StunnedDuration { get; set; }
        public bool Stunned { get; set; }
        public bool ArmorBroken { get; set; }
        public bool Armored { get; set; }
        public bool Damaging { get; set; }
        public bool Berserk { get; set; }
        public bool Weak { get; set; }
        public bool Evasive { get; set; }
        public bool Slowed { get; set; }
        public bool Bleeding { get; set; }
        public bool Paralyzed { get; set; }
        public bool Dodged { get; set; }
        
        public string Name { get; set; }
        public bool Alive { get; set; }
        public int HP { get; set; }   
        public int MP { get; set; }
        public int DEF { get; set; }
        public int DamageDealt { get; set; }
        public int MinDMG { get; set; }
        public int Evasion { get; set; }
        public int MaxDMG { get; set; }
        public bool HasLootDropped { get; set; }
        public Item LootDropped { get; set; }

        public Loot loot { get; set; }

        public void ResetLoot ()
        {
            LootDropped = null;
            Loot.LootToDrop = null;
            HasLootDropped = false;
            Loot.DropRate = 0;
            Loot.Amount = 0;
        }

        public void DropLoot (Player player, Enemy enemy)
        {
            float dropProb = Loot.DropRate * 100;
            int rollDice = new Random().Next(1, 101);

            if (rollDice < dropProb)
            {
                LootDropped = Loot.LootToDrop;
                HasLootDropped = true;
                player.Inventory.Add(player.Inventory.Count + 1, Loot.LootToDrop);
            }
            else
            {
                HasLootDropped = false;
                Loot.LootToDrop = null;
                Loot.DropRate = 0;
                Loot.Amount = 0;
            }
        }
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
            if (TurnsSinceStun > StunnedDuration) Stunned = false;
            int dmg = Item.CalculateDMG(item, player);
            if (enemy.HP - JohnDog.GetDEFDamage(dmg, enemy) <= 0)
            {
                enemy.Alive = false;
                return;
            }
            else
            {
                enemy.HP -= JohnDog.GetDEFDamage(dmg, enemy);
                DamageDealt = JohnDog.GetDEFDamage(dmg, enemy);
                if (enemy.HP <= 0) enemy.Alive = false;
            }
        }
    }
}
