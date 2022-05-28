using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    public static int[] data, vector;
    public static int N;
    public static bool[] used;
    public static List<string> result = new List<string>();

    static void Main(string[] args)
    {
        data = Console.ReadLine().Split().Select(int.Parse).ToArray();

        vector = new int[data.Length];
        used = new bool[data.Length];

        N = int.Parse(Console.ReadLine());
        

        CalculateSumRecirsive(0, 1, "");

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }

        return;

    }

    private static void CalculateSumRecirsive(int currentSum, int index, string sNext)
    {
        int i, nextSum;
        string sCurr = "";
        HashSet<string> visited = new HashSet<string>();

        if (currentSum == N)
        {
            //result.Add(sNext);
            Console.WriteLine(sNext);
            return;
        }

        if(index > vector.Length)
        {
            return;
        }

        for (i = 0; i < data.Length; i++)
        {
            if(used[i] == false)
            {
                nextSum = currentSum + data[i] * index;
                if(nextSum <= N)
                {
                    if (index > 1)
                    {
                        sCurr = sNext + " " + data[i].ToString();
                    }
                    else
                    {
                        sCurr = data[i].ToString();
                    }
                    
                    if (!visited.Contains(sCurr))
                    {
                        visited.Add(sCurr);

                        vector[index - 1] = data[i];
                        used[i] = true;
                        CalculateSumRecirsive(nextSum, index + 1, sCurr);
                        used[i] = false;
                        vector[index - 1] = 0;

                    }
                }
            }
        }
    }
}
