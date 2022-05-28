using System;
using System.Collections.Generic;

public class ArticulationPoints
{
    
    private static List<int>[] graph;
    private static bool[] visited;
    private static int?[] parent;
    private static int[] depths;
    private static int[] lowpoints;
    private static List<int> articulationPoints;

    public static List<int> FindArticulationPoints(List<int>[] targetGraph)
    {
        int i;
        graph = targetGraph;
        visited = new bool[graph.Length];
        parent = new int?[graph.Length];
        depths = new int[graph.Length];
        lowpoints = new int[graph.Length];
        articulationPoints = new List<int>();


        for(i = 0; i < graph.Length; i++ )
        {
            FindArticulationPoints(i, depths[i]);
        }
        
        return articulationPoints;

    }

    private static void FindArticulationPoints(int node, int depth)
    {
        visited[node] = true;
        depths[node] = depth;
        lowpoints[node] = depth;

        int childCount = 0;
        bool isArticulation = false;

        foreach (var childNode in graph[node])
        {
            if (!visited[childNode])
            {
                parent[childNode] = node;
                FindArticulationPoints(childNode, depth + 1);

                childCount++;

                if (lowpoints[childNode] >= depths[node])
                {
                    isArticulation = true;

                }

                lowpoints[node] = Math.Min(lowpoints[node], lowpoints[childNode]);

            }
            else if (parent[node] == null || parent[node] != childNode)
            {
                lowpoints[node] = Math.Min(lowpoints[node], depths[childNode]);
            }
        }

        if((parent[node] != null && isArticulation == true) || (parent[node] == null && childCount > 1))
        {
            articulationPoints.Add(node);
        }

    }
}
