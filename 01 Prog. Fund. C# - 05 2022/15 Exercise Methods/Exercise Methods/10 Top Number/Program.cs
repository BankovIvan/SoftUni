using System;

namespace _10_Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, nNumbers;

            nNumbers = int.Parse(Console.ReadLine());

            for(i = 8; i <= nNumbers; i++)
            {
                if (IsTopNumber(i))
                {
                    Console.WriteLine(i);
                }
            }

        }

        private static bool IsTopNumber(int nNumber)
        {
            int nSumOfDigits = 0, nDigit;
            bool bOddDigitExists = false;

            for (; nNumber > 0; nNumber /= 10)
            {
                nDigit = nNumber % 10;
                nSumOfDigits += nDigit;
                bOddDigitExists = bOddDigitExists || ((nDigit & 1) == 1);
            }


            return ((nSumOfDigits % 8) == 0) && bOddDigitExists;
        }
    }
}
