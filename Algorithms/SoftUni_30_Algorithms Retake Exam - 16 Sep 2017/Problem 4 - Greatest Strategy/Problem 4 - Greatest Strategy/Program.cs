using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    public static bool[,] graph;
    public static bool[] visited;
    public static int[] totals;
    public static int[] parents;
    public static int maxSum = 0;

    static void Main(string[] args)
    {
        int i, start, currentSum;

        start = ReadGraph();

        //PrintMatrix(graph);

        BFSGraphRecursive(start - 1, 0);

        //PrintMatrix(graph);

        for (i = 0; i < graph.GetLength(0); i++)
        {
            visited[i] = false;
        }

        for (i = 0; i < graph.GetLength(0); i++)
        {
            currentSum = CalcPriceRecursive(i);
            if(maxSum < currentSum)
            {
                maxSum = currentSum;
            }
        }

        Console.WriteLine(maxSum.ToString());

        return;

    }

    private static int BFSGraphRecursive(int start, int count)
    {
        int i, ret = 1, next;

        visited[start] = true;

        for(i = 0; i < graph.GetLength(0); i++)
        {
            if(graph[start, i] == true && visited[i] == false)
            {
                next = BFSGraphRecursive(i, count + 1);
                ret = ret + next;

                if(next % 2 == 0 && parents[start] % 2 == 0)
                {
                    graph[start, i] = false;
                    graph[i, start] = false;
                    ret = ret - next;

                }
                
            }
        }

        parents[start] = ret;

        //currentSum = currentSum + start + 1;

        return ret;
    }

    private static int CalcPriceRecursive(int start)
    {
        int i, ret = start + 1;

        visited[start] = true;

        for (i = 0; i < graph.GetLength(0); i++)
        {
            if (graph[start, i] == true && visited[i] == false)
            {
                ret = ret + CalcPriceRecursive(i);
            }
        }

        return ret;
    }

    public static int ReadGraph()
    {
        int i, nNodes, nEdges, start;
        string[] s;

        s = Console.ReadLine().Split(' ').ToArray();

        nNodes = int.Parse(s[0]);
        nEdges = int.Parse(s[1]);
        start = int.Parse(s[2]);

        graph = new bool[nNodes, nNodes];
        visited = new bool[nNodes];
        totals = new int[nNodes];
        parents = new int[nNodes];

        for (i = 0; i < nEdges; i++)
        {
            s = Console.ReadLine().Split(' ').ToArray();

            graph[int.Parse(s[0]) - 1, int.Parse(s[1]) - 1] = true;
            graph[int.Parse(s[1]) - 1, int.Parse(s[0]) - 1] = true;

        }

        return start;

    }

    public static void PrintMatrix(bool[,] matrix)
    {
        string s;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            s = (matrix[i, 0] == true ? "1 " : "0 ");
            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                s = s + (matrix[i, j] == true ? "1 " : "0 ");
            }
            Console.WriteLine(s);
        }

        Console.WriteLine();

    }

}
