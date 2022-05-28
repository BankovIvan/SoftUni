using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    public static int maxRow = 0;
    public static int maxCol = 0;
    public static int maxLen = 0;

    static void Main(string[] args)
    {
        int i, j;

        string firstString = Console.ReadLine();
        string secondString = Console.ReadLine();

        int firstLen = firstString.Length + 1;
        int secondLen = secondString.Length + 1;

        int[,] lcs = new int[firstLen, secondLen];
        int[] prev = new int[firstLen];

        FindLongestCommonSubsequence(lcs, firstString, secondString, firstLen, secondLen);

        Console.WriteLine(ReconstructLongestCommonSubsequence(lcs, firstString));

        return;
    }

    private static string ReconstructLongestCommonSubsequence(int[,] lcs, string firstString)
    {
        int i, j;
        string result = "";

        i = maxRow;
        j = maxCol;

        while (lcs[i, j] > 0)
        {
            result = firstString[i - 1] + result;
            i--;
            j--;
        }

        return result;
    }

    private static int FindLongestCommonSubsequence(int[,] lcs, string firstString, string secondString, int firstLen, int secondLen)
    {
        int i, j;

        for (i = 0; i < firstLen; i++)
        {
            lcs[i, 0] = 0;
        }

        for (j = 0; j < secondLen; j++)
        {
            lcs[0, j] = 0;
        }

        for (i = 1; i < firstLen; i++)
        {
            for (j = 1; j < secondLen; j++)
            {
                if (firstString[i - 1] == secondString[j - 1])
                {
                    //Equal chars -> lcs = lcs(cell to the left and up) + 1;
                    lcs[i, j] = lcs[i - 1, j - 1] + 1;
                }
                /*else
                {
                    //Not equal chars -> lcs = max ( lcs(cell above), lcs(cell to the left) ), order is important...;
                    lcs[i, j] = Math.Max(lcs[i - 1, j], lcs[i, j - 1]);
                }*/

                if (maxLen < lcs[i, j])
                {
                    maxLen = lcs[i, j];
                    maxRow = i;
                    maxCol = j;
                }

            }



            //PrintMatrix(lcs, 3, true);

        }

        return lcs[firstLen - 1, secondLen - 1];
    }

    public static void PrintMatrix(int[,] matrix, int padding = 5, bool addNewLine = false)
    {
        string s;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            s = matrix[i, 0].ToString().PadLeft(padding);
            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                s = s + "," + matrix[i, j].ToString().PadLeft(padding);
            }
            Console.WriteLine(s);
        }

        if (addNewLine) Console.WriteLine();

    }
}

