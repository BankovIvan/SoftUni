using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace _04_Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> dicNumbers = new Dictionary<int, int>();
            int i, nNumber, nRepeat = int.Parse(Console.ReadLine());

            for(i = 0; i < nRepeat; i++)
            {
                nNumber = int.Parse(Console.ReadLine());
                if (!dicNumbers.ContainsKey(nNumber))
                {
                    dicNumbers.Add(nNumber, 1);
                }
                else
                {
                    dicNumbers[nNumber]++;
                }
            }

            foreach(var v in dicNumbers)
            {
                if((v.Value & 1) == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(v.Key);
                    Console.ResetColor();
                    return;
                }
            }
        }
    }
}
