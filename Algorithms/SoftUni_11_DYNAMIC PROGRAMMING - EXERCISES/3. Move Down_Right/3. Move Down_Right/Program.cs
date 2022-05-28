using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int i, j, n = 0, m = 0;
        int[,] matrix, memo;
        string[] s;

        /*
        matrix = new int[,] 
        {
            { 1, 2, 3}, 
            { 4, 2, 3}, 
            { 1, 4, 3}
        };
        n = matrix.GetLength(0);
        m = matrix.GetLength(1);
        memo = new int[n, m];
        */

        n = int.Parse(Console.ReadLine());
        m = int.Parse(Console.ReadLine());

        if (!(n > 0 && m > 0)) return;

        matrix = new int[n, m];
        memo = new int[n, m];

        for (i = 0; i < n; i++)
        {
            s = Console.ReadLine().Split(' ');
            for (j = 0; j < m; j++)
            {
                matrix[i, j] = int.Parse(s[j]);
            }
        }


        FindMaxPath(matrix, memo);

        //Console.WriteLine();
        //PrintMatrix(matrix);
        //Console.WriteLine();
        //PrintMatrix(memo);
        //Console.WriteLine();
        Console.WriteLine(PrintPath(memo));

        return;
    }

    private static void FindMaxPath(int[,] matrix, int[,] memo)
    {
        int i, j;

        memo[0, 0] = matrix[0, 0];
        for (i = 1; i < matrix.GetLength(0); i++) memo[i, 0] = matrix[i, 0] + memo[i - 1, 0];
        for (j = 1; j < matrix.GetLength(1); j++) memo[0, j] = matrix[0, j] + memo[0, j - 1];

        for (i = 1; i < matrix.GetLength(0); i++)
        {
            for (j = 1; j < matrix.GetLength(1); j++)
            {
                memo[i, j] = Math.Max(memo[i - 1, j], memo[i, j - 1]) + matrix[i, j];
            }
        }


        return;
    }

    private static void PrintMatrix(int[,] matrix)
    {
        int i, j;
        string s;

        for (i = 0; i < matrix.GetLength(0); i++)
        {
            s = matrix[i, 0].ToString().PadLeft(3);

            for (j = 1; j < matrix.GetLength(1); j++)
            {
                s = s + " " + matrix[i, j].ToString().PadLeft(3);

            }

            Console.WriteLine(s);

        }

        return;

    }

    private static string PrintPath(int[,] matrix)
    {

        int i = matrix.GetUpperBound(0);
        int j = matrix.GetUpperBound(1);
        int tmp1, tmp2;

        string s = "[" + i + ", " + j + "]";

        while (true)
        {

            if((i - 1) >= 0) tmp1 = matrix[i - 1, j];
            else tmp1 = -1;

            if ((j - 1) >= 0) tmp2 = matrix[i, j - 1];
            else tmp2 = -1;

            if(tmp1 == -1 && tmp2 == -1)
            {
                break;
            }
            else if(tmp1 > tmp2)
            {
                i = i - 1;
                s = "[" + i + ", " + j + "] " + s;
            }
            else
            {
                j = j - 1;
                s = "[" + i + ", " + j + "] " + s;
            }

        }

        return s;

    }
}
