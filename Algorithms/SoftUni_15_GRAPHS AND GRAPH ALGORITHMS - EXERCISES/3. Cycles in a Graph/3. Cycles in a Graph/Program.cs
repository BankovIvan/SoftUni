using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        //REV 2

        string s;
        //char[] graphData;
        Dictionary<char, List<char>> graphInput = new Dictionary<char, List<char>>();
        Dictionary<char, List<char>> predecessors = new Dictionary<char, List<char>>();
        HashSet<char> visited = new HashSet<char>();
        HashSet<char> cycleNodes = new HashSet<char>();

        
        while(true)
        {
            s = Console.ReadLine();

            if (s == null) break;
            if (s == "") break;

            //graphData = s.ToCharArray();

            if (!graphInput.ContainsKey(s.ToCharArray()[0]))
            {
                graphInput.Add(s.ToCharArray()[0], new List<char>());
            }

            if (!graphInput.ContainsKey(s.ToCharArray()[2]))
            {
                graphInput.Add(s.ToCharArray()[2], new List<char>());
            }

            graphInput[s.ToCharArray()[0]].Add(s.ToCharArray()[2]);

        }

        //Fix the graph;
        //Add all predecessors to each node: like if {A->B,C->B} then add B->C;
        foreach (var node in graphInput)     
        {
            if (!predecessors.ContainsKey(node.Key))
            {
                predecessors.Add(node.Key, new List<char>());
            }

            foreach (var child in node.Value)
            {
                //A -> B, add B to the list of A connections; 
                if (!predecessors[node.Key].Contains(child))
                {
                    predecessors[node.Key].Add(child);
                }

                
                if (!predecessors.ContainsKey(child))
                {
                    //Add new element to the childs list (dictionary);
                    predecessors.Add(child, new List<char>());
                }

                //A -> B, add A to the list of B connections; 
                if (!predecessors[child].Contains(node.Key))
                {
                    predecessors[child].Add(node.Key);
                }

            }
        }

        s = "Yes";

        //Now walk through the fixed graph;
        //At each step remember where you come from... :)
        foreach (var node in predecessors.Keys)
        {
            if (FindCyclesInGraphDFSRecursile(predecessors, visited, cycleNodes, node, '_'))
            {
                s = "No";
                break;
            }
        }

        Console.WriteLine("Acyclic: {0}", s);

        return;

    }

    private static bool FindCyclesInGraphDFSRecursile(Dictionary<char, List<char>> graph, HashSet<char> visited, HashSet<char> cycleNodes, char node, char prevNode)
    {

        if (cycleNodes.Contains(node))
        {
            return true;
        }

        if (!visited.Contains(node))
        {
            visited.Add(node);
            cycleNodes.Add(node);

            foreach (var item in graph[node])
            {
                if(item != prevNode)
                {
                    if (FindCyclesInGraphDFSRecursile(graph, visited, cycleNodes, item, node))
                    {
                        return true;
                    }
                }


            }

            cycleNodes.Remove(node);

        }

        return false;
    }
}
