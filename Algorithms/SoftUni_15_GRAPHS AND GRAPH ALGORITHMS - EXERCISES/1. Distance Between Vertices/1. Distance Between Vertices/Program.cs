using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int P = int.Parse(Console.ReadLine());

        Dictionary<int, List<int>> graph = ReadGraph(N);    //int key = node id; List<> value = list of childs; 
        LinkedList<taskInfo> tasks = ReadTasks(P);

        foreach (var item in tasks)
        {
            CalculateShortestPathBFSIterative(graph, item);
            Console.WriteLine(item.ToString());
        }

        return;

    }

    private static void CalculateShortestPathBFSIterative(Dictionary<int, List<int>> graph, taskInfo task)
    {
        if (!graph.ContainsKey(task.nodeFrom)) return; //Just in any case...
        if (!graph.ContainsKey(task.nodeTo)) return; //Just in any case...

        bool[] visited = new bool[graph.Keys.Max() + 1];  //visited[0] is not used;
        int[] currentPaths = new int[graph.Keys.Max() + 1];  //currentPaths[0] is not used;

        Queue<int> nodesQueue = new Queue<int>();

        int nextElement;

        nodesQueue.Enqueue(task.nodeFrom);
        visited[task.nodeFrom] = true;

        while (nodesQueue.Count > 0)
        {
            nextElement = nodesQueue.Dequeue();

            foreach (var child in graph[nextElement])
            {
                if (!visited[child])
                {
                    if (task.nodeTo == child)
                    {
                        task.distance = currentPaths[nextElement] + 1;
                        return;
                    }

                    nodesQueue.Enqueue(child);
                    visited[child] = true;
                    currentPaths[child] = currentPaths[nextElement] + 1;
                }
            }
        }

        return;

    }

    private static Dictionary<int, List<int>> ReadGraph(int N)
    {
        int i;
        string s;
        List<int> childs;
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

        for (i = 0; i < N; i++)
        {
            s = Console.ReadLine();
            childs = new List<int>();

            foreach (var item in s.Split(':')[1].Split())
            {
                if (item != "")
                {
                    childs.Add(int.Parse(item));
                }
            }

            graph.Add(int.Parse(s.Split(':')[0]), childs);
        }

        return graph;
    }

    private static LinkedList<taskInfo> ReadTasks(int P)
    {
        int i;
        string s;
        LinkedList<taskInfo> tasks = new LinkedList<taskInfo>();

        for (i = 0; i < P; i++)
        {
            s = Console.ReadLine();
            tasks.AddLast( new taskInfo { nodeFrom = int.Parse(s.Split('-')[0]), nodeTo = int.Parse(s.Split('-')[1]), distance  = -1}   );
        }

        return tasks;
    }

    public class taskInfo
    {
        public int nodeFrom { get; set; }
        public int nodeTo { get; set; }
        public int distance { get; set; }    

        public override string ToString()
        {
            return "{" + nodeFrom.ToString() + ", " + nodeTo.ToString() + "} -> " + distance.ToString();
        }

    }

}
