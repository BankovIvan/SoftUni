using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{

    private static int[] childCounter;    // Track blocked edges
    private static int[] bfsDist;         // Distances in the Level Graph
    private static int[][] edges;     // adjacency list
    private static double[][] capacities;
    private static int startNode;
    private static int endNode;
    private static int N;

    static void Main(string[] args)
    {

        ReadGraph();

        Console.WriteLine();
        PrintGraph(edges);
        Console.WriteLine();
        PrintGraph(capacities);

        //cost = MinFlowCost(graph, numberOfSoldiers, numberOfShelters, shelterCapacity);

        Console.WriteLine("{0:F6}", Dinic(0, endNode));

        return;
    }

    static double Dinic(int source, int destination)
    {
        double result = 0.0;
        while (Bfs(source, destination))                // While we can find a path from source to sink
        {
            for (int i = 0; i < childCounter.Length; i++)
            {
                childCounter[i] = 0;                    // Reset blocked edges on each Level Graph
            }

            double delta;
            do
            {
                delta = Dfs(source, double.MaxValue);      // Each delta is the flow from an augmenting path
                result += delta;
            }
            while (delta != 0);
        }
        return result;
    }

    static bool Bfs(int src, int dest)
    {
        for (int i = 0; i < bfsDist.Length; i++)
        {
            bfsDist[i] = -1;         // Reset distances in Level Graph
        }
        bfsDist[src] = 0;
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(src);
        while (queue.Count > 0)
        {
            int currentNode = queue.Dequeue();
            for (int i = 0; i < N; i++)
            {
                //int child = edges[currentNode][i];

                if (edges[currentNode][i] > 0)
                {
                    //int child = i;
                    if (bfsDist[i] < 0 && capacities[currentNode][i] > 0.0)  // If node has not been visited
                    {
                        bfsDist[i] = bfsDist[currentNode] + 1;
                        queue.Enqueue(i);
                    }

                }

            }
        }
        return bfsDist[dest] >= 0;   // If there is a path to the sink return true
    }

    static double Dfs(int source, double flow)
    {
        if (source == endNode)    // If we reach the sink return the flow
        {
            return flow;
        }
        for (int i = childCounter[source]; i < N; i++)
        {
            //int child = edges[source][i];

            if (edges[source][i] == 0) continue;            // No path
            if (capacities[source][i] <= 0) continue;   // If the edge has no more room skip
            if (bfsDist[i] == bfsDist[source] + 1)      // Only check vertexes following the Level Graph
            {
                double augmentationPathFlow = Dfs(i, Math.Min(flow, capacities[source][i]));
                if (augmentationPathFlow > 0.0)
                {
                    capacities[source][i] -= augmentationPathFlow;     // Fix capacities
                    capacities[i][source] += augmentationPathFlow;
                    return augmentationPathFlow;
                }

                Console.WriteLine();
                PrintGraph(capacities);

            }
            childCounter[source]++;     // Mark child as blocked
        }
        return 0.0;          // If no path is found return 0 – path is blocked
    }

    private static void ReadGraph()
    {
        int numberOfSoldiers, numberOfShelters, shelterCapacity;
        int i, j, k;
        int[][] soldierPositions, shelterPositions;
        string[] s;
        double dx, dy, cost, maxCost = 0.0;

        Console.Write("    ");
        s = Console.ReadLine().Split(' ');

        numberOfSoldiers = int.Parse(s[0]);
        numberOfShelters = int.Parse(s[1]);
        shelterCapacity = int.Parse(s[2]);


        soldierPositions = new int[numberOfSoldiers][];
        for (i = 0; i < numberOfSoldiers; i++)
        {
            s = Console.ReadLine().Split(' ');
            soldierPositions[i] = new int[] { int.Parse(s[0]), int.Parse(s[1]) };
        }

        shelterPositions = new int[numberOfShelters][];
        for (i = 0; i < numberOfShelters; i++)
        {
            s = Console.ReadLine().Split(' ');
            shelterPositions[i] = new int[] { int.Parse(s[0]), int.Parse(s[1]) };
        }

        // START ---> ALL SOLDIERS ---> ---> ---> (ALL SHELTERS 2 TIMES) ---> END
        N = 1 + numberOfSoldiers + numberOfShelters * shelterCapacity + 1;
        capacities = new double[N][];
        edges = new int[N][];
        childCounter = new int[N];
        bfsDist = new int[N];
        startNode = 0;
        endNode = N - 1;

        for (i = 0; i < N; i++)
        {
            capacities[i] = new double[N];
            edges[i] = new int[N];
        }

        //ALL SOLDIERS ---> ---> ---> ALL SHELTERS 2 TIMES
        //CAPACITIES (ALL SOLDIERS ---> ---> ---> ALL SHELTERS 2 TIMES)
        for (i = 0; i < numberOfSoldiers; i++)
        {
            for (j = 0; j < numberOfShelters; j++)
            {
                dx = (double)(soldierPositions[i][0] - shelterPositions[j][0]);
                dx = dx * dx;
                dy = (double)(soldierPositions[i][1] - shelterPositions[j][1]);
                dy = dy * dy;
                cost = Math.Sqrt(dx + dy);

                if (maxCost < cost)
                {
                    maxCost = cost;
                }

                for(k = 0; k < shelterCapacity; k++)
                {
                    edges[i + 1][1 + numberOfSoldiers + j + numberOfShelters * k] = 1;
                    capacities[i + 1][1 + numberOfSoldiers + j + numberOfShelters * k] = cost;
                    //capacities[1 + numberOfSoldiers + j + numberOfShelters * k][i + 1] = cost;
                }
            }
        }

        //START ---> ALL SOLDIERS
        for (i = 0; i < numberOfSoldiers; i++)
        {
            edges[0][i + 1] = 1;
            capacities[0][i + 1] = maxCost;
        }

        //ALL EDGES ---> END
        for (j = 0; j < numberOfShelters * shelterCapacity; j++)
        {
            edges[1 + numberOfSoldiers + j][endNode] = 1;
            capacities[1 + numberOfSoldiers + j][endNode] = maxCost;
        }

        return;
    } 

    private static void PrintGraph(int[][] graph)
    {
        int i, j;
        string s;

        for (i = 0; i < graph.Length; i++)
        {
            s = string.Format("{0:F1}", graph[i][0]).PadLeft(5);
            for (j = 1; j < graph[i].Length; j++)
            {
                s = s + "," + string.Format("{0:F1}", graph[i][j]).PadLeft(4);
            }

            Console.WriteLine(s);
        }
    }

    private static void PrintGraph(double[][] graph)
    {
        int i, j;
        string s;

        for (i = 0; i < graph.Length; i++)
        {
            s = string.Format("{0:F1}", graph[i][0]).PadLeft(5);
            for (j = 1; j < graph[i].Length; j++)
            {
                s = s + "," + string.Format("{0:F1}", graph[i][j]).PadLeft(4);
            }

            Console.WriteLine(s);
        }
    }
}

