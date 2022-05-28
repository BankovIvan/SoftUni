using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int i, j, startVolume, maxVolume, nextVolume, result;
        int[] volumeChanges;
        bool[,] memo;

        Console.Write("    ");
        volumeChanges = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

        Console.Write("    ");
        startVolume = int.Parse(Console.ReadLine());

        Console.Write("    ");
        maxVolume = int.Parse(Console.ReadLine());

        memo = new bool[maxVolume + 1, volumeChanges.Length + 1];
        memo[startVolume, 0] = true;

        for (i = 1; i < memo.GetLength(1); i++)
        {
            for (j = 0; j < memo.GetLength(0); j++)
            {
                if (memo[j, i - 1] == true)
                {
                    nextVolume = j + volumeChanges[i - 1];
                    if (nextVolume >= 0 && nextVolume <= maxVolume)
                    {
                        memo[nextVolume, i] = true;
                    }

                    nextVolume = j - volumeChanges[i - 1];
                    if (nextVolume >= 0 && nextVolume <= maxVolume)
                    {
                        memo[nextVolume, i] = true;
                    }
                }
            }

            //debugMatrix(memo);
            //Console.WriteLine();
        }

        result = -1;
        j = memo.GetUpperBound(1);
        for (i = memo.GetUpperBound(0); i >= 0; i--)
        {
            if (memo[i, j] == true)
            {
                result = i;
                break;
            }
        }

        Console.WriteLine(result);

        return;
    }
}

    /*
    private static void debugMatrix(bool[,] memo)
    {
        int i, j;
        string s;

        for(i = 0; i < memo.GetLength(0); i++)
        {
            s = memo[i, 0] == true ? " 1" : " 0";

            for (j = 1; j < memo.GetLength(1); j++)
            {
                s = s +( memo[i, j] == true ? " 1" : " 0");
            }

            Console.WriteLine(s);
        }
    }
}
*/