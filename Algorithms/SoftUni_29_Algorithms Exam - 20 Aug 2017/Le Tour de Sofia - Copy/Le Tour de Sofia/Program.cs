using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    public static bool[,] graph;
    public static int[] junctions;
    public static int maxCount = int.MaxValue;
    public static int pathCount = int.MaxValue;
    public static int start;

    static void Main(string[] args)
    {
        ReadGraph();

        TraverseGraphBFS();

        if(pathCount < int.MaxValue)
        {
            Console.WriteLine(pathCount);
        }
        else
        {
            Console.WriteLine(junctions.Count(x => x < int.MaxValue));
        }
        return;
    }

    private static void TraverseGraphBFS()
    {
        int i;
        int nextNodeCount = 0;
        int currentNode = start;
        Queue<int> nodesQueue = new Queue<int>();

        junctions[currentNode] = 0;
        nodesQueue.Enqueue(currentNode);

        while(nodesQueue.Count > 0)
        {
            currentNode = nodesQueue.Dequeue();
            nextNodeCount = junctions[currentNode] + 1;

            for (i = 0; i < graph.GetLength(1); i++)
            {
                if(graph[currentNode, i] == true)
                {
                    if(junctions[i] > nextNodeCount)
                    {
                        junctions[i] = nextNodeCount;
                        nodesQueue.Enqueue(i);

                    }

                    if(i == start)
                    {
                        if(pathCount > nextNodeCount)
                        {
                            pathCount = nextNodeCount;
                        }

                        return;

                    }
                }
            }
        }

        return;

    }

    private static void ReadGraph()
    {
        int i, from, to, n, m;
        string[] s;

        n = int.Parse(Console.ReadLine());
        m = int.Parse(Console.ReadLine());
        start = int.Parse(Console.ReadLine());

        graph = new bool[n, n];
        junctions = new int[n]; // Enumerable.Repeat(int.MaxValue, n).ToArray(); //new int[n];

        for (i = 0; i < m; i++)
        {
            Console.Write("    ");
            s = Console.ReadLine().Split();
            from = int.Parse(s[0]);
            to = int.Parse(s[1]);

            graph[from, to] = true;

        }

        for (i = 0; i < n; i++)
        {
            junctions[i] = int.MaxValue;
        }

    }
}
