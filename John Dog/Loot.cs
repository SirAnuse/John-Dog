using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace John_Dog
{
    class Loot
    {
        public static Dictionary<int, int> Amount = new Dictionary<int, int>();
        public static Dictionary<int, Item> ItemToDrop = new Dictionary<int, Item>();
        public static Dictionary<int, float> DropRate = new Dictionary<int, float>();

        // Loot Documentation [Simple As Heck]
        // - written by Rustiniz / Sir Anuse
        //
        // Make sure the first part of the dictionary is the same as the other parts of the item you want to drop! 
        // This is the drop's 'ID' in a sense.
        // Say, if you want 3 Short Swords to drop with a rate of 50%.
    }
}
