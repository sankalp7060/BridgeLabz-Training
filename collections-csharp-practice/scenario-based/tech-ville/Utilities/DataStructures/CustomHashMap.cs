using System;
using System.Collections;
using System.Collections.Generic;

namespace TechVilleSmartCity.Utilities.DataStructures
{
    /// <summary>
    /// Custom HashMap implementation
    /// Module 12: Hash functions and collision handling
    /// </summary>
    /// <typeparam name="K">Key type</typeparam>
    /// <typeparam name="V">Value type</typeparam>
    public class CustomHashMap<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        #region Node Class
        private class Node
        {
            public K Key { get; set; }
            public V Value { get; set; }
            public Node Next { get; set; }

            public Node(K key, V value)
            {
                Key = key;
                Value = value;
                Next = null;
            }
        }
        #endregion

        #region Private Fields
        private Node[] buckets;
        private int size;
        private readonly double loadFactor = 0.75;
        private readonly object lockObject = new object();
        #endregion

        #region Public Properties
        public int Count
        {
            get { return size; }
        }

        public bool IsEmpty
        {
            get { return size == 0; }
        }

        public int BucketCount
        {
            get { return buckets.Length; }
        }
        #endregion

        #region Constructors
        public CustomHashMap()
            : this(16) { }

        public CustomHashMap(int capacity)
        {
            capacity = GetNextPrime(capacity);
            buckets = new Node[capacity];
            size = 0;
        }
        #endregion

        #region Hash Functions
        /// <summary>
        /// Primary hash function - computes bucket index
        /// Module 12: Hash function design
        /// </summary>
        private int Hash(K key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            // Get hash code and ensure positive
            int hash = key.GetHashCode() & 0x7FFFFFFF;
            return hash % buckets.Length;
        }

        /// <summary>
        /// Secondary hash for collision resolution
        /// </summary>
        private int SecondaryHash(K key)
        {
            int hash = key.GetHashCode();
            // Mix the hash bits
            hash ^= (hash >> 20) ^ (hash >> 12);
            hash ^= (hash >> 7) ^ (hash >> 4);
            return hash & 0x7FFFFFFF;
        }
        #endregion

        #region Core Operations
        /// <summary>
        /// Add or update key-value pair
        /// </summary>
        public void Put(K key, V value)
        {
            lock (lockObject)
            {
                if (size >= buckets.Length * loadFactor)
                {
                    Resize();
                }

                int index = Hash(key);
                Node current = buckets[index];

                // Check if key already exists
                while (current != null)
                {
                    if (current.Key.Equals(key))
                    {
                        current.Value = value; // Update existing
                        return;
                    }
                    current = current.Next;
                }

                // Add new node at beginning of chain
                Node newNode = new Node(key, value);
                newNode.Next = buckets[index];
                buckets[index] = newNode;
                size++;
            }
        }

        /// <summary>
        /// Get value by key
        /// </summary>
        public V Get(K key)
        {
            int index = Hash(key);
            Node current = buckets[index];

            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    return current.Value;
                }
                current = current.Next;
            }

            throw new KeyNotFoundException($"Key '{key}' not found");
        }

        /// <summary>
        /// Try to get value (safe version)
        /// </summary>
        public bool TryGetValue(K key, out V value)
        {
            value = default(V);

            int index = Hash(key);
            Node current = buckets[index];

            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    value = current.Value;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Check if key exists
        /// </summary>
        public bool ContainsKey(K key)
        {
            int index = Hash(key);
            Node current = buckets[index];

            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Remove key-value pair
        /// </summary>
        public bool Remove(K key)
        {
            lock (lockObject)
            {
                int index = Hash(key);
                Node current = buckets[index];
                Node prev = null;

                while (current != null)
                {
                    if (current.Key.Equals(key))
                    {
                        if (prev == null)
                        {
                            buckets[index] = current.Next;
                        }
                        else
                        {
                            prev.Next = current.Next;
                        }
                        size--;
                        return true;
                    }
                    prev = current;
                    current = current.Next;
                }

                return false;
            }
        }

        public void Clear()
        {
            lock (lockObject)
            {
                buckets = new Node[buckets.Length];
                size = 0;
            }
        }
        #endregion

        #region Resize Operations
        private void Resize()
        {
            int newCapacity = GetNextPrime(buckets.Length * 2);
            Node[] oldBuckets = buckets;
            buckets = new Node[newCapacity];
            size = 0;

            // Rehash all existing entries
            foreach (Node node in oldBuckets)
            {
                Node current = node;
                while (current != null)
                {
                    Put(current.Key, current.Value);
                    current = current.Next;
                }
            }
        }

        private int GetNextPrime(int number)
        {
            while (!IsPrime(number))
            {
                number++;
            }
            return number;
        }

        private bool IsPrime(int number)
        {
            if (number < 2)
                return false;
            if (number == 2)
                return true;
            if (number % 2 == 0)
                return false;

            for (int i = 3; i * i <= number; i += 2)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
        #endregion

        #region IEnumerable Implementation
        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (Node bucket in buckets)
            {
                Node current = bucket;
                while (current != null)
                {
                    yield return new KeyValuePair<K, V>(current.Key, current.Value);
                    current = current.Next;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        #region Indexer
        public V this[K key]
        {
            get { return Get(key); }
            set { Put(key, value); }
        }
        #endregion
    }
}
