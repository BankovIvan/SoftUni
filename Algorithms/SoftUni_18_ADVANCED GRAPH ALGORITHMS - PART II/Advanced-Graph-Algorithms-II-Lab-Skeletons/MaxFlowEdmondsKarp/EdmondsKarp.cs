using System;
using System.Collections.Generic;

public class EdmondsKarp
{
    private static int[][] graph;
    private static int[] parents;

    public static int FindMaxFlow(int[][] targetGraph)
    {
        int i;
        graph = targetGraph;
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

            while(currentNode != start)
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

        while(nodesQueue.Count > 0)
        {
            currentNode = nodesQueue.Dequeue();

            for(i = 0; i < graph[currentNode].Length; i++)
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
