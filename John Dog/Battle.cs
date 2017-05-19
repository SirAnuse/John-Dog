using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using Console = Colorful.Console;

namespace John_Dog
{
    class Battle
    {
        public static string Command { get; set; }
        public static bool OngoingBattle { get; set; }
        public static void Begin (Player player, Enemy enemy, bool firstTime)
        {
            Console.Clear();
            OngoingBattle = true;
            NPC.Say("Battle Manager", "You challenge: " + enemy.Name + "!");
            NPC.Say("Battle Manager", "Let the battle begin!");
            Thread.Sleep(1000);
            while (OngoingBattle)
            {
                Console.Clear();
                if (firstTime)
                {
                    NPC.Say("Battle Manager", "To attack, use the command \"attack\".");
                    NPC.Say("Battle Manager", "To use your shield, use the command \"shieldbash\".");
                }
                Command = Console.ReadLine();
                Console.Clear();
                switch (Command.ToLower())
                {
                    case "attack":
                        NPC.Say("Battle Manager", "You attack with your " + player.Inventory[1].Name + "!");
                        enemy.Damage(player.Inventory[1], player, enemy);
                        player.Damage(enemy, player);
                        Console.Write("\nYou take " + player.DamageTaken + " damage!", Color.DarkRed);
                        Console.Write("\nYou deal " + enemy.DamageDealt + " damage!", Color.DarkOrange);
                        Console.Write("\n" + enemy.Name + " is on " + enemy.HP + " HP!", Color.Orange);
                        Console.Write("\nYou are on " + player.HP + " HP!", Color.Red);
                        Console.ReadKey();
                        break;
                    default:
                        NPC.Say("Battle Manager", "Enter a valid command!");
                        Console.ReadKey();
                        Thread.Sleep(250);
                        break;
                }
            }
        }
    }
}
