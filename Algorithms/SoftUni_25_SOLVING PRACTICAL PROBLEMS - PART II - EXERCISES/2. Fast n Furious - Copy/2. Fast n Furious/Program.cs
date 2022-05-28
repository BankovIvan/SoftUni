using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    public static SortedSet<string> result = new SortedSet<string>();

    static void Main(string[] args)
    {
        Dictionary<string, List<Edge>> graph = new Dictionary<string, List<Edge>>();
        Dictionary<string, List<Task>> tasks = new Dictionary<string, List<Task>>();

        ReadGraph(graph, tasks);

        foreach (var task in tasks)
        {
            task.Value.Sort();
            CheckSpeeding(graph, task);
        }

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }

        return;

    }

    private static bool CheckSpeeding(Dictionary<string, List<Edge>> graph, KeyValuePair<string, List<Task>> task)
    {
        int i;

        for(i = 1; i < task.Value.Count; i++)
        {
            if(CheckSpeeding(graph, task.Value[i - 1], task.Value[i]))
            {
                result.Add(task.Key);
                return true;
            }
        }

        return false;
    }

    private static bool CheckSpeeding(Dictionary<string, List<Edge>> graph, Task start, Task end)
    {
        Dictionary<string, bool> visited = new Dictionary<string, bool>();
        Dictionary<string, double> arrival = new Dictionary<string, double>();
        double currentTimespan;
        string currentNode = start.destination;
        Queue<string> nodes = new Queue<string>();

        foreach (var item in graph)
        {
            arrival.Add(item.Key, 0.0);
            visited.Add(item.Key, false);
        }

        arrival[currentNode] = 0.0;
        nodes.Enqueue(currentNode);

        while(nodes.Count > 0)
        {
            currentNode = nodes.Dequeue();
            visited[currentNode] = true;

            foreach (var child in graph[currentNode])
            {
                currentTimespan = arrival[currentNode] + child.distance / child.speedLimit;
                if(arrival[child.destination] < currentTimespan)
                {
                    arrival[child.destination] = currentTimespan;

                    nodes.Enqueue(child.destination);
                }
            }

        }

        return ((end.time - start.time) < arrival[end.destination]) && (visited[end.destination] == true);
    }

    private static void ReadGraph(Dictionary<string, List<Edge>> graph, Dictionary<string, List<Task>> tasks)
    {
        string s;
        string[] input;
        DateTime timeIn;
        double time;

        Console.Write("    ");
        s = Console.ReadLine();

        //Cameras
        Console.Write("    ");
        s = Console.ReadLine().Trim();

        while (s != "Records:")
        {
            input = s.Split(' ');

            if (!graph.ContainsKey(input[0]))
            {
                graph.Add(input[0], new List<Edge>());
            }
            graph[input[0]].Add(new Edge(input[1], double.Parse(input[2]), double.Parse(input[3])));

            if (!graph.ContainsKey(input[1]))
            {
                graph.Add(input[1], new List<Edge>());
            }
            graph[input[1]].Add(new Edge(input[0], double.Parse(input[2]), double.Parse(input[3])));

            Console.Write("    ");
            s = Console.ReadLine().Trim();

        }

        //Cars
        Console.Write("    ");
        s = Console.ReadLine().Trim();

        while (s != "End")
        {
            input = s.Split(' ');

            if (!tasks.ContainsKey(input[1]))
            {
                tasks.Add(input[1], new List<Task>());
            }
            timeIn = DateTime.Parse(input[2]);
            time = (double)timeIn.Hour + ((double)timeIn.Minute / 60.0) + ((double)timeIn.Second / 3600.0);
            tasks[input[1]].Add(new Task(input[0], time));

            Console.Write("    ");
            s = Console.ReadLine().Trim();

        }

        return;
    }
}

public class Edge : IComparable<Edge>
{
    public string destination;
    public double distance;
    public double speedLimit;

    public Edge(string destination, double distance, double speedLimit)
    {
        this.distance = distance;
        this.speedLimit = speedLimit;
        this.destination = destination;
    }

    public int CompareTo(Edge other)
    {
        return this.distance.CompareTo(other.distance);
    }

    public override string ToString()
    {
        return "<" + destination.PadLeft(8) + string.Format(":{0:F2}", this.distance) + string.Format(",{0:F2}>", this.speedLimit);
    }

}


public class Task : IComparable<Task>
{
    public string destination;
    public double time; //time in hours

    public Task(string destination, double time)
    {
        this.destination = destination;
        this.time = time;
    }

    public int CompareTo(Task other)
    {
        return this.time.CompareTo(other.time);
    }

    public override string ToString()
    {
        return "<" + destination.PadLeft(8) + string.Format(":{0:F2}>", time);
    }

}
