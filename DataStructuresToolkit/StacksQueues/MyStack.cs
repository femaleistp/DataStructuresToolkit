using System;

namespace DataStructuresToolkit.StacksQueues
{
    /// <summary>
    /// Generic stack with array-backed storage and doubling policy.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyStack<T>
    {
        private T[] _items;
        private int _count;
        public MyStack(int initialCapacity = 4)
        {
            if (initialCapacity < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(initialCapacity));
            }

            _items = new T[initialCapacity];
            _count = 0;
        }

        // Complexity Time O(1) and Space O(1)
        public int Count
        {
            get { return _count; }
        }

        // Complexity Time O(1) amortized and Space O(1) amortized
        public void Push(T item)
        {
            EnsureCapacityForOneMore();
            _items[_count] = item;
            _count++;
        }

        // Complexity Time O(1) and Space O(1)
        public T Peek()
        { 
            if (_count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return _items[_count - 1];
        }

        // Complexity Time O(1) and Space O(1) if capacity available
        // Complexity Time O(n) and Space O(n) if resizing needed
        // Amortized effect on Push remains O(1) time and O(1) space
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
                newArray[i] = _items[i];
            }
            _items = newArray;
        }
    }
}
