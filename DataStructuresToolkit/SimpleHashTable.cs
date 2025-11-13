using System;
using System.Collections.Generic;

namespace DataStructuresToolkit
{
    /// <summary>
    /// A simple hash table implementation with basic operations.
    /// </summary>
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

        /// <summary>
        /// Inserts a key into the hash table.
        /// </summary>
        /// <param name="key">The key to insert.</param>
        /// <remarks>Complexity time O(1) on average, O(n) in the worst case due to collisions and space complexity O(n)</remarks>
        public void Insert(int key)
        {
            int index = key % buckets.Length;
            if (!buckets[index].Contains(key))
            {
                buckets[index].Add(key);
            }
        }

        /// <summary>
        /// Checks if the hash table contains a specific key.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns>True if the key exists, false otherwise.</returns>
        /// <remarks>Complexity time O(1) on average, O(n) in the worst case due to collisions and space complexity O(n)</remarks>
        public bool Contains(int key)
        {
            int index = key % buckets.Length;
            return buckets[index].Contains(key);
        }

        /// <summary>
        /// Prints the contents of the hash table.
        /// </summary>
        /// <remarks>Complexity time O(n) and space complexity O(1)</remarks>
        public void PrintTable()
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                Console.Write($"Bucket {i}: ");
                Console.WriteLine(string.Join(", ", buckets[i]));
            }
        }   
    }
}
