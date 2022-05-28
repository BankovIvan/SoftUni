using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

class Program
{
    public static Dictionary<int, List<int>> graph; // = new List<Edge>();
    public static int[] predecessors;
    public static List<int> removed = new List<int>();

    static void Main(string[] args)
    {

        ReadGraph();

        if (EvaluateGraph())
        {
            Console.WriteLine("Cannot lift all sticks");
        }

        Console.WriteLine(string.Join(" ", removed));

        return;
    }

    private static bool EvaluateGraph()
    {
        int i;
        bool removeNext = true;
        bool[] removedNodes = new bool[graph.Count]; 

        while(removeNext == true)
        {

            removeNext = false;

            for(i = graph.Count - 1; i >= 0; i--)
            {
                if (predecessors[i] == 0 && removedNodes[i] == false)
                {
                    foreach (var item in graph[i])
                    {
                        predecessors[item]--;
                    }

                    removedNodes[i] = true;
                    removed.Add(i);
                    removeNext = true;
                    break;
                }
            }
        }

        return removed.Count != graph.Count;

    }

    private static void ReadGraph()
    {
        int i, j, k, numberOfSticks, numberOfEntries;
        string[] s;
        //Edge newEdge;

        //Console.Write("    ");
        numberOfSticks = int.Parse(Console.ReadLine());

        //Console.Write("    ");
        numberOfEntries = int.Parse(Console.ReadLine());

        graph = new Dictionary<int, List<int>>();
        predecessors = new int[numberOfSticks];

        for (i = 0; i < numberOfSticks; i++)
        {
            graph.Add(i, new List<int>());
            //predecessors.Add(i, 0);
        }

        for (i = 0; i < numberOfEntries; i++)
        {
            //Console.Write("    ");
            s = Console.ReadLine().Split(' ');
            j = int.Parse(s[0]);
            k = int.Parse(s[1]);
            graph[j].Add(k);
            predecessors[k]++;

        }

    }
}

/*
public class Edge : IComparable<Edge>, IEquatable<Edge>
{
    public long topStick;
    public long bottomStick;

    public Edge(long topStick, long bottomStick)
    {
        this.topStick = topStick;
        this.bottomStick = bottomStick;
    }

    public int CompareTo(Edge other)
    {
        return this.topStick.CompareTo(other.topStick);
    }

    public bool Equals(Edge other)
    {
        return this.topStick == other.topStick && this.bottomStick == other.bottomStick;
    }

    public override string ToString()
    {
        return "<" + topStick.ToString().PadLeft(2) + "," + bottomStick.ToString().PadLeft(2) + ">";
    }

}
*/