using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    //public static Dictionary<long, List<Edge>> graph = new Dictionary<long, List<Edge>>();
    //public static Dictionary<long, long> pathCost = new Dictionary<long, long>();   //path cost for BFS/DFS;
    public static Dictionary<long, bool> colors = new Dictionary<long, bool>(); //white/black camera status as per the task;
    public static Dictionary<long, long> distances = new Dictionary<long, long>();  //distance to check the current color of the node;

    //public static Dictionary<Vertex, List<Edge>> graph = new Dictionary<Vertex, List<Edge>>();

    public static Dictionary<long, Node> nodes = new Dictionary<long, Node>();
    public static Dictionary<Node, Dictionary<Node, long>> graph = new Dictionary<Node, Dictionary<Node, long>>();

    public static long startingEnergy;
    public static long costForWaiting;
    public static long nodeStart;
    public static long nodeEnd;
    public static long N;

    static void Main(string[] args)
    {
        ReadGraph();

        var path = DijkstraWithPriorityQueue.DijkstraAlgorithm(graph, nodes[nodeStart], nodes[nodeEnd], distances, colors, costForWaiting);

        if (nodes[nodeEnd].DistanceFromStart > startingEnergy)
        {
            Console.WriteLine("Busted - need {0} more energy", nodes[nodeEnd].DistanceFromStart - startingEnergy);
        }
        else
        {
            Console.WriteLine(startingEnergy - nodes[nodeEnd].DistanceFromStart);
        }

        return;
    }
    
    private static void ReadGraph()
    {
        long i;
        string[] s;
        Node newNode;

        //Console.Write("    ");
        s = Console.ReadLine().Split(' ');

        foreach (var item in s)
        {
            i = long.Parse(item.Substring(0, item.Length - 1));

            newNode = new Node(i);
            nodes.Add(i, newNode);

            graph.Add(nodes[i], new Dictionary<Node, long>());
            //pathCost.Add(i, long.MaxValue);
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

        for (i = 0; i < N; i++)
        {
            Console.Write("    ");
            s = Console.ReadLine().Split(' ');

            graph[nodes[long.Parse(s[0])]].Add(nodes[long.Parse(s[1])], long.Parse(s[2]));
        }

    }

}


public static class DijkstraWithPriorityQueue
{
    public static List<long> DijkstraAlgorithm(Dictionary<Node, Dictionary<Node, long>> graph, Node sourceNode, Node destinationNode,
        Dictionary<long, long> distances, Dictionary<long, bool> colors, long costForWaiting)
    {
        //////////////////////////////////////
        long nextDistance;
        //////////////////////////////////////

        long?[] previous = new long?[graph.Count];
        bool[] visited = new bool[graph.Count];

        PriorityQueue<Node> priorityQueue = new PriorityQueue<Node>();

        List<long> path = new List<long>();
        long? current;

        Node currentNode;
        long distance = long.MaxValue;

        foreach (var pair in graph)
        {
            pair.Key.DistanceFromStart = long.MaxValue;
        }

        sourceNode.DistanceFromStart = 0;
        priorityQueue.Enqueue(sourceNode);
        //Assuming max node ID <= Count ???
        visited[sourceNode.Id] = true;

        /////////////////////////////////////////
        //pathCost[sourceNode.Id] = 0;
        distances[sourceNode.Id] = 1;
        /////////////////////////////////////////

        while (priorityQueue.Count > 0)
        {
            currentNode = priorityQueue.ExtractMin();

            if (currentNode.Id == destinationNode.Id)
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


                //////////////////////////////////////////////////////
                nextDistance = distances[currentNode.Id] + 1;

                if (distances[currentNode.Id] % 2 != 0)
                {
                    //Odd step
                    if (colors[edge.Key.Id] == false)
                    {
                        //-->black
                        distance = distance + costForWaiting;
                        nextDistance++;
                    }
                }
                else
                {
                    //Even step
                    if (colors[edge.Key.Id] == true)
                    {
                        //-->black
                        distance = distance + costForWaiting;
                        nextDistance++;
                    }
                }
                //////////////////////////////////////////////////////





                if (distance < edge.Key.DistanceFromStart)
                {
                    edge.Key.DistanceFromStart = distance;

                    previous[edge.Key.Id] = currentNode.Id;
                    priorityQueue.DecreaseKey(edge.Key);

                    //////////////////////////////////////////////////////////////
                    //pathCost[item.destination] = nextCost;
                    distances[edge.Key.Id] = nextDistance;
                    //nodesQueue.Enqueue(item.destination);
                    //////////////////////////////////////////////////////////////
                }

            }

        }

        /*
        if (destinationNode.DistanceFromStart == long.MaxValue)
        {
            return null;
        }

        current = destinationNode.Id;

        while (current != null)
        {
            path.Add(current.Value);
            current = previous[current.Value];
        }

        path.Reverse();

        */
        return path;

    }
}

public class Node : IComparable<Node>
{
    // set default value for the distance equal to positive infinity
    public Node(long id, long distance = long.MaxValue)
    {
        this.Id = id;
        this.DistanceFromStart = distance;
    }

    public long Id { get; set; }

    public long DistanceFromStart { get; set; }

    public int CompareTo(Node other)
    {
        return this.DistanceFromStart.CompareTo(other.DistanceFromStart);
    }

    public override string ToString()
    {
        return "<" + this.Id.ToString().PadLeft(2) + string.Format(":{0:F2}>", this.DistanceFromStart);
    }
}

public class PriorityQueue<T> where T : IComparable<T>
{
    private Dictionary<T, int> searchCollection;
    private List<T> heap;

    public PriorityQueue()
    {
        this.heap = new List<T>();
        this.searchCollection = new Dictionary<T, int>();
    }

    public int Count
    {
        get
        {
            return this.heap.Count;
        }
    }

    public T ExtractMin()
    {
        var min = this.heap[0];
        var last = this.heap[this.heap.Count - 1];
        this.searchCollection[last] = 0;
        this.heap[0] = last;
        this.heap.RemoveAt(this.heap.Count - 1);
        if (this.heap.Count > 0)
        {
            this.HeapifyDown(0);
        }

        this.searchCollection.Remove(min);

        return min;
    }

    public T PeekMin()
    {
        return this.heap[0];
    }

    public void Enqueue(T element)
    {
        this.searchCollection.Add(element, this.heap.Count);
        this.heap.Add(element);
        this.HeapifyUp(this.heap.Count - 1);
    }

    private void HeapifyDown(int i)
    {
        var left = (2 * i) + 1;
        var right = (2 * i) + 2;
        var smallest = i;

        if (left < this.heap.Count && this.heap[left].CompareTo(this.heap[smallest]) < 0)
        {
            smallest = left;
        }

        if (right < this.heap.Count && this.heap[right].CompareTo(this.heap[smallest]) < 0)
        {
            smallest = right;
        }

        if (smallest != i)
        {
            T old = this.heap[i];
            this.searchCollection[old] = smallest;
            this.searchCollection[this.heap[smallest]] = i;
            this.heap[i] = this.heap[smallest];
            this.heap[smallest] = old;
            this.HeapifyDown(smallest);
        }
    }

    private void HeapifyUp(int i)
    {
        var parent = (i - 1) / 2;
        while (i > 0 && this.heap[i].CompareTo(this.heap[parent]) < 0)
        {
            T old = this.heap[i];
            this.searchCollection[old] = parent;
            this.searchCollection[this.heap[parent]] = i;
            this.heap[i] = this.heap[parent];
            this.heap[parent] = old;

            i = parent;
            parent = (i - 1) / 2;
        }
    }

    public void DecreaseKey(T element)
    {
        int index = this.searchCollection[element];
        this.HeapifyUp(index);
    }
}