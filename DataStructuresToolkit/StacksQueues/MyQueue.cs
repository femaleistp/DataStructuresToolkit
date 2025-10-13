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
        public MyQueue(int intialCapacity = 4)
        {
            if (intialCapacity < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(intialCapacity));
            }

            _items = new T[intialCapacity];
            _count = 0;
            _head = 0;
            _tail = 0;
        }
        // Complexity time O(1) and space O(n)
        public int Count
        {
            get { return _count; }
        }
    }
}
