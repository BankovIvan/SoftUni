using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
        long i, j;
        string s;
        Dictionary<long, List<long>> graph = new Dictionary<long, List<long>>();
        //int[] salary;

        long N = long.Parse(Console.ReadLine());
        for(i = 0; i < N; i++)
        {
            graph.Add(i, new List<long>());
            s = Console.ReadLine();

            for (j = 0; j < N; j++)
            {
                if(s.ToCharArray()[j] == 'Y')
                {
                    graph[i].Add(j);
                }
            }
        }

        //salary = Enumerable.Repeat(0, N).ToArray();
        long[] salary = new long[N + 1];

        Console.WriteLine(TopSort(graph/*, predecessorCount*/, salary));

        return;

    }

    public static long TopSort(Dictionary<long, List<long>> graph, long[] salary)
    {

        while (graph.Count > 0)
        {
            long nodeToRemove = -1;

            foreach (var item in graph)
            {
                if (item.Value.Count == 0)
                {
                    nodeToRemove = item.Key;
                    break;
                }
            }

            if (nodeToRemove == -1)
            {
                //Console.WriteLine("Error: graph has at least one cycle");
                break;
                //throw new InvalidOperationException();

            }

            graph.Remove(nodeToRemove);

            if(salary[nodeToRemove] == 0)
            {
                salary[nodeToRemove] = 1;
            }

            foreach (var item in graph)
            {
                if (item.Value.Contains(nodeToRemove))
                {
                    salary[item.Key] += salary[nodeToRemove];
                    item.Value.Remove(nodeToRemove);
                }
            }

        }

        return salary.Sum();
    }

}
