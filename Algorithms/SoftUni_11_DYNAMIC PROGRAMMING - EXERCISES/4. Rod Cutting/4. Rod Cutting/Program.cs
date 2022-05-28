using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    const int RODLENGTH = 10;

    static void Main(string[] args)
    {
        int rodLength;
        int[] cutPrices, maxPrices, indexPrices;

        cutPrices = Console.ReadLine().Split().Select(int.Parse).ToArray();
        rodLength = int.Parse(Console.ReadLine());

        maxPrices = new int[cutPrices.Length];
        indexPrices = new int[cutPrices.Length];

        //Console.WriteLine(CutRodRecursive(cutPrices, maxPrices, indexPrices, rodLength));
        Console.WriteLine(CutRodIterative(cutPrices, maxPrices, indexPrices, rodLength));

        ReconstructSolution(cutPrices, maxPrices, indexPrices, rodLength);

        return;

    }

    private static void ReconstructSolution(int[] cutPrices, int[] maxPrices, int[] indexPrices, int rodLength)
    {
        while (rodLength - indexPrices[rodLength] != 0)
        {
            Console.Write(indexPrices[rodLength] + " ");
            rodLength = rodLength - indexPrices[rodLength];
        }

        Console.WriteLine(indexPrices[rodLength]);

    }

    private static int CutRodRecursive(int[] cutPrices, int[] maxPrices, int[] indexPrices, int rodLength)
    {
        int cost, currentPrice = 0;

        if (rodLength <= 0) return 0;

        if (maxPrices[rodLength] == 0)
        {
            for (int i = 1; i <= rodLength; i++)
            {
                cost = cutPrices[i] + CutRodRecursive(cutPrices, maxPrices, indexPrices, rodLength - i);
                if(currentPrice < cost)
                {
                    currentPrice = cost;
                    indexPrices[rodLength] = i;
                    maxPrices[rodLength] = cost;
                }
            }

        }
        else
        {
            currentPrice = maxPrices[rodLength];
        }

        return currentPrice;
    }

    private static int CutRodIterative(int[] cutPrices, int[] maxPrices, int[] indexPrices, int rodLength)
    {
        int i, j, currentBest;

        for (i = 1; i <= rodLength; i++)
        {
            currentBest = maxPrices[i];

            for(j = 1; j <= i; j++)
            {
                currentBest = Math.Max(maxPrices[i], cutPrices[j] + maxPrices[i - j]);

                if(currentBest > maxPrices[i])
                {
                    maxPrices[i] = currentBest;
                    indexPrices[i] = j;
                }
            }
        }

        return maxPrices[rodLength];
    }
}

