using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Strings.Graphs
{

    /// <summary>
    /// Depth First Search
    /// </summary>
    public class DFSFeatures
    {
        public void Main(string[] args)
        {
            var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var edges = new[]{Tuple.Create(1,2), Tuple.Create(1,3),
                Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
                Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
                Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(9,10)};

            var graph = new Graph<int>(vertices, edges);

            Console.WriteLine(string.Join(", ", DFS(graph, 1)));
            /// 1, 3, 6, 5, 8, 9, 10, 7, 4, 2
        }

        public class Graph<T>
        {
            public Graph() { }
            public Graph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges)
            {
                foreach (var vertex in vertices)
                    AddVertex(vertex);

                foreach (var edge in edges)
                    AddEdge(edge);
            }

            public Dictionary<T, List<T>> AdjacencyList { get; } = new Dictionary<T, List<T>>();

            public void AddVertex(T vertex)
            {
                AdjacencyList[vertex] = new List<T>();
            }

            public void AddEdge(Tuple<T, T> edge)
            {
                if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
                {
                    AdjacencyList[edge.Item1].Add(edge.Item2);
                    AdjacencyList[edge.Item2].Add(edge.Item1);
                }
            }
        }

        public List<T> DFS<T>(Graph<T> graph, T start)
        {
            var visited = new List<T>();

            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;

            var stack = new Stack<T>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                foreach (var neighbor in graph.AdjacencyList[vertex])
                    if (!visited.Contains(neighbor))
                        stack.Push(neighbor);
            }

            return visited;
        }

    }
}
