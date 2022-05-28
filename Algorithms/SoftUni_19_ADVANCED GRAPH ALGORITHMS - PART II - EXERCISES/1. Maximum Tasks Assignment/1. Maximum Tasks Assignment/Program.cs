using System;
using System.Collections.Generic;

class Program
{

    private static int[][] graph;
    private static int[] parents;

    static void Main(string[] args)
    {
        int i, j;
        char[] c; 
        int persons, tasks, nodes;

        Console.Write(" ");
        persons = int.Parse(Console.ReadLine().Split(' ')[1]);

        Console.Write(" ");
        tasks = int.Parse(Console.ReadLine().Split(' ')[1]);

        nodes = tasks + persons + 2;
        graph = new int[nodes][];
        for (i = 0; i < nodes; i++)
        {
            graph[i] = new int[nodes];
        }
        parents = new int[nodes];

        for (i = 0; i < tasks; i++)
        {
            Console.Write(" ");
            c = Console.ReadLine().ToCharArray();

            for(j = 0; j < persons; j++)
            {
                if(c[j] == 'Y')
                {
                    graph[i + 1][persons + j + 1] = 1;
                }
            }
        }

        for(i = 0; i < persons; i++)
        {
            //Element 0 = Start
            graph[0][i + 1] = 1;
        }

        for (i = 0; i < tasks; i++)
        {
            graph[i + persons + 1][nodes - 1] = 1;
        }

        /*
        Console.WriteLine();
        for (i = 0; i < nodes; i++)
        {
            Console.WriteLine(string.Join(" ", graph[i]));
        }
        */

        if(FindMaxFlow() > 0)
        {
            for (i = 0; i < persons; i++) //column
            {
                for (j = 0; j < tasks; j++)  //row
                {
                    if (graph[j + persons + 1][i + 1] == 1)
                    {
                        Console.WriteLine("{0}-{1}", Convert.ToChar('A' + i), j + 1);
                    }
                }
            }
        }

        /*
        Console.WriteLine();
        for (i = 0; i < nodes; i++)
        {
            Console.WriteLine(string.Join(" ", graph[i]));
        }

        Console.WriteLine();
        Console.WriteLine(FindMaxFlow(graph));
        */


        return;

    }


    public static int FindMaxFlow(/*int[][] targetGraph*/)
    {
        int i;
        //graph = targetGraph;
        parents = new int[graph.Length];
        int maxFlow;
        int start;
        int end;
        int pathFlow;
        int currentNode;
        int previousNode1;
        int previousNode2;

        for (i = 0; i < parents.Length; i++)
        {
            parents[i] = -1;
        }

        maxFlow = 0;
        start = 0;
        end = graph.Length - 1;
        parents[0] = 0;

        while (BreadthFirstSearch(start, end))
        {
            pathFlow = int.MaxValue;
            currentNode = end;

            while (currentNode != start)
            {
                previousNode1 = parents[currentNode];

                pathFlow = Math.Min(pathFlow, graph[previousNode1][currentNode]);

                currentNode = previousNode1;

            }

            maxFlow += pathFlow;

            currentNode = end;

            while (currentNode != start)
            {
                previousNode2 = parents[currentNode];

                graph[previousNode2][currentNode] -= pathFlow;

                graph[currentNode][previousNode2] += pathFlow;

                currentNode = previousNode2;

            }

            /*
            Console.WriteLine();
            for (i = 0; i < graph.Length; i++)
            {
                Console.WriteLine(string.Join(" ", graph[i]));
            }
            Console.WriteLine();
            Console.WriteLine(string.Join(" ", parents));
            */

        }

        return maxFlow;

    }

    private static bool BreadthFirstSearch(int start, int end)
    {
        int i, currentNode;
        bool[] visited = new bool[graph.Length];
        Queue<int> nodesQueue = new Queue<int>();

        nodesQueue.Enqueue(start);
        visited[start] = true;

        while (nodesQueue.Count > 0)
        {
            currentNode = nodesQueue.Dequeue();

            //for (i = 0; i < graph[currentNode].Length; i++)
            for (i = graph[currentNode].Length - 1; i >= 0; i--)
            {
                if (visited[i] == false && graph[currentNode][i] > 0)
                {
                    nodesQueue.Enqueue(i);
                    visited[i] = true;
                    parents[i] = currentNode;
                }
            }

        }

        return visited[end];

    }

}