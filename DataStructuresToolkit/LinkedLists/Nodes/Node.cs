using System;
using System.Collections.Generic;

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
}
