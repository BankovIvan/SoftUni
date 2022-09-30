namespace _03_Custom_Min_Function
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> fPrintMin = x =>
                x.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Min(x => x);

            Console.WriteLine(fPrintMin(Console.ReadLine()));

        }
    }
}