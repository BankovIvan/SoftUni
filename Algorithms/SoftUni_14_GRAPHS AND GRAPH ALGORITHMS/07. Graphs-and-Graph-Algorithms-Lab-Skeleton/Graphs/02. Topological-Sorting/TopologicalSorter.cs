using System;
using System.Collections.Generic;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;     //key = node name, value = child's names;
    private Dictionary<string, int> predecessorCount;   //key = (current node) node name, value = number of childs;
    private HashSet<string> visited;                    //DFS sort algo vaiable; 
    private HashSet<string> cycleNodes;                 //DFS sort algo vaiable;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
    }

    public ICollection<string> TopSortDFS()
    {
        // TODO: Implement the topological sorting algorithm
        LinkedList<string> sorted = new LinkedList<string>();
        visited = new HashSet<string>();
        cycleNodes = new HashSet<string>();

        foreach (var node in graph.Keys)
        {
            DFS(node, sorted);
        }

        return sorted;
    }

    private void DFS(string node, LinkedList<string> result)
    {
        if (cycleNodes.Contains(node))
        {
            throw new InvalidOperationException("Cycle detected.");
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

    public ICollection<string> TopSort()
    {
        // TODO: Implement the topological sorting algorithm
        List<string> sorted = new List<string>();

        GetPredecessorCount(graph);

        while (graph.Count > 0)
        {
            string nodeToRemove = null;

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

            if (nodeToRemove == null)
            {
                //Console.WriteLine("Error: graph has at least one cycle");
                //break;
                throw new InvalidOperationException();

            }

            DecrementPredecessorCount(graph, nodeToRemove);

            graph.Remove(nodeToRemove);
            sorted.Add(nodeToRemove);

        }

        return sorted;
    }

    private void GetPredecessorCount(Dictionary<string, List<string>> graph)
    {
        //Fill the predecessorCount variable (dictionary);
        //It stores all nodes in graph and the number of their predecessors;
        predecessorCount = new Dictionary<string, int>();

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

    private void DecrementPredecessorCount(Dictionary<string, List<string>> graph, string nodeToRemove)
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
