//namespace Kurskal
//{
    using System;
    using System.Collections.Generic;

    public class KruskalAlgorithm
    {
        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {
            int i;
            List<Edge> MST = new List<Edge>();
            int[] parent = new int[numberOfVertices];
            int ultraParentFrom, ultraParentTo;

            edges.Sort();

            for(i = 0;  i < numberOfVertices;  i++)
            {
                parent[i] = i;
            }

            foreach (var edge in edges)
            {
                ultraParentFrom = FindRoot(edge.StartNode, parent);
                ultraParentTo = FindRoot(edge.EndNode, parent);

                if(ultraParentFrom != ultraParentTo)
                {
                    parent[ultraParentTo] = ultraParentFrom;
                    MST.Add(edge);
                }

            }

            return MST;
        }

        public static int FindRoot(int node, int[] parent)
        {
            //recursive
            if(parent[node] == node) return node;

            parent[node] = FindRoot(parent[node], parent);

            return parent[node];

        }
    }
//}
