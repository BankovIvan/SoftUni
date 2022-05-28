using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    public static Dictionary<int, Node> graph;
    public static int[,] strikes;   //{neighbourhood} {damage}

    public static void Main()
    {
        int i;

        ReadData();

        for(i = 0; i < strikes.GetLength(0); i++)
        {
            BFSGraph(strikes[i, 0], strikes[i, 1]);
        }

        Console.WriteLine(graph.Values.Max().damage.ToString());

        return;

    }

    private static void BFSGraph(int strikeNode, int strikeDamage)
    {
        int nextNode, prevNode;
        Edge currentEdge;
        bool[] currentVisited = new bool[graph.Count];
        int[] currentDamage = new int[graph.Count];
        PriorityQueue<Edge> edgesQueue = new PriorityQueue<Edge>();

        currentVisited[strikeNode] = true;
        currentDamage[strikeNode] = strikeDamage;
        graph[strikeNode].damage = graph[strikeNode].damage + currentDamage[strikeNode];
        foreach (var item in graph[strikeNode].edges)
        {
            edgesQueue.Enqueue(item);
        }

        while (edgesQueue.Count > 0)
        {
            currentEdge = edgesQueue.ExtractMin();

            if(currentVisited[currentEdge.node1] == false)
            {
                prevNode = currentEdge.node2;
                nextNode = currentEdge.node1;
            }
            else if (currentVisited[currentEdge.node2] == false)
            {
                prevNode = currentEdge.node1;
                nextNode = currentEdge.node2;
            }
            else
            {
                continue;
            }

            currentVisited[nextNode] = true;
            currentDamage[nextNode] = currentDamage[prevNode] / 2;
            graph[nextNode].damage = graph[nextNode].damage + currentDamage[nextNode];
            foreach (var item in graph[nextNode].edges)
            {
                if(currentVisited[item.GetOtherNode(nextNode)] == false)
                {
                    edgesQueue.Enqueue(item);
                }                
            }
        }

        return;
    }

    private static void ReadData()
    {
        int i, n, m, l;
        string[] s;
        Edge cable;

        n = int.Parse(Console.ReadLine());
        m = int.Parse(Console.ReadLine());
        l = int.Parse(Console.ReadLine());

        graph = new Dictionary<int, Node>();
        strikes = new int[l, 2];

        for (i = 0; i < n; i++)
        {
            graph.Add(i, new Node());
        }

        for (i = 0; i < m; i++)
        {
            s = Console.ReadLine().Split(' ').ToArray();
            cable = new Edge(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]));

            graph[cable.node1].edges.Add(cable);
            graph[cable.node2].edges.Add(cable);
        }

        for (i = 0; i < l; i++)
        {
            s = Console.ReadLine().Split(' ').ToArray();
            strikes[i, 0] = int.Parse(s[0]);
            strikes[i, 1] = int.Parse(s[1]);
        }

        return;
    }
}

class Edge : IComparable<Edge>
{
    public int node1;
    public int node2;
    public int distance;

    public Edge(int node1, int node2, int distance)
    {
        this.node1 = node1;
        this.node2 = node2;
        this.distance = distance;
    }

    public int CompareTo(Edge other)
    {
        return this.distance.CompareTo(other.distance);
    }

    public override string ToString()
    {
       return "<" + node1.ToString() + ", " + node2.ToString() + ":" + distance.ToString() + ">";
    }

    public int GetOtherNode(int node)
    {
        int ret = node;

        if(node == this.node1) ret = this.node2;
        else if (node == this.node2) ret = this.node1;

        return ret;
    }
}

class Node : IComparable<Node>
{
    public int damage;
    public List<Edge> edges;

    public Node()
    {
        this.damage = 0;
        edges = new List<Edge>();
    }

    public int CompareTo(Node other)
    {
        return this.damage.CompareTo(other.damage);
    }

    public override string ToString()
    {
            return "<" + damage.ToString() + ":(" + edges.Count + ")>";
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
