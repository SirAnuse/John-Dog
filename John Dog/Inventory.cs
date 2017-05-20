using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace John_Dog
{
    public class PlayerInventory<TKey, TValue>
    {
        private Dictionary<TKey, TValue> dictionary;
        private Queue<TKey> keys;
        private int capacity;

        public PlayerInventory(int capacity)
        {
            this.keys = new Queue<TKey>(capacity);
            this.capacity = capacity;
            this.dictionary = new Dictionary<TKey, TValue>(capacity);
        }

        public int Count ()
        {
            return dictionary.Count();
        }

        public void Remove(TKey key)
        {
            dictionary.Remove(key);
        }

        public void Add(TKey key, TValue value)
        {
            if (dictionary.Count == capacity)
            {
                var oldestKey = keys.Dequeue();
                dictionary.Remove(oldestKey);
            }

            dictionary.Add(key, value);
            keys.Enqueue(key);
        }

        public TValue this[TKey key]
        {
            get { return dictionary[key]; }
        }
    }
}
