using System;

namespace _05_Sum_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrNumbers;
            int nSum, nNumber;

            arrNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            nSum = 0;
            nNumber = 0;

            for(int i = 0; i < arrNumbers.Length; i++)
            {
                nNumber = int.Parse(arrNumbers[i]);
                if((nNumber & 1) == 0)
                {
                    nSum += nNumber;
                }
            }

            Console.WriteLine(nSum);

        }
    }
}
