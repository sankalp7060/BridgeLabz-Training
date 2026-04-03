using System;
using System.Collections;
using System.Collections.Generic;

namespace TechVilleSmartCity.Utilities.DataStructures
{
    /// <summary>
    /// Priority Queue implementation using binary heap
    /// Module 11: Priority Queue for emergency services
    /// </summary>
    /// <typeparam name="T">Type of elements</typeparam>
    public class CustomPriorityQueue<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        #region Private Fields
        private List<T> heap;
        private readonly object lockObject = new object();
        #endregion

        #region Public Properties
        public int Count
        {
            get { return heap.Count; }
        }

        public bool IsEmpty
        {
            get { return heap.Count == 0; }
        }
        #endregion

        #region Constructors
        public CustomPriorityQueue()
        {
            heap = new List<T>();
        }

        public CustomPriorityQueue(IEnumerable<T> collection)
        {
            heap = new List<T>(collection);
            BuildHeap();
        }
        #endregion

        #region Core Operations
        /// <summary>
        /// Add item with priority (higher priority = higher in queue)
        /// </summary>
        public void Enqueue(T item)
        {
            lock (lockObject)
            {
                heap.Add(item);
                HeapifyUp(heap.Count - 1);
            }
        }

        /// <summary>
        /// Remove and return highest priority item
        /// </summary>
        public T Dequeue()
        {
            lock (lockObject)
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Priority queue is empty");

                T result = heap[0];
                int lastIndex = heap.Count - 1;

                heap[0] = heap[lastIndex];
                heap.RemoveAt(lastIndex);

                if (!IsEmpty)
                {
                    HeapifyDown(0);
                }

                return result;
            }
        }

        /// <summary>
        /// Peek at highest priority item without removing
        /// </summary>
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Priority queue is empty");

            return heap[0];
        }

        public void Clear()
        {
            lock (lockObject)
            {
                heap.Clear();
            }
        }
        #endregion

        #region Heap Operations
        private void BuildHeap()
        {
            for (int i = (heap.Count / 2) - 1; i >= 0; i--)
            {
                HeapifyDown(i);
            }
        }

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parent = (index - 1) / 2;

                // If current item has higher priority than parent
                if (heap[index].CompareTo(heap[parent]) > 0)
                {
                    Swap(index, parent);
                    index = parent;
                }
                else
                {
                    break;
                }
            }
        }

        private void HeapifyDown(int index)
        {
            int leftChild,
                rightChild,
                largest;

            while (index < heap.Count)
            {
                leftChild = 2 * index + 1;
                rightChild = 2 * index + 2;
                largest = index;

                // Compare with left child
                if (leftChild < heap.Count && heap[leftChild].CompareTo(heap[largest]) > 0)
                {
                    largest = leftChild;
                }

                // Compare with right child
                if (rightChild < heap.Count && heap[rightChild].CompareTo(heap[largest]) > 0)
                {
                    largest = rightChild;
                }

                if (largest != index)
                {
                    Swap(index, largest);
                    index = largest;
                }
                else
                {
                    break;
                }
            }
        }

        private void Swap(int i, int j)
        {
            T temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
        #endregion

        #region IEnumerable Implementation
        public IEnumerator<T> GetEnumerator()
        {
            // Return items in priority order without modifying queue
            var copy = new List<T>(heap);
            copy.Sort();
            copy.Reverse();
            return copy.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
