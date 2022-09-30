namespace _01_Action_Point
{

    using System;
    using System.Linq;
    //using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> fPrinter = x => Console.WriteLine(x);

            Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(x => fPrinter(x));
        }
    }
}