namespace _05_Courses
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    //using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dicCourses = new Dictionary<string, List<string>>();
            string[] arrInput;

            while (true)
            {
                arrInput = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                if (arrInput[0] == "end")
                {
                    break;
                }

                if (!dicCourses.ContainsKey(arrInput[0]))
                {
                    dicCourses.Add(arrInput[0], new List<string>());

                }

                dicCourses[arrInput[0]].Add(arrInput[1]);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var v in dicCourses)
            {
                Console.WriteLine("{0}: {1}", v.Key, v.Value.Count);
                foreach (var l in v.Value)
                {
                    Console.WriteLine("-- {0}", l);
                }
            }
            Console.ResetColor();

        }
    }
}