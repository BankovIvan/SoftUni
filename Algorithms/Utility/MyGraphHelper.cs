using System;


class Vertex : IComparable<Vertex>, IEquatable<Vertex>, IEquatable<int>
{
    public int nodeID;
    public double? cost;
    public int? parent;
    public bool? visited;
    public List<Edge> edges;

    public Vertex(int nodeID)
    {
        this.nodeID = nodeID;
        edges = new List<Edge>();
    }

    public int CompareTo(Vertex other)
    {
        int result = 0;

        if (this.cost != null && other.cost != null)
        {
            result = this.cost.Value.CompareTo(other.cost.Value);
        }
        else
        {
            result = other.nodeID.CompareTo(this.nodeID);
        }

        return result;

    }

    public override string ToString()
    {
        string s = "<";

        s = s + this.nodeID.ToString();

        if (this.cost != null)
        {
            s = s + ":" + string.Format("{0:F2}", this.cost.Value) + "]";
        }
        else
        {
            s = s + ":*>";
        }

#if !JUDGE

        foreach (var item in edges)
        {
            s = s + ":" + item.ToString();
        }

#endif

        return s;
    }

    public void SetValue(double value = double.PositiveInfinity)
    {
        this.cost = value;
    }

    public void SetParent(int parent)
    {
        this.parent = parent;
    }

    public void SetVisited(bool visited = false)
    {
        this.visited = visited;
    }

    public bool AddChild(Edge vector)
    {
        int i;

        if (vector.nodeFrom != this.nodeID)
        {
            return false;
        }

        //Very slow, add elements pre-sorted...
        i = 0;
        while (i < edges.Count)
        {
            if (edges[i].CompareTo(vector) < 0)
            {
                break;
            }
            i++;
        }

        this.edges.Insert(i, vector);

        return true;
    }

    public bool UpdatePath(Vertex parent, Edge link, bool setVisited = true)
    {
        //NOT USED!

        if (parent.parent == null || this.parent == null)
        {
            return false;
        }

        this.parent = parent.parent;

        if (this.cost != null && parent.cost != null && link.cost != null)
        {
            this.cost = parent.cost + link.cost;
        }

        if (this.visited != null && parent.visited != null && setVisited == true)
        {
            this.visited = true;
        }

        return true;
    }

    public bool UpdatePath(Vertex parent, bool setVisited = true)
    {
        //NOT USED!

        if (parent.parent == null || this.parent == null)
        {
            return false;
        }

        this.parent = parent.parent;

        if (this.visited != null && parent.visited != null && setVisited == true)
        {
            this.visited = true;
        }

        return true;
    }

    public bool Equals(Vertex other)
    {
        //NOT USED!

        return this.nodeID == other.nodeID;

    }

    public bool Equals(int other)
    {
        //NOT USED!

        return this.nodeID == other;

    }

}

class Edge : IComparable<Edge>, IEquatable<Edge>
{
    public int nodeFrom;
    public int nodeTo;
    public double? cost;
    public bool directed;
    public bool? visited;

    public Edge(int nodeFrom, int nodeTo, bool directed = false)
    {
        this.nodeFrom = nodeFrom;
        this.nodeTo = nodeTo;
        this.directed = directed;
        //this.cost = null;
        //this.visited = false;
    }

    public Edge(int nodeFrom, int nodeTo, double cost, bool directed = false)
    {
        this.nodeFrom = nodeFrom;
        this.nodeTo = nodeTo;
        this.directed = directed;
        this.cost = cost;
        //this.visited = false;
    }

    public int CompareTo(Edge other)
    {
        int result = 0;
        if (this.cost != null && other.cost != null)
        {
            result = this.cost.Value.CompareTo(other.cost.Value);
        }
        else
        {
            result = this.nodeTo.CompareTo(other.nodeTo);
        }

        return result;
    }

    public void SetVisited(bool visited = false)
    {
        this.visited = visited;
    }

    public bool GetVisited()
    {
        if (this.visited != null)
        {
            return visited.Value;
        }

        return false;

    }

    public override string ToString()
    {
        string s = "<";

        s = s + this.nodeFrom.ToString();

        if (this.directed)
        {
            s = s + "->";
        }
        else
        {
            s = s + "--";
        }

        s = s + nodeTo.ToString() + ">";

        if (this.cost != null)
        {
            if (double.IsInfinity(this.cost.Value))
            {
                s = s + ":INF>";
            }
            else
            {
                s = s + ":" + string.Format("{0:F2}>", this.cost.Value);
            }

        }

#if !JUDGE

        if (this.visited != null)
        {
            s = s + (this.visited.Value ? "Y" : "N");
        }
        else
        {
            s = s + "*";
        }

#endif
        return s;
    }

    public bool Equals(Edge other)
    {
        //NOT USED!

        bool result = true;

        result = (this.nodeTo == other.nodeTo) && (this.nodeFrom == other.nodeFrom);

        return result;
    }

    public Edge Reverse()
    {
        if (cost != null)
        {
            return new Edge(this.nodeTo, this.nodeFrom, this.cost.Value, this.directed);
        }

        return new Edge(this.nodeTo, this.nodeFrom, this.directed);
    }

}

class SlowPriorityQueue<T> where T : IComparable<T>, IEquatable<T>
{
    public LinkedList<T> Q;
    public int Count
    {
        get
        {
            return this.Q.Count;
        }
    }

    public SlowPriorityQueue()
    {
        Q = new LinkedList<T>();
    }

    public void Enqueue(T element)
    {
        LinkedListNode<T> current = Q.First;

        if (Q.First != null)
        {
            //Add element while maintaining sorted order;
            while (current.Value.CompareTo(element) < 0)
            {
                if (current == Q.Last)
                {
                    break;
                }

                current = current.Next;
            }

            Q.AddBefore(current, element);

        }
        else
        {
            Q.AddFirst(element);
        }

    }

    public T Dequeue()
    {

        LinkedListNode<T> current = Q.First;

        Q.RemoveFirst();

        return current.Value;

    }

    public void Sort()
    {
        List<T> data = Q.ToList();

        data.Sort();

        Q.Clear();

        Q = new LinkedList<T>(data);

    }

    public void ChangeValue(T element)
    {
        //Replaces given element in the list;

        LinkedListNode<T> current = Q.First;

        /*
        if (current == null)
        {
            return;
        }

        if(Q.Last.Value.Equals(element))
        {
            Q.Last.Value = element;
            return;
        }
        */

        while (current != null)
        {
            if (current.Value.Equals(element))
            {
                current.Value = element;
                //return;
            }

            current = current.Next;
        }
    }
}

class GraphHelper
{

    public static List<Edge> ReadEdges(ref int nNodes, ref int nEdges)
    {
        List<Edge> edges = new List<Edge>();

        string[] s;
        int i;

        Console.Write(" ");
        nNodes = int.Parse(Console.ReadLine().Split(' ')[1]);
        Console.Write(" ");
        nEdges = int.Parse(Console.ReadLine().Split(' ')[1]);

        for (i = 0; i < nEdges; i++)
        {
            s = Console.ReadLine().Split(' ');

            //For Kruskal we don’t need edges to be added to both source and destination;
            edges.Add(new Edge(int.Parse(s[0]), int.Parse(s[1]), double.Parse(s[2]), true));

            //For Kruskal we need visited flag;
            edges[i].SetVisited(false);
        }

        return edges;
    }

    public static Dictionary<int, Vertex> ReadGraph(ref int nNodes, ref int nEdges, ref int start, ref int finish)
    {

        Dictionary<int, Vertex> graph = new Dictionary<int, Vertex>();
        Edge currentEdge;

        string[] s;
        int i;

        Console.Write(" ");
        nNodes = int.Parse(Console.ReadLine().Split(' ')[1]);
        Console.Write(" ");
        s = Console.ReadLine().Split(' ');
        start = int.Parse(s[1]);
        finish = int.Parse(s[3]);
        Console.Write(" ");
        nEdges = int.Parse(Console.ReadLine().Split(' ')[1]);

        for (i = 0; i < nNodes; i++)
        {
            graph.Add(i, new Vertex(i));
            //graph[i].SetVisited(false);
            graph[i].SetParent(i);
            graph[i].SetValue(0.0);
        }

        for (i = 0; i < nEdges; i++)
        {
            Console.Write(" ");
            s = Console.ReadLine().Split(' ');

            currentEdge = new Edge(int.Parse(s[0]), int.Parse(s[1]), double.Parse(s[2]) / 100.0, false);

            if (!graph.ContainsKey(currentEdge.nodeFrom))
            {
                graph.Add(currentEdge.nodeFrom, new Vertex(currentEdge.nodeFrom));
                //graph[currentEdge.nodeFrom].SetVisited(false);
                graph[currentEdge.nodeFrom].SetParent(currentEdge.nodeFrom);
                graph[currentEdge.nodeFrom].SetValue(0.0);
            }

            if (!graph.ContainsKey(currentEdge.nodeTo))
            {
                graph.Add(currentEdge.nodeTo, new Vertex(currentEdge.nodeTo));
                //graph[currentEdge.nodeTo].SetVisited(false);
                graph[currentEdge.nodeTo].SetParent(currentEdge.nodeTo);
                graph[currentEdge.nodeTo].SetValue(0.0);
            }

            graph[currentEdge.nodeFrom].AddChild(currentEdge);

            if (currentEdge.directed == false)
            {
                currentEdge = currentEdge.Reverse();
                graph[currentEdge.nodeFrom].AddChild(currentEdge);
            }

        }

        return graph;
    }

    public static Dictionary<int, Vertex> CreateGraph(List<Edge> edges, int nNodes = 0)
    {
        int i;
        Dictionary<int, Vertex> graph = new Dictionary<int, Vertex>();

        foreach (var item in edges)
        {
            if (!graph.ContainsKey(item.nodeFrom))
            {
                graph.Add(item.nodeFrom, new Vertex(item.nodeFrom));
                graph[item.nodeFrom].parent = item.nodeFrom;
                //graph[item.nodeFrom].SetValue(double.PositiveInfinity);
                graph[item.nodeFrom].SetVisited(false);
            }

            graph[item.nodeFrom].AddChild(item);

            if (!graph.ContainsKey(item.nodeTo))
            {
                graph.Add(item.nodeTo, new Vertex(item.nodeTo));
                graph[item.nodeTo].parent = item.nodeTo;
                //graph[item.nodeTo].SetValue(double.PositiveInfinity);
                graph[item.nodeTo].SetVisited(false);
            }

            if (item.directed == false)
            {
                graph[item.nodeTo].AddChild(item.Reverse());
            }


        }

        for (i = 0; i < nNodes; i++)
        {
            if (!graph.ContainsKey(i))
            {
                graph.Add(i, new Vertex(i));
                graph[i].parent = i;
                //graph[i].SetValue(double.PositiveInfinity);
                graph[i].SetVisited(false);
            }
        }

        return graph;
    }

    public static Dictionary<int, Vertex> CreateEmptyGraph(List<Edge> edges, int nNodes = 0)
    {
        int i;
        Dictionary<int, Vertex> graph = new Dictionary<int, Vertex>();

        foreach (var item in edges)
        {
            if (!graph.ContainsKey(item.nodeFrom))
            {
                graph.Add(item.nodeFrom, new Vertex(item.nodeFrom));
                graph[item.nodeFrom].parent = item.nodeFrom;
                //graph[item.nodeFrom].SetValue(double.PositiveInfinity);
                graph[item.nodeFrom].SetVisited(false);
            }

            if (!graph.ContainsKey(item.nodeTo))
            {
                graph.Add(item.nodeTo, new Vertex(item.nodeTo));
                graph[item.nodeTo].parent = item.nodeTo;
                //graph[item.nodeTo].SetValue(double.PositiveInfinity);
                graph[item.nodeTo].SetVisited(false);
            }

        }

        for (i = 0; i < nNodes; i++)
        {
            if (!graph.ContainsKey(i))
            {
                graph.Add(i, new Vertex(i));
                graph[i].parent = i;
                //graph[i].SetValue(double.PositiveInfinity);
                graph[i].SetVisited(false);
            }
        }

        return graph;
    }

    public static void PrintGraph(Dictionary<int, Vertex> graph)
    {

    }

    public static void PrintEdges(List<Edge> edges, bool bUsed = false)
    {
        foreach (var item in edges)
        {
            if (bUsed == false || item.GetVisited() == true)
            {
                Console.WriteLine("({0} {1}) -> {2}", item.nodeFrom, item.nodeTo, (int)item.cost.Value);
            }
        }


    }

    public static void PrintEdgesSortedByParent(Dictionary<int, Vertex> graph, List<Edge> edges, bool bUsed = false)
    {
        Edge edge;

        foreach (var item in edges)
        {
            if (bUsed == false || item.GetVisited() == true)
            {
                if (graph[item.nodeFrom].parent < graph[item.nodeTo].parent)
                {
                    edge = item;
                }
                else
                {
                    edge = item.Reverse();
                }


                Console.WriteLine("({0} {1}) -> {2}", edge.nodeFrom, edge.nodeTo, (int)edge.cost.Value);
            }
        }


    }

    public static int FindRoot(Dictionary<int, Vertex> graph, int nodeFrom)
    {
        while (graph[nodeFrom].parent != nodeFrom)
        {
            nodeFrom = graph[nodeFrom].parent.Value;
        }

        return nodeFrom;

    }

}