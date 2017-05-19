using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;

namespace John_Dog
{
    class JohnDog
    {
        public static bool DodgeHandler(Enemy enemy)
        {
            float step1 = enemy.Evasion / 50;
            float step2 = 0.15f * step1;
            float prob = step2 * 100;
            int DiceRoll = new Random().Next(0, 100);
            if (DiceRoll < prob) return true;
            else return false;
        }
        public static bool DodgeHandler (Player player)
        {
            float step1 = player.Evasion / 50;
            float step2 = 0.15f * step1;
            float prob = step2 * 100;
            int DiceRoll = new Random().Next(0, 100);
            if (DiceRoll < prob) return true;
            else return false;
        }
        public static void HandleDamageText (Player player, Enemy enemy)
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

        public static void Say (string name, string text)
        {
            Console.Write("<" + name + "> ", Color.Orange);
            Console.Write(text + "\n", Color.White);
        }
    }
}
