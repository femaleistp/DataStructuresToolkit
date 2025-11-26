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
            _adjacency[from].Add(to);
            _adjacency[to].Add(from);
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


            if (!_adjacency.ContainsKey(start))
            {
                return result;
            }

            result.Add(start);
            return result;
        }
    }
}
