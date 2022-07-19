namespace _07_Student_Academy
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    //using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> dicStudents = new Dictionary<string, List<double>>();
            string sName;
            double dGrade;
            int i, nRepeat;

            nRepeat = int.Parse(Console.ReadLine());
            for (i = 0; i < nRepeat; i++)
            {
                sName = Console.ReadLine();
                dGrade = double.Parse(Console.ReadLine());

                if (!dicStudents.ContainsKey(sName))
                {
                    dicStudents.Add(sName, new List<double>());
                }

                dicStudents[sName].Add(dGrade);

            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var v in dicStudents)
            {
                double dAverage = 0.0;
                v.Value.ForEach(x => dAverage += x);
                dAverage /= v.Value.Count;

                if (dAverage >= 4.50)
                {
                    Console.WriteLine("{0} -> {1:F2}", v.Key, dAverage);
                }
            }
            Console.ResetColor();

        }
    }
}