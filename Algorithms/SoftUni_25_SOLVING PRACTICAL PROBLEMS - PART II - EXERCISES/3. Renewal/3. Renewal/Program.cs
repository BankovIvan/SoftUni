using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

class Program
{
    public static List<Edge> oldRoads = new List<Edge>();
    public static List<Edge> newRoads = new List<Edge>();
    //public static Dictionary<int, List<Edge>> graph = new Dictionary<int, List<Edge>>();
    public static int[] parent;
    public static bool[] visited;
    public static int total = 0, N;

    static void Main(string[] args)
    {
        ReadEdges();

        //Check old paths, add to graph the minimal spanning tree of old roads;
        CheckOldRoads();

        //Add new roads to the minimal spaning tree;
        CheckNewRoads();

        Console.WriteLine(total);

        return;
    }

    private static void CheckNewRoads()
    {
        Edge currentRoad;
        int i, parentSource, parentDestination;

        i = 0;
        while (i < newRoads.Count)
        {
            currentRoad = newRoads[i];

            parentSource = FindRoot(parent, currentRoad.source);
            parentDestination = FindRoot(parent, currentRoad.destination);

            if (parentSource != parentDestination)
            {
                //Adding only minimal spanning tree elements;
                parent[parentDestination] = parentSource;

                if (visited[currentRoad.source] == false)
                {
                    visited[currentRoad.source] = true;
                }

                if (visited[currentRoad.destination] == false)
                {
                    visited[currentRoad.destination] = true;
                }

                total = total + currentRoad.price;

                //graph[currentRoad.source].Add(new Edge(currentRoad.source, currentRoad.destination, currentRoad.price, false));
                //graph[currentRoad.destination].Add(new Edge(currentRoad.destination, currentRoad.source, currentRoad.price, false));
                
            }

            i++;
        }

        return;
    }

    private static void CheckOldRoads()
    {
        Edge currentRoad;
        int i, parentSource, parentDestination;

        visited = new bool[N];
        parent = new int[N];
        for(i = 0; i < N; i++)
        {
            parent[i] = i;
        }

        i = oldRoads.Count - 1;
        while (i >= 0)
        {
            currentRoad = oldRoads[i];

            parentSource = FindRoot(parent, currentRoad.source);
            parentDestination = FindRoot(parent, currentRoad.destination);

            if (parentSource != parentDestination)
            {
                //Adding only minimal spanning tree elements;
                parent[parentDestination] = parentSource;

                if(visited[currentRoad.source] == false)
                {
                    visited[currentRoad.source] = true;
                }

                if (visited[currentRoad.destination] == false)
                {
                    visited[currentRoad.destination] = true;
                }

                //graph[currentRoad.source].Add(new Edge(currentRoad.source, currentRoad.destination, currentRoad.price, true));
                //graph[currentRoad.destination].Add(new Edge(currentRoad.destination, currentRoad.source, currentRoad.price, true));

            }
            else
            {
                total = total + currentRoad.price;
            }

            i--;
        }

        return;
    }

    private static void ReadEdges()
    {
        int i, j, k;
        char[] input;
        Edge newEdge;
        Edge[][] allRoads;

        Console.Write("    ");
        N = int.Parse(Console.ReadLine());

        allRoads = new Edge[N][]; //NxN

        for (i = 0; i < N; i++)
        {
            allRoads[i] = new Edge[N]; //NxN

            Console.Write("    ");
            input = Console.ReadLine().Trim().ToCharArray();

            if(input.Length < N)
            {
                continue;
            }

            for (j = 0; j < N; j++)
            {
                //newEdge = new Edge(i, j, input[j], (input[j] == '1'));
                allRoads[i][j] = new Edge(i, j, input[j], (input[j] == '1'));
            }
        }


        for (i = 0; i < N; i++)
        {
            Console.Write("    ");
            input = Console.ReadLine().Trim().ToCharArray();

            for (j = i + 1; j < N; j++)
            {
                if(allRoads[i][j].existing == false || allRoads[j][i].existing == false)
                {
                    allRoads[i][j].CalcPrice(input[j]);
                    newRoads.Add(new Edge(allRoads[i][j]));
                }
            }
        }

        for (i = 0; i < N; i++)
        {
            Console.Write("    ");
            input = Console.ReadLine().Trim().ToCharArray();

            for (j = i + 1; j < N; j++)
            {
                if (allRoads[i][j].existing == true && allRoads[j][i].existing == true)
                {
                    allRoads[i][j].CalcPrice(input[j]);
                    oldRoads.Add(new Edge(allRoads[i][j]));
                }
            }
        }

        oldRoads.Sort();
        newRoads.Sort();

        return;
    }

    private static int FindRoot(int[] parent, int node)
    {
        while (parent[node] != node)
        {
            node = parent[node];
        }
        return node;
    }
}

public class Edge : IComparable<Edge>
{
    public int source;
    public int destination;
    public int price;
    public bool existing;

    public Edge(int source, int destination, char price, bool existing)
    {
        this.source = source;
        this.destination = destination;

        if(price >= 'A' && price <= 'Z')
        {
            this.price = (int)(price - 'A');
        }
        else if(price >= 'a' && price <= 'z')
        {
            this.price = (int)(price - 'a' + (char)26);
        }
        else
        {
            this.price = 0;
        }

        this.existing = existing;
    }

    public Edge(int source, int destination, int price, bool existing)
    {
        this.source = source;
        this.destination = destination;
        this.price = price;
        this.existing = existing;
    }

    public Edge(Edge other)
    {
        this.source = other.source;
        this.destination = other.destination;
        this.price = other.price;
        this.existing = other.existing;
    }

    public int CompareTo(Edge other)
    {
        int ret;

        ret = other.existing.CompareTo(this.existing);

        if(ret == 0)
        {
            ret = this.price.CompareTo(other.price);
        }

        return ret;

    }

    public override string ToString()
    {
        return "<" + source.ToString().PadLeft(2) + "," + destination.ToString().PadLeft(2) + ":" + this.price.ToString().PadLeft(2) + "/" + (this.existing ? "1" : "0") + ">";
    }

    public int CalcPrice(char price)
    {
        if (price >= 'A' && price <= 'Z')
        {
            this.price = (int)(price - 'A');
        }
        else if (price >= 'a' && price <= 'z')
        {
            this.price = (int)(price - 'a' + (char)26);
        }

        return this.price;
    }

}
