using System.Collections.Generic;

namespace TechVille.DSA.DataStructures.Graphs
{
    public class RoadGraph
    {
        private Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

        public void AddRoad(string a, string b)
        {
            if (!graph.ContainsKey(a))
                graph[a] = new List<string>();

            graph[a].Add(b);
        }

        // BFS traversal
        public void BFS(string start)
        {
            Queue<string> q = new Queue<string>();
            HashSet<string> visited = new HashSet<string>();

            q.Enqueue(start);

            while (q.Count > 0)
            {
                string node = q.Dequeue();
                if (visited.Contains(node))
                    continue;

                visited.Add(node);
                System.Console.WriteLine(node);

                if (graph.ContainsKey(node))
                    foreach (var n in graph[node])
                        q.Enqueue(n);
            }
        }
    }
}
