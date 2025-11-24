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

        // stub
        public void AddFirst(T value)
        {
            // Implementation goes here
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
