using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Drawing;
using Console = Colorful.Console;

namespace John_Dog
{
    class Item
    {
        public bool Weapon { get; set; }
        public float StunDuration { get; set; }
        public bool Shield { get; set; }
        // ManaCost if ability
        public int ManaCost { get; set; } 
        public bool Ability { get; set; }
        public bool Armor { get; set; }
        public bool Ring { get; set; }
        public int DefBonus { get; set; }
        public string Name { get; set; }
        public int MaxDamage { get; set; }
        public int MinDamage { get; set; }
        public float RateOfFire { get; set; }
        public int Tier { get; set; }
        public bool Untiered { get; set; }
        public string Description { get; set; }
        public bool Consumable { get; set; }
        public static void Compare (Item item1, Item item2, Player player)
        {
            if (!item1.Untiered && !item2.Untiered)
            {
                if (item1.Tier > item2.Tier)
                {
                    Console.WriteLine(item1.Name + " is better.", Color.White);
                    Item.PrintDetails(item1, Color.Green);
                    Item.PrintDetails(item2, Color.Red);
                }
                else if (item1.Tier < item2.Tier)
                {
                    Console.WriteLine(item2.Name + " is better.", Color.White);
                    Item.PrintDetails(item2, Color.Green);
                    Item.PrintDetails(item1, Color.Red);
                }
                else if (item1.Tier == item2.Tier)
                {
                    Console.WriteLine(item1.Name + " and " + item2.Name + " are the same!", Color.White);
                    Item.PrintDetails(item1, Color.Khaki);
                    Item.PrintDetails(item2, Color.Khaki);
                }
            }
            else
            {
                float DPS1 = CalculateDPS(item1, player, true);
                float DPS2 = CalculateDPS(item2, player, true);
                if (DPS1 > DPS2)
                {
                    Console.WriteLine(item1.Name + " is superior in DPS.", Color.White);
                    Item.PrintDetails(item1, Color.Green);
                    Item.PrintDetails(item2, Color.Red);
                }
                else if (DPS1 < DPS2)
                {
                    Console.WriteLine(item2.Name + " is superior in DPS.", Color.White);
                    Item.PrintDetails(item2, Color.Green);
                    Item.PrintDetails(item1, Color.Red);
                }
                else
                {
                    Console.WriteLine(item1.Name + " and " + item2.Name + " have the same DPS!", Color.White);
                    Item.PrintDetails(item1, Color.Khaki);
                    Item.PrintDetails(item2, Color.Khaki);
                }
                
            }
        }

        public static void Drop (Player player, string slot)
        {
            string entry = slot;
            string[] cmds;
            Regex argReg = new Regex(@"\w+|""[\w\s]*""");
            cmds = new string[argReg.Matches(entry).Count];
            int i = 0;
            foreach (var enumer in argReg.Matches(entry))
            {
                cmds[i] = (string)enumer.ToString();
                i++;
            }

            int meme = 0;
            try { meme = Convert.ToInt32(cmds[0]); }
            catch { }
            if (meme > 0)
            {
                try
                {
                    Console.Write("<Inventory Manager> ", Color.Orange);
                    Console.Write("Are you sure you want to drop your ", Color.White);
                    if (player.Inventory[meme].Untiered) Console.Write(player.Inventory[meme].Name, Color.Purple);
                    else Console.Write(player.Inventory[meme].Name, Color.Khaki);
                    Console.Write("? [YES/NO]\n", Color.White);
                    string yorn = Console.ReadLine();
                    switch (yorn.ToLower())
                    {
                        case "never say never":
                        case "y":
                        case "ye":
                        case "yes":
                            JohnDog.Drop(player, meme);
                            Console.ReadKey();
                            break;
                        case "n":
                        case "ne":
                        case "neh":
                        case "never":
                        case "neva":
                        case "never forget justin bieber 2k06":
                        case "no":
                            JohnDog.Say("Inventory Manager", player.Inventory[meme].Name + " was not dropped!");
                            Console.ReadKey();
                            break;
                        default:
                            JohnDog.Say("Inventory Manager", "Please use 'n' or 'no' next time! If you meant yes, then use 'y' or 'yes'.");
                            Console.ReadKey();
                            break;
                    }
                }
                catch { JohnDog.Say("Inventory Manager", "You can't drop what doesn't exist!"); }
                Console.ReadKey();
                return;
            }
            else if (cmds[0] == "slot")
            {
                try { meme = Convert.ToInt32(cmds[1]); }
                catch { }
                if (meme > 0)
                {
                    try
                    {
                        Console.Write("<Inventory Manager> ", Color.Orange);
                        Console.Write("Are you sure you want to drop your ", Color.White);
                        if (player.Inventory[meme].Untiered) Console.Write(player.Inventory[meme].Name, Color.Purple);
                        else Console.Write(player.Inventory[meme].Name, Color.Khaki);
                        Console.Write("? [YES/NO]\n", Color.White);
                        string yorn = Console.ReadLine();
                        switch (yorn.ToLower())
                        {
                            case "never say never":
                            case "y":
                            case "ye":
                            case "yes":
                                JohnDog.Drop(player, meme);
                                Console.ReadKey();
                                break;
                            case "n":
                            case "ne":
                            case "neh":
                            case "never":
                            case "neva":
                            case "never forget justin bieber 2k06":
                            case "no":
                                JohnDog.Say("Inventory Manager", player.Inventory[meme].Name + " was not dropped!");
                                Console.ReadKey();
                                break;
                            default:
                                JohnDog.Say("Inventory Manager", "Please use 'n' or 'no' next time! If you meant yes, then use 'y' or 'yes'.");
                                Console.ReadKey();
                                break;
                        }
                    }
                    catch { JohnDog.Say("Inventory Manager", "You can't examine what doesn't exist!"); }
                    Console.ReadKey();
                    return;
                }
            }
            else
            {
                switch (slot.ToLower())
                {
                    case "1":
                    case "weapon":
                        JohnDog.Drop(player, meme);
                        Console.ReadKey();
                        break;
                    case "2":
                    case "shield":
                    case "ability":
                        JohnDog.Drop(player, meme);
                        Console.ReadKey();
                        break;
                    case "3":
                    case "armour":
                    case "armor":
                        JohnDog.Drop(player, meme);
                        Console.ReadKey();
                        break;
                    case "ring":
                        JohnDog.Drop(player, meme);
                        Console.ReadKey();
                        break;
                    default:
                        JohnDog.Say("Inventory Manager", "You can't drop what doesn't exist!");
                        break;
                }
            }
        }

        public static void Examine(Player player, string slot, string slotpt2)
        {
            string entry = slot + " " + slotpt2;
            string[] cmds;
            Regex argReg = new Regex(@"\w+|""[\w\s]*""");
            cmds = new string[argReg.Matches(entry).Count];
            int i = 0;
            foreach (var enumer in argReg.Matches(entry))
            {
                cmds[i] = (string)enumer.ToString();
                i++;
            }

            int meme = 0;
            try { meme = Convert.ToInt32(cmds[0]); }
            catch { }
            if (meme > 0)
            {
                try
                {
                    PrintDetails(player.Inventory[meme]);
                    Console.Write("\nPress 'Enter' once you are finished reading.", Color.Yellow);
                }
                catch { JohnDog.Say("Inventory Manager", "You can't examine what doesn't exist!"); }
                Console.ReadKey();
                return;
            }
            else if (cmds[0] == "slot")
            {
                try { meme = Convert.ToInt32(cmds[1]); }
                catch { }
                if (meme > 0)
                {
                    try
                    {
                        PrintDetails(player.Inventory[meme]);
                        Console.Write("\nPress 'Enter' once you are finished reading.", Color.Yellow);
                    }
                    catch { JohnDog.Say("Inventory Manager", "You can't examine what doesn't exist!"); }
                    Console.ReadKey();
                    return;
                }
            }
            else
            {
                switch (slot.ToLower())
                {
                    case "1":
                    case "weapon":
                        Item.PrintDetails(player.Inventory[1]);
                        Console.Write("\nPress 'Enter' once you are finished reading.", Color.Yellow);
                        Console.ReadKey();
                        break;
                    case "2":
                    case "shield":
                    case "ability":
                        Item.PrintDetails(player.Inventory[2]);
                        Console.Write("\nPress 'Enter' once you are finished reading.", Color.Yellow);
                        Console.ReadKey();
                        break;
                    case "3":
                    case "armour":
                    case "armor":
                        Item.PrintDetails(player.Inventory[3]);
                        Console.Write("\nPress 'Enter' once you are finished reading.", Color.Yellow);
                        Console.ReadKey();
                        break;
                    case "ring":
                        Item.PrintDetails(player.Inventory[4]);
                        Console.Write("\nPress 'Enter' once you are finished reading.", Color.Yellow);
                        Console.ReadKey();
                        break;
                    default:
                        JohnDog.Say("Inventory Manager", "You can't examine what doesn't exist!");
                        break;
                }
            }
        }

        public static void Examine (Player player, string slot)
        {
            string entry = slot;
            string[] cmds;
            Regex argReg = new Regex(@"\w+|""[\w\s]*""");
            cmds = new string[argReg.Matches(entry).Count];
            int i = 0;
            foreach (var enumer in argReg.Matches(entry))
            {
                cmds[i] = (string)enumer.ToString();
                i++;
            }

            int meme = 0;
            try { meme = Convert.ToInt32(cmds[0]); }
            catch { }
            if (meme > 0)
            {
                try {
                    PrintDetails(player.Inventory[meme]);
                    Console.Write("\nPress 'Enter' once you are finished reading.", Color.Yellow);
                }
                catch { JohnDog.Say("Inventory Manager", "You can't examine what doesn't exist!"); }
                Console.ReadKey();
                return;
            }
            else if (cmds[0] == "slot")
            {
                try { meme = Convert.ToInt32(cmds[1]); }
                catch { }
                if (meme > 0)
                {
                    try {
                        PrintDetails(player.Inventory[meme]);
                        Console.Write("\nPress 'Enter' once you are finished reading.", Color.Yellow);
                    }
                    catch { JohnDog.Say("Inventory Manager", "You can't examine what doesn't exist!"); }
                    Console.ReadKey();
                    return;
                }
            }
            else
            {
                switch (slot.ToLower())
                {
                    case "1":
                    case "weapon":
                        Item.PrintDetails(player.Inventory[1]);
                        Console.Write("\nPress 'Enter' once you are finished reading.", Color.Yellow);
                        Console.ReadKey();
                        break;
                    case "2":
                    case "shield":
                    case "ability":
                        Item.PrintDetails(player.Inventory[2]);
                        Console.Write("\nPress 'Enter' once you are finished reading.", Color.Yellow);
                        Console.ReadKey();
                        break;
                    case "3":
                    case "armour":
                    case "armor":
                        Item.PrintDetails(player.Inventory[3]);
                        Console.Write("\nPress 'Enter' once you are finished reading.", Color.Yellow);
                        Console.ReadKey();
                        break;
                    case "ring":
                        Item.PrintDetails(player.Inventory[4]);
                        Console.Write("\nPress 'Enter' once you are finished reading.", Color.Yellow);
                        Console.ReadKey();
                        break;
                    default:
                        JohnDog.Say("Inventory Manager", "You can't examine what doesn't exist!");
                        break;
                }
            }
        }

        public static int CalculateDMG(Item item, Player player)
        {
            Random rand = new Random();
            float ATTMultiplier = 0.5f + player.ATT / 50;               // Calculate damage multiplier
            float MinDMG = item.MinDamage * ATTMultiplier;
            float MaxDMG = item.MaxDamage * ATTMultiplier;
            return rand.Next(Convert.ToInt32(MinDMG), Convert.ToInt32(MaxDMG));
        }
        public static float CalculateDPS(Item item, Player player, bool isValue)
        {
            float step1 = item.MaxDamage + item.MinDamage;      // Calculate average damage (pt 1)
            float step2 = step1 / 2;                            // Calculate average damage (pt 2)
            float step3 = 0.5f + player.ATT / 50;               // Calculate damage multiplier
            float step4 = step2 * step3;                        // Multiply damage by multiplier
            float step5 = 1.5f + 6.5f * (player.DEX / 75);      // Calculate APS (attacks per second)
            return step4 * step5;                                // Calculate DPS by multiplying APS by damage
        }
        public static void CalculateDPS (Item item, Player player)
        {
            float step1 = item.MaxDamage + item.MinDamage;      // Calculate average damage (pt 1)
            float step2 = step1 / 2;                            // Calculate average damage (pt 2)
            float step3 = 0.5f + player.ATT / 50;               // Calculate damage multiplier
            float step4 = step2 * step3;                        // Multiply damage by multiplier
            float step5 = 1.5f + 6.5f * (player.DEX / 75);      // Calculate APS (attacks per second)
            float DPS = step4 * step5;                          // Calculate DPS by multiplying APS by damage
            Console.Write("\nDPS Average: ", Color.White);
            Console.Write(DPS);
        }
        public static void PrintDetails (Item item)
        {
            Console.Write("\nName: ", Color.White);
            Console.Write(item.Name);
            Console.Write("\nTier: ", Color.White);
            if (item.Untiered) Console.Write("Untiered", Color.Purple);
            else Console.Write(item.Tier);
            Console.Write("\nDamage: ", Color.White);
            Console.Write(item.MinDamage + " - " + item.MaxDamage);
            if (item.Weapon)
            {
                Console.Write("\nRate of Fire: ", Color.White);
                float FireRate = item.RateOfFire * 100;
                Console.Write(FireRate + "%");
            }
            Console.Write("\nDescription: ", Color.White);
            Console.Write(item.Description);
            if (item.Shield)
            {
                Console.Write("\nStun Duration: ", Color.White);
                Console.Write(item.StunDuration + " Turns");
            }
            if (item.Ability)
            {
                Console.Write("\nMana Cost: ", Color.White);
                Console.Write(item.ManaCost);
            }
            if (item.DefBonus > 0 || item.DefBonus < 0)
            {
                Console.Write("\nStat Bonuses: ", Color.White);
                Console.Write("+" + item.DefBonus + " DEF");
            }
            Console.Write("\n");
        }
        public static void PrintDetails(Item item, Color color)
        {
            Console.Write("\n\nName: ", Color.White);
            Console.Write(item.Name, color);
            Console.Write("\nTier: ", Color.White);
            if (item.Untiered) Console.Write("Untiered", Color.Purple);
            else Console.Write(item.Tier, color);
            Console.Write("\nDamage: ", Color.White);
            Console.Write(item.MinDamage + " - " + item.MaxDamage, color);
            Console.Write("\nRate of Fire: ", Color.White);
            float FireRate = item.RateOfFire * 100;
            Console.Write(FireRate + "%", color);
            Console.Write("\nDescription: ", Color.White);
            Console.Write(item.Description, color);
        }
    }
}
