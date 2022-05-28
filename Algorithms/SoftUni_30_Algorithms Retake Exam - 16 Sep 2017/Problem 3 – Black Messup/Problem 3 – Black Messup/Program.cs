using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    //public static Dictionary<int, Node>[] molecules; // = new Dictionary<int, Node>();
    public static Dictionary<string, Node> athoms = new Dictionary<string, Node>();

    public static void Main()
    {
        int i;
        int nextValue = 0, maxValue = 0;

        ReadData();

        foreach (var item in athoms)
        {
            nextValue = BFSGraph(item.Value.name);
            if(maxValue < nextValue)
            {
                maxValue = nextValue;
            }
        }

        Console.WriteLine(maxValue.ToString());

        return;

    }

    private static int BFSGraph(string startNode)
    {
        int ret = 0;
        Queue<string> nodesQueue = new Queue<string>();
        string nextNode = startNode;
        List<Node> molecule = new List<Node>();

        if (athoms[startNode].visited == true)
        {
            return 0;
        }

        nodesQueue.Enqueue(nextNode);
        athoms[nextNode].visited = true;
        molecule.Add(athoms[nextNode]);

        while(nodesQueue.Count > 0)
        {
            nextNode = nodesQueue.Dequeue();

            foreach (var item in athoms[nextNode].edges)
            {
                if(athoms[item].visited == false)
                {
                    nodesQueue.Enqueue(item);
                    athoms[item].visited = true;
                    molecule.Add(athoms[item]);
                }
            }

        }

        ret = CalculateValue(molecule);

        return ret;
    }

    private static int CalculateValue(List<Node> molecule)
    {

        if (molecule.Count == 0) return 0;

        int i, j;
        int finalDeadline;
        int[] mySequence;

        molecule.Sort();
        finalDeadline = molecule.Last().decay;
        mySequence = new int[finalDeadline];

        for (i = molecule.Count - 1; i >= 0; i--)
        {
            for (j = molecule[i].decay - 1; j >= 0; j--)
            {

                if (mySequence[j] == 0)
                {
                    mySequence[j] = molecule[i].mass;
                    break;
                }
            }
        }

        return mySequence.Sum();
    }

    private static void ReadData()
    {
        int i, n, k;
        string[] s;

        n = int.Parse(Console.ReadLine());
        k = int.Parse(Console.ReadLine());

        for (i = 0; i < n; i++)
        {
            s = Console.ReadLine().Split(' ').ToArray();
            athoms.Add(s[0], new Node(s[0], int.Parse(s[1]), int.Parse(s[2])));
        }

        for (i = 0; i < k; i++)
        {
            s = Console.ReadLine().Split(' ').ToArray();

            athoms[s[0]].edges.Add(s[1]);
            athoms[s[1]].edges.Add(s[0]);

        }

        return;
    }
}

class Node : IComparable<Node>
{
    public string name;
    public int mass;
    public int decay;
    public List<string> edges;
    public bool visited;

    public Node(string name, int mass, int decay)
    {
        this.name = name;
        this.mass = mass;
        this.decay = decay;
        edges = new List<string>();
        visited = false;
    }

    public int CompareTo(Node other)
    {

        return this.mass.CompareTo(other.mass);
    }

    public override string ToString()
    {
        return "<" + this.name + ":" + mass.ToString() + "," + decay.ToString() + ">";
    }
}
