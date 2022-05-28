using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    public static int[,] school;
    public static int[] rooms;
    public static int[] exits;
    public static int time;

    static void Main(string[] args)
    {
        int i, maxIndex = 0, maxTime = 0, hours, minutes, seconds;
        List<string> s = new List<string>();

        ReadGraph();

        BFSGraph();

        for (i = 0; i < rooms.Length; i++)
        {
            if(rooms[i] == int.MaxValue)
            {
                s.Add(string.Format("{0} (unreachable)", i));
            }
            else if(rooms[i] > time)
            {
                hours = rooms[i] / 3600;
                minutes = (rooms[i] / 60) - (hours * 60);
                seconds = rooms[i] % 60;

                s.Add(string.Format("{0} ({1:D2}:{2:D2}:{3:D2})", i, hours, minutes, seconds));
            }

            if(maxTime < rooms[i])
            {
                maxTime = rooms[i];
                maxIndex = i;
            }
        }

        if(s.Count > 0)
        {
            Console.WriteLine("Unsafe");

            Console.Write(s[0]);
            i = 1;
            while(i < s.Count)
            {
                Console.Write(", {0}", s[i]);
                i++;
            }

        }
        else
        {

            Console.WriteLine("Safe");

            hours = maxTime / 3600;
            minutes = (maxTime / 60) - (hours * 60);
            seconds = maxTime % 60;

            Console.Write("{0} ({1:D2}:{2:D2}:{3:D2})", maxIndex, hours, minutes, seconds);

        }

        Console.WriteLine();

        return;

    }

    private static void BFSGraph()
    {
        int i, currentNode, currentTime;
        Queue<int> nodesQueue = new Queue<int>();

        foreach (var item in exits)
        {
            rooms[item] = 0;
            nodesQueue.Enqueue(item);
        }

        while(nodesQueue.Count > 0)
        {
            currentNode = nodesQueue.Dequeue();
            
            for(i = 0; i < rooms.Length; i++)
            {
                currentTime = rooms[currentNode] + school[currentNode, i];

                if (currentTime < rooms[i] && school[currentNode, i] > 0)
                {
                    rooms[i] = currentTime;
                    nodesQueue.Enqueue(i);

                }

            }
        }

        return;

    }

    public static void ReadGraph()
    {
        int i, j, k, N, C, seconds;
        string[] s;

        Console.Write("    ");
        N = int.Parse(Console.ReadLine());

        school = new int[N, N];
        //rooms = Enumerable.Repeat(int.MaxValue, N).ToArray();  //new int[N];
        rooms = new int[N];
        for(i = 0; i < N; i++)
        {
            rooms[i] = int.MaxValue;
        }

        Console.Write("    ");
        exits = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Console.Write("    ");
        C = int.Parse(Console.ReadLine());

        for(i = 0; i < C; i++)
        {
            Console.Write("    ");
            s = Console.ReadLine().Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
            seconds = int.Parse(s[2]) * 60 + int.Parse(s[3]);
            j = int.Parse(s[0]);
            k = int.Parse(s[1]);

            if(j < N && k < N)
            {
                school[j, k] = seconds;
                school[k, j] = seconds;
            }

        }

        Console.Write("    ");
        s = Console.ReadLine().Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
        time = int.Parse(s[0]) * 60 + int.Parse(s[1]);

        return;

    }

}

