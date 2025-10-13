using System;

namespace DataStructuresToolkit.StacksQueues
{
    /// <summary>
    /// Generic queue with circular array storage and doubling policy.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyQueue<T>
    {
        private T[] _items;
        private int _count;
        private int _head;
        private int _tail;
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
        // Complexity time O(1) and space O(1)
        public int Count
        {
            get { return _count; }
        }

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

        // If space available, complexity time O(1) and space O(1)
        // If space not available, complexity time O(n) and space O(n)
        // Amortized effect on Enqueue remains O(1) time and O(1) space
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
