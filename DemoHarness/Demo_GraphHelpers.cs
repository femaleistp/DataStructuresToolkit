using System;
using System.Collections.Generic;
using System.Diagnostics;
using DataStructuresToolkit.Graph;

namespace DemoHarness
{
    public class Demo_GraphHelpers
    {
        public static void Main(string[] args)
        {
            // --- JIT WARM-UP ---
            {
                var warmGraph = new GraphHelpers();
                warmGraph.AddVertex("A");
                warmGraph.AddVertex("B");
                warmGraph.AddEdge("A", "B");
                foreach (var _ in warmGraph.BFS("A")) { }
            }
            // --- END WARM-UP ---

            Console.WriteLine("=== Graph Helpers Demo ===\n");

            RunGraphTraversalDemo();
            RunAdjacencyAndDegreeDemo();
            RunUniqueVerticesDemo();
            RunBenchmarkDemo();

            Console.WriteLine("\n=== End of Graph Helpers Demo ===");
        }

        /// <summary>
        /// Demonstrates graph traversal using BFS and DFS.
        /// </summary>
        /// <remarks>Complexity time O(V + E) and space O(V)</remarks>
        private static void RunGraphTraversalDemo()
        {
            Console.WriteLine("-- Traversal Demo (BFS and DFS) --");

            var g = new GraphHelpers();

            g.AddVertex("A");
            g.AddVertex("B");
            g.AddVertex("C");
            g.AddVertex("D");
            g.AddVertex("E");

            g.AddEdge("A", "B");
            g.AddEdge("A", "C");
            g.AddEdge("B", "D");
            g.AddEdge("C", "E");

            var sw = new Stopwatch();

            // --- BFS TIMING ---
            sw.Start();
            foreach (var v in g.BFS("A"))
            {
                // no-op, just enumerating
            }
            sw.Stop();
            Console.WriteLine($"BFS traversal time: {sw.ElapsedTicks} ticks ({sw.ElapsedMilliseconds} ms)");
            Console.WriteLine();

            Console.WriteLine("BFS from A:");
            foreach (var v in g.BFS("A"))
            {
                Console.WriteLine(v);
            }
            Console.WriteLine();

            Console.WriteLine("DFS from A:");
            foreach (var v in g.DFS("A"))
            {
                Console.WriteLine(v);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Demonstrates counting unique vertices in edges.
        /// </summary>
        /// <remarks>Complexity time O(E) and space O(V)</remarks>
        public static void RunAdjacencyAndDegreeDemo()
        { 
            var g = new GraphHelpers();

            g.AddVertex("A");
            g.AddVertex("B");
            g.AddVertex("C");

            g.AddEdge("A", "B");
            g.AddEdge("B", "C");

            Console.WriteLine("CountEdges(): " + g.CountEdges());
            Console.WriteLine();

            Console.WriteLine("DegreeCounts():");
            var degrees = g.DegreeCounts();
            foreach (var kvp in degrees)
            {
                Console.WriteLine(kvp.Key +":" + kvp.Value);
            }
            Console.WriteLine();

            Console.WriteLine("BuildAdjacencyList():");
            var adj = g.BuildAdjacencyList();
            foreach (var kvp in adj)
            {
                Console.WriteLine(kvp.Key + "-> " + string.Join(", ", kvp.Value));
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Demonstrates counting unique vertices in edges.
        /// </summary>
        /// <remarks>Complexity time O(E) and space O(V)</remarks>
        private static void RunUniqueVerticesDemo()
        {
            Console.WriteLine("-- UniqueVertices Demo --");
            var g = new GraphHelpers();

            g.AddVertex("B");
            g.AddVertex("A");
            g.AddVertex("D");
            g.AddVertex("C");

            Console.WriteLine("Unique vertices (sorted):");
            foreach (var v in g.UniqueVertices())
            {
                Console.WriteLine(v);
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Demonstrates benchmarking List.Contains vs HashSet.Contains.
        /// </summary>
        /// <remarks>Complexity time O(n) for List.Contains and O(1) for HashSet.Contains</remarks>
        private static void RunBenchmarkDemo()
        {
            Console.WriteLine("-- Benchmark Demo: List.Contains vs HashSet.Contains --");

            int size = 1000000;
            int target = size - 1;

            var list = new List<int>();
            for (int i = 0; i < size; i++)
            {
                list.Add(i);
            }

            var set = new HashSet<int>(list);

            var sw = new Stopwatch();

            Console.WriteLine("Searching for " + target + "...\n");

            sw.Start();
            bool foundList = list.Contains(target);
            sw.Stop();

            Console.WriteLine("List.Contains time: " + sw.ElapsedMilliseconds + " ms");

            sw.Reset();

            sw.Start();

            bool foundSet = set.Contains(target);
            sw.Stop();
            Console.WriteLine("HashSet.Contains time: " + sw.ElapsedMilliseconds + " ms");
            Console.WriteLine();
        }
    }
}
