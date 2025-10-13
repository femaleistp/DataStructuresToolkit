using System;

namespace DataStructuresToolkit.StacksQueues
{
    public class MyStack<T>
    {
        private T[] _items;
        private int _count;
        /// <summary>
        /// Creates a new stack with the given initial capacity.
        /// </summary>
        /// <param name="initialCapacity">Starting array size (at least 1)</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when initialCapacity is less than 1.</exception>
        public MyStack(int initialCapacity = 4)
        {
            if (initialCapacity < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(initialCapacity));
            }

            _items = new T[initialCapacity];
            _count = 0;
        }

        /// <summary>
        /// Get the numbe rof items currently in the stack.
        /// </summary>
        /// <remarks>Time O(1) and space O(1) complexity</remarks>
        public int Count
        {
            get { return _count; }
        }

        /// <summary>
        /// Pushes an item onto the top of the stack.
        /// </summary>
        /// <param name="item">The item to push.</param>
        /// <remarks>Amortized O(1) time and O(1) space complexity.</remarks>
        public void Push(T item)
        {
            EnsureCapacityForOneMore();
            _items[_count] = item;
            _count++;
        }

        /// <summary>
        /// Returns the item at the top of the stack without removing it.
        /// </summary>
        /// <returns>The item currently on the top of the stack.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception>
        /// <remarks>Runs in O(1) time and O(1) space complexity.</remarks>
        public T Peek()
        { 
            if (_count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return _items[_count - 1];
        }

        /// <summary>
        /// Removes and returns the item at the top of the stack.
        /// </summary>
        /// <returns>The item that was removed from the top of the stack.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception>
        /// <remarks>Runs in O(1) time and O(1) space complexity.</remarks>
        public T Pop()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            int topIndex = _count - 1;
            T value = _items[topIndex];
            _items[topIndex] = default(T); // Clear reference
            _count = topIndex;
            return value;
        }

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
