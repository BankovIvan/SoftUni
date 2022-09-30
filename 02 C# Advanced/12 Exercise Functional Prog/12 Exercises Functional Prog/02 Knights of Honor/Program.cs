namespace _02_Knights_of_Honor
{

    using System;
    using System.Linq;
    //using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> fPrinter = x => Console.WriteLine("Sir {0}", x);

            Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(x => fPrinter(x));
        }
    }
}