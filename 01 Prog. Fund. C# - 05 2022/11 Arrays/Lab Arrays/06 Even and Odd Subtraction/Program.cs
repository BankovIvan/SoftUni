using System;

namespace _06_Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrNumbers;
            int nSumEven, nSumOdd, nNumber;

            arrNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            nSumEven = 0;
            nSumOdd = 0;
            nNumber = 0;

            for (int i = 0; i < arrNumbers.Length; i++)
            {
                nNumber = int.Parse(arrNumbers[i]);
                if ((nNumber & 1) == 0)
                {
                    nSumEven += nNumber;
                }
                else
                {
                    nSumOdd += nNumber;
                }
            }

            Console.WriteLine(nSumEven - nSumOdd);
        }
    }
}
