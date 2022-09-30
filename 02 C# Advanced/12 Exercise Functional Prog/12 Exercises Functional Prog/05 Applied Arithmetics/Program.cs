namespace _05_Applied_Arithmetics
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> lstNumbers = Console
                                    .ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();

            Func<string, List<int>, List<int>> fEvaluate = (x, y) =>
            {
                List<int> ret = new List<int>(y);

                switch (x)
                {
                    case "add":
                        for (int i = 0; i < ret.Count; i++) ret[i] += 1;
                        break;
                    case "multiply":
                        for (int i = 0; i < ret.Count; i++) ret[i] *= 2;
                        break;
                    case "subtract":
                        for (int i = 0; i < ret.Count; i++) ret[i] -= 1;
                        break;
                    case "print":
                        Console.WriteLine(String.Join(' ', ret));
                        break;
                    default:
                        break;
                }

                return ret;
            };

            while (true)
            {
                string sCommand = Console.ReadLine();
                if(sCommand == "end")
                {
                    break;
                }

                lstNumbers = fEvaluate(sCommand, lstNumbers);

            }

        }

    }
}