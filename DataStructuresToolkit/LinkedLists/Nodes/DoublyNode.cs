using System;
using System.Collections.Generic;

namespace DataStructuresToolkit.LinkedLists.Nodes
{
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
