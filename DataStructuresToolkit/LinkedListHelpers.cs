using System;
using System.Collections.Generic;

namespace DataStructuresToolkit
{
    /// <summary>
    /// A node in a singly linked list.
    /// </summary>
    /// <typeparam name="T">The type of data stored in the node.</typeparam>
    public class Node<T>
    {
        public T Data;
        public Node<T> Next;

        /// <summary>
        /// Initializes a new instance of the Node class with the specified data.
        /// </summary>
        /// <param name="data">The data to store in the node.</param>
        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    /// <summary>
    /// A simple implementation of a singly linked list.
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the linked list.</typeparam>
    /// <remarks>Complexity time O(1) and space O(1) for AddFirst and AddLast methods; O(n) time and space for Traverse method.</remarks>
    public class SinglyLinkedList<T>
    { 
        public Node<T> Head { get; private set; }
        private Node<T> Tail;

        /// <summary>
        /// Adds a new node with the specified value at the beginning of the linked list.
        /// </summary>
        /// <param name="value">The value to add.</param>
        /// <remarks>Complexity time O(1) and space O(1)</remarks>
        public void AddFirst(T value)
        {
            var newNode = new Node<T>(value);
            newNode.Next = Head;
            Head = newNode;
        }

        /// <summary>
        /// Adds a new node with the specified value at the end of the linked list.
        /// </summary>
        /// <param name="value">The value to add.</param>
        /// <remarks>Complexity time O(1) and space O(1)</remarks>
        public void AddLast(T value)
        {
            var newNode = new Node<T>(value);

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
                return;
            }

            Tail.Next = newNode;
            Tail = newNode;
        }

        /// <summary>
        /// Traverses the linked list and returns an array of its elements.
        /// </summary>
        /// <returns>The elements of the linked list as an array.</returns>
        /// <remarks>Complexity time O(n) and space O(n)</remarks>
        public T[] Traverse()
        {
            var result = new List<T>();
            var current = Head;

            while (current != null)
            {
                result.Add(current.Data);
                current = current.Next;
            }

            return result.ToArray();
        }

        // stubs for tdd

        public bool Contains(T value)
        {
            // TODO: implement Contains method
            throw new NotImplementedException(); 
        }
    }
}
