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
using Console = Colorful.Console;

namespace John_Dog
{
    class Program
    {
        static void Main(string[] args)
        {
            string entry;

            Player player = new Player();
            Swords.SetSwords();
            Shields.SetShields();
            player.Inventory.Add(1, Swords.ShortSword);
            player.Inventory.Add(2, Shields.WoodenShield);
            JohnDog.Say("Console", "Welcome to John Dog v0.0.1, player!");
            JohnDog.Say("Console", "What is your name?");
            Console.Write(">", Color.NavajoWhite);
            player.Name = Console.ReadLine();
            JohnDog.Say("Console", "Welcome, " + player.Name + "! I hope you enjoy your time playing John Dog!");
            Thread.Sleep(1500);
            Console.Clear();
            bool firstBit = true;
            bool running = true;
            while (running)
            {
                if (firstBit)
                { 
                    JohnDog.Say("Console", "You are on a beach. You are carrying a short sword and wooden shield.");
                    JohnDog.Say("Console", "There's a pirate wandering across the beach.");
                    JohnDog.Say("Console", "You can say \"examine weapon\", for example, to examine your short sword.");
                    entry = Console.ReadLine();
                    Console.Clear();
                    switch (entry.ToLower())
                    {
                        case "attack pirate":
                            Enemies.LowLevel.SetPirate();
                            Battle.Begin(player, Enemies.LowLevel.Pirate, true);
                            break;
                        case "examine weapon":
                            Item.PrintDetails(player.Inventory[1]);
                            Console.Write("\nPress 'Enter' once you are finished reading.", Color.Yellow);
                            Console.ReadKey();
                            break;
                        case "examine shield":
                            Item.PrintDetails(player.Inventory[2]);
                            Console.Write("\nPress 'Enter' once you are finished reading.", Color.Yellow);
                            Console.ReadKey();
                            break;
                        default:
                            JohnDog.Say("Console", "Please enter something!");
                            Thread.Sleep(1250);
                            break;
                    }
                    Console.Clear();
                }
            }
            Console.ReadKey();
        }
    }
}
