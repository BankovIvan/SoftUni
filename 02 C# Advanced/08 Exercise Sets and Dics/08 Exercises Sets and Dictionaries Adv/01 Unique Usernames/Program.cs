namespace _01_Unique_Usernames
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    //using System.Linq;
    //using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> setUsernames = new HashSet<string>();
            int i, nRepeat = int.Parse(Console.ReadLine());

            for (i = 0; i < nRepeat; i++)
            {
                setUsernames.Add(Console.ReadLine());
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(string.Join('\n', setUsernames));
            Console.ResetColor();

        }
    }
}