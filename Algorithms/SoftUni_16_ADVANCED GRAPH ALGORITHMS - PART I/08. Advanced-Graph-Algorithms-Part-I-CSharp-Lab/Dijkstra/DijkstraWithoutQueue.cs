//namespace Dijkstra
//{
    using System;
    using System.Collections.Generic;

    public static class DijkstraWithoutQueue
    {
        public static List<int> DijkstraAlgorithm(int[,] graph, int sourceNode, int destinationNode)
        {
            int i, vertex;
            int minIndex;
            bool sthUpdate;
            
            int n = graph.GetLength(0);
            bool[] visited = new bool[n];   //Visited...

            int[] d = new int[n];           //Path costs
            int[] parent = new int[n];      //Shortest path table;

            List<int> path = new List<int>();
            
            //Initialize variables
            for (i = 0; i < n; i++)
            {
                d[i] = int.MaxValue;
                parent[i] = i;
            }

            //Start from node d[sourceNode]!
            d[sourceNode] = 0;

            while (true)
            {
                //Find node with minimum distance to starting node and not visited;
                minIndex = int.MaxValue;

                for (i = 0; i < d.Length; i++)
                {
                    if(!visited[i])
                    {
                        //Not visited +
                        if (minIndex == int.MaxValue || d[minIndex] > d[i])
                            {
                            //First pass (minIndex == int.MaxValue) or 
                            //d[minIndex] > d[i] is checked only if minIndex != int.MaxValue!!!!!
                            //minIndex is updated until the node with minimum value is found, regardless whether it is connected or not...
                            minIndex = i;
                        }
                    }
                }

                //All nodes marked as visited, exit;
                if (minIndex == int.MaxValue)
                {
                    break;
                }

                sthUpdate = false;
                visited[minIndex] = true;

                //Traverse through children of graph[minIndex, ];
                for (i = 0; i < n; i++)
                {
                    if(graph[minIndex, i] == 0)
                    {
                        continue;
                    }

                    //If we have value already stored for this node...
                    //d holds path cost for node [i];
                    if(d[i] > d[minIndex] + graph[minIndex, i])
                    {
                        d[i] = d[minIndex] + graph[minIndex, i];
                        parent[i] = minIndex;
                        sthUpdate = true;
                    }
                }

                //sthUpdate == false means no further calculation is possible;
                //We are checking only the part of the graph which is connected to start node; 
                if (sthUpdate == false)
                {
                    break;
                }
            }

            //No path found
            if(parent[destinationNode] == destinationNode)
            {
                return null;
            }


            //Reconstruct the path;
            vertex = destinationNode;

            while(vertex != sourceNode)
            {
                path.Add(vertex);
                vertex = parent[vertex];
            }

            path.Add(sourceNode);

            path.Reverse();

            return path;

        }
    }
//}
