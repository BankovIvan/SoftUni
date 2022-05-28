using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int i, j, n = 0, m = 0;
        long[,] matrix, memo;
        string[] s;

        n = int.Parse(Console.ReadLine());
        m = int.Parse(Console.ReadLine());

        if (!(n > 0 && m > 0)) return;

        matrix = new long[n, m];
        memo = new long[n, m];

        for (i = 0; i < n; i++)
        {
            Console.Write(" ");
            s = Console.ReadLine().Split(',');
            for (j = 0; j < m; j++)
            {
                matrix[i, j] = long.Parse(s[j]);
            }
        }


        FindMaxPath(matrix, memo);

        //Console.WriteLine();
        //PrintMatrix(matrix);
        //Console.WriteLine();
        //PrintMatrix(memo);
        //Console.WriteLine();
        Console.WriteLine(PrintPath(matrix, memo));

        return;
    }

    private static void FindMaxPath(long[,] matrix, long[,] memo)
    {
        int i = 0, j = 1, k = 1;
        bool goUp = true;
        string s;

        for(i = 0; i < matrix.GetLength(0); i++)
        {
            memo[i, 0] = matrix[i, 0];
        }

        for(j = 1; j < matrix.GetLength(1); j++)
        {
            if (goUp)
            {
                //UP
                for (i = 0; i < matrix.GetLength(0); i++)
                {
                    for (k = i + 1; k < matrix.GetLength(0); k++)
                    {
                        memo[i, j] = Math.Max(memo[i, j], memo[k, j - 1] + matrix[i, j]);
                    }
                }

            }
            else
            {
                //DOWN
                for (i = 0; i < matrix.GetLength(0); i++)
                {
                    for (k = 0; k < i; k++)
                    {
                        memo[i, j] = Math.Max(memo[i, j], memo[k, j - 1] + matrix[i, j]);
                    }
                }

            }

            goUp = !goUp;
        }

        return;
    }

    private static string PrintPath(long[,] matrix, long[,] memo)
    {

        int i = 0, j = 1, k = 1;
        bool goUp = (memo.GetUpperBound(1) % 2) == 0; //Revere direction
        string s = "";
        long maxPathValue = 0, prevPathValue;
        int maxPathIndex = 0, prevPathIndex = 0;

        for (i = 0; i < memo.GetLength(0); i++)
        {
            if(memo[i, memo.GetUpperBound(1)] > maxPathValue)
            {
                maxPathValue = memo[i, memo.GetUpperBound(1)];
                maxPathIndex = i;
            }
        }

        prevPathValue = maxPathValue;
        s = matrix[maxPathIndex, memo.GetUpperBound(1)].ToString();

        for (j = memo.GetUpperBound(1) - 1; j >= 0; j--)
        {
            prevPathIndex = maxPathIndex;
            maxPathValue = 0;

            if (goUp)
            {
                //UP
                for (i = 0; i < prevPathIndex; i++)
                {
                    if (memo[i, j] > maxPathValue)
                    {
                        maxPathValue = memo[i, j];
                        maxPathIndex = i;
                    }

                }

            }
            else
            {
                //DOWN
                for (i = prevPathIndex + 1; i < memo.GetLength(0); i++)
                {
                    if (memo[i, j] > maxPathValue)
                    {
                        maxPathValue = memo[i, j];
                        maxPathIndex = i;
                    }
                }

            }

            s = matrix[maxPathIndex, j].ToString() + " + " + s;

            goUp = !goUp;
        }

        s = prevPathValue.ToString() + " = " + s;

        return s;

    }

    private static void PrintMatrix(long[,] matrix)
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
}