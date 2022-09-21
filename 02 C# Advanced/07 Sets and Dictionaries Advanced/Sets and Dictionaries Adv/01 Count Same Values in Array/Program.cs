using System;
using System.Collections.Generic;
using System.Linq;

/// ////////////////////////////////////////////////////////////////////////////////////
//
//         LINQ FOREVER !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//
////////////////////////////////////////////////////////////////////////////////////////

namespace _01_Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            Dictionary<double, int> dicCounts = new Dictionary<double, int>();

            foreach(var v in arrInput)
            {
                if (dicCounts.ContainsKey(v))
                {
                    dicCounts[v]++;
                }
                else
                {
                    dicCounts.Add(v, 1);
                }
            }

            foreach (var v in dicCounts)
            {
                Console.WriteLine("{0} - {1} times", v.Key, v.Value);
            }

        }
    }
}
