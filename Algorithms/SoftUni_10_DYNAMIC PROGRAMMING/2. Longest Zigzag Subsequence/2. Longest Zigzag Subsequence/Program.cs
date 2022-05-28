using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{

    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        //int[] numbers = { 1, 3, 2 };
        //int[] numbers = { 8, 3, 5, 7, 0, 8, 9, 10, 20, 20, 20, 12, 19, 11 };
        int[] memo = new int[numbers.Length];
        int[] prev = Enumerable.Repeat(-1, numbers.Length).ToArray();

        PrintList3(LongestZigZagIteraive(numbers, memo, prev), numbers, prev);

        return;

    }

    private static int LongestZigZagIteraive(int[] numbers, int[] memo, int[] prev)
    {
        //Similar to LIS iterative solution...
        int maxLen = 0;
        int lastIndex = -1;

        for (int x = 0; x < numbers.Length; x++)
        {
            memo[x] = 1;
            prev[x] = -1;

            for (int i = 0; i < x; i++)
            {
                //As per iterative LIS;
                //if ((numbers[i] < numbers[x]) && (memo[i] + 1 > memo[x]))
                if (ZigZagCheck(numbers, memo, prev, i, x) && (memo[i] + 1 > memo[x]))
                {
                    memo[x] = memo[i] + 1;
                    prev[x] = i;
                }
            }

            if (memo[x] > maxLen)
            {
                maxLen = memo[x];
                lastIndex = x;
            }

        }

        return lastIndex;
    }

    private static bool ZigZagCheck(int[] numbers, int[] memo, int[] prev, int index, int next)
    {
        int lastLasElement, preLastElement;
        bool ret = false;

        if (memo[index] < 2) return true;

        //Get (Reconstruct) last 2 elements via the prev[] table:
        lastLasElement = numbers[index];
        index = prev[index];
        preLastElement = numbers[index];

        //Odd number of elements -> adding even element at the end, lastLasElement is Odd one, preLastElement is Even... 
        //Even number of elements -> adding odd element at the end, lastLasElement is Even one, preLastElement is Odd... 
        if (numbers[next] < lastLasElement && lastLasElement > preLastElement) ret = true;

        if (numbers[next] > lastLasElement && lastLasElement < preLastElement) ret = true;

        return ret;

    }


    private static void PrintList3(int index, int[] numbers, int[] prev)
    {
        string s = numbers[index].ToString();
        index = prev[index];

        while (index >= 0)
        {
            s = numbers[index] + " " + s;
            index = prev[index];
        }

        Console.WriteLine(s);
    }

}