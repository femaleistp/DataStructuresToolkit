using System;
using System.Collections.Generic;

namespace DataStructuresToolkit
{
    /// <summary>
    /// A simple implementation of a priority queue using a binary heap.
    /// </summary>
    public class PriorityQueue
    {
        private readonly List<int> _heap = new List<int>();

        /// <summary>
        /// Adds an element to the priority queue.
        /// </summary>
        /// <param name="value">The value to add.</param>
        /// <remarks>Complexity time O(log n) and space O(1).</remarks>
        public void Enqueue(int value)
        {
            _heap.Add(value);
            // Todo: implement bubble up: HeapifyUp(_heap.Count - 1);
            HeapifyUp(_heap.Count - 1);
        }

        /// <summary>
        /// Bubbles up the element at the specified index to maintain the heap property.
        /// </summary>
        /// <param name="index">The index of the element to bubble up.</param>
        /// <remarks>Complexity time O(log n) and space O(1).</remarks>
        private void HeapifyUp(int index)
        {
            while (index > 0)
            { 
                int parentIndex = (index - 1) / 2;
                if (_heap[index] >= _heap[parentIndex])
                {
                    break;
                }

                // Swap child and parent
                int temp = _heap[index];
                _heap[index] = _heap[parentIndex];
                _heap[parentIndex] = temp;
                index = parentIndex;
            }    
        }

        /// <summary>
        /// Removes and returns the element with the highest priority (smallest value).
        /// </summary>
        /// <returns>The element with the highest priority.</returns>
        /// <exception cref="InvalidOperationException">The priority queue is empty.</exception>
        /// <remarks>Complexity time O(log n) and space O(1).</remarks>
        public int Dequeue()
        { 
            if (_heap.Count == 0)
                throw new InvalidOperationException("Priority queue is empty.");

            // Heapify down not implemented yet, so just remove the root for now
            int minValue = _heap[0];
            int lastValue = _heap[_heap.Count - 1];

            _heap.RemoveAt(_heap.Count - 1);

            if (_heap.Count > 0)
            {
                _heap[0] = lastValue;
                HeapifyDown(0);
            }
            return minValue;
        }

        /// <summary>
        /// Bubbles down the element at the specified index to maintain the heap property.
        /// </summary>
        /// <param name="index">The index of the element to bubble down.</param>
        /// <remarks>Complexity time O(log n) and space O(1).</remarks>
        private void HeapifyDown(int index)
        {
            int lastIndex = _heap.Count - 1;

            while (true)
            {
                int left = 2 * index + 1;
                int right = 2 * index + 2;
                int smallest = index;

                if (left <= lastIndex && _heap[left] < _heap[smallest])
                {
                    smallest = left;
                }

                if (right <= lastIndex && _heap[right] < _heap[smallest])
                {
                    smallest = right;
                }
                if (smallest == index)
                {
                    break;
                }

                // Swap
                int temp = _heap[index];
                _heap[index] = _heap[smallest];
                _heap[smallest] = temp;

                index = smallest;
            }
        }

        /// <summary>
        /// Gets the number of elements in the priority queue.
        /// </summary>
        /// <remarks>Complexity time O(1) and space O(1).</remarks></remarks>
        public int Count => _heap.Count;
    }
}
