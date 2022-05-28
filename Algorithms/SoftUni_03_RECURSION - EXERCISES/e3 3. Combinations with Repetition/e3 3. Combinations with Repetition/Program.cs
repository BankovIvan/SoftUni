using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int k, n;
        int[] arrResult1;

        n = int.Parse(Console.ReadLine());
        k = int.Parse(Console.ReadLine());

        if (k > 0 && n > k)
        {
            arrResult1 = new int[k];
        }
        else return;

        Combinations1(arrResult1, 0, 0, n);
        
        return;

    }

    private static void Combinations1(int[] arrResult1, int idx, int start, int n)
    {
        int i;

        if (idx <= arrResult1.GetUpperBound(0))
        {

            for (i = start; i < n; i++)
            {
                arrResult1[idx] = i + 1;
                Combinations1(arrResult1, idx + 1, i, n);
            }

            //start++;

        }
        else
        {
            Console.WriteLine(string.Join(" ", arrResult1));
        }

    }
}


