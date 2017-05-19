using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace John_Dog.Enemies
{
    class LowLevel
    {
        public static Enemy Pirate = new Enemy();
        public static void SetPirate()
        {
            // Pirate
            Pirate.Alive = true;
            Pirate.DEF = 5;
            Pirate.MinDMG = 5;
            Pirate.MaxDMG = 15;
            Pirate.HP = 125;
            Pirate.MP = 75;
            Pirate.Name = "John the Pirate";            
        }
    }
}
