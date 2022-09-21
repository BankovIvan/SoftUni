using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, nRepeat = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> dicStudents = new Dictionary<string, List<decimal>>();
            string[] arrInput;

            for(i = 0; i < nRepeat; i++)
            {
                arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (!dicStudents.ContainsKey(arrInput[0])){
                    dicStudents.Add(arrInput[0], new List<decimal>(new decimal[] { decimal.Parse(arrInput[1]) }));
                }
                else
                {
                    dicStudents[arrInput[0]].Add(decimal.Parse(arrInput[1]));
                }
            }

            foreach(var v in dicStudents)
            {
                Console.WriteLine("{0} -> {1} (avg: {2:F2})", 
                                    v.Key,
                                    string.Join(" ", v.Value.Select(x => string.Format("{0:F2}", x)).ToArray()),
                                    v.Value.Average());
            }

        }
    }
}
