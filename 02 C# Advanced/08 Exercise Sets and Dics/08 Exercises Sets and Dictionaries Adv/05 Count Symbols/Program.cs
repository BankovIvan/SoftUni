using System;
using System.Collections.Generic;

namespace _05_Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> dicSymbols = new SortedDictionary<char, int>();
            string sInput = Console.ReadLine();

            foreach(var v in sInput)
            {
                if (!dicSymbols.ContainsKey(v))
                {
                    dicSymbols.Add(v, 1);
                }
                else
                {
                    dicSymbols[v]++;
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var v in dicSymbols)
            {
                Console.WriteLine("{0}: {1} time/s", v.Key, v.Value);   
            }
            Console.ResetColor();

        }
    }
}
