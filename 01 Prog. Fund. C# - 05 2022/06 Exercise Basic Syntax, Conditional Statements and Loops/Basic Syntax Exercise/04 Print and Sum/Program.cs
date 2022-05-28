using System;

namespace _04_Print_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, nSum, nStart, nEnd;

            nStart = int.Parse(Console.ReadLine());
            nEnd = int.Parse(Console.ReadLine());
            nSum = nStart;
            i = 0;

            Console.Write(nStart);

            for (i = ++nStart; i <= nEnd; i++)
            {
                nSum += i;
                Console.Write(" {0}", i);
            }

            Console.WriteLine();
            Console.WriteLine("Sum: {0}", nSum);

        }
    }
}
