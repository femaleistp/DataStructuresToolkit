using System;
using System.Collections.Generic;

namespace DataStructuresToolkit
{
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

            // Todo: implement bubble down (heapify down)
            return _heap[0];
        }

        /// <summary>
        /// Gets the number of elements in the priority queue.
        /// </summary>
        /// <remarks>Complexity time O(1) and space O(1).</remarks></remarks>
        public int Count => _heap.Count;
    }
}
