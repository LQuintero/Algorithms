using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AlgorithmLib
{
    /*
     * Undirected Graph - Breadth First Search and Depth First Search
     */

    public class Graph<T>
    {
        public Graph() { }
        public Graph(IEnumerable<T> nodes, IEnumerable<Tuple<T, T>> edges)
        {
            foreach (var node in nodes)
            {
                AddNode(node);
            }
            foreach (var edge in edges)
            {
                AddEdge(edge);
            }
        }

        public Dictionary<T, HashSet<T>> AdjacentList { get; } = new Dictionary<T, HashSet<T>>();

        public void AddNode(T node)
        {
            if (!AdjacentList.ContainsKey(node))
            { AdjacentList[node] = new HashSet<T>(); }
        }

        public void AddEdge(Tuple<T, T> edge)
        {
            if (AdjacentList.ContainsKey(edge.Item1) && AdjacentList.ContainsKey(edge.Item2))
            {
                AdjacentList[edge.Item1].Add(edge.Item2);
                AdjacentList[edge.Item2].Add(edge.Item1);
            }
        }

        public bool HasPathDFS(T source, T destination)
        {
            HashSet<T> visited = new HashSet<T>();
            return hasPathDFS(source, destination, visited);
        }

        private bool hasPathDFS(T source, T destination, HashSet<T> visited)
        {
            if (visited.Contains(source)) { return false; }

            visited.Add(source);

            if (source.Equals(destination))
            {
                return true;
            }

            foreach (var neighbor in this.AdjacentList[source])
            {
                if (hasPathDFS(neighbor, destination, visited))
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasPathBFS(T source, T destination)
        {
            return hasPathBFS(source, destination);
        }

        private bool hasPathBFS(T source, T destination)
        {
            Queue<T> nextToVisit = new Queue<T>();
            HashSet<T> visited = new HashSet<T>();
            nextToVisit.Enqueue(source);
            while (nextToVisit.Any())
            {
                var node = nextToVisit.Dequeue();

                if (node.Equals(destination))
                {
                    return true;
                }

                if (visited.Contains(node))
                {
                    continue;
                }
                visited.Add(node);

                foreach (var neighbor in this.AdjacentList[node])
                {
                    nextToVisit.Enqueue(neighbor);
                }
            }

            return false;
        }

        public Dictionary<T, int> GetShortestDistances(T start, int edgeWeight)
        {
            Queue<T> nextToVisit = new Queue<T>();
            nextToVisit.Enqueue(start);

            Dictionary<T, int> distances = new Dictionary<T, int>();
            foreach (var node in this.AdjacentList.Keys)
            {
                distances.Add(node, -1);
            }
            distances[start] = 0;

            HashSet<T> visited = new HashSet<T>();

            while (nextToVisit.Any())
            {
                var currentNode = nextToVisit.Dequeue();

                if (visited.Contains(currentNode))
                {
                    continue;
                }
                visited.Add(currentNode);

                foreach (var neighbor in this.AdjacentList[currentNode])
                {
                    if (distances[neighbor] == -1)
                    { distances[neighbor] = distances[currentNode] + edgeWeight; }

                    nextToVisit.Enqueue(neighbor);
                }

            }

            return distances;
        }

        public Func<T, IEnumerable<T>> ShortestPathFunction<T>(Graph<T> graph, T start)
        {
            var previous = new Dictionary<T, T>();

            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                foreach (var neighbor in graph.AdjacentList[node])
                {
                    if (previous.ContainsKey(neighbor))
                        continue;

                    previous[neighbor] = node;
                    queue.Enqueue(neighbor);
                }
            }

            Func<T, IEnumerable<T>> shortestPath = v => {
                var path = new List<T> { };

                var current = v;
                while (!current.Equals(start))
                {
                    path.Add(current);
                    current = previous[current];
                };

                path.Add(start);
                path.Reverse();

                return path;
            };

            return shortestPath;
        }
    }

}
