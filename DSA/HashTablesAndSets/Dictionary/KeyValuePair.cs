namespace Dictionary
{
    public class KeyValuePair<K, V>
    {
        public KeyValuePair(K key, V value)
        {
            this.Key = key;
            this.Value = value;
        }

        public K Key { get; }

        public V Value { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as KeyValuePair<K, V>;
            return this.Key.Equals(other.Key);
        }

        public override int GetHashCode()
        {
            return this.Key.GetHashCode();
        }

        public override string ToString()
        {
            return $"[{this.Key} - {this.Value}]";
        }
    }
}
