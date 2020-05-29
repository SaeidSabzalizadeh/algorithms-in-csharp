using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Strings.Graphs
{

    /// <summary>
    /// Breadth First Search
    /// </summary>
    public class BFS
    {
        static void Main(string[] args)
        {
            IDictionary <int, List<int>> tree = new Dictionary<int, List<int>> ();
            tree[1] = new List<int> { 2, 3, 4 };
            tree[2] = new List<int> { 5 };
            tree[3] = new List<int> { 6, 7 };
            tree[4] = new List<int> { 8 };
            tree[5] = new List<int> { 9 };
            tree[6] = new List<int> { 10 };


            HashSet<int> itemCovered = new HashSet<int>();
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(tree.Keys.First());
            
            while (queue.Count > 0)
            {
                var element = queue.Dequeue();
                if (itemCovered.Contains(element))
                    continue;
                else
                    itemCovered.Add(element);
                Console.WriteLine(element);
                List<int> neighbours;
               
                tree.TryGetValue(element, out neighbours);
               
                if (neighbours == null)
                    continue;

                foreach (var item1 in neighbours)
                {
                    queue.Enqueue(item1);
                }

            }

        }
    }

}
