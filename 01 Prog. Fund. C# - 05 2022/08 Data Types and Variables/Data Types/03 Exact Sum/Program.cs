using System;

namespace _03_Exact_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal decSum, decNumber;
            int i, n;

            n = int.Parse(Console.ReadLine());
            decSum = 0;

            for (i = 0; i < n; i++)
            {
                decNumber = decimal.Parse(Console.ReadLine());
                decSum += decNumber;

            }

            Console.WriteLine(decSum);

        }
    }
}
