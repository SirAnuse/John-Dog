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
                        JohnDog.Say("Battle Manager", "You attack with your " + player.Inventory[1].Name + "!");
                        enemy.Damage(player.Inventory[1], player, enemy);
                        if (!enemy.Stunned) player.Damage(enemy, player);
                        JohnDog.HandleDamageText(player, enemy);
                        Console.ReadKey();
                        break;
                    case "shieldbash":
                        enemy.Stunned = true;
                        JohnDog.Say("Battle Manager", "You use your " + player.Inventory[2].Name + " to bash " + enemy.Name + "!");
                        enemy.Damage(player.Inventory[2], player, enemy);
                        if (!enemy.Stunned) player.Damage(enemy, player);
                        JohnDog.HandleDamageText(player, enemy);
                        Console.ReadKey();
                        break;
                    default:
                        JohnDog.Say("Battle Manager", "Enter a valid command!");
                        Console.ReadKey();
                        Thread.Sleep(250);
                        break;
                }
            }
        }
    }
}
