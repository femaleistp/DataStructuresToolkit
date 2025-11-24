using DataStructuresToolkit.LinkedLists.Nodes;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
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

        /// <summary>
        /// Adds a new node with the specified value at the end of the list.
        /// </summary>
        /// <param name="value">The value to add.</param>
        /// <remarks>Complexity time O(1) and space O(1)</remarks>
        public void AddLast(T value)
        {
            var newNode = new DoublyNode<T>(value);

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
                return;
            }

            Tail.Next = newNode; // Link the current tail to the new node
            newNode.Prev = Tail; // Link the new node back to the current tail
            Tail = newNode; // Update the tail to be the new node
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
            var result = new List<T>();
            var current = Tail;

            while (current != null)
            {
                result.Add(current.Data);
                current = current.Prev;
            }

            return result.ToArray();
        }

        
    }
}
