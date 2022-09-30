namespace _11_TriFunction
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> fLargerSum = (sName, nLimit) =>
            {
                bool ret = false;
                int nSum = 0;

                foreach(var c in sName)
                {
                    nSum += (int) c;
                }

                ret = nSum >= nLimit;
                return ret;

            };

            Func<List<string>, Func<string, int, bool>, int, string> fFirstName = (lstNames, flLargerSum, nLimit) =>
            {
                string ret = "";

                ret = lstNames.Find(x => flLargerSum(x, nLimit));

                return ret;

            };

            int nLimit = int.Parse(Console.ReadLine());
            List<string> lstNames = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            Console.WriteLine(fFirstName(lstNames, fLargerSum, nLimit));

        }
    }
}