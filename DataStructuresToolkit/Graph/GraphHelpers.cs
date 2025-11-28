/*
 * Brittany Hancock
 * IT 415 - Data Structures and Algorithms
 * Instructor: Lenore Montalbano
 * November 28, 2025
 * Project 10: Graphs, Sets, and Benchmarking
 * 
 * Reflection:
 * I chose the graph feature because I had already worked on it in the 
 * Guided Demo and Lab and had more familiarity with it. It felt 
 * straightforward and practical. I knew it would be an extensive 
 * project, and I wanted enough space to do thorough testing. I needed 
 * more understanding on how to map graphs correctly and uncover edge 
 * cases. BFS and DFS helped me see the difference between retrieving 
 * data one layer at a time versus diving deep into the channels. It 
 * showed me how to build little by little. I learned how to find cycles, 
 * prevent revisits, avoid duplicate entries, handle items not in the 
 * graph, handle unreachable vertices, count edges, count degrees, order 
 * traversals, handle empty graphs, handle zero degrees, and build an 
 * adjacency list without losing state.
 * 
 * Nothing felt surprisingly easy. The difficult part was when tests 
 * passed that I thought would fail and figuring out why the method behaved 
 * better than expected. Test-driven development helped me catch issues 
 * like ignoring null empty or whitespace-only vertex names. I noticed the 
 * difference between BFS using a queue and DFS using recursion with a 
 * local DFSVisit.
 * 
 * The benchmark showed that HashSet.Contains is faster than List.Contains 
 * because HashSet uses buckets and List takes longer.
 * 
 * Adding GraphHelpers improved my Capstone because it integrated queues 
 * lists stacks HashSets complexity arrays and nodes. It made the project 
 * feel more professional through modular design and console output. I struggled 
 * with the size of the project and the number of edge cases. UniqueVertices 
 * helped things click when I saw how sorting changed adjacency order. Overall 
 * I feel satisfied with each step needed to build GraphHelpers tests and the 
 * demo harness.
 */

using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace DataStructuresToolkit.Graph
{
    /// <summary>
    /// Provides helper methods for working with undirected graphs.
    /// </summary>
    public class GraphHelpers
    {
        /// <summary>
        /// The adjacency list representing the graph.
        /// </summary>
        private readonly Dictionary<string, List<string>> _adjacency;

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphHelpers"/> class.
        /// </summary>
        public GraphHelpers()
        {
            _adjacency = new Dictionary<string, List<string>>();
        }

        /// <summary>
        /// Adds a vertex to the graph.
        /// </summary>
        /// <param name="v">The vertex to be added.</param>
        /// <remarks>Complexity time O(1), space O(1)</remarks>
        public void AddVertex(string v)
        {
            // ignore null, empty or whitespace-only vertex names
            if (string.IsNullOrWhiteSpace(v))
            {
                return;
            }

            if (!_adjacency.ContainsKey(v))
            {
                _adjacency[v] = new List<string>();
            }
        }

        /// <summary>
        /// Adds an undirected edge between two vertices.
        /// </summary>
        /// <param name="from">The starting vertex of the edge.</param>
        /// <param name="to">The ending vertex of the edge.</param>
        /// <remarks>Complexity time O(1), space O(1)</remarks>
        public void AddEdge(string from, string to)
        {
            // Ensure both vertices exist
            if (!_adjacency.ContainsKey(from) || !_adjacency.ContainsKey(to))
            {
                return;
            }

            // Add the edge in both directions for undirected graph
            if (!_adjacency[from].Contains(to))
            {
                _adjacency[from].Add(to);
            }

            // Add the reverse edge
            if (!_adjacency[to].Contains(from))
            {
                _adjacency[to].Add(from);
            }
        }

        /// <summary>
        /// Gets the neighbors of a given vertex.
        /// </summary>
        /// <param name="v">The vertex whose neighbors are to be retrieved.</param>
        /// <returns>The list of neighboring vertices.</returns>
        /// <remarks>Complexity time O(1), space O(1)</remarks>
        public List<string> GetNeighbors(string v)
        {
            if (!_adjacency.ContainsKey(v))
            {
                return new List<string>();
            }

            return _adjacency[v];
        }

        /// <summary>
        /// Performs Breadth-First Search (BFS) traversal starting from the given vertex.
        /// </summary>
        /// <param name="start">The starting vertex for BFS traversal.</param>
        /// <returns>The list of vertices visited in BFS order.</returns>
        /// <remarks>Complexity time O(V + E), space O(V)</remarks>
        public List<string> BFS(string start)
        {
            var result = new List<string>();

            // If the graph is empty or the start vertex does not exist, return empty list
            if (!_adjacency.ContainsKey(start))
            {
                return result;
            }

            var visited = new HashSet<string>();
            var queue = new Queue<string>();

            visited.Add(start);
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                string current = queue.Dequeue();
                result.Add(current);

                foreach (var neighbor in _adjacency[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Performs Depth-First Search (DFS) traversal starting from the given vertex.
        /// </summary>
        /// <param name="start">The starting vertex for DFS traversal.</param>
        /// <returns>The list of vertices visited in DFS order.</returns>
        /// <remarks>Complexity time O(V + E), space O(V)</remarks>
        public List<string> DFS(string start)
        {
            var result = new List<string>();

            if (!_adjacency.ContainsKey(start))
            {
                return result;
            }

            var visited = new HashSet<string>();
            DFSVisit(start, visited, result);
            return result;
        }

        /// <summary>
        /// Helper method for DFS traversal.
        /// </summary>
        /// <param name="current">The current vertex being visited.</param>
        /// <param name="visited">The set of visited vertices.</param>
        /// <param name="result">The list to store the traversal result.</param>
        /// <remarks>Complexity time O(V + E), space O(V)</remarks>
        private void DFSVisit(string current, HashSet<string> visited, List<string> result)
        {
            visited.Add(current);
            result.Add(current);

            foreach (var neighbor in _adjacency[current])
            {
                if (!visited.Contains(neighbor))
                {
                    DFSVisit(neighbor, visited, result);
                }
            }
        }

        /// <summary>
        /// Counts the number of edges in the undirected graph.
        /// </summary>
        /// <returns>The number of edges.</returns>
        /// <remarks>Complexity time O(V + E), space O(1)</remarks>
        public int CountEdges()
        {
            int directedEdgeCount = 0;
            foreach (var kvp in _adjacency)
            {
                directedEdgeCount += kvp.Value.Count;
            }

            return directedEdgeCount / 2; // Each edge counted twice
        }

        /// <summary>
        /// Calculates the degree of each vertex in the undirected graph.
        /// </summary>
        /// <returns>The dictionary with vertex as key and its degree as value.</returns>
        /// <remarks>Complexity time O(V + E), space O(V)</remarks>
        public Dictionary<string, int> DegreeCounts()
        {
            var result = new Dictionary<string, int>();

            foreach (var kvp in _adjacency)
            {
                string vertex = kvp.Key;
                List<string> neighbors = kvp.Value;

                result[vertex] = neighbors.Count;  // Degree is the count of neighbors
            }

            return result;
        }

        /// <summary>
        /// Performs Breadth-First Search (BFS) traversal and returns the order of visited vertices.
        /// </summary>
        /// <param name="start">The starting vertex for BFS traversal.</param>
        /// <returns>The list of vertices in the order they were visited.</returns>
        /// <remarks>Complexity time O(V + E), space O(V)</remarks>
        public List<string> OrderBFS(string start)
        {
            var result = new List<string>();

            if (!_adjacency.ContainsKey(start))
            {
                return result;
            }

            var visited = new HashSet<string>();
            var queue = new Queue<string>();

            visited.Add(start);
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                string current = queue.Dequeue();
                result.Add(current);

                foreach (var neighbor in _adjacency[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Performs Depth-First Search (DFS) traversal and returns the order of visited vertices.
        /// </summary>
        /// <param name="start">The starting vertex for DFS traversal.</param>
        /// <returns>The list of vertices in the order they were visited.</returns>
        /// <remarks>Complexity time O(V + E), space O(V)</remarks>
        public List<string> OrderDFS(string start)
        {
            var result = new List<string>();

            if (!_adjacency.ContainsKey(start))
            {
                return result;
            }

            var visited = new HashSet<string>();

            // Local function for DFS traversal
            void DFSVisit(string node)
            {
                visited.Add(node);
                result.Add(node);

                foreach (var neighbor in _adjacency[node])
                {
                    if (!visited.Contains(neighbor))
                    {
                        DFSVisit(neighbor);
                    }
                }
            }

            DFSVisit(start);
            return result;
        }

        /// <summary>
        /// Gets a sorted list of unique vertices in the graph.
        /// </summary>
        /// <returns>The list of unique vertices.</returns>
        /// <remarks>Complexity time O(V log V), space O(V)</remarks>
        public List<string> UniqueVertices()
        {
            // Vertices are the dictionary keys.
            var result = new List<string>(_adjacency.Keys);

            // Ensre sorted deterministic order.
            result.Sort();

            return result;
        }

        public Dictionary<string, List<string>> BuildAdjacencyList()
        {
            var copy = new Dictionary<string, List<string>>();

            foreach (var kvp in _adjacency)
            {
                // Deep-copy neighbors while preserving insertion order
                copy[kvp.Key] = new List<string>(kvp.Value);
            }
            return copy;
        }
    }
}
