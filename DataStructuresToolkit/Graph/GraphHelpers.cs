using System;
using System.Collections.Generic;

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
        /// <param name="v">The vertex to add.</param>
        /// <remarks>Complexity time O(1), space O(1)</remarks>
        public void AddVertex(string v)
        {
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

            var visited = new   HashSet<string>();
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

                foreach(var neighbor in _adjacency[node])
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
    }
}
