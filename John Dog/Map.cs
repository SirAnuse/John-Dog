using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using John_Dog.Enemies;

namespace John_Dog
{
    class Map
    {
        public Dictionary<int, Enemy> Enemies = new Dictionary<int, Enemy>();
        public static void GetEquipmentDescription (Player player)
        {
            JohnDog.Say("Equipment Info", "You are wielding a " + player.Inventory[1].Name + " and a " + player.Inventory[2].Name + ".");
        }
        public static void GetMapDescription (string area)
        {
            switch (area.ToLower())
            {
                case "forest":
                    JohnDog.Say("Map Info", "You are in a forest.");
                    break;
                default:
                    JohnDog.Say("Map Info", "You rest in the void... eternal darkness consumes as far as you can see.");
                    break;
            }
        }
        public static void GetMapEnemies (string area)
        {
            switch (area.ToLower())
            {
                case "forest":
                    JohnDog.Say("Enemy Info", "There is a Slime, simply sliming across the forest floor.");
                    JohnDog.Say("Enemy Info", "There's also a Pirate plundering the forests. Who knows why he's there.");
                    break;
                default:
                    JohnDog.Say("Enemy Info", "There seems to be nothing here.");
                    break;
            }
        }
    }
}
