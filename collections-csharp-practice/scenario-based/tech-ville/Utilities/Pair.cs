namespace TechVilleSmartCity.Utilities
{
    /// <summary>
    /// Generic Pair class for key-value associations
    /// Module 16: Generics - Multiple type parameters
    /// </summary>
    /// <typeparam name="K">Key type</typeparam>
    /// <typeparam name="V">Value type</typeparam>
    public class Pair<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }

        public Pair() { }

        public Pair(K key, V value)
        {
            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Key}: {Value}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Pair<K, V> other = (Pair<K, V>)obj;
            return Key.Equals(other.Key) && Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return (Key?.GetHashCode() ?? 0) ^ (Value?.GetHashCode() ?? 0);
        }
    }
}
