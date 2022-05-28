using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

class Program
{
    public static Dictionary<long, List<Edge>> graph = new Dictionary<long, List<Edge>>();
    public static Dictionary<long, long> path = new Dictionary<long, long>();   //path cost for BFS/DFS;
    public static Dictionary<long, bool> colors = new Dictionary<long, bool>(); //white/black camera status as per the task;
    public static Dictionary<long, long> distances = new Dictionary<long, long>();  //distance to check the current color of the node;
    public static long startingEnergy;
    public static long costForWaiting;
    public static long nodeStart;
    public static long nodeEnd;
    public static long N;

    static void Main(string[] args)
    {

        ReadGraph();

        BFSGraph();

        if(path[nodeEnd] > startingEnergy)
        {
            Console.WriteLine("Busted - need {0} more energy", path[nodeEnd] - startingEnergy);
        }
        else
        {
            Console.WriteLine(startingEnergy - path[nodeEnd]);
        }

        return;
    }

    private static void BFSGraph()
    {
        long nextCost = 0;
        long currentNode = nodeStart;
        Queue<long> nodesQueue = new Queue<long>();
        long nextDistance;

        path[currentNode] = 0;
        distances[currentNode] = 1;
        nodesQueue.Enqueue(currentNode);

        while(nodesQueue.Count > 0)
        {
            currentNode = nodesQueue.Dequeue();
            
            foreach (var item in graph[currentNode])
            {
                nextCost = path[currentNode] + item.energy;
                nextDistance = distances[currentNode] + 1;

                if(distances[currentNode] % 2 != 0)
                {
                    //Odd step
                    if(colors[item.destination] == false)
                    {
                        //-->black
                        nextCost = nextCost + costForWaiting;
                        nextDistance++;
                    }
                }
                else
                {
                    //Even step
                    if (colors[item.destination] == true)
                    {
                        //-->black
                        nextCost = nextCost + costForWaiting;
                        nextDistance++;
                    }
                }

                if(nextCost < path[item.destination])
                {
                    path[item.destination] = nextCost;
                    distances[item.destination] = nextDistance;
                    nodesQueue.Enqueue(item.destination);
                }
            }
        }
    }

    private static void ReadGraph()
    {
        long i;
        string[] s;
        Edge newEdge;

        Console.Write("    ");
        s = Console.ReadLine().Split(' ');

        foreach (var item in s)
        {
            i = long.Parse(item.Substring(0, item.Length - 1));
            graph.Add(i, new List<Edge>());
            path.Add(i, long.MaxValue);
            colors.Add(i, item.Substring(item.Length - 1, 1) == "w");
            distances.Add(i, 0);
 
        }

        Console.Write("    ");
        startingEnergy = long.Parse(Console.ReadLine());

        Console.Write("    ");
        costForWaiting = long.Parse(Console.ReadLine());

        Console.Write("    ");
        nodeStart = long.Parse(Console.ReadLine());

        Console.Write("    ");
        nodeEnd = long.Parse(Console.ReadLine());

        Console.Write("    ");
        N = long.Parse(Console.ReadLine());

        for(i = 0; i < N; i++)
        {
            Console.Write("    ");
            s = Console.ReadLine().Split(' ');

            newEdge = new Edge(long.Parse(s[0]), long.Parse(s[1]), long.Parse(s[2]));

            //graph[newEdge.source].Add(new Edge(newEdge.source, newEdge.destination, newEdge.energy, newEdge.color));
            graph[newEdge.source].Add(newEdge);

        }

    }
}


public class Edge : IComparable<Edge>
{
    public long source;
    public long destination;
    public long energy;

    public Edge(long source, long destination, long energy)
    {
        this.source = source;
        this.destination = destination;
        this.energy = energy;
    }

    public int CompareTo(Edge other)
    {
        return this.energy.CompareTo(other.energy);
    }

    public override string ToString()
    {
        return "<" + source.ToString().PadLeft(2) + "," + destination.ToString().PadLeft(2) + ":" + energy.ToString().PadLeft(2) + ">";
    }

}

