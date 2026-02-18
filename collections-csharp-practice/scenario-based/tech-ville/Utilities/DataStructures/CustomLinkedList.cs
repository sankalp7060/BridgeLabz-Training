using System;
using System.Collections;
using System.Collections.Generic;

namespace TechVilleSmartCity.Utilities.DataStructures
{
    /// <summary>
    /// Custom implementation of Singly Linked List
    /// Module 10: Linked Lists
    /// </summary>
    /// <typeparam name="T">Type of elements</typeparam>
    public class CustomLinkedList<T> : IEnumerable<T>
    {
        #region Node Class
        private class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }

            public Node(T data)
            {
                Data = data;
                Next = null;
            }
        }
        #endregion

        #region Private Fields
        private Node head;
        private Node tail;
        private int count;
        private readonly object lockObject = new object();
        #endregion

        #region Public Properties
        public int Count
        {
            get { return count; }
        }

        public bool IsEmpty
        {
            get { return head == null; }
        }

        public T First
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException("List is empty");
                return head.Data;
            }
        }

        public T Last
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException("List is empty");
                return tail.Data;
            }
        }
        #endregion

        #region Constructors
        public CustomLinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }
        #endregion

        #region Add Operations
        /// <summary>
        /// Add item at the beginning
        /// </summary>
        public void AddFirst(T item)
        {
            lock (lockObject)
            {
                Node newNode = new Node(item);
                newNode.Next = head;
                head = newNode;

                if (count == 0)
                    tail = head;

                count++;
            }
        }

        /// <summary>
        /// Add item at the end
        /// </summary>
        public void AddLast(T item)
        {
            lock (lockObject)
            {
                Node newNode = new Node(item);

                if (IsEmpty)
                {
                    head = newNode;
                    tail = newNode;
                }
                else
                {
                    tail.Next = newNode;
                    tail = newNode;
                }

                count++;
            }
        }

        /// <summary>
        /// Insert at specified index
        /// </summary>
        public void InsertAt(int index, T item)
        {
            lock (lockObject)
            {
                if (index < 0 || index > count)
                    throw new IndexOutOfRangeException($"Index {index} is out of range");

                if (index == 0)
                {
                    AddFirst(item);
                    return;
                }

                if (index == count)
                {
                    AddLast(item);
                    return;
                }

                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                Node newNode = new Node(item);
                newNode.Next = current.Next;
                current.Next = newNode;

                count++;
            }
        }
        #endregion

        #region Remove Operations
        /// <summary>
        /// Remove first item
        /// </summary>
        public T RemoveFirst()
        {
            lock (lockObject)
            {
                if (IsEmpty)
                    throw new InvalidOperationException("List is empty");

                T data = head.Data;
                head = head.Next;

                if (head == null)
                    tail = null;

                count--;
                return data;
            }
        }

        /// <summary>
        /// Remove last item
        /// </summary>
        public T RemoveLast()
        {
            lock (lockObject)
            {
                if (IsEmpty)
                    throw new InvalidOperationException("List is empty");

                if (count == 1)
                {
                    return RemoveFirst();
                }

                Node current = head;
                while (current.Next != tail)
                {
                    current = current.Next;
                }

                T data = tail.Data;
                current.Next = null;
                tail = current;

                count--;
                return data;
            }
        }

        /// <summary>
        /// Remove specific item
        /// </summary>
        public bool Remove(T item)
        {
            lock (lockObject)
            {
                if (IsEmpty)
                    return false;

                if (head.Data.Equals(item))
                {
                    RemoveFirst();
                    return true;
                }

                Node current = head;
                Node previous = null;

                while (current != null && !current.Data.Equals(item))
                {
                    previous = current;
                    current = current.Next;
                }

                if (current == null)
                    return false;

                previous.Next = current.Next;

                if (current == tail)
                    tail = previous;

                count--;
                return true;
            }
        }

        /// <summary>
        /// Remove at specified index
        /// </summary>
        public T RemoveAt(int index)
        {
            lock (lockObject)
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException($"Index {index} is out of range");

                if (index == 0)
                    return RemoveFirst();

                if (index == count - 1)
                    return RemoveLast();

                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                T data = current.Next.Data;
                current.Next = current.Next.Next;

                count--;
                return data;
            }
        }

        public void Clear()
        {
            lock (lockObject)
            {
                head = null;
                tail = null;
                count = 0;
            }
        }
        #endregion

        #region Search Operations
        /// <summary>
        /// Find index of item (linear search)
        /// </summary>
        public int IndexOf(T item)
        {
            Node current = head;
            int index = 0;

            while (current != null)
            {
                if (current.Data.Equals(item))
                    return index;

                current = current.Next;
                index++;
            }

            return -1;
        }

        /// <summary>
        /// Check if item exists
        /// </summary>
        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }
        #endregion

        #region IEnumerable Implementation
        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        #region Utility Methods
        /// <summary>
        /// Reverse the linked list
        /// </summary>
        public void Reverse()
        {
            lock (lockObject)
            {
                if (count <= 1)
                    return;

                Node prev = null;
                Node current = head;
                tail = head;

                while (current != null)
                {
                    Node next = current.Next;
                    current.Next = prev;
                    prev = current;
                    current = next;
                }

                head = prev;
            }
        }

        /// <summary>
        /// Get array representation
        /// </summary>
        public T[] ToArray()
        {
            T[] array = new T[count];
            Node current = head;
            int index = 0;

            while (current != null)
            {
                array[index++] = current.Data;
                current = current.Next;
            }

            return array;
        }
        #endregion
    }
}
