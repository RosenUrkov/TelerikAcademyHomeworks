using HashSet;
using System.Collections.Generic;
using System;
using System.Collections;
using System.Linq;

namespace Dictionary
{
    public class Dictionary<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        private HashSet.HashSet<KeyValuePair<K, V>> set;

        public Dictionary()
        {
            this.set = new HashSet.HashSet<KeyValuePair<K, V>>();
        }

        public int Count => this.set.Count;

        public void Clear() => this.set.Clear();

        public bool Add(K key, V value)
        {
            return this.set.Add(new KeyValuePair<K, V>(key, value));
        }

        public bool Remove(K key)
        {
            return this.set.Remove(new KeyValuePair<K, V>(key, default(V)));
        }

        public KeyValuePair<K, V> Find(K key)
        {
            foreach (var item in set)
            {
                if (item.Key.Equals(key))
                {
                    return item;
                }
            }

            return null;
        }

        public bool ContainsKey(K key)
        {
            return this.set.Contains(new KeyValuePair<K, V>(key, default(V)));
        }

        public K[] Keys()
        {
            return this.set
                .Select(x => x.Key)
                .ToArray();
        }

        public V[] Values()
        {
            return this.set
                .Select(x => x.Value)
                .ToArray();
        }

        public V this[K key]
        {
            get
            {
                return this.Find(key).Value;
            }
            set
            {
                var found = this.Find(key);
                if (found is null)
                {
                    found = new KeyValuePair<K, V>(key, value);
                }
                else
                {
                    found.Value = value;
                }
            }
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var item in set)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
