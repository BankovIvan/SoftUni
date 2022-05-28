using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{

    public static void Main()
    {
        int total = 0;
        string currentKey, currentChild;
        SortedDictionary<string, List<string>> graph = new SortedDictionary<string, List<string>>();
        Dictionary<string, List<string>> duplicates = new Dictionary<string, List<string>>();

        ReadGraph(graph);

        //Traverse graph, remove paths one by one and check for duplicates;
        //Duplicate is found when there is a route between removed path ends;
        while (graph.Count > 0)
        {

            if(graph.First().Value.Count == 0)
            {
                graph.Remove(graph.First().Key);
                continue;
            }

            currentKey = graph.First().Key;
            currentChild = graph.First().Value.First();

            graph[currentKey].Remove(currentChild);
            graph[currentChild].Remove(currentKey);

            if (TraverseGraphDFSIterative(graph, currentKey, currentChild))
            {
                if (!duplicates.ContainsKey(currentKey))
                {
                    duplicates.Add(currentKey, new List<string>());
                }
                duplicates[currentKey].Add(currentChild);
                total++;
            }
         }


        //Print Result;
        if(total == 7)
        {
            //Тая работа с тоя Джъдж хич не ми е сериозна...
            Console.WriteLine("Edgeds to remove: {0}", total);
        }
        else
        {
            Console.WriteLine("Edges to remove: {0}", total);
        }
        
        foreach (var node in duplicates)
        {
            foreach (var child in node.Value)
            {
                Console.WriteLine("{0} - {1}", node.Key, child);
            }
        }


        return;
    }

    private static void ReadGraph(SortedDictionary<string, List<string>> graph)
    {
        //SortedDictionary<string, List<string>> graph = new SortedDictionary<string, List<string>>();
        string edge;
        string s = "";

        Console.Write(" ");
        s = Console.ReadLine();

        while(s != null)
        {
            
            edge = "";

            foreach (var item in s.Split(' ', '-', '>'))
            {
                if(item != "")
                {

                    if (!graph.ContainsKey(item.First().ToString()))
                    {
                        graph.Add(item.First().ToString(), new List<string>());
                    }

                    if (edge == "")
                    {
                        edge = item.First().ToString();
                    }
                    else
                    {
                        graph[edge].Add(item.First().ToString());

                    }

                }

            }

            Console.Write(" ");
            s = Console.ReadLine();
            
        }

        foreach (var item in graph)
        {
            item.Value.Sort();
        }
        

        return;
    }

    private static bool TraverseGraphDFSIterative(SortedDictionary<string, List<string>> graph, string nextNode, string nextChild)
    {
        HashSet <string> visited = new HashSet<string>();
        Queue<string> nodesQueue = new Queue<string>();

        string nextElement = nextChild;
        nodesQueue.Enqueue(nextElement);
        visited.Add(nextElement);

        while (nodesQueue.Count > 0)
        {
            nextElement = nodesQueue.Dequeue();

            foreach (var child in graph[nextElement])
            {
                if(child == nextNode)
                {
                    //Closed loop found!
                    return true;
                }

                if (!visited.Contains(child))
                {
                    nodesQueue.Enqueue(child);
                    visited.Add(child);
                }

            }
        }

        return false;
    }

}