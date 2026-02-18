using System;
using System.Collections.Generic;

namespace TechVilleSmartCity.Utilities
{
    /// <summary>
    /// Generic container class for TechVille
    /// Module 16: Generics - Type-safe container system
    /// </summary>
    /// <typeparam name="T">Type of items to store</typeparam>
    public class CityContainer<T>
    {
        #region Private Fields
        private List<T> items;
        private int capacity;
        private readonly object lockObject = new object();
        #endregion

        #region Public Properties
        public int Count
        {
            get { return items.Count; }
        }

        public int Capacity
        {
            get { return capacity; }
            set
            {
                if (value < items.Count)
                    throw new InvalidOperationException(
                        "Capacity cannot be less than current count"
                    );
                capacity = value;
            }
        }

        public bool IsEmpty
        {
            get { return items.Count == 0; }
        }

        public bool IsFull
        {
            get { return items.Count >= capacity; }
        }
        #endregion

        #region Constructors
        public CityContainer()
            : this(100) { }

        public CityContainer(int capacity)
        {
            this.capacity = capacity > 0 ? capacity : 100;
            items = new List<T>(this.capacity);
        }

        public CityContainer(IEnumerable<T> collection)
        {
            items = new List<T>(collection);
            capacity = items.Count * 2;
        }
        #endregion

        #region Core Generic Methods
        /// <summary>
        /// Add an item to the container
        /// </summary>
        public void Add(T item)
        {
            lock (lockObject)
            {
                if (IsFull)
                    throw new InvalidOperationException("Container is full");

                items.Add(item);
            }
        }

        /// <summary>
        /// Get item at specified index
        /// </summary>
        public T Get(int index)
        {
            if (index < 0 || index >= items.Count)
                throw new IndexOutOfRangeException($"Index {index} is out of range");

            return items[index];
        }

        /// <summary>
        /// Remove an item from the container
        /// </summary>
        public bool Remove(T item)
        {
            lock (lockObject)
            {
                return items.Remove(item);
            }
        }

        /// <summary>
        /// Remove item at specified index
        /// </summary>
        public void RemoveAt(int index)
        {
            lock (lockObject)
            {
                if (index < 0 || index >= items.Count)
                    throw new IndexOutOfRangeException($"Index {index} is out of range");

                items.RemoveAt(index);
            }
        }

        /// <summary>
        /// Clear all items
        /// </summary>
        public void Clear()
        {
            lock (lockObject)
            {
                items.Clear();
            }
        }

        /// <summary>
        /// Check if container contains item
        /// </summary>
        public bool Contains(T item)
        {
            return items.Contains(item);
        }

        /// <summary>
        /// Get all items
        /// </summary>
        public List<T> GetAll()
        {
            return new List<T>(items);
        }

        /// <summary>
        /// Indexer for array-like access
        /// </summary>
        public T this[int index]
        {
            get { return Get(index); }
            set
            {
                lock (lockObject)
                {
                    if (index < 0 || index >= items.Count)
                        throw new IndexOutOfRangeException($"Index {index} is out of range");

                    items[index] = value;
                }
            }
        }
        #endregion

        #region Generic Methods with Predicates
        /// <summary>
        /// Find items matching a condition
        /// Module 16: Generic method with predicate
        /// </summary>
        public List<T> FindAll(Predicate<T> match)
        {
            return items.FindAll(match);
        }

        /// <summary>
        /// Find first item matching condition
        /// </summary>
        public T Find(Predicate<T> match)
        {
            return items.Find(match);
        }

        /// <summary>
        /// Check if any item matches condition
        /// </summary>
        public bool Exists(Predicate<T> match)
        {
            return items.Exists(match);
        }
        #endregion

        #region Generic Methods with Actions
        /// <summary>
        /// Perform action on each item
        /// </summary>
        public void ForEach(Action<T> action)
        {
            items.ForEach(action);
        }

        /// <summary>
        /// Convert container to different type
        /// Module 16: Generic conversion method
        /// </summary>
        public CityContainer<TResult> ConvertAll<TResult>(Converter<T, TResult> converter)
        {
            var result = new CityContainer<TResult>(capacity);
            result.AddRange(items.ConvertAll(converter));
            return result;
        }
        #endregion

        #region Bulk Operations
        public void AddRange(IEnumerable<T> collection)
        {
            lock (lockObject)
            {
                items.AddRange(collection);
            }
        }

        public void RemoveRange(int index, int count)
        {
            lock (lockObject)
            {
                items.RemoveRange(index, count);
            }
        }
        #endregion
    }
}
