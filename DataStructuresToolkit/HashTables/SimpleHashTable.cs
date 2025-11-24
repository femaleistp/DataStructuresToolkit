/*
 * Brittany Hancock
 * IT 415: Data Structures and Algorithms
 * Instructor: Lenore Montalbano
 * November 13, 2025
 * Project 8: Hash Tables & Associative Containers Toolkit
 * Reflection
 * 
 * While building my SimpleHashTable, I learned that collisions happen whenever
 * more than one item is mapped to the same bucket. In our case, the hash is
 * based on taking the key modulus the bucket length, so keys like 12, 22, and
 * 37 all go into the same bucket. I also learned that collisions are normal,
 * not errors. The important part is having a clear way to handle them. With
 * chaining, each bucket stores a list, and new items are added only if they
 * are not already present.
 *
 * Writing the Insert method helped me understand the sequence: find the correct
 * bucket, check whether the key already exists, and then either return or add it
 * to the end of the list. Writing the Contains method showed me how it again
 * finds the correct bucket using the modulus and then checks the list for the
 * key. This made it easier to see exactly what the hash table does step by step.
 *
 * Working with Dictionary and HashSet helped me compare my simple structure to
 * the built-in ones. Dictionary stores key–value pairs and handles hashing,
 * collisions, duplicates, and resizing internally. HashSet makes sure no item
 * is added more than once. These built-in containers handle much more than my
 * basic version and are what I would use in a real project because they are
 * already optimized and dependable.
 *
 * Even though I would normally use built-in structures, creating my own hash
 * table helped me understand the mechanics of hashing, collisions, and lookup
 * behavior
 */


using System;
using System.Collections.Generic;

namespace DataStructuresToolkit.HashTables
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
