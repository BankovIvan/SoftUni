using System;
using System.Collections.Generic;

public class StronglyConnectedComponents
{
    private static int size;
    private static bool[] visited;
    private static List<int>[] graph;
    private static List<int>[] reverseGraph;
    private static List<List<int>> stronglyConnectedComponents;
    private static Stack<int> nodeStack;

    public static List<List<int>> FindStronglyConnectedComponents(List<int>[] targetGraph)
    {
        int node;
        size = targetGraph.Length;
        visited = new bool[size];
        graph = targetGraph;
        reverseGraph = new List<int>[size];
        stronglyConnectedComponents = new List<List<int>>();
        nodeStack = new Stack<int>();

        for (node = 0; node < size; node++)
        {
            DFS(node);
        }
            

        BuildReverseGraph();

        visited = new bool[size];

        while(nodeStack.Count > 0)
        {
            node = nodeStack.Pop();

            if (!visited[node])
            {
                stronglyConnectedComponents.Add(new List<int>());
                ReverseDFS(node);

            }

        }


        return stronglyConnectedComponents;
    }

    private static void ReverseDFS(int node)
    {
        if (!visited[node])
        {
            visited[node] = true;
            stronglyConnectedComponents[stronglyConnectedComponents.Count - 1].Add(node);

            foreach (int childNode in reverseGraph[node])
            {
                ReverseDFS(childNode);
            }

        }

    }

    private static void BuildReverseGraph()
    {
        int node;

        for(node = 0; node < size; node++)
        {
            reverseGraph[node] = new List<int>();
        }

        for (node = 0; node < size; node++)
        {
            foreach (int childNode in graph[node])
            {
                reverseGraph[childNode].Add(node);
            }
        }

    }

    private static void DFS(int node)
    {
        if (!visited[node])
        {
            visited[node] = true;
            //Queue.Enqueue(node);

            foreach (int childNode in graph[node])
            {
                DFS(childNode);
            }

            nodeStack.Push(node);

        }

    }
}
