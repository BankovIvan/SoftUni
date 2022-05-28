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
        int[] coins = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int givenSum = int.Parse(Console.ReadLine());
#else
        int[] coins = { 1, 2, 2, 5 };
        int givenSum = 5;
#endif
        LinkedList<SubsetSum> memo = new LinkedList<SubsetSum>();
        memo.AddFirst(new SubsetSum { sum = 0, previousSum = -1, path = "0"});

        //int[] memo = new int[givenSum + 1];
        //memo[0] = 1;


        Console.WriteLine(SumCoinsIterative(memo, coins, givenSum));
        //Console.WriteLine(SumCoinsRecursive(coins, coins.Length - 1, givenSum, 0, ""));

        return;

    }

    public struct SubsetSum : IEquatable<SubsetSum>
    {
        public int sum;
        public int previousSum;
        public string path;

        public bool Equals(SubsetSum other)
        {
            return path.Equals(other.path);
        }

        public override string ToString()
        {
            return sum.ToString();
        }

    }

    private static int SumCoinsIterative(LinkedList<SubsetSum> memo, int[] coins, int givenSum)
    {
        int ret = 0;
        int i, j;
        //SubsetSum currentSum;

        for (i = 0; i < coins.Length; i++)
        {
            LinkedList<SubsetSum> newSums = new LinkedList<SubsetSum>();
            foreach (var item in memo)
            {
                newSums.AddLast(new SubsetSum { sum = item.sum + coins[i], previousSum = item.sum, path = coins[i].ToString() + " " + item.path });
            }

            foreach (var item in newSums)
            {
                memo.AddLast(item);
            }

        }

        ret = memo.Where(x => x.sum == givenSum).Distinct().ToList().Count;
        return ret;
    }

    private static int SumCoinsRecursive(int[] coins, int index, int givenSum, int currentSum, string debug)
    {

        int total = 0;
        int nextSum = 0;
        //string tmp = debug;
        HashSet<int> memo = new HashSet<int>();

        //Console.WriteLine(debug);
        if (currentSum == givenSum)
        {
            //Console.WriteLine("FOUND");
            return 1;
        }

        if (currentSum >= givenSum || index < 0) return 0;

        for (int i = index - 1; i >= 0; i--)
        {
            if (!memo.Contains(coins[i]))
            {
                memo.Add(coins[i]);
                //debug = tmp + coins[i].ToString().PadLeft(4);
                nextSum = currentSum + coins[i];
                total += SumCoinsRecursive(coins, i, givenSum, nextSum, debug);

            }

        }

        return total;
    }

}

