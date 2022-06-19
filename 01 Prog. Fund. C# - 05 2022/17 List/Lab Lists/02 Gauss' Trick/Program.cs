using System;
using System.Collections.Generic;

namespace _02_Gauss__Trick
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

            nListMax = lstNumbers.Count/2;

            for(i = 0; i < nListMax; i++)
            {
                lstNumbers[i] += lstNumbers[lstNumbers.Count - 1];
                lstNumbers.RemoveAt(lstNumbers.Count - 1);
            }

            Console.WriteLine(string.Join(" ", lstNumbers));
        }
    }
}
