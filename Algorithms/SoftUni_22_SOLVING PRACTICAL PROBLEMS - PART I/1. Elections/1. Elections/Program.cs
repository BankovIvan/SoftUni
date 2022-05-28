using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

class Program
{

    static void Main(string[] args)
    {
        int i, N, K, L;
        BigInteger total = 0;
        int[] votes;
        BigInteger[] sums;

        
        Console.Write("    ");
        K = int.Parse(Console.ReadLine());

        Console.Write("    ");
        N = int.Parse(Console.ReadLine());

        votes = new int[N];

        for (i = 0; i < N; i++)
        {
            Console.Write("    ");
            votes[i] = int.Parse(Console.ReadLine());
        }

        i = votes.Sum() + 1;

        sums = new BigInteger[i];
        sums[0] = 1;

        foreach (var item in votes)
        {
            for(i = sums.Length - 1; i >= 0; i--)
            {
                if(sums[i] > 0)
                {
                    sums[i + item] += sums[i];
                }
            }
        }

        for(i = sums.Length - 1; i >= K; i--)
        {
            total += sums[i];
        }

        Console.WriteLine(total);

        return;

    }

}
