namespace _04_Find_Evens_or_Odds
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrLimits = Console
                                    .ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();
            Predicate<int> SelectNumbers = CreateSelector(Console.ReadLine());
            for(int i = arrLimits[0]; i <= arrLimits[1]; i++)
            {
                if (SelectNumbers(i))
                {
                    Console.Write(i);
                    Console.Write(" ");
                }
            }


            Console.WriteLine();

        }

        private static Predicate<int> CreateSelector(string sSelector)
        {
            if (sSelector == "even")
            {
                return x => (x & 1) == 0;
            }
            else if (sSelector == "odd")
            {
                return x => (x & 1) == 1;
            }
            else { 
                return null; 
            }
        }
    }
}