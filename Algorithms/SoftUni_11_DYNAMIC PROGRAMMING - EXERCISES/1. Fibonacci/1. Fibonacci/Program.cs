using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{

    static int[] memo = {0, 1, 1, 2};

    static void Main(string[] args)
    {
        int num;

        num = int.Parse(Console.ReadLine());

        if(num >= 0) Console.WriteLine(FibIterative(num));
        //if (num >= 0) Console.WriteLine(FibIRecursive(num));

        return;

    }

    private static int FibIRecursive(int num)
    {
        //Not tested!
        if (num == 0) return 0;

        if (num <= 2)
        {
            return memo[num];
        }
        else
        {
            memo[num] = FibIRecursive(num - 1) + FibIRecursive(num - 2);
        }

        return memo[num];
    }

    private static int FibIterative(int num)
    {
        int i, j;
        int[] result = {0, 1};

        if (num == 0)
        {
            return result[0];
        }

        if (num == 1)
        {
            return result[1];
        }

        for(i = 2; i <= num; i++)
        {
            j = result[0] + result[1];
            result[0] = result[1];
            result[1] = j;
        }

        return result[1];
    }
}
