using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{

    static void Main(string[] args)
    {
        long n, k;
        long[,] memoPascalTree; // = { 0, 1, 1, 2 };

        n = long.Parse(Console.ReadLine());
        k = long.Parse(Console.ReadLine());

        if (k < 0 || n < k) return;

        memoPascalTree = new long[n + 1, k + 1];

        Console.WriteLine(BinomialIterative(memoPascalTree, n, k));

        return;

    }

    private static long BinomialIterative(long[,] memoPascalTree, long n, long k)
    {
        long i, j, iLimit = n - k;

        if (k < 1 || n < 1 || k >= n) return 1;

        PrintPascalTree(memoPascalTree, n, k);

        for (i = 0, j = 0; i <= n; i++)
        {
            memoPascalTree[i, j] = 1;
        }

        PrintPascalTree(memoPascalTree, n, k);

        for (i = 0, j = 0; j <= k; j++)
        {
            memoPascalTree[i, j] = 1;
        }

        PrintPascalTree(memoPascalTree, n, k);

        for (i = 1; i <= iLimit; i++)
        {

            for (j = 1; j <= k; j++)
            {
                memoPascalTree[i, j] = memoPascalTree[i, j - 1] + memoPascalTree[i - 1, j];
                PrintPascalTree(memoPascalTree, n, k);

            }
        }

        return memoPascalTree[i - 1, j - 1];
    }

    private static void PrintPascalTree(long[,] memoPascalTree, long n, long k, bool printEnable = false)
    {
        string s;

        if (!printEnable) return;

        for (long i = 0; i <= n; i++)
        {
            s = "";

            for (long j = 0; j <= k; j++)
            {
                s = s + (s == "" ? "" : " ") + memoPascalTree[i, j].ToString().PadLeft(4);
            }

            Console.WriteLine(s);
        }

        Console.WriteLine();
    }
}
