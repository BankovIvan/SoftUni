using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        int i, x, n, best = 1;
        BigInteger[] citizens;
        int[] len1, len2, len3;

        n = int.Parse(Console.ReadLine());
        citizens = new BigInteger[n];
        len1 = new int[citizens.Length];
        len2 = new int[citizens.Length];
        len3 = new int[citizens.Length];

        for (i = 0; i < n; i++)
        {
            Console.Write("    ");
            citizens[i] = BigInteger.Parse(Console.ReadLine().Split(' ').ToArray()[0]);
        }



        for (x = 0; x < citizens.Length; x++)
        {
            len1[x] = 1;
            for (i = 0; i <= x - 1; i++)
            {
                if (citizens[i] < citizens[x] && len1[i] + 1 > len1[x])
                {
                    len1[x] = 1 + len1[i];
                }
                    
            }
                
        }

        for (x = citizens.Length - 1; x >= 0; x--)
        {
            len2[x] = 1;
            for (i = citizens.Length - 1; i > x; i--)
            {
                if (citizens[i] < citizens[x] && len2[i] + 1 > len2[x])
                {
                    len2[x] = 1 + len2[i];
                }

            }

        }

        for (x = 0; x < citizens.Length; x++)
        {
            i = len1[x] + len2[x] - 1;
            if (i > best)
            {
                best = i;
            }
        }

        Console.WriteLine("{0}", best);


        return;

    }
}
