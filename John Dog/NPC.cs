using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;

namespace John_Dog
{
    class NPC
    {
        public static void Say (string name, string text)
        {
            Console.Write("<" + name + "> ", Color.Orange);
            Console.Write(text + "\n", Color.White);
        }
    }
}
