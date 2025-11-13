using System;
using System.Collections.Generic;

namespace DataStructuresToolkit
{
    public class SimpleHashTable
    {
        // A simple hash table implementation using chaining for collision resolution.
        private List<int>[] buckets;

        public SimpleHashTable(int size)
        {
            buckets = new List<int>[size];
            for (int i = 0; i < size; i++)
            {
                buckets[i] = new List<int>();
            }
        }

        public void Insert(int key)
        {
            throw new NotImplementedException();
        }

        public bool Contains(int key)
        {
            throw new NotImplementedException();
        }

        public void PrintTable()
        {
            throw new NotImplementedException();
        }   
    }
}
