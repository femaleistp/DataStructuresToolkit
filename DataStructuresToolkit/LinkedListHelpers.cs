using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresToolkit.LinkedLists.Nodes;

namespace DataStructuresToolkit.LinkedLists.Nodes
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
    /// A node in a doubly linked list.
    /// </summary>
    /// <typeparam name="T">The type of data stored in the node.</typeparam>
    public class DoublyNode<T>
    {
        public T Data;
        public DoublyNode<T> Prev;
        public DoublyNode<T> Next;

        /// <summary>
        /// Initializes a new instance of the DoublyNode class with the specified data.
        /// </summary>
        /// <param name="data">The data to store in the node.</param>
        public DoublyNode(T data)
        {
            Data = data;
            Prev = null;
            Next = null;
        }
    }
}

namespace DataStructuresToolkit.LinkedLists
{
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

        /// <summary>
        /// Checks if the linked list contains a node with the specified value.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <returns>The true if the value is found; otherwise, false.</returns>
        /// <remarks>Complexity time O(n) and space O(1)</remarks>
        public bool Contains(T value)
        {
            var current = Head;

            while (current != null)
            {
                if (current.Data.Equals(value))
                {
                    return true;
                }

                current = current.Next;
            }
            return false;
        }
    }

    /// <summary>
    /// A simple implementation of a doubly linked list.
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the linked list.</typeparam>
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

        /// <summary>
        /// Removes the specified node from the list.
        /// </summary>
        /// <param name="node">The node to remove.</param>
        /// <remarks>Complexity time O(1) and space O(1)</remarks>
        public void Remove(DoublyNode<T> node)
        {
            if (node == Head)
            {
                Head = Head.Next;
            }

            if (node == Tail)
            {
                Tail = Tail.Prev;
            }

            if (node.Prev != null)
            {
                node.Prev.Next = node.Next;
            }

            if (node.Next != null)
            {
                node.Next.Prev = node.Prev;
            }
        }

        /// <summary>
        /// Traverses the list from head to tail and returns an array of the data in each node.
        /// </summary>
        /// <returns>The array of data from the list.</returns>
        /// <remarks>Complexity time O(n) and space O(n)</remarks>
        public T[] TraverseForward()
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

        /// <summary>
        /// Traverses the list from tail to head and returns an array of the data in each node.
        /// </summary>
        /// <returns>The array of data from the list.</returns>
        /// <remarks>Complexity time O(n) and space O(n)</remarks>
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

