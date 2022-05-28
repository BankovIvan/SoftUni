using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

class Program
{

    public static Dictionary<string, List<string>> graph;
    public static Dictionary<string, int> steps;
    public static List<string> startupNodes;

    static void Main(string[] args)
    {
        int i;
        int maxStep = 0;

        List<string> cycledNodes = new List<string>();
        List<string> emptyNodes = new List<string>();

        ReadGraph();

        BFSGraphRecursive();

        foreach (var item in steps)
        {
            if(item.Value < int.MaxValue)
            {
                if(maxStep < item.Value)
                {
                    maxStep = item.Value;
                }
                
            }
            else
            {
                emptyNodes.Add(item.Key);
            }
        }

        if(emptyNodes.Count > 0)
        {
            emptyNodes.Sort();

            Console.Write("Cannot reach: " + emptyNodes[0]);

            for(i = 1; i < emptyNodes.Count; i++)
            {
                Console.Write(", " + emptyNodes[i]);
            }

            Console.WriteLine();

        }
        else
        {
            foreach (var item in steps)
            {
                if (item.Value == maxStep)
                {
                    cycledNodes.Add(item.Key);
                }
            }

            cycledNodes.Sort();

            Console.WriteLine("All people reached in {0} steps", maxStep);
            Console.Write("People at last step: " + cycledNodes[0]);

            for (i = 1; i < cycledNodes.Count; i++)
            {
                Console.Write(", " + cycledNodes[i]);
            }

            Console.WriteLine();

        }

        return;
    }

    private static void BFSGraphRecursive()
    {
        int currentStep;
        string currentNode;
        Queue<string> nodesQueue = new Queue<string>();

        foreach (var item in startupNodes)
        {
            nodesQueue.Enqueue(item);
            steps[item] = 0;
        }

        while(nodesQueue.Count > 0)
        {
            currentNode = nodesQueue.Dequeue();
            currentStep = steps[currentNode] + 1;

            foreach (var friend in graph[currentNode])
            {
                if(steps[friend] > currentStep)
                {
                    steps[friend] = currentStep;
                    nodesQueue.Enqueue(friend);
                }
            }
        }

        return;
    }

    private static void ReadGraph()
    {
        int i;
        string[] s;

        graph = new Dictionary<string, List<string>>();
        steps = new Dictionary<string, int>();
        startupNodes = new List<string>();

        s = Console.ReadLine().Split(new char[] { ' ', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

        for(i = 1; i < s.Length; i++)
        {
            graph.Add(s[i].Trim(), new List<string>());
            steps.Add(s[i].Trim(), int.MaxValue);
        }

        s = Console.ReadLine().Split(new char[] { ' ', ':', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);

        for (i = 2; i < s.Length; i = i + 2)
        {
            graph[s[i - 1].Trim()].Add(s[i].Trim());
            graph[s[i].Trim()].Add(s[i - 1].Trim());
        }

        s = Console.ReadLine().Split(new char[] { ' ', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

        for (i = 1; i < s.Length; i++)
        {
            startupNodes.Add(s[i].Trim());
            //steps[s[i].Trim()] = 0;
        }

        return;
    }
}
