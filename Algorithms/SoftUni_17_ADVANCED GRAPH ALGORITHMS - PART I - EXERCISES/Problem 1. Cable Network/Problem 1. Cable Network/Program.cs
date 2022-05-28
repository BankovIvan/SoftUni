#define JUDGE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string[] s;
        int i, budget, nNodes, nEdges;
        double total = 0.0;
        double addedValue = 0.0;

        Dictionary<int, vertex> graph = new Dictionary<int, vertex>();

        vertex currentVertex, prevVertex;
        edge currentEdge;

        slowPriorityQueue<edge> slowPriorityQueue = new slowPriorityQueue<edge>();

        Console.Write(" ");
        budget = int.Parse(Console.ReadLine().Split(' ')[1]);
        Console.Write(" ");
        nNodes = int.Parse(Console.ReadLine().Split(' ')[1]);
        Console.Write(" ");
        nEdges = int.Parse(Console.ReadLine().Split(' ')[1]);

        for (i = 0; i < nNodes; i++)
        {
            graph.Add(i, new vertex(i));
            graph[i].SetVisited(false);
            //No need to keep note cost;
            //graph[i].SetValue(double.PositiveInfinity);
        }

        //Create graph;
        //Add all edges twice (undirected);
        //Mark all already connected vertices as visited;
        //Set their cost to 0;
        for (i = 0; i < nEdges; i++)
        {
            s = Console.ReadLine().Split(' ');
            currentEdge = new edge(int.Parse(s[0]), int.Parse(s[1]), double.Parse(s[2]), false);

            foreach (var item in graph.Where(x => x.Key == currentEdge.nodeFrom || x.Key == currentEdge.nodeTo))
            {
                item.Value.AddChild(currentEdge);
                item.Value.AddChild(currentEdge.Reverse());  //undirected graph;
                if (s.Length > 3)
                {
                    //No need to keep note cost;
                    //item.Value.cost = 0.0;
                    item.Value.visited = true;
                }
                
            }
        }

        //Add all edges from already connected vertices to the priority queue;
        foreach (var item in graph.Where(x => x.Value.visited == true))
        {
            foreach (var vector in item.Value.edges)
            {
                if(graph[vector.nodeTo].visited == false)
                {
                    slowPriorityQueue.Enqueue(vector);
                }
            }
        }

        //Extract lowest cost edge;
        //If it is connecting to non-visited node...
        //Update next vertex cost;
        //Mark next vertex as visited;
        //Add it's edges to queue, if they point to non-visited nodes;
        while(slowPriorityQueue.Count > 0)
        {
            currentEdge = slowPriorityQueue.Dequeue();
            currentVertex = graph[currentEdge.nodeTo];
            prevVertex = graph[currentEdge.nodeFrom];

            if (currentVertex.visited == false)
            {
                currentVertex.visited = true;
                //No need to keep note cost;
                //addedValue = prevVertex.cost.Value + currentEdge.cost.Value;
                //currentVertex.cost = prevVertex.cost.Value + currentEdge.cost.Value;

                addedValue = total + currentEdge.cost.Value;
                if (addedValue > budget)
                {
                    //Budget will be exceeded, exit;
                    //No need to test further;
                    break;
                }
                else
                {
                    total = addedValue;
                }

                foreach (var item in currentVertex.edges)
                {
                    if (graph[item.nodeTo].visited == false)
                    {
                        slowPriorityQueue.Enqueue(item);
                    }
                }

            }

        }

        Console.WriteLine("Budget used: {0}", (int) total);

        return;

    }
}

class vertex : IComparable<vertex>, IEquatable<vertex>, IEquatable<int>
{
    public int nodeID;
    public double? cost;
    public int? parent;
    public bool? visited;
    public List<edge> edges;

    public vertex(int nodeID)
    {
        this.nodeID = nodeID;
        edges = new List<edge>();
    }

    public int CompareTo(vertex other)
    {
        int result = 0;

        if(this.cost != null && other.cost != null)
        {
            result = this.cost.Value.CompareTo(other.cost.Value);
        }
        else
        {
            result = other.nodeID.CompareTo(this.nodeID);
        }

        return result;

    }

    public override string ToString ()
    {
        string s = "<";

        s = s + this.nodeID.ToString();

        if(this.cost != null)
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

    public bool AddChild(edge vector)
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

    public bool UpdatePath(vertex parent, edge link, bool setVisited = true)
    {
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

    public bool UpdatePath(vertex parent, bool setVisited = true)
    {
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

    public bool Equals(vertex other)
    {
        return this.nodeID == other.nodeID;
    }

    public bool Equals(int other)
    {
        return this.nodeID == other;
    }
}

class edge : IComparable<edge>, IEquatable<edge>
{
    public int nodeFrom;
    public int nodeTo;
    public double? cost;
    public bool directed;
    
    public edge(int nodeFrom, int nodeTo, bool directed = false)
    {
        this.nodeFrom = nodeFrom;
        this.nodeTo = nodeTo;
        this.directed = directed;
        //this.cost = null;
    }

    public edge(int nodeFrom, int nodeTo, double cost, bool directed = false)
    {
        this.nodeFrom = nodeFrom;
        this.nodeTo = nodeTo;
        this.directed = directed;
        this.cost = cost;
    }

    public int CompareTo(edge other)
    {
        int result = 0;
        if(this.cost != null && other.cost != null)
        {
            result = this.cost.Value.CompareTo(other.cost.Value);
        }
        else
        {
            result = this.nodeTo.CompareTo(other.nodeTo);
        }

        return result;
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

        if(this.cost != null)
        {
            if (double.IsInfinity(this.cost.Value))
            {
                s = s + ":INF";
            }
            else
            {
                s = s + ":" + string.Format("{0:F2}", this.cost.Value);
            }
            
        }

        return s;
    }

    public bool Equals(edge other)
    {
        bool result = true;

        result = (this.nodeTo == other.nodeTo) && (this.nodeFrom == other.nodeFrom);

        return result;
    }

    public edge Reverse()
    {
        if(cost != null)
        {
            return new edge(this.nodeTo, this.nodeFrom, this.cost.Value, this.directed);
        }

        return new edge(this.nodeTo, this.nodeFrom, this.directed);
    }

}

class slowPriorityQueue<T> where T:IComparable<T>
{
    public LinkedList<T> Q;
    public int Count
    {
        get
        {
            return this.Q.Count;
        }
    }

    public slowPriorityQueue()
    {
        Q = new LinkedList<T>();
    }

    public void Enqueue(T element)
    {
        LinkedListNode<T> current = Q.First;

        if (Q.First != null)
        {
            //Add element while maintaining sorted order;
            while(current.Value.CompareTo(element) < 0)
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

}