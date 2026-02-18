using System;
using System.Collections;
using System.Collections.Generic;

namespace TechVilleSmartCity.Utilities.DataStructures
{
    /// <summary>
    /// Custom Stack implementation (LIFO)
    /// Module 11: Stack data structure
    /// </summary>
    /// <typeparam name="T">Type of elements</typeparam>
    public class CustomStack<T> : IEnumerable<T>
    {
        #region Private Fields
        private T[] array;
        private int top;
        private int capacity;
        private readonly object lockObject = new object();
        #endregion

        #region Public Properties
        public int Count
        {
            get { return top + 1; }
        }

        public bool IsEmpty
        {
            get { return top == -1; }
        }

        public bool IsFull
        {
            get { return top == capacity - 1; }
        }

        public int Capacity
        {
            get { return capacity; }
        }
        #endregion

        #region Constructors
        public CustomStack()
            : this(10) { }

        public CustomStack(int capacity)
        {
            this.capacity = capacity > 0 ? capacity : 10;
            array = new T[this.capacity];
            top = -1;
        }

        public CustomStack(IEnumerable<T> collection)
            : this()
        {
            foreach (var item in collection)
            {
                Push(item);
            }
        }
        #endregion

        #region Core Operations
        /// <summary>
        /// Push item onto stack
        /// </summary>
        public void Push(T item)
        {
            lock (lockObject)
            {
                if (IsFull)
                {
                    Resize(capacity * 2);
                }

                array[++top] = item;
            }
        }

        /// <summary>
        /// Pop item from stack
        /// </summary>
        public T Pop()
        {
            lock (lockObject)
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Stack is empty");

                T item = array[top];
                array[top--] = default(T); // Clear reference

                // Shrink if necessary
                if (top > 0 && top < capacity / 4)
                {
                    Resize(capacity / 2);
                }

                return item;
            }
        }

        /// <summary>
        /// Peek at top item without removing
        /// </summary>
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");

            return array[top];
        }

        public void Clear()
        {
            lock (lockObject)
            {
                Array.Clear(array, 0, capacity);
                top = -1;
            }
        }
        #endregion

        #region Helper Methods
        private void Resize(int newCapacity)
        {
            T[] newArray = new T[newCapacity];
            Array.Copy(array, 0, newArray, 0, top + 1);
            array = newArray;
            capacity = newCapacity;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i <= top; i++)
            {
                if (array[i].Equals(item))
                    return true;
            }
            return false;
        }
        #endregion

        #region IEnumerable Implementation
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = top; i >= 0; i--)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
