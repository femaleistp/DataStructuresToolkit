using System;

namespace DataStructuresToolkit.StacksQueues
{
    public class MyQueue<T>
    {
        private T[] _items;
        private int _count;
        private int _head;
        private int _tail;
        /// <summary>
        /// Creates a new queue with the given initial capacity.
        /// </summary>
        /// <param name="initialCapacity">Starting array size (must be at least 1).</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when initialCapacity is less than 1.</exception>
        /// <remarks>complexity O(1) time and O(n) space</remarks>
        public MyQueue(int initialCapacity = 4)
        {
            if (initialCapacity < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(initialCapacity));
            }

            _items = new T[initialCapacity];
            _count = 0;
            _head = 0;
            _tail = 0;
        }
        /// <summary>
        /// Get the number of items currently in the queue.
        /// </summary>
        /// <remarks>Time O(1) and space O(1) complexity</remarks>
        public int Count
        {
            get { return _count; }
        }

        /// <summary>
        /// Adds an item to the end of the queue.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <remarks>Amortized O(1) time using a circular array and O(1) space complexity.</remarks>
        public void Enqueue(T item)
        {
            EnsureCapacityForOneMore();
            _items[_tail] = item;
            _tail++; // advance tail with circular wrap
            if (_tail == _items.Length)
            {
                _tail = 0;
            }
            _count++;
        }

        /// <summary>
        /// Returns the item at the front of the queue without removing it. 
        /// </summary>
        /// <returns>The item currently at the front of the queue.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception>
        /// <remarks>Runs in O(1) time and O(1) space complexity.</remarks>
        public T Peek()
        { 
            if (_count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return _items[_head];
        }

        /// <summary>
        /// Removes and returns the item at the front of the queue.
        /// </summary>
        /// <returns>The item that was removed from the front of the queue.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception>
        /// <remarks>Runs in O(1) time and O(1) space complexity.</remarks>
        public T Dequeue()
        {
            if (_count == 0)
            { 
                throw new InvalidOperationException("Queue is empty.");
            }

            T value = _items[_head]; // read current front

            _items[_head] = default(T); // clear reference

            _head++; // advance head with circular wrap
            if (_head == _items.Length)
            {
                _head = 0;
            }
            _count--;
            return value;
        }

        /// <summary>
        /// Ensures there is capacity for one more item, resizing if necessary.
        /// </summary>
        /// <remarks>complexity O(n) time and O(n) space</remarks>
        private void EnsureCapacityForOneMore()
        {
            if (_count < _items.Length)
            {
                return;
            }

            int newCapacity;
            if (_items.Length == 0)
            {
                newCapacity = 4;
            }
            else
            {
                newCapacity = _items.Length * 2;
            }

            T[] newArray = new T[newCapacity];

            for (int i = 0; i < _count; i++)
            {
                int sourceIndex = _head + i;
                if (sourceIndex >= _items.Length)
                { 
                    sourceIndex = sourceIndex - _items.Length;
                }
                newArray[i] = _items[sourceIndex];
            }

            _items = newArray;
            _head = 0;
            _tail = _count;
        }
    }
}
