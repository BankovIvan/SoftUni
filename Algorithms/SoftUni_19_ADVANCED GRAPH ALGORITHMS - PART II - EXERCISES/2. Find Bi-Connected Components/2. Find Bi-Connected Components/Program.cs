using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{

    private static List<int>[] graph;
    private static bool[] visited;
    private static int?[] parent;
    private static int[] depths;
    private static int[] lowpoints;
    private static List<int> articulationPoints;
    private static Stack<int> nodesStack;
    static int total = 0;

    static void Main(string[] args)
    {
        int i, nNodes, nEdges, edgeFrom, edgeTo;
        string s;

        /*var graph = new List<int>[]
        {
                new List<int>() {1, 2, 6, 7, 9},      // children of node 0
                new List<int>() {0, 6},               // children of node 1
                new List<int>() {0, 7},               // children of node 2
                new List<int>() {4},                  // children of node 3
                new List<int>() {3, 6, 10},           // children of node 4
                new List<int>() {7},                  // children of node 5
                new List<int>() {0, 1, 4, 8, 10, 11}, // children of node 6
                new List<int>() {0, 2, 5, 9},         // children of node 7
                new List<int>() {6, 11},              // children of node 8
                new List<int>() {0, 7},               // children of node 9
                new List<int>() {4, 6},               // children of node 10
                new List<int>() {6, 8},               // children of node 11
        };*/


        Console.Write(" ");
        nNodes = int.Parse(Console.ReadLine().Split(' ').ToArray()[1]);
        Console.Write(" ");
        nEdges = int.Parse(Console.ReadLine().Split(' ').ToArray()[1]);

        graph = new List<int>[nNodes];
        for (i = 0; i < nNodes; i++)
        {
            graph[i] = new List<int>();
        }

        for (i = 0; i < nEdges; i++)
        {
            Console.Write(" ");
            s = Console.ReadLine();
            edgeFrom = int.Parse(s.Split(' ').ToArray()[0]);
            edgeTo = int.Parse(s.Split(' ').ToArray()[1]);

            graph[edgeFrom].Add(edgeTo);
            graph[edgeTo].Add(edgeFrom);
        }

        var articulationPoints = FindArticulationPoints(/*graph*/);
        Console.WriteLine("Number of bi-connected components: {0}", total);

        return;

    }



    public static List<int> FindArticulationPoints(/*List<int>[] targetGraph*/)
    {
        int i;
        visited = new bool[graph.Length];
        parent = new int?[graph.Length];
        depths = new int[graph.Length];
        lowpoints = new int[graph.Length];
        articulationPoints = new List<int>();
        nodesStack = new Stack<int>();

        for (i = 0; i < graph.Length; i++)
        {
            FindArticulationPoints(i, depths[i]);
        }

        return articulationPoints;

    }

    private static void FindArticulationPoints(int node, int depth)
    {
        parent[node] = node;
        visited[node] = true;
        depths[node] = depth;
        lowpoints[node] = depth;

        int childCount = 0;
        bool isArticulation = false;
        string s;

        foreach (var childNode in graph[node])
        {
            if (!visited[childNode])
            {
                FindArticulationPoints(childNode, depth + 1);
                childCount++;

                nodesStack.Push(childNode);

                if (lowpoints[childNode] >= depths[node])
                {
                    isArticulation = true;
                    s = "";
                    while (nodesStack.Count > 0 && lowpoints[nodesStack.Peek()] >= depths[node])
                    {
                        s = s + nodesStack.Pop().ToString().PadLeft(3);
                    }
                    s = s + node.ToString().PadLeft(3);
                    //Console.WriteLine(s);

                    total++;
                }

                lowpoints[node] = Math.Min(lowpoints[node], lowpoints[childNode]);

            }
            else if (parent[node] == null || parent[node] != childNode)
            {
                lowpoints[node] = Math.Min(lowpoints[node], depths[childNode]);
            }
        }

        if ((parent[node] != null && isArticulation == true) || (parent[node] == null && childCount > 1))
        {
            articulationPoints.Add(node);
        }

    }
}
/*
    private static void PrintGraph()
    {
        int i, j;
        string s;
        Console.WriteLine("     0  1  2  3  4  5  6  7  8  9 10 11 12");
        Console.WriteLine("   ---------------------------------------");
        for (i = 0; i < graph.Length; i++)
        {
            s = i.ToString().PadLeft(2) + "|";
            for (j = 0; j < graph.Length; j++)
            {
                s = s + (graph[i].Contains(j) ? j.ToString().PadLeft(3) : "  -");
            }
            Console.WriteLine(s);
        }
        Console.WriteLine();
    }

    private static void PrintVectors()
    {
        int i, j;
        string s;

        s = "visited=  ";
        for (i = 0; i < visited.Length; i++)
            s = s + (visited[i] == true ? "  *" : "   ");
        Console.WriteLine(s);

        s = "parent=   ";
        for (i = 0; i < parent.Length; i++)
            s = s + (parent[i] != null ? parent[i].ToString().PadLeft(3) : "   ");
        Console.WriteLine(s);

        s = "depths=   ";
        for (i = 0; i < depths.Length; i++)
            s = s + depths[i].ToString().PadLeft(3);
        Console.WriteLine(s);

        s = "lowpoints=";
        for (i = 0; i < lowpoints.Length; i++)
            s = s + lowpoints[i].ToString().PadLeft(3);
        Console.WriteLine(s);

        Console.WriteLine();
        Console.ReadLine();
    }

}
*/