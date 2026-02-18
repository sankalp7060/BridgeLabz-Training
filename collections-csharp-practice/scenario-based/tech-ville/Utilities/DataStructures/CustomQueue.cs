using System;
using System.Collections;
using System.Collections.Generic;

namespace TechVilleSmartCity.Utilities.DataStructures
{
    /// <summary>
    /// Custom Queue implementation (FIFO)
    /// Module 11: Queue data structure
    /// </summary>
    /// <typeparam name="T">Type of elements</typeparam>
    public class CustomQueue<T> : IEnumerable<T>
    {
        #region Private Fields
        private T[] array;
        private int head;
        private int tail;
        private int size;
        private int capacity;
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

        public bool IsFull
        {
            get { return size == capacity; }
        }

        public int Capacity
        {
            get { return capacity; }
        }
        #endregion

        #region Constructors
        public CustomQueue()
            : this(10) { }

        public CustomQueue(int capacity)
        {
            this.capacity = capacity > 0 ? capacity : 10;
            array = new T[this.capacity];
            head = 0;
            tail = 0;
            size = 0;
        }

        public CustomQueue(IEnumerable<T> collection)
            : this()
        {
            foreach (var item in collection)
            {
                Enqueue(item);
            }
        }
        #endregion

        #region Core Operations
        /// <summary>
        /// Add item to the end of queue
        /// </summary>
        public void Enqueue(T item)
        {
            lock (lockObject)
            {
                if (IsFull)
                {
                    Resize(capacity * 2);
                }

                array[tail] = item;
                tail = (tail + 1) % capacity;
                size++;
            }
        }

        /// <summary>
        /// Remove and return item from front
        /// </summary>
        public T Dequeue()
        {
            lock (lockObject)
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Queue is empty");

                T item = array[head];
                array[head] = default(T); // Clear reference
                head = (head + 1) % capacity;
                size--;

                return item;
            }
        }

        /// <summary>
        /// Return front item without removing
        /// </summary>
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty");

            return array[head];
        }

        public void Clear()
        {
            lock (lockObject)
            {
                Array.Clear(array, 0, capacity);
                head = 0;
                tail = 0;
                size = 0;
            }
        }
        #endregion

        #region Helper Methods
        private void Resize(int newCapacity)
        {
            T[] newArray = new T[newCapacity];
            if (size > 0)
            {
                if (head < tail)
                {
                    Array.Copy(array, head, newArray, 0, size);
                }
                else
                {
                    Array.Copy(array, head, newArray, 0, capacity - head);
                    Array.Copy(array, 0, newArray, capacity - head, tail);
                }
            }

            array = newArray;
            capacity = newCapacity;
            head = 0;
            tail = size;
        }

        public bool Contains(T item)
        {
            int index = head;
            for (int i = 0; i < size; i++)
            {
                if (array[index].Equals(item))
                    return true;
                index = (index + 1) % capacity;
            }
            return false;
        }
        #endregion

        #region IEnumerable Implementation
        public IEnumerator<T> GetEnumerator()
        {
            int index = head;
            for (int i = 0; i < size; i++)
            {
                yield return array[index];
                index = (index + 1) % capacity;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
