namespace _04_Word_Filter
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {

            string[] arrWords = Console
                                .ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Where(x => (x.Length & 1) == 0)
                                .ToArray();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(string.Join('\n', arrWords));           
            Console.ResetColor();

        }
    }
}