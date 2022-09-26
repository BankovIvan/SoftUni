namespace _02_Sets_of_Elements
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
            HashSet<string> setLeft = new HashSet<string>();
            HashSet<string> setRight = new HashSet<string>();
            List<string> lstJoined = new List<string>();

            int i;
            int[] arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse).ToArray();

            for (i = 0; i < arrInput[0]; i++)
            {
                setLeft.Add(Console.ReadLine());
            }

            for (i = 0; i < arrInput[1]; i++)
            {
                setRight.Add(Console.ReadLine());
            }

            foreach (var v in setLeft)
            {
                if (setRight.Contains(v))
                {
                    lstJoined.Add(v);
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(string.Join(' ', lstJoined));
            Console.ResetColor();
        }
    }
}
