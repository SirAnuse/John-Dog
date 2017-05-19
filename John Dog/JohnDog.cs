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
        public static void HandleDamageText (Player player, Enemy enemy)
        {
            Console.Write("\nYou deal " + enemy.DamageDealt + " damage!", Color.DarkOrange);
            Console.Write("\n" + enemy.Name + " is on " + enemy.HP + " HP!", Color.Orange);
            if (enemy.Stunned) Console.Write("\n" + enemy.Name + " is unable to retaliate!", Color.DarkRed);
            else Console.Write("\nYou take " + player.DamageTaken + " damage!", Color.DarkRed);
            Console.Write("\nYou are on " + player.HP + " HP!", Color.Red);
        }

        public static void Say (string name, string text)
        {
            Console.Write("<" + name + "> ", Color.Orange);
            Console.Write(text + "\n", Color.White);
        }
    }
}
