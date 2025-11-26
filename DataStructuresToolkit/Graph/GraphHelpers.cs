using System;
using System.Collections.Generic;

namespace DataStructuresToolkit.Graph
{
    public class GraphHelpers
    {
        private readonly Dictionary<string, List<string>> _adjacency;

        public GraphHelpers()
        {
            _adjacency = new Dictionary<string, List<string>>();
        }

        public void AddVertex(string v)
        {
            if (!_adjacency.ContainsKey(v))
            {
                _adjacency[v] = new List<string>();
            }
        }

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

        public List<string> GetNeighbors(string v)
        {
            if (!_adjacency.ContainsKey(v))
            {
                return new List<string>();
            }

            return _adjacency[v];
        }

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
    }
}
