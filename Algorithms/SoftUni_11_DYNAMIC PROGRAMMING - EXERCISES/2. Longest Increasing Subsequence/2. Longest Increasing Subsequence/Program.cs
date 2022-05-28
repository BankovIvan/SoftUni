using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    //static int[] numbers;
    //static int[] memo;
    //static int[] prev;

    static void Main(string[] args)
    {
        int i;

        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        //int[] numbers = new int[] {3, 5, 8, 6, 7};
        int[] memo = new int[numbers.Length];
        int[] prev = Enumerable.Repeat(-1, numbers.Length).ToArray();

        /*

        for (i = 0; i < numbers.Length; i++)
        {
            //length = LISRecursive1(i, numbers, memo);
            length = LISRecursive2(i, numbers, memo, prev);
            Console.WriteLine(length);
        }

        for (i = 0; i < numbers.Length; i++)
        {
            PrintList2(i, numbers, prev);
        }
            */

        PrintList3(LISIteratirve3(numbers, memo, prev), numbers, prev);

        return;
    }

    private static int LISIteratirve3(int[] numbers, int[] memo, int[] prev)
    {
        int maxLen = 0;
        int lastIndex = -1;

        for (int x = 0; x < numbers.Length; x++)
        {
            memo[x] = 1;
            prev[x] = -1;

            for (int i = 0; i < x; i++)
            {
                if ((numbers[i] < numbers[x]) && (memo[i] + 1 > memo[x]))
                {
                    memo[x] = memo[i] + 1;
                    prev[x] = i;
                }
            }

            if(memo[x] > maxLen)
            {
                maxLen = memo[x];
                lastIndex = x;
            }

        }

        return lastIndex;
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

    private static void PrintList2(int index, int[] numbers, int[] prev)
    {
        while(prev[index] != index)
        {
            Console.Write(numbers[index] + " ");
            index = prev[index];
        }

        Console.WriteLine(numbers[index]);

    }

    private static int LISRecursive2(int index, int[] numbers, int[] prev, int[] memo)
    {
        if (memo[index] != 0)
        {
            return memo[index];
        }

        int maxLength = 1;
        prev[index] = index;

        for (int i = index + 1; i < numbers.Length; i++)
        {
            //maxLength = 1;

            if (numbers[index] < numbers[i])
            {
                int length = LISRecursive2(i, numbers, prev, memo);

                if (length >= maxLength)
                {
                    maxLength = length + 1;
                    prev[index] = i;
                }

            }
        }

        memo[index] = maxLength;

        return maxLength;
    }

    private static int LISRecursive1(int index, int[] numbers, int[] memo)
    {
        if(memo[index] != 0)
        {
            return memo[index];
        }

        int maxLength = 1;

        for (int i = index + 1; i < numbers.Length; i++)
        {
            //maxLength = 1;

            if (numbers[index] < numbers[i])
            {
                int length = LISRecursive1(i, numbers, memo);

                if(length >= maxLength)
                {
                    maxLength = length + 1;

                }

            }
        }

        memo[index] = maxLength;

        return maxLength;
    }
}
