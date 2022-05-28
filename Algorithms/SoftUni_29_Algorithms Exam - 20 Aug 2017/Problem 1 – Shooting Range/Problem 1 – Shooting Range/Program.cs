using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    
    static void Main(string[] args)
    {

        int i, score;
        int[] targets;
        bool[] used;
        List<int> vector = new List<int>();
        List<string> result = new List<string>();

        targets = Console.ReadLine().Split().Select(int.Parse).ToArray();
        score = int.Parse(Console.ReadLine());

        used = new bool[targets.Length];

        HitTargetsRecursive(targets, result, vector, used, score, 1);

        /*if(result.Count == 0)
        {
            Console.WriteLine("Score of {0} cannot be achieved.", score);
        }*/

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }

        return;

    }

    private static void HitTargetsRecursive(int[] targets, List<string> result, List<int> vector, bool[] used, int score, int index)
    {
        int i, n, k;
        HashSet<int> numbers = new HashSet<int>();

        if(score == 0)
        {
            result.Add(string.Join(" ", vector.ToArray()));

            return;
        }

        for(i = 0; i < targets.Length; i++)
        {
            if(used[i] == false && (!numbers.Contains(targets[i])))
            {
                numbers.Add(targets[i]);

                n = index * targets[i];
                k = score - n;
                if(k >= 0)
                {
                    used[i] = true;
                    vector.Add(targets[i]);

                    HitTargetsRecursive(targets, result, vector, used, k, index + 1);

                    vector.RemoveAt(index - 1);
                    used[i] = false;
                }
                
            }
        }

    }
}
