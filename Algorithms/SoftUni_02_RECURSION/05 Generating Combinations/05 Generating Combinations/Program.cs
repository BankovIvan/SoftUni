using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {

        int[] set;
        int[] vector;
        int k;
        //int border;

        set = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        k = int.Parse(Console.ReadLine());

        if (k < 1 || k > set.Length) return;

        vector = new int[k];

        GenCombs(set, vector, 0, 0);

        //Console.WriteLine(Sum(numbers, 0));

        return;
    }

    private static void GenCombs(int[] set, int[] vector, int index, int border)
    {
        int i;

        if(index < vector.Length)
        {
            for (i = border; i < set.Length; i++)
            {
                vector[index] = set[i];
                GenCombs(set, vector, index+1, i+1);

            }

        }
        else
        {
            //Console.WriteLine(string.Concat(vector));
            Console.WriteLine(string.Join(" ", vector));

        }

        return;
    }
}

