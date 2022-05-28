using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int i, j;
        int N = int.Parse(Console.ReadLine());
        int P;
        char[][] map = new char[N][];
        bool[,] visited;
        //Dictionary<char, List<int>> counts = new Dictionary<char, List<int>>();
        List<char> counts = new List<char>();

        for (i = 0; i < N; i++)
        {
            map[i] = Console.ReadLine().ToCharArray();
        }

        P = map[0].Length;
        visited = new bool[N,P];

        for(i = 0; i < N; i++)
        {
            for(j = 0; j < P; j++)
            {
                CountFieldsBFSIterative(map, visited, counts, i, j);
            }
        }

        counts.Sort();

        Console.WriteLine("Areas: {0}", counts.Count);
        foreach (var item in counts.Distinct())
        {
            Console.WriteLine("Letter '{0}' -> {1}", item, counts.Count(x => x == item));
        }

        return;

    }

    //private static void CountFieldsBFSIterative(char[][] map, bool[,] visited, Dictionary<char, List<int>> counts, int row, int col)
    private static void CountFieldsBFSIterative(char[][] map, bool[,] visited, List<char> counts, int row, int col)
    {
        int N = map.Length;
        int P = map[0].Length;
        int nextRow, nextCol;
        char currentChar;
        int[] currentElement;
        //int total = 0;

        Queue<int[]> nodesQueue;
        
        if (visited[row, col]) return; //Go Next;

        nodesQueue = new Queue<int[]>();
        currentChar = map[row][col];
        currentElement = new int[] { row, col };

        counts.Add(currentChar);

        nodesQueue.Enqueue(currentElement);
        visited[currentElement[0], currentElement[1]] = true;

        while (nodesQueue.Count > 0)
        {
            currentElement = nodesQueue.Dequeue();
            //total++;

            //Left
            nextRow = currentElement[0];
            nextCol = currentElement[1] - 1;
            if ((nextRow >= 0 && nextRow < N) && (nextCol >= 0 && nextCol < P))
            {
                if (visited[nextRow, nextCol] == false && currentChar == map[nextRow][nextCol])
                {
                    nodesQueue.Enqueue(new int[] { nextRow, nextCol });
                    visited[nextRow, nextCol] = true;
                }
            }


            //Top
            nextRow = currentElement[0] - 1;
            nextCol = currentElement[1];
            if ((nextRow >= 0 && nextRow < N) && (nextCol >= 0 && nextCol < P))
            {
                if (visited[nextRow, nextCol] == false && currentChar == map[nextRow][nextCol])
                {
                    nodesQueue.Enqueue(new int[] { nextRow, nextCol });
                    visited[nextRow, nextCol] = true;
                }
            }

            //Right
            nextRow = currentElement[0];
            nextCol = currentElement[1] + 1;
            if ((nextRow >= 0 && nextRow < N) && (nextCol >= 0 && nextCol < P))
            {
                if (visited[nextRow, nextCol] == false && currentChar == map[nextRow][nextCol])
                {
                    nodesQueue.Enqueue(new int[] { nextRow, nextCol });
                    visited[nextRow, nextCol] = true;
                }
            }

            //Bottom
            nextRow = currentElement[0] + 1;
            nextCol = currentElement[1];
            if ((nextRow >= 0 && nextRow < N) && (nextCol >= 0 && nextCol < P))
            {
                if (visited[nextRow, nextCol] == false && currentChar == map[nextRow][nextCol])
                {
                    nodesQueue.Enqueue(new int[] { nextRow, nextCol });
                    visited[nextRow, nextCol] = true;
                }
            }

        }

        //if (!counts.ContainsKey(currentChar)) counts.Add(currentChar, new List<int>());

        //counts[currentChar].Add(total);

        return;

    }

}

public class graphInfo
{
    Dictionary<int, List<int>> graph;

    public graphInfo()
    {
        graph = new Dictionary<int, List<int>>();
    }

    public static Dictionary<int, List<int>> ReadGraph(int N)
    {
        int i;
        string s;
        List<int> childs;
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

        for (i = 0; i < N; i++)
        {
            s = Console.ReadLine();
            childs = new List<int>();

            foreach (var item in s.Split(':')[1].Split())
            {
                if (item != "")
                {
                    childs.Add(int.Parse(item));
                }
            }

            graph.Add(int.Parse(s.Split(':')[0]), childs);
        }

        return graph;
    }
}

public class taskInfo : IComparable<taskInfo>, IEquatable<taskInfo>
{
    public int nodeFrom { get; set; }
    public int nodeTo { get; set; }
    public int value { get; set; }

    public taskInfo()
    {
        this.nodeFrom = 0;
        this.nodeTo = 0;
        this.value = -1;
    }

    public taskInfo(int _nodeFrom, int _nodeTo)
    {
        this.nodeFrom = _nodeFrom;
        this.nodeTo = _nodeTo;
        this.value = -1;
    }

    public taskInfo(int _nodeFrom, int _nodeTo, int _value)
    {
        this.nodeFrom = _nodeFrom;
        this.nodeTo = _nodeTo;
        this.value = _value;
    }

    public int CompareTo(taskInfo other)
    {
        return other.value.CompareTo(this.value);
    }

    public bool Equals(taskInfo other)
    {
        return (this.nodeFrom == other.nodeFrom && this.nodeTo == other.nodeTo);
    }

    public override string ToString()
    {
        return "{" + nodeFrom.ToString() + ", " + nodeTo.ToString() + "} -> " + value.ToString();
    }

    public static List<taskInfo> ReadTasks(int P)
    {
        int i;
        string s;
        List<taskInfo> tasks = new List<taskInfo>();

        for (i = 0; i < P; i++)
        {
            s = Console.ReadLine();
            tasks.Add(new taskInfo(int.Parse(s.Split('-')[0]), int.Parse(s.Split('-')[1])));
        }

        return tasks;
    }
}
