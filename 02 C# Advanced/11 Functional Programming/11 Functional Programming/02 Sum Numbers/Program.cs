namespace _02_Sum_Numbers
{
    using System;
    using System.Linq;
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> MyParser = x => int.Parse(x);
            int[] arrNumbers = Console
                                .ReadLine()
                                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(MyParser)
                                .ToArray();

            Console.WriteLine(arrNumbers.Length);
            Console.WriteLine(arrNumbers.Sum());
        }
    }
}