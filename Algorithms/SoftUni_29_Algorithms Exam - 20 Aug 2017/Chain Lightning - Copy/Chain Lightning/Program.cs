using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chain_Lightning
{
    class Program
    {
        public static Dictionary<int, Dictionary<int, int>> graph;
        public static int[] currDamage, maxDamage; //, path;
        //public static bool[] visited;

        public static void Main()
        {

            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int[,] strikes;
            maxDamage = new int[n];

            int i, from, to, distance;
            string[] s;

            graph = new Dictionary<int, Dictionary<int, int>>();

            for (i = 0; i < n; i++)
            {
                graph.Add(i, new Dictionary<int, int>());
            }

            for (i = 0; i < m; i++)
            {
                s = Console.ReadLine().Split(' ');
                from = int.Parse(s[0].Trim());
                to = int.Parse(s[1].Trim());
                distance = int.Parse(s[2].Trim());

                graph[from].Add(to, distance);
                graph[to].Add(from, distance);
            }

            strikes = new int[l, 2];

            for (i = 0; i < l; i++)
            {
                s = Console.ReadLine().Split(' ');
                strikes[i, 0] = int.Parse(s[0].Trim());
                strikes[i, 1] = int.Parse(s[1].Trim());
            }

            for (i = 0; i < l; i++)
            {
                currDamage = new int[n];
                //visited = new bool[n];
                //path = new int[n];

                DfsGraph(graph, strikes[i, 0], strikes[i, 1]);
            }

            Console.WriteLine(maxDamage.Max().ToString());

            return;

        }

        private static void DfsGraph(Dictionary<int, Dictionary<int, int>> graph, int strikeNode, int strikeValue)
        {
            int currentNode = strikeNode;
            //KeyValuePair<int, int>[] nodes;
            //int[] currentSrikeDamage = new int[graph.Count];
            List<KeyValuePair<int, int>> nodesQueue = new List<KeyValuePair<int, int>>();

            //currDamage[strikeNode] = strikeValue;
            //maxDamage[strikeNode] = maxDamage[strikeNode] + strikeValue;

            /*foreach (var item in graph[strikeNode])
            {
                nodesQueue.Add(item);
            }*/
            nodesQueue.Add(new KeyValuePair<int, int>(strikeNode, strikeValue * 2));

            while (nodesQueue.Count > 0)
            {
                nodesQueue = nodesQueue.OrderBy(x => x.Value).ToList();
                strikeNode = nodesQueue[0].Key;
                strikeValue = nodesQueue[0].Value / 2;
                if(currDamage[strikeNode] == 0)
                {
                    currDamage[strikeNode] = strikeValue;
                    maxDamage[strikeNode] = maxDamage[strikeNode] + strikeValue;
                }

                nodesQueue.RemoveAt(0);

                foreach (var child in graph[strikeNode])
                {
                    if (currDamage[child.Key] == 0)
                    {
                        nodesQueue.Add(new KeyValuePair<int, int>(child.Key, strikeValue));
                        //currDamage[child.Key] = currDamage[strikeNode] / 2;
                        //maxDamage[child.Key] = maxDamage[child.Key] + currDamage[child.Key];
                    }
                }
            }


        }
    }
}
