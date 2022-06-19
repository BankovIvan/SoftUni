using System;
using System.Collections.Generic;

namespace _01_Sum_Adjacent_Equal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> lstNumbers;
            int i, nListMax;

            lstNumbers = new List<double>(Array.ConvertAll(
                                                Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                                                new Converter<string, double>(double.Parse)
                                                ));

            nListMax = lstNumbers.Count - 1;
            for (i = 0; i < nListMax; i++)
            {
                if(lstNumbers[i] == lstNumbers[i + 1])
                {
                    lstNumbers[i] += lstNumbers[i + 1];
                    lstNumbers.RemoveAt(i + 1);
                    i = -1;
                    nListMax = lstNumbers.Count - 1;
                }
            }

            Console.WriteLine(string.Join(" ", lstNumbers));

        }
    }
}
