using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using Console = Colorful.Console;

namespace John_Dog
{
    class JohnDog
    {
        public static void Dequip(Player player, int slot)
        {
            if (slot < 4)
            {
                Say("Inventory Manager", "You can't dequip what you don't have equipped!");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            else
            {
                Item itemToDequip = player.Inventory[slot];
                int availableSlot = 0;
                for (int i = 4; i < 12; i++)
                {
                    try
                    {
                        string john = player.Inventory[i].Name;
                    }
                    catch
                    {
                        availableSlot = i;
                        return;
                    }
                }
                player.Inventory.Remove(slot);
                player.Inventory.Add(availableSlot, itemToDequip);
            }
        }

        public static void Give (Player player, Item item)
        {
            int availableSlot = 0;
            for (int i = 4; i < 12; i++)
            {
                try
                {
                    string john = player.Inventory[i].Name;
                }
                catch
                {
                    availableSlot = i;
                    return;
                }
            }
            player.Inventory.Add(availableSlot, item);
        }

        public static void Give(Player player, Item item, int slot)
        {
            // Overrides the given slot

            try {
                player.Inventory.Remove(slot);
                JohnDog.Say("Console", "Item '" + item.Name + "' is overwriting " + player.Inventory[slot]+ "!");
                player.Inventory.Add(slot, item);
                JohnDog.Say("Console", "Item '" + item.Name + "' given in slot " + slot + "!");
            }
            catch {
                player.Inventory.Add(slot, item);
                JohnDog.Say("Console", "Item '" + item.Name + "' given in slot " + slot + "!");
            }
        }

        public static void Drop(Player player, int slot)
        {
            try
            {
                player.Inventory.Remove(slot);
                JohnDog.Say("Inventory Manager", "You have dropped " + player.Inventory[slot] + "!");
            }
            catch
            {
                JohnDog.Say("Inventory Manager", "You cannot drop what does not exist!");
            }
        }
        public static void Equip(Player player, int slot)
        {
            int swapId;
            Console.Clear();
            Dictionary<int, Item> QueueToSwap = new Dictionary<int, Item>();

            // Add slot the player is attempting to equip to swap queue
            QueueToSwap.Add(slot, player.Inventory[slot]);

            // Just in case there's nothing there
            try
            {
                if (player.Inventory[slot].Weapon)
                {
                    // Add player's weapon to swap queue
                    QueueToSwap.Add(1, player.Inventory[1]);
                    swapId = 1;
                }
                else if (player.Inventory[slot].Ability)
                {
                    // Add player's ability to swap queue
                    QueueToSwap.Add(2, player.Inventory[2]);
                    swapId = 2;
                }
                else if (player.Inventory[slot].Armor)
                {
                    // Add player's armor to swap queue
                    QueueToSwap.Add(3, player.Inventory[3]);
                    swapId = 3;
                }
                else if (player.Inventory[slot].Ring)
                {
                    // Add player's ability to swap queue
                    QueueToSwap.Add(4, player.Inventory[4]);
                    swapId = 4;
                }
                else
                {
                    Say("Inventory Manager", "You cannot equip this!");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }
            }
            catch
            {
                Say("Inventory Manager", "There is no item in that slot or you're swapping an equipment slot!");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            player.Inventory.Remove(slot);
            player.Inventory.Remove(swapId);
            player.Inventory.Add(slot, QueueToSwap[swapId]);
            player.Inventory.Add(swapId, QueueToSwap[slot]);
            Say("Inventory Manager", "Equipped " + QueueToSwap[slot].Name + "!");
            Console.ReadKey();
            Console.Clear();
        }
        public static void ViewInventory(Player player)
        {
            #region long and ugly block of try and catch
            Console.Write("Slot 1 [Weapon Slot]: ", Color.Orange);
            try { Console.Write(player.Inventory[1].Name + "\n", Color.White); }
            catch { Console.Write("Empty\n", Color.White); }
            Console.Write("Slot 2 [Ability Slot]: ", Color.Orange);
            try { Console.Write(player.Inventory[2].Name + "\n", Color.White); }
            catch { Console.Write("Empty\n", Color.White); }
            Console.Write("Slot 3 [Armor Slot]: ", Color.Orange);
            try { Console.Write(player.Inventory[3].Name + "\n", Color.White); }
            catch { Console.Write("Empty\n", Color.White); }
            Console.Write("Slot 4 [Ring Slot]: ", Color.Orange);
            try { Console.Write(player.Inventory[4].Name + "\n", Color.White); }
            catch { Console.Write("Empty\n", Color.White); }
            #endregion
            for (int i = 4; i < 11; i++)
            {
                int slotNo = i + 1;
                {
                    Console.Write("Slot " + slotNo + ": ", Color.Orange);
                    try { Console.Write(player.Inventory[i + 1].Name + "\n", Color.White); }
                    catch { Console.Write("Empty\n", Color.White); }
                }
            }
        }
        public static bool DodgeHandler(Enemy enemy)
        {
            float step1 = enemy.Evasion / 50;
            float step2 = 0.15f * step1;
            float prob = step2 * 100;
            int DiceRoll = new Random().Next(1, 101);
            if (DiceRoll < prob) return true;
            else return false;
        }
        public static bool DodgeHandler (Player player)
        {
            float step1 = player.Evasion / 50;
            float step2 = 0.15f * step1;
            float prob = step2 * 100;
            int DiceRoll = new Random().Next(1, 101);
            if (DiceRoll < prob) return true;
            else return false;
        }
        public static void HandleBattleText (Player player, Enemy enemy)
        {
            if (!enemy.Alive)
            {
                Console.Write("\nYou have killed " + enemy.Name + "!", Color.DarkOrange);
            }
            else
            {
                if (enemy.Dodged) Console.Write("\n" + enemy.Name + " dodges your attack!", Color.DarkOrange);
                else if (player.Stunned) Console.Write("\nYou are stunned and unable to attack!", Color.DarkRed);
                else Console.Write("\nYou deal " + enemy.DamageDealt + " damage!", Color.DarkOrange);
                Console.Write("\n" + enemy.Name + " is on " + enemy.HP + " HP!", Color.Orange);
                if (player.Dodged) Console.Write("\nYou dodge " + enemy.Name + "'s attack!", Color.DarkRed);
                else if (enemy.Stunned) Console.Write("\n" + enemy.Name + " is stunned and unable to retaliate!", Color.DarkRed);
                else Console.Write("\nYou take " + player.DamageTaken + " damage!", Color.DarkRed);
                Console.Write("\nYou are on " + player.HP + " HP!", Color.Red);
                Console.Write("\nYou are on " + player.MP + " MP!", Color.CornflowerBlue);
            }
        }

        public static int GetDEFDamage(int damage, Enemy enemy)
        {
            float limit = damage * 0.15f;
            int enemyDef = enemy.DEF;
            if (enemy.ArmorBroken) enemyDef = 0;
            if (enemy.Armored) enemyDef *= 2;
            if (damage - enemy.DEF < limit) return Convert.ToInt32(limit);
            else return damage - enemy.DEF;
        }
        public static int GetDEFDamage(int damage, Player player)
        {
            int playerDef = player.DEF += player.TotalDefenseBonus;
            if (player.ArmorBroken) playerDef = 0;
            if (player.Armored) playerDef *= 2;
            float limit = damage * 0.15f;
            if (damage - playerDef < limit) return Convert.ToInt32(limit);
            else return damage - playerDef;
        }

        public static void Say (string name, string text)
        {
            Console.Write("<" + name + "> ", Color.Orange);
            Console.Write(text + "\n", Color.White);
        }
    }
}
