namespace _06_Reverse_Exclude
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, string, List<int>> fDivisible = (sNumbers, sDivisor) =>
            {
                int nDivisor = int.Parse(sDivisor);
                List<int> ret = sNumbers
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .Where(x => (x % nDivisor) != 0)
                                    .ToList();
                ret.Reverse();
                return ret;

            };

            Console.WriteLine(String.Join(' ', fDivisible(Console.ReadLine(), Console.ReadLine())));

        }

    }
}