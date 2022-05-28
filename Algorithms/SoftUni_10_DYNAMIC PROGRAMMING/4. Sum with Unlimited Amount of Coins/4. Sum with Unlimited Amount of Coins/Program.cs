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
        //int[] coins = { 0 };
        //coins = coins.Concat(Console.ReadLine().Split(' ').Select(int.Parse)).ToArray();
        int[] coins = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int givenSum = int.Parse(Console.ReadLine());
#else
        int[] coins = { 1, 2, 5 };
        int givenSum = 5;
#endif

        LinkedList<SubsetSum> memo = new LinkedList<SubsetSum>();
        memo.AddFirst(new SubsetSum { sum = 0, previousSum = -1, path = "0" });
        Console.WriteLine(SumCoinsIterative(memo, coins, givenSum));

        //int[] memo = new int[givenSum + 1];
        //memo[0] = 1;
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
        int i, j, currentSum;
        SubsetSum tempSum;

        for (i = 0; i < coins.Length; i++)
        {
            currentSum = coins[i];
            LinkedList<SubsetSum> newSums = new LinkedList<SubsetSum>();

            while (currentSum <= givenSum)
            {
                foreach (var item in memo)
                {
                    tempSum = new SubsetSum { sum = item.sum + coins[i], previousSum = item.sum, path = coins[i].ToString() + " " + item.path };
                    if(memo.Find(x => x.path == ""))
                    newSums.AddLast(tempSum);
                }

                currentSum += coins[i];

                foreach (var item in newSums)
                {
                    memo.AddLast(item);
                }

            }





        }

        ret = memo.Where(x => x.sum == givenSum).Distinct().ToList().Count;
        return ret;
    }

    private static int SumCoinsRecursive(int[] coins, int index, int givenSum, int currentSum, string debug)
    {

        int total = 0;
        ////int nextSum = 0;
        //string tmp = debug;

        //Console.WriteLine(debug);
        if (currentSum == givenSum) return 1;
        if (currentSum >= givenSum) return 0;

        for (int i = index; i > 0; i--) //Checking for i > 0 because input = { 0, x y, z, ... }
        {
            //debug = tmp + coins[i].ToString().PadLeft(4);
            ////nextSum = currentSum + coins[i];
            total += SumCoinsRecursive(coins, i, givenSum, currentSum + coins[i], debug);

        }

        return total;
    }

}


