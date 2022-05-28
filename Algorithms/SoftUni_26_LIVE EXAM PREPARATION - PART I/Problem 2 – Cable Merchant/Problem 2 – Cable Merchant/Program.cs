using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

class Program
{
    //public const int RODLENGTH = 10;
    public static long cableLength, capPrice;
    public static long[] cutPrices, maxPrices, indexPrices;

    static void Main(string[] args)
    {
        int i;
        string s;

        ReadCableData();

        CutRodIterative(cutPrices, maxPrices, indexPrices, cableLength);

        //        ReconstructSolution(cutPrices, maxPrices, indexPrices, cableLength);
        s = maxPrices[1].ToString();
        for (i = 2; i < maxPrices.Length; i++)
        {
            s = s + " " + maxPrices[i].ToString();
        }

        Console.WriteLine(s);

        return;

    }

    private static void ReadCableData()
    {
        int i;
        string[] s;

        Console.Write("    ");
        s = Console.ReadLine().Split(' ');

        cableLength = s.Length + 1;
        cutPrices = new long[cableLength];
        maxPrices = new long[cableLength];
        indexPrices = new long[cableLength];
        

        for (i = 0; i < s.Length; i++)
        {
            cutPrices[i + 1] = long.Parse(s[i]);
        }

        Console.Write("    ");
        capPrice = long.Parse(Console.ReadLine());

    }

    private static void ReconstructSolution(long[] cutPrices, long[] maxPrices, long[] indexPrices, long cableLength)
    {
        cableLength = cableLength - 1;
        while (cableLength - indexPrices[cableLength] != 0)
        {
            Console.Write(indexPrices[cableLength] + " ");
            cableLength = cableLength - indexPrices[cableLength];
        }

        Console.WriteLine(indexPrices[cableLength]);

    }

    private static long CutRodIterative(long[] cutPrices, long[] maxPrices, long[] indexPrices, long cableLength)
    {
        long i, j, currentBest;

        for (i = 1; i < cableLength; i++)
        {
            //currentBest = maxPrices[i];

            for (j = 1; j <= i; j++)
            {
                if(i != j)
                {
                    currentBest = cutPrices[j] + maxPrices[i - j] - 2 * capPrice;
                }
                else
                {
                    currentBest = cutPrices[j];
                }
                
                currentBest = Math.Max(maxPrices[i], currentBest);

                if (currentBest > maxPrices[i])
                {
                    maxPrices[i] = currentBest;
                    indexPrices[i] = j;
                }
            }
        }

        return maxPrices[cableLength - 1];
    }
}