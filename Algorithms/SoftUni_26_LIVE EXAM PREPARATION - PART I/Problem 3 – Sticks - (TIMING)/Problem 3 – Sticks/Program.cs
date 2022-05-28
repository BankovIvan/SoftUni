using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

class Program
{
    public static Dictionary<long, List<Edge>> graph; // = new List<Edge>();
    public static Dictionary<long, List<Edge>> parents;
    public static List<long> result = new List<long>();
    public static long N = 0;

    static void Main(string[] args)
    {

        ReadGraph();

        if (EvaluateGraph())
        {
            Console.WriteLine("Cannot lift all sticks");
        }

        Console.WriteLine(string.Join(" ", result));

        return;
    }

    private static bool EvaluateGraph()
    {
        long i;

        while(graph.Count > 0)
        {
            i = N;
            while (i >= 0)
            {
                if (graph.ContainsKey(i))
                {
                    if (graph[i].Count == 0)
                    {
                        result.Add(i);
                        foreach (var item in parents[i])
                        {
                            graph[item.bottomStick].Remove(item);
                        }
                        graph.Remove(i);
                        break;
                    }
                }


                i--;
            }

            if(i < 0 && graph.Count > 0)
            {
                return true;
            }
        }

        return false;

    }

    private static void ReadGraph()
    {
        long i, numberOfSticks;
        string[] s;
        Edge newEdge;

        //Console.Write("    ");
        N = long.Parse(Console.ReadLine());

        //Console.Write("    ");
        numberOfSticks = long.Parse(Console.ReadLine());

        graph = new Dictionary<long, List<Edge>>();
        parents = new Dictionary<long, List<Edge>>();
        for (i = 0; i < N; i++)
        {
            graph.Add(i, new List<Edge>());
            parents.Add(i, new List<Edge>());
        }

        for (i = 0; i < numberOfSticks; i++)
        {
            //Console.Write("    ");
            s = Console.ReadLine().Split(' ');
            newEdge = new Edge(long.Parse(s[0]), long.Parse(s[1]));
            graph[newEdge.bottomStick].Add(new Edge(newEdge.topStick, newEdge.bottomStick));
            parents[newEdge.topStick].Add(new Edge(newEdge.topStick, newEdge.bottomStick));
        }

    }
}

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
