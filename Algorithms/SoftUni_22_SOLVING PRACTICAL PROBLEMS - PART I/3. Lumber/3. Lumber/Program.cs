using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string[] s;
        int i, j, N, M;
        int[,] rectangles, queries;
        bool[,] graph;
        bool[] visited;

        Console.Write("    ");
        s = Console.ReadLine().Split(' ');
        N = int.Parse(s[0]);
        M = int.Parse(s[1]);

        rectangles = new int[N,4];
        queries = new int[M,2];
        //graph = new int[N][];
        visited = new bool[N];

        for (i = 0; i < N; i++)
        {
            Console.Write("    ");
            s = Console.ReadLine().Split(' ');
            rectangles[i, 0] = int.Parse(s[0]);
            rectangles[i, 1] = int.Parse(s[1]);
            rectangles[i, 2] = int.Parse(s[2]);
            rectangles[i, 3] = int.Parse(s[3]);
        }

        graph = CreateGraph(rectangles, N);

        for (i = 0; i < M; i++)
        {
            Console.Write("    ");
            s = Console.ReadLine().Split(' ');
            queries[i, 0] = int.Parse(s[0]);
            queries[i, 1] = int.Parse(s[1]);
        }

        for (i = 0; i < N; i++)
        {
            if(visited[i] == false)
            {
                TraverseGraphBFS(graph, visited, N, i);
            }
            
        }

        for(i = 0; i < queries.GetLength(0); i++)
        {
            Console.WriteLine(graph[queries[i, 0] - 1, queries[i, 1] - 1] == true ? "YES" : "NO");
        }

        return;

    }

    private static void TraverseGraphBFS(bool[,] graph, bool[] visited, int N, int start)
    {
        int i, j, childNode, currentElement = start;
        Queue<int> nodesQueue = new Queue<int>();
        List<int> connectedElements = new List<int>();

        nodesQueue.Enqueue(currentElement);
        visited[currentElement] = true;

        while(nodesQueue.Count > 0)
        {
            currentElement = nodesQueue.Dequeue();
            connectedElements.Add(currentElement);

            for (childNode = 0; childNode < N; childNode++)
            {

                if(graph[currentElement, childNode] == true && currentElement != childNode)
                {
                    if (visited[childNode] == false)
                    {
                        nodesQueue.Enqueue(childNode);
                        visited[childNode] = true;
                    }

                }

            }

        }

        for(i = connectedElements.Count - 1; i > 0; i--)
        {
            for (j = i - 1; j >= 0; j--)
            {
                graph[connectedElements[i], connectedElements[j]] = true;
                graph[connectedElements[j], connectedElements[i]] = true;
            }
        }

    }

    private static bool[,] CreateGraph(int[,] rectangles, int N)
    {
        int i, j;
        bool[,] graph = new bool[N,N];

        for (i = 0; i < N; i++)
        {

            for (j = i + 1; j < N; j++)
            {
                graph[i, i] = true;
                graph[j, j] = true;

                if (rectangles[i,0] <= rectangles[j,2] && 
                    rectangles[i,2] >= rectangles[j,0] && 
                    rectangles[i,1] >= rectangles[j,3] && 
                    rectangles[i,3] <= rectangles[j,1])
                {
                    graph[i,j] = true;
                    graph[j,i] = true;

                }
            }
        }

        return graph;
    }
}
