//namespace Dijkstra
//{
    using System;
    using System.Collections.Generic;

    public static class DijkstraWithPriorityQueue
    {
        public static List<int> DijkstraAlgorithm(Dictionary<Node, Dictionary<Node, int>> graph, Node sourceNode, Node destinationNode)
        {
            int?[] previous = new int?[graph.Count];
            bool[] visited = new bool[graph.Count];

            PriorityQueue<Node> priorityQueue = new PriorityQueue<Node>();

            List<int> path = new List<int>();
            int? current;

            Node currentNode;
            double distance = double.MaxValue;

            foreach (var pair in graph)
            {
                pair.Key.DistanceFromStart = double.PositiveInfinity;
            }

            sourceNode.DistanceFromStart = 0.0;
            priorityQueue.Enqueue(sourceNode);
            //Assuming max node ID <= Count ???
            visited[sourceNode.Id] = true;

            while (priorityQueue.Count > 0)
            {
                currentNode = priorityQueue.ExtractMin();

                if(currentNode.Id == destinationNode.Id)
                {
                    break;
                }

                foreach (var edge in graph[currentNode])
                {
                    if (!visited[edge.Key.Id])
                    {
                        priorityQueue.Enqueue(edge.Key);
                        visited[edge.Key.Id] = true;
                    }

                    distance = currentNode.DistanceFromStart + edge.Value;
                    if (distance < edge.Key.DistanceFromStart)
                    {
                        edge.Key.DistanceFromStart = distance;

                        previous[edge.Key.Id] = currentNode.Id;
                        priorityQueue.DecreaseKey(edge.Key);
                    }



                }

            }

            if (double.IsInfinity(destinationNode.DistanceFromStart))
            {
                return null;
            }

            current = destinationNode.Id;

            while(current != null)
            {
                path.Add(current.Value);
                current = previous[current.Value];
            }

            path.Reverse();
            return path;

        }
    }
//}
