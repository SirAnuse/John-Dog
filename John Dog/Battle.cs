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
            player.CalculateDefBonus(player);
            Console.Clear();
            OngoingBattle = true;
            JohnDog.Say("Battle Manager", "You challenge: " + enemy.Name + "!");
            JohnDog.Say("Battle Manager", "Let the battle begin!");
            Thread.Sleep(1000);
            while (OngoingBattle)
            {
                Console.Clear();
                if (firstTime)
                {
                    JohnDog.Say("Battle Manager", "To attack, use the command \"attack\".");
                    JohnDog.Say("Battle Manager", "To use your shield, use the command \"shieldbash\".");
                }
                Command = Console.ReadLine();
                Console.Clear();
                switch (Command.ToLower())
                {
                    case "attack":
                        player.MP += player.CalculateMPRegen(player);
                        player.BattleTurnsCounter++;
                        JohnDog.Say("Battle Manager", "You attack with your " + player.Inventory[1].Name + "!");
                        enemy.Damage(player.Inventory[1], player, enemy);
                        if (!enemy.Stunned) player.Damage(enemy, player);
                        JohnDog.HandleBattleText(player, enemy);
                        Console.ReadKey();
                        break;
                    case "shieldbash":
                        player.BattleTurnsCounter++;
                        player.MP += player.CalculateMPRegen(player);
                        if (player.MP < player.Inventory[2].ManaCost)
                        {
                            JohnDog.Say("Battle Manager", "You don't have the MP to do that right now!");
                            Console.ReadKey();
                            break;
                        }
                        player.MP -= player.Inventory[2].ManaCost;
                        enemy.Stunned = true;
                        enemy.StunnedDuration = player.Inventory[2].StunDuration;
                        JohnDog.Say("Battle Manager", "You use your " + player.Inventory[2].Name + " to bash " + enemy.Name + "!");
                        enemy.Damage(player.Inventory[2], player, enemy);
                        if (!enemy.Stunned) player.Damage(enemy, player);
                        JohnDog.HandleBattleText(player, enemy);
                        Console.ReadKey();
                        break;
                    default:
                        JohnDog.Say("Battle Manager", "Enter a valid command!");
                        Console.ReadKey();
                        Thread.Sleep(1250);
                        break;
                }
            }
        }
    }
}
