using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    public static int[,] graph;
    public static int[] parents;
    public static List<string> readData = new List<string>();
    public static Queue<int> nodesQueue = new Queue<int>();

    static void Main(string[] args)
    {
        int start, count, next;

        start = ReadGraph();

        //Console.WriteLine("X");
        //return;

        BFSGraph(start);

        if (parents.Length == 0 || start < 0 || start >= parents.Length)
        {
            Console.WriteLine("0");
            //return;
        }
        else if (parents[start] == -1)
        {
            Console.WriteLine((parents.Where(x => x >= 0).Count() + 1).ToString());
            //Console.WriteLine("2");
            //return;
        }
        else
        {
            next = parents[start];
            count = 1;

            while (next != start && next >= 0 && next < parents.Length)
            {
                count++;
                next = parents[next];
            }

            Console.WriteLine(count.ToString());
        }

        return;

    }

    public static void BFSGraph(int start)
    {
        int i, next;

        next = start;
        nodesQueue.Enqueue(next);

        while(nodesQueue.Count >= 1)
        {
            next = nodesQueue.Dequeue();

            for(i = 0; i < graph.GetLength(0); i++)
            {
                if (graph[i, 0] == next && parents[graph[i, 1]] < 0)
                {
                    parents[graph[i, 1]] = next;

                    if (graph[i, 1] == start)
                    {
                        return;
                    }

                    nodesQueue.Enqueue(graph[i, 1]);
                }

            }
        }

        return;
    }

    public static int ReadGraph()
    {
        int i, m = 0, n = 0, nNodes, nEdges, start;
        string s;

        nNodes = int.Parse(Console.ReadLine());
        nEdges = int.Parse(Console.ReadLine());
        start = int.Parse(Console.ReadLine());

        for(i = 0; i < nEdges; i++)
        {
            s = Console.ReadLine();
            readData.Add(s);
        }

        graph = new int[nEdges, 2];

        for (i = 0; i < readData.Count; i++)
        {
            m = int.Parse(readData[i].Split(' ')[0]);
            n = int.Parse(readData[i].Split(' ')[1]);

            graph[i, 0] = m;
            graph[i, 1] = n;

        }

        parents = new int[nNodes];

        for (i = 0; i < nNodes; i++)
        {
            parents[i] = -1;
        }

        return start;

    }

}
