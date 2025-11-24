using System;
using System.Collections.Generic;

namespace DataStructuresToolkit
{
    public class Node<T>
    {
        public T Data;
        public Node<T> Next;

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public class SinglyLinkedList<T>
    { 
        public Node<T> Head { get; private set; }

        public void AddFirst(T value)
        {
            var newNode = new Node<T>(value);
            newNode.Next = Head;
            Head = newNode;
        }

        // stubs for tdd

        public void AddLast(T value)
        {
            // TODO: implement AddLast method
            throw new NotImplementedException();
        }

        public T[] Traverse()
        {
            // TODO: implement Traverse method
            throw new NotImplementedException();
        }

        public bool Contains(T value)
        {
            // TODO: implement Contains method
            throw new NotImplementedException(); 
        }
    }
}
