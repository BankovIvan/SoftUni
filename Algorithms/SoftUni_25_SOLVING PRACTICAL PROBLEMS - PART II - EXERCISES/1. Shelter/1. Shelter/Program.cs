using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    private static int numberOfSoldiers, numberOfShelters, soldierCapacity, shelterCapacity, N;
    //private static int[] soldiersCount, sheltesrCount;
    private static double maxValue;
    private static List<Edge> edges;

    private static int[][] graph;
    private static int[] parents;


    static void Main(string[] args)
    {

        int i;

        ReadGraph();

        for (i = Preset() - 1; i < edges.Count; i++)
        {
            InitGraph(i);
            if (FindMaxFlow() >= numberOfSoldiers)
            {
                maxValue = edges[i].cost;
                break;
            }

        }

        Console.WriteLine("{0:F6}", maxValue);

        return;
    }

    private static int Preset()
    {
        int i = 0, count = 0;
        bool[] visited = new bool[N];

        while (i < edges.Count)
        {
            if (visited[edges[i].soldier] == false)
            {
                visited[edges[i].soldier] = true;
                count++;
                if (count >= numberOfSoldiers)
                {
                    break;
                }
            }

            i++;
        }

        return i;
    }

    private static void InitGraph(int index)
    {
        int i;
        //N = 1 + numberOfSoldiers + numberOfShelters + 1;

        graph = new int[N][];
        for (i = 0; i < N; i++)
        {
            graph[i] = new int[N];
        }

        parents = new int[N];

        for (i = 0; i <= index; i++)
        {
            graph[edges[i].soldier + 1][numberOfSoldiers + edges[i].shelter + 1] = soldierCapacity; //soldierCapacity = 1
        }

        for (i = 0; i < numberOfSoldiers; i++)
        {
            //Element 0 = Start
            graph[0][i + 1] = soldierCapacity; //soldierCapacity = 1
        }

        for (i = 0; i < numberOfShelters; i++)
        {
            //Element k = End
            graph[i + numberOfSoldiers + 1][N - 1] = shelterCapacity;
        }

        /*
        Console.WriteLine();
        for (i = 0; i < N; i++)
        {
            Console.WriteLine(string.Join(" ", graph[i]));
        }
        */

    }

    private static void ReadGraph()
    {
        int i, j;
        int[][] soldierPositions, shelterPositions;
        string[] s;
        Edge newEdge;

        //Console.Write("    ");
        s = Console.ReadLine().Split(' ');

        numberOfSoldiers = int.Parse(s[0]);
        numberOfShelters = int.Parse(s[1]);
        shelterCapacity = int.Parse(s[2]);
        soldierCapacity = 1;

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

        edges = new List<Edge>();
        for (i = 0; i < numberOfShelters; i++)
        {
            for (j = 0; j < numberOfSoldiers; j++)
            {
                newEdge = new Edge(i, j);
                newEdge.CalculateCost(shelterPositions[i][0], shelterPositions[i][1], soldierPositions[j][0], soldierPositions[j][1]);
                edges.Add(newEdge);

            }
        }

        edges.Sort();

        N = 1 + numberOfSoldiers + numberOfShelters + 1;

        return;
    }

    public static int FindMaxFlow()
    {
        int i;
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


public class Edge : IComparable<Edge>
{
    public int soldier;
    public int shelter;
    public double cost;

    public Edge(int shelter, int soldier)
    {
        this.soldier = soldier;
        this.shelter = shelter;
        this.cost = 0.0;
    }

    public void CalculateCost(int shelterX, int shelterY, int soldierX, int soldierY)
    {
        double dx, dy;
        dx = (double)(shelterX - soldierX);
        dx = dx * dx;
        dy = (double)(shelterY - soldierY);
        dy = dy * dy;
        this.cost = Math.Sqrt(dx + dy);
    }

    public int CompareTo(Edge other)
    {
        return this.cost.CompareTo(other.cost);
    }
    public override string ToString()
    {
        return "<(" + soldier.ToString().PadLeft(4) + "," + shelter.ToString().PadLeft(4) + string.Format("):{0:F2}>", cost);
    }
}