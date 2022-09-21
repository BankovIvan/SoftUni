using System;
using System.Collections.Generic;

namespace _06_Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, nRepeat = int.Parse(Console.ReadLine());
            HashSet<string> setNames = new HashSet<string>();

            for(i = 0; i < nRepeat; i++)
            {
                setNames.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join('\n', setNames));

        }
    }
}
