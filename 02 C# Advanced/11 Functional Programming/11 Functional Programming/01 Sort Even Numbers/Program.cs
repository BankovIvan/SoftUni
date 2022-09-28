namespace _01_Sort_Even_Numbers
{
    using System;
    using System.Linq;
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine( 
                string.Join(", ", 
                    Console.ReadLine()
                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .Where(x => (x & 1) == 0)
                        .OrderBy(x => x)
                        .ToArray()));
        }
    }
}