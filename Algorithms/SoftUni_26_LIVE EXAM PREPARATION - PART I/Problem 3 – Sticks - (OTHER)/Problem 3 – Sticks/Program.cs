using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        var graph = ReadGraph();

        var topSorter = new TopologicalSorter(graph);

        var sortedNodes = topSorter.TopSortDFS();

        Console.WriteLine("Topological sorting: {0}",
            string.Join(", ", sortedNodes));

        return;

    }

    private static Dictionary<long, List<long>> ReadGraph()
    {
        long i, N, top, bottom, numberOfSticks;
        string[] s;
        var graph = new Dictionary<long, List<long>>();

        Console.Write("    ");
        N = long.Parse(Console.ReadLine());

        Console.Write("    ");
        numberOfSticks = long.Parse(Console.ReadLine());

        for (i = 0; i < N; i++)
        {
            graph.Add(i, new List<long>());
        }

        for (i = 0; i < numberOfSticks; i++)
        {
            Console.Write("    ");
            s = Console.ReadLine().Split(' ');
            top = long.Parse(s[0]);
            bottom = long.Parse(s[1]);
            graph[top].Add(bottom);
        }

        return graph;
    }
}

public class TopologicalSorter
{
    private Dictionary<long, List<long>> graph;     //key = node name, value = child's names;
    private Dictionary<long, int> predecessorCount;   //key = (current node) node name, value = number of childs;
    private HashSet<long> visited;                    //DFS sort algo vaiable; 
    private HashSet<long> cycleNodes;                 //DFS sort algo vaiable;

    public TopologicalSorter(Dictionary<long, List<long>> graph)
    {
        this.graph = graph;
    }

    public ICollection<long> TopSortDFS()
    {
        // TODO: Implement the topological sorting algorithm
        LinkedList<long> sorted = new LinkedList<long>();
        visited = new HashSet<long>();
        cycleNodes = new HashSet<long>();

        foreach (var node in graph.Keys)
        {
            DFS(node, sorted);
        }

        return sorted;
    }

    private void DFS(long node, LinkedList<long> result)
    {
        if (cycleNodes.Contains(node))
        {
            Console.WriteLine("Cannot lift all sticks");
            return;
            //throw new InvalidOperationException("Cycle detected.");
        }

        if (!visited.Contains(node))
        {
            visited.Add(node);
            cycleNodes.Add(node);

            foreach (var item in graph[node])
            {
                DFS(item, result);
            }

            cycleNodes.Remove(node);
            result.AddFirst(node);

        }
    }


    public ICollection<long> TopSort()
    {
        // TODO: Implement the topological sorting algorithm
        List<long> sorted = new List<long>();

        GetPredecessorCount(graph);

        while (graph.Count > 0)
        {
            long nodeToRemove = -1;

            /*
            //
            // NOT WORKING! (Key type of string!)
            //
            string nodeToRemove = predecessorCount.Keys
                .Where(x => predecessorCount[x] == 0)
                .FirstOrDefault();
                */

            foreach (var item in predecessorCount)
            {
                if (item.Value == 0)
                {
                    nodeToRemove = item.Key;
                    break;
                }
            }

            if (nodeToRemove == -1)
            {
                Console.WriteLine("Cannot lift all sticks");
                break;
                //throw new InvalidOperationException();

            }

            DecrementPredecessorCount(graph, nodeToRemove);

            graph.Remove(nodeToRemove);
            sorted.Add(nodeToRemove);

        }

        return sorted;
    }

    private void GetPredecessorCount(Dictionary<long, List<long>> graph)
    {
        //Fill the predecessorCount variable (dictionary);
        //It stores all nodes in graph and the number of their predecessors;
        predecessorCount = new Dictionary<long, int>();

        foreach (var node in graph)     //Iterate through all nodes in the graph;
        {
            if (!predecessorCount.ContainsKey(node.Key))
            {
                //Add new element to the dictionary, set it's value to 0 (no children);
                predecessorCount[node.Key] = 0;
            }

            foreach (var child in node.Value)       //Iterate through all child names for the given graph node;
            {
                if (!predecessorCount.ContainsKey(child))
                {
                    //Add new element to the childs list (dictionary);
                    predecessorCount[child] = 0;
                }

                //Count number of childs;
                predecessorCount[child]++;

            }
        }
    }

    private void DecrementPredecessorCount(Dictionary<long, List<long>> graph, long nodeToRemove)
    {
        if (graph.ContainsKey(nodeToRemove))
        {
            foreach (var child in graph[nodeToRemove])
            {
                if (predecessorCount.ContainsKey(child))
                {
                    if (predecessorCount[child] > 0)
                    {
                        predecessorCount[child]--;
                    }

                }

            }
        }

        predecessorCount.Remove(nodeToRemove);

    }


}
