namespace _03_Periodic_Table
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Linq;
    //using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {

            int i, nRepeat = int.Parse(Console.ReadLine());
            HashSet<string> setElements = new HashSet<string>();

            for (i = 0; i < nRepeat; i++)
            {
                foreach (var v in Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries))
                {
                    setElements.Add(v);
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(string.Join(' ', setElements.OrderBy(x => x)));
            Console.ResetColor();

        }
    }
}
