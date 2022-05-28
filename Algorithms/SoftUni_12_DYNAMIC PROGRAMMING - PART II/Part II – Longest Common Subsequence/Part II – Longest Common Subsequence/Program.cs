#define JUDGE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {

#if JUDGE
        string firstString = Console.ReadLine();
        string secondString = Console.ReadLine();
#else
        //string firstString = "abc";
        //string secondString = "adb";

        string firstString = "tree";
        string secondString = "team";
#endif

        int firstLen = firstString.Length + 1;
        int secondLen = secondString.Length + 1;

        int[,] lcs = new int[firstLen, secondLen];

        Console.WriteLine( FindLongestCommonSubsequence(lcs, firstString, secondString, firstLen, secondLen) );

#if !JUDGE
        Console.WriteLine( ReconstructLongestCommonSubsequence(lcs, firstString, secondString, firstLen, secondLen) );
#endif

        return;
    }

    private static string ReconstructLongestCommonSubsequence(int[,] lcs, string firstString, string secondString, int firstLen, int secondLen)
    {
        int i, j;
        string result = "";

        i = firstLen - 1;
        j = secondLen - 1;

        while (i > 0 && j > 0)
        {

#if !JUDGE
            Console.WriteLine("i = {0}, j = {1}, path = {2}", i, j, result);
#endif


            if (firstString[i - 1] == secondString[j - 1])
            {
                result = firstString[i - 1] + result;
                i--;
                j--;
            }
            else if(lcs[i, j] == lcs[i - 1, j])
            {
                i--;
            }
            else
            {
                j--;
            }

        }

        return result;
    }

    private static int FindLongestCommonSubsequence(int[,] lcs, string firstString, string secondString, int firstLen, int secondLen)
    {
        int i , j;

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
                if(firstString[i - 1] == secondString[j - 1])
                {
                    //Equal chars -> lcs = lcs(cell to the left and up) + 1;
                    lcs[i, j] = lcs[i - 1, j - 1] + 1;
                }
                else
                {
                    //Not equal chars -> lcs = max ( lcs(cell above), lcs(cell to the left) ), order is important...;
                    lcs[i, j] = Math.Max(lcs[i - 1, j], lcs[i, j - 1]);
                }

#if !JUDGE
                MyConsolePrintHelper.PrintMatrix(lcs, 5, true);
#endif

            }
        }

        return lcs[firstLen - 1, secondLen - 1];

    }
}

