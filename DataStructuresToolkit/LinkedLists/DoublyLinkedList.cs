using DataStructuresToolkit.LinkedLists.Nodes;
using System;
using System.Collections.Generic;
using System.Security.Policy;


namespace DataStructuresToolkit.LinkedLists
{
    public class DoublyLinkedList<T>
    {
        public DoublyNode<T> Head { get; private set; }
        public DoublyNode<T> Tail { get; private set; }

        /// <summary>
        /// Adds a new node with the specified value at the beginning of the list.
        /// </summary>
        /// <param name="value">The value to add.</param>
        /// <remarks>Complexity time O(1) and space O(1)</remarks>
        public void AddFirst(T value)
        {
            var newNode = new DoublyNode<T>(value);

            if (Head == null)
            {
                Head = Tail = newNode;
                return;
            }

            newNode.Next = Head;
            Head.Prev = newNode;
            Head = newNode;
        }

        public void AddLast(T value)
        {
            // Implementation goes here
        }

        public void Remove(DoublyNode<T> node)
        {
            // Implementation goes here
        }

        public T[] TraverseForward()
        {
            // Implementation goes here
            return Array.Empty<T>();
        }

        public T[] TraverseBackward()
        {
            // Implementation goes here
            return Array.Empty<T>();
        }
    }
}
