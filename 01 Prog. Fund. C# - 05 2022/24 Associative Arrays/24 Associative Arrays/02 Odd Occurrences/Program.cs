namespace _02_Odd_Occurrences
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    //using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dicCounts = new Dictionary<string, int>();
            string[] arrInput;

            arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in arrInput)
            {
                string sLower = s.ToLower();
                if (!dicCounts.ContainsKey(sLower))
                {
                    dicCounts.Add(sLower, 1);
                }
                else
                {
                    dicCounts[sLower]++;
                }

            }

            foreach (var v in dicCounts)
            {
                if ((v.Value & 1) == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("{0} ", v.Key);
                    Console.ResetColor();
                }
            }
        }
    }
}