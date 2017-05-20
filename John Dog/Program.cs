using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Threading;
using Colorful;
using MySql.Data;
using System.Xml.Linq;
using System.Xml;
using John_Dog.Items;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using Console = Colorful.Console;

namespace John_Dog
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] cmds;
            string entry;
            Player player = new Player();
            Swords.SetSwords();
            Shields.SetShields();
            JohnDog.Say("Console", "Welcome to John Dog v0.0.1, player!");
            JohnDog.Say("Console", "What is your name?");
            player.Name = Console.ReadLine();
            player.SetPlayerDefaults(player);
            JohnDog.Say("Console", "Welcome, " + player.Name + "! I hope you enjoy your time playing John Dog!");
            Thread.Sleep(1500);
            Console.Clear();
            bool firstBit = true;
            bool running = true;
            while (firstBit)
            {
                if (player.BattleCompleted)
                {
                    firstBit = false;
                    JohnDog.Say("Console", "Congratulations on completing the tutorial!");
                    JohnDog.Say("Console", "You will now be placed in a forest. Good luck.");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
                else
                {
                    JohnDog.Say("Console", "You are on a beach. You are carrying a short sword and wooden shield.");
                    JohnDog.Say("Console", "There's a pirate wandering across the beach.");
                    JohnDog.Say("Console", "You can say 'examine weapon' (without the apostrophes), for example, to examine your sword.");
                    entry = Console.ReadLine();
                    
                    Console.Clear();
                    switch (entry.ToLower())
                    {
                        case "skip":
                            firstBit = false;
                            JohnDog.Say("Console", "You have skipped the tutorial.");
                            Console.ReadKey();
                            break;
                        case "view inventory":
                            JohnDog.ViewInventory(player);
                            Console.ReadKey();
                            break;
                        case "attack pirate":
                            Enemies.LowLevel.SetPirate();
                            Battle.Begin(player, Enemies.LowLevel.Pirate, true);
                            break;
                        case "examine weapon":
                            Item.PrintDetails(player.Inventory[1]);
                            Console.Write("\nPress any key once you are finished reading.", Color.Yellow);
                            Console.ReadKey();
                            break;
                        case "examine shield":
                            Item.PrintDetails(player.Inventory[2]);
                            Console.Write("\nPress any key once you are finished reading.", Color.Yellow);
                            Console.ReadKey();
                            break;
                        default:
                            JohnDog.Say("Console", "Please enter a valid command!");
                            Console.ReadKey();
                            break;
                    }
                    Console.Clear();
                }
            }
            while (running)
            {
                Map.GetEquipmentDescription(player);
                Map.GetMapDescription("forest");
                Map.GetMapEnemies("forest");
                entry = Console.ReadLine();
                Console.Clear();
                Regex argReg = new Regex(@"\w+|""[\w\s]*""");
                cmds = new string[argReg.Matches(entry).Count];
                int i = 0;
                foreach (var enumer in argReg.Matches(entry))
                {
                    cmds[i] = (string)enumer.ToString();
                    i++;
                }
                if (cmds.Length == 0)
                {
                    JohnDog.Say("Console", "Please enter a valid command!");
                    Console.ReadKey();
                }
                else
                {
                    switch (cmds[0].ToLower())
                    {
                        case "give":
                            if (cmds.Length > 1)
                            {
                                if (cmds.Length > 2)
                                {
                                    switch (cmds[2].ToLower())
                                    {
                                        case "ass":
                                        case "\"ancient stone sword\"":
                                            switch (cmds[3].ToLower())
                                            {
                                                case "1":
                                                    JohnDog.Give(player, Swords.AncientStoneSword, 4);
                                                    Console.ReadKey();
                                                    break;
                                            }
                                            break;
                                        default:
                                            JohnDog.Say("Console", "Invalid item!");
                                            Console.ReadKey();
                                            break;

                                    }
                                }
                                switch (cmds[1].ToLower())
                                {
                                    case "ass":
                                    case "\"ancient stone sword\"":
                                        JohnDog.Give(player, Swords.AncientStoneSword);
                                        break;
                                    default:
                                        JohnDog.Say("Console", "Invalid item!");
                                        Console.ReadKey();
                                        break;
                                }
                            }
                            else
                            {
                                JohnDog.Say("Console", "Did you mean 'give <item>'?");
                                Console.ReadKey();
                            }
                            break;
                        case "view":
                            if (cmds.Length > 1)
                            {
                                switch (cmds[1].ToLower())
                                {
                                    case "inventory":
                                        JohnDog.ViewInventory(player);
                                        Console.ReadKey();
                                        break;
                                    default:
                                        JohnDog.Say("Console", "Did you mean 'view inventory'?");
                                        Console.ReadKey();
                                        break;
                                }
                            }
                            else
                            {
                                JohnDog.Say("Console", "Did you mean 'view inventory'?");
                                Console.ReadKey();
                            }
                            break;
                        case "attack":
                            if (cmds.Length > 1)
                            {
                                switch (cmds[1].ToLower())
                                {
                                    case "pirate":
                                        Enemies.LowLevel.SetPirate();
                                        Battle.Begin(player, Enemies.LowLevel.Pirate, true);
                                        break;
                                    case "slime":
                                        Enemies.LowLevel.SetSlime();
                                        Battle.Begin(player, Enemies.LowLevel.Slime, true);
                                        break;
                                    default:
                                        JohnDog.Say("Battle Manager", "You can't attack nothing!");
                                        break;
                                }
                            }
                            else
                            {
                                JohnDog.Say("Console", "Did you mean 'attack <enemy>'?");
                                Console.ReadKey();
                            }
                            break;
                        case "examine":
                            if (cmds.Length > 2) Item.Examine(player, cmds[1].ToLower(), cmds[2].ToLower());
                            else Item.Examine(player, cmds[1].ToLower());
                            break;
                        case "drop":
                            Item.Drop(player, cmds[1].ToLower());
                            break;
                        default:
                            JohnDog.Say("Console", "Please enter something!");
                            Thread.Sleep(1250);
                            break;
                    }
                }
                Console.Clear();
            }
            Console.ReadKey();
        }
    }
}
