using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        int i, j, k, m, N, B;
        long[,] soil, memo;
        string[] s;
        long maxValue = long.MinValue;

        B = int.Parse(Console.ReadLine());
        N = int.Parse(Console.ReadLine());
        m = N - B + 1;

        soil = new long[N, N];
        memo = new long[N, N];

        for (i = 0; i < N; i++)
        {
            s = Console.ReadLine().Split();
            for(j = 0; j < N; j++)
            {
                soil[i, j] = long.Parse(s[j]);
            }
        }

        for (i = 0; i < N; i++)
        {
            for (j = 0; j < m; j++)
            {
                for (k = 0; k < B; k++)
                {
                    memo[i, j] = memo[i, j] + soil[i, j + k];
                }
            }
        }

        //PrintMatrix(memo);

        for (i = 0; i < m; i++)
        {
            for (j = 0; j < m; j++)
            {
                for (k = 1; k < B; k++)
                {
                    memo[j, i] = memo[j, i] + memo[j + k, i];
                }

                if(maxValue < memo[j, i])
                {
                    maxValue = memo[j, i];
                }

            }

        }

        //PrintMatrix(memo);

        Console.WriteLine(maxValue);

        return;

    }

    private static void PrintMatrix(long[,] matrix)
    {
        int i, j;
        string s;

        for (i = 0; i < matrix.GetLength(0); i++)
        {
            s = matrix[i, 0].ToString().PadLeft(4);

            for (j = 1; j < matrix.GetLength(1); j++)
            {
                s = s + matrix[i, j].ToString().PadLeft(4);
            }
            Console.WriteLine(s);

        }

        Console.WriteLine();

        return;
    }
}