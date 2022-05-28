using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

class Program
{
    public static List<string> result = new List<string>();

    static void Main(string[] args)
    {
        int S;
        int[] vector;
        

        S = int.Parse(Console.ReadLine());
        vector = new int[S];

        LimitedSequences(vector, 0, S, "");

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }

        return;

    }

    private static void LimitedSequences(int[] vector, int index, int S, string ret)
    {
        int i, j;
        string s;

        for (i = 1; i <= S; i++)
        {
            vector[index] = i;

            if(index == 0)
            {
                s = i.ToString();
            }
            else
            {
                s = ret + " " + i.ToString();
            }

            result.Add(s);

            LimitedSequences(vector, index + 1, S - i, s);

            //vector[index] = 0;
        }

        return;

    }
}
