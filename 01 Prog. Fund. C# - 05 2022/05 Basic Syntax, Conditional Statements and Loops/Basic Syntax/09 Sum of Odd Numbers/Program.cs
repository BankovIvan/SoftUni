using System;

namespace _09_Sum_of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, nLast, nSum;

            nLast = int.Parse(Console.ReadLine());
            nSum = 0;

            for(i = 1; nLast > 0; nLast--, i += 2)
            {
                nSum += i;
                Console.WriteLine(i);

            }

            Console.WriteLine("Sum: {0}", nSum);
        }
    }
}
