namespace _08_List_of_Predicates
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections;

    internal class Program
    {
        static void Main(string[] args)
        {
            int nLast = int.Parse(Console.ReadLine());
            List<Predicate<int>> lstPredicates = new List<Predicate<int>>();
            Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList()
                .ForEach(x => lstPredicates.Add(y => (y % x) == 0));

            Func<int, List<Predicate<int>>, List<int>> fEvaluate = (x, y) =>
            {
                List<int> ret = new List<int>();

                for (int i = 1; i <= x; i++)
                {
                    bool bPrint = true;
                    foreach (var v in y)
                    {
                        if (!v(i))
                        {
                            bPrint = false;
                            break;
                        }
                    }
                    if (bPrint) ret.Add(i);
                }

                return ret;
            };

            Console.WriteLine(String.Join(' ', fEvaluate(nLast, lstPredicates)));

        }
    }
}