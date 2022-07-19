namespace _08_Company_Users
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    //using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> dicEmployees = new Dictionary<string, HashSet<string>>();
            string[] arrInput;

            while (true)
            {
                arrInput = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                if (arrInput[0].ToLower() == "end")
                {
                    break;
                }

                if (!dicEmployees.ContainsKey(arrInput[0]))
                {
                    dicEmployees.Add(arrInput[0], new HashSet<string>());
                    dicEmployees[arrInput[0]].Add(arrInput[1]);
                }
                else
                {
                    if (!dicEmployees[arrInput[0]].Contains(arrInput[1]))
                    {
                        dicEmployees[arrInput[0]].Add(arrInput[1]);
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var v in dicEmployees)
            {
                Console.WriteLine(v.Key);
                foreach (var h in v.Value)
                {
                    Console.WriteLine("-- " + h);
                }
            }
            Console.ResetColor();

        }
    }
}