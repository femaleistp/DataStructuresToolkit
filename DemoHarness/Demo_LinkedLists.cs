using System;
using System.Collections.Generic;
using DataStructuresToolkit.LinkedLists;
using DataStructuresToolkit.LinkedLists.Nodes;

namespace DemoHarness
{
    public class Demo_LinkedLists
    {
        /// <summary>
        /// The main entry point for the linked lists demo.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Linked Lists Demo ===\n");

            RunSinglyLinkedListDemo();
            RunDoublyLlinkedListDemo();
            RunBuiltInLinkedListComparison();

            Console.WriteLine("\n=== End of Linked List Demo ===");
        }

        /// <summary>
        /// Demonstrates the SinglyLinkedList functionality.
        /// </summary>
        /// <remarks>Complexity time O(n) and space O(n)</remarks>
        private static void RunSinglyLinkedListDemo()
        {
            Console.WriteLine("-- SinglyLinkedList<int> Demo --");

            var list = new SinglyLinkedList<int>();

            list.AddFirst(30);
            list.AddFirst(20);
            list.AddFirst(10);

            Console.WriteLine("Traversal:");
            foreach(var value in list.Traverse())
            {
                Console.WriteLine(value + " ");
            }
            Console.WriteLine("\n");
        }

        /// <summary>
        /// Demonstrates the DoublyLinkedList functionality.
        /// </summary>
        /// <remarks>Complexity time O(n) and space O(n)</remarks>
        private static void RunDoublyLlinkedListDemo()
        {
            Console.WriteLine("-- DoublyLinkedList<string> Demo --");

            var list = new DoublyLinkedList<string>();

            list.AddFirst("Charlie");
            list.AddFirst("Bravo");
            list.AddFirst("Alpha");

            Console.WriteLine("Forward Traversal:");
            foreach(var value in list.TraverseForward())
            {
                Console.WriteLine(value + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Backward Traversal:");
            foreach (var value in list.TraverseBackward())
            {
                Console.WriteLine(value + " ");
            }
            Console.WriteLine();

            Console.WriteLine("\nRemoving middle element (Bravo)...");
            var middle = list.Head.Next; // Node with value "Bravo"
            list.Remove(middle);

            Console.WriteLine("Forward Traversal after removal:");
            foreach (var value in list.TraverseForward())
            {
                Console.WriteLine(value + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Demonstrates the built-in LinkedList<T> functionality for comparison.
        /// </summary>
        /// <!--/ <remarks>Complexity time O(n) and space O(n)</remarks>-->
        private static void RunBuiltInLinkedListComparison()
        {
            Console.WriteLine("-- Built-in LinkedList<T> Comparison --");

            var builtIn = new LinkedList<int>();
            builtIn.AddFirst(3);
            builtIn.AddFirst(5);
            builtIn.AddLast(7);

            Console.WriteLine("Built-in LinkedList traversal:");
            foreach (var value in builtIn)
            {
                Console.WriteLine(value + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Removing the middle element (5)...");
            builtIn.Remove(5);

            Console.WriteLine("After Remove:");
            foreach (var value in builtIn)
            {
                Console.WriteLine(value + " ");
            }
            Console.WriteLine();
        }

    }
}
