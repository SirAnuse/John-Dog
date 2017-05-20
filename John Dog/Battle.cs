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
            Thread.Sleep(2500);
            while (OngoingBattle)
            {
                Console.Clear();
                if (enemy.HP <= 0 || !enemy.Alive)
                {
                    JohnDog.Say("Battle Manager", "You have killed " + enemy.Name + "!");
                    enemy.DropLoot(player, enemy);
                    if (enemy.HasLootDropped)
                    {
                        Console.Write("<Battle Manager> ", Color.Orange);
                        Console.Write("You have looted a ", Color.White);
                        Console.Write(enemy.LootDropped.Name, Color.Khaki);
                        Console.Write("!\n", Color.White);
                        Console.ReadKey();
                        OngoingBattle = false;
                        enemy.ResetLoot();
                        player.BattleCompleted = true;
                        return;
                    }
                    else
                    {
                        JohnDog.Say("Battle Manager", "Sadly, " + enemy.Name + " did not drop anything.");
                        Console.ReadKey();
                        OngoingBattle = false;
                        enemy.ResetLoot();
                        player.BattleCompleted = true;
                        return;
                    }
                }
                if (enemy.Alive || enemy.HP > 0)
                {
                    JohnDog.Say("Battle Manager", "To attack, use the command \"attack\".");
                    JohnDog.Say("Battle Manager", "To use your shield, use the command \"shieldbash\".");
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
                            
                            if (player.MP < player.Inventory[2].ManaCost)
                            {
                                JohnDog.Say("Battle Manager", "You don't have the MP to do that right now!");
                                Console.ReadKey();
                                break;
                            }
                            player.MP += player.CalculateMPRegen(player);
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
}
